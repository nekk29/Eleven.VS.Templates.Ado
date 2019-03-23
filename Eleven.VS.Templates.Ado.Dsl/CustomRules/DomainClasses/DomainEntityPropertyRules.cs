using Eleven.VS.Templates.Ado.Dsl.Resources;
using Eleven.VS.Templates.Ado.Dsl.Util;
using Eleven.VS.Templates.Ado.Util;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Eleven.VS.Templates.Ado.Dsl.CustomRules.DomainClasses
{
    [RuleOn(typeof(DomainEntityProperty))]
    public class DomainEntityPropertyChangeRule : ChangeRule
    {
        private const string DomainEntityProperty_Name = "Name";
        private const string DomainEntityProperty_DomainEntityType = "DomainEntityType";

        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            if (GlobalVariables.Model_DomainEntityProperty_IsUpdating == GlobalConstants.ValorTrue)
                return;

            base.ElementPropertyChanged(e);

            switch (e.DomainProperty.Name)
            {
                case DomainEntityProperty_Name:
                    ElementPropertyChanged_Name(e);
                    break;
                case DomainEntityProperty_DomainEntityType:
                    ElementPropertyChanged_DomainEntityType(e);
                    break;
            }
        }

        public void ElementPropertyChanged_Name(ElementPropertyChangedEventArgs e)
        {
            DomainEntityProperty domainEntityProperty = e.ModelElement as DomainEntityProperty;
            DomainEntity targetDomainEntity = domainEntityProperty.DomainEntity;

            if (domainEntityProperty.IdDomainEntityProperty == string.Empty)
            {
                if (targetDomainEntity != null)
                {
                    string IdDomainEntity;
                    string IdDomainEntityProperty;
                    int IdDomainEntityPropertyNumber;

                    IdDomainEntity = targetDomainEntity.IdDomainEntity;
                    IdDomainEntityPropertyNumber = GlobalFunctions.Get_Max_IdDomainEntityProperty(targetDomainEntity) + 1;
                    IdDomainEntityProperty = GlobalFunctions.Get_StringId(IdDomainEntityPropertyNumber, GlobalConstants.ValorCinco);
                    IdDomainEntityProperty = string.Concat(IdDomainEntity, IdDomainEntityProperty);

                    domainEntityProperty.IdDomainEntity = IdDomainEntity;
                    domainEntityProperty.IdDomainEntityProperty = IdDomainEntityProperty;
                    domainEntityProperty.IdDomainEntityReferencesTargetDomainEntities = IdDomainEntityProperty;
                    domainEntityProperty.HasDomainType = true;
                }
            }
        }

        public void ElementPropertyChanged_DomainEntityType(ElementPropertyChangedEventArgs e)
        {
            bool domainEntityPropertyExists = false;
            bool sourceDomainEntityOldExists = GlobalConstants.ValorFalse;
            bool sourceDomainEntityNewExists = GlobalConstants.ValorFalse;

            DomainEntityProperty domainEntityProperty = e.ModelElement as DomainEntityProperty;

            if (domainEntityProperty.IsGeneratedCollection)
                return;

            if (e.OldValue != null && domainEntityProperty.HasDomainType == false)
                if (string.IsNullOrEmpty(e.OldValue.ToString()))
                    return;

            if (e.NewValue != null)
                if (!string.IsNullOrEmpty(e.NewValue.ToString()))
                    domainEntityProperty.HasDomainType = true;

            DomainEntityProperty domainEntityPropertyDel = domainEntityProperty;
            DomainEntity targetDomainEntity = domainEntityProperty.DomainEntity;
            DomainEntity sourceDomainEntityOld = domainEntityProperty.DomainEntity;
            DomainEntity sourceDomainEntityNew = domainEntityProperty.DomainEntity;
            ReadOnlyCollection<DomainEntityReferencesTargetDomainEntities> domainEntityReferencesTargetDomainEntitiesList;

            if (targetDomainEntity != null)
            {
                DomainEntityModel domainEntityModel = targetDomainEntity.DomainEntityModel;

                foreach (DomainEntity sourceDomainEntity in domainEntityModel.DomainEntities)
                    if (sourceDomainEntity.Name == e.OldValue.ToString())
                    {
                        sourceDomainEntityOldExists = GlobalConstants.ValorTrue;
                        sourceDomainEntityOld = sourceDomainEntity;
                        break;
                    }

                foreach (DomainEntity sourceDomainEntity in domainEntityModel.DomainEntities)
                    if (sourceDomainEntity.Name == e.NewValue.ToString())
                    {
                        sourceDomainEntityNewExists = GlobalConstants.ValorTrue;
                        sourceDomainEntityNew = sourceDomainEntity;
                        break;
                    }

                if (sourceDomainEntityOldExists)
                {
                    domainEntityReferencesTargetDomainEntitiesList = DomainEntityReferencesTargetDomainEntities.GetLinks(sourceDomainEntityOld, targetDomainEntity);

                    if (domainEntityReferencesTargetDomainEntitiesList != null)
                    {
                        foreach (DomainEntityReferencesTargetDomainEntities domainEntityReferencesTargetDomainEntities in domainEntityReferencesTargetDomainEntitiesList)
                        {
                            if (domainEntityReferencesTargetDomainEntities.Id.ToString() == domainEntityProperty.IdDomainEntityReferencesTargetDomainEntities)
                            {
                                GlobalVariables.Model_DomainEntityReferencesTargetDomainEntities_IsDeleting = GlobalConstants.ValorTrue;
                                domainEntityReferencesTargetDomainEntities.Delete();
                                GlobalVariables.Model_DomainEntityReferencesTargetDomainEntities_IsDeleting = GlobalConstants.ValorFalse;
                                break;
                            }
                        }
                    }

                    foreach (DomainEntityProperty domainEntityPropertyIn in sourceDomainEntityOld.DomainEntityProperties)
                        if (domainEntityPropertyIn.IdDomainEntityReferencesTargetDomainEntities == domainEntityProperty.IdDomainEntityReferencesTargetDomainEntities && domainEntityPropertyIn.IsGeneratedCollection)
                        {
                            domainEntityPropertyExists = true;
                            domainEntityPropertyDel = domainEntityPropertyIn;
                            break;
                        }

                    if (domainEntityPropertyExists)
                        domainEntityPropertyDel.Delete();
                }

                if (sourceDomainEntityNewExists)
                {
                    GlobalVariables.Model_DomainEntityReferencesTargetDomainEntities_IsAdding = GlobalConstants.ValorTrue;

                    DomainEntityReferencesTargetDomainEntities domainEntityReferencesTargetDomainEntities = (DomainEntityReferencesTargetDomainEntities)DomainEntityReferencesTargetDomainEntitiesBuilder.Connect(sourceDomainEntityNew, targetDomainEntity);
                    domainEntityProperty.IdDomainEntityReferencesTargetDomainEntities = domainEntityReferencesTargetDomainEntities.Id.ToString();

                    string IdDomainEntitySourceNew = sourceDomainEntityNew.IdDomainEntity;

                    int IdDomainEntityPropertyNumberSourceNew = GlobalFunctions.Get_Max_IdDomainEntityProperty(sourceDomainEntityNew) + 1;
                    string IdDomainEntityPropertySourceNew = GlobalFunctions.Get_StringId(IdDomainEntityPropertyNumberSourceNew, GlobalConstants.ValorCinco);

                    IdDomainEntityPropertySourceNew = string.Concat(IdDomainEntitySourceNew, IdDomainEntityPropertySourceNew);

                    string NameDomainEntityPropertySourceNew = string.Empty;
                    IdDomainEntityPropertyNumberSourceNew = GlobalFunctions.Get_CountDomainEntityProperties_By_Type(sourceDomainEntityNew, targetDomainEntity.Name, true);
                    if (IdDomainEntityPropertyNumberSourceNew == 0)
                        NameDomainEntityPropertySourceNew = string.Concat(targetDomainEntity.Name, "s");
                    else
                        NameDomainEntityPropertySourceNew = string.Concat(targetDomainEntity.Name, "s", IdDomainEntityPropertyNumberSourceNew.ToString());

                    PropertyAssignment[] propertyAssignmentsSource = new PropertyAssignment[7];
                    propertyAssignmentsSource[0] = new PropertyAssignment(DomainEntityProperty.IdDomainEntityDomainPropertyId, IdDomainEntitySourceNew);
                    propertyAssignmentsSource[1] = new PropertyAssignment(DomainEntityProperty.IdDomainEntityPropertyDomainPropertyId, IdDomainEntityPropertySourceNew);
                    propertyAssignmentsSource[2] = new PropertyAssignment(DomainEntityProperty.IdDomainEntityReferencesTargetDomainEntitiesDomainPropertyId, domainEntityReferencesTargetDomainEntities.Id.ToString());
                    propertyAssignmentsSource[3] = new PropertyAssignment(DomainEntityProperty.NameDomainPropertyId, NameDomainEntityPropertySourceNew);
                    propertyAssignmentsSource[4] = new PropertyAssignment(DomainEntityProperty.DomainEntityTypeDomainPropertyId, targetDomainEntity.Name);
                    propertyAssignmentsSource[5] = new PropertyAssignment(DomainEntityProperty.CollectionTypeDomainPropertyId, TypeConverters.DomainEntityProperty_CollectionType_ICollection);
                    propertyAssignmentsSource[6] = new PropertyAssignment(DomainEntityProperty.IsGeneratedCollectionDomainPropertyId, GlobalConstants.ValorTrue);

                    DomainEntityProperty targetDomainEntityPropertySource = new DomainEntityProperty(targetDomainEntity.Store, propertyAssignmentsSource);
                    sourceDomainEntityNew.DomainEntityProperties.Add(targetDomainEntityPropertySource);

                    GlobalVariables.Model_DomainEntityReferencesTargetDomainEntities_IsAdding = GlobalConstants.ValorFalse;
                }
            }
        }
    }

    [RuleOn(typeof(DomainEntityProperty), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainEntityPropertyDeletingRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (GlobalVariables.Model_DomainEntityProperty_Deleting == GlobalConstants.ValorTrue)
                return;

            base.ElementDeleting(e);

            DomainEntityProperty domainEntityProperty = e.ModelElement as DomainEntityProperty;
            DomainEntity targetDomainEntity = domainEntityProperty.DomainEntity;

            if (targetDomainEntity != null)
            {
                DomainEntityModel domainEntityModel = targetDomainEntity.DomainEntityModel;

                if (domainEntityModel != null)
                {
                    foreach (DomainEntity sourceDomainEntity in domainEntityModel.DomainEntities)
                    {
                        if (sourceDomainEntity.Name.CompareTo(domainEntityProperty.DomainEntityType) == 0)
                        {
                            ReadOnlyCollection<DomainEntityReferencesTargetDomainEntities> domainEntityReferencesTargetDomainEntitiesList;
                            domainEntityReferencesTargetDomainEntitiesList = DomainEntityReferencesTargetDomainEntities.GetLinks(sourceDomainEntity, targetDomainEntity);
                            if (domainEntityReferencesTargetDomainEntitiesList != null)
                            {
                                foreach (DomainEntityReferencesTargetDomainEntities domainEntityReferencesTargetDomainEntities in domainEntityReferencesTargetDomainEntitiesList)
                                {
                                    if (domainEntityReferencesTargetDomainEntities.Id.ToString() == domainEntityProperty.IdDomainEntityReferencesTargetDomainEntities)
                                    {
                                        GlobalVariables.Model_DomainEntityReferencesTargetDomainEntities_IsDeleting = GlobalConstants.ValorTrue;
                                        domainEntityReferencesTargetDomainEntitiesList[0].Delete();
                                        GlobalVariables.Model_DomainEntityReferencesTargetDomainEntities_IsDeleting = GlobalConstants.ValorFalse;
                                        break;
                                    }
                                }
                            }
                            domainEntityReferencesTargetDomainEntitiesList = DomainEntityReferencesTargetDomainEntities.GetLinks(targetDomainEntity, sourceDomainEntity);
                            if (domainEntityReferencesTargetDomainEntitiesList != null)
                            {
                                foreach (DomainEntityReferencesTargetDomainEntities domainEntityReferencesTargetDomainEntities in domainEntityReferencesTargetDomainEntitiesList)
                                {
                                    if (domainEntityReferencesTargetDomainEntities.Id.ToString() == domainEntityProperty.IdDomainEntityReferencesTargetDomainEntities)
                                    {
                                        GlobalVariables.Model_DomainEntityReferencesTargetDomainEntities_IsDeleting = GlobalConstants.ValorTrue;
                                        domainEntityReferencesTargetDomainEntitiesList[0].Delete();
                                        GlobalVariables.Model_DomainEntityReferencesTargetDomainEntities_IsDeleting = GlobalConstants.ValorFalse;
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
