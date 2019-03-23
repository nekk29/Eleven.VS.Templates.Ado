using Eleven.VS.Templates.Ado.Dsl.Resources;
using Eleven.VS.Templates.Ado.Dsl.Util;
using Eleven.VS.Templates.Ado.Util;
using Microsoft.VisualStudio.Modeling;

namespace Eleven.VS.Templates.Ado.Dsl.CustomRules.DomainRelationships
{
    [RuleOn(typeof(DomainEntityReferencesTargetDomainEntities))]
    public class DomainEntityReferencesTargetDomainEntitiesAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            DomainEntityReferencesTargetDomainEntities domainEntityReferencesTargetDomainEntities = e.ModelElement as DomainEntityReferencesTargetDomainEntities;

            if (GlobalVariables.Model_DomainEntityReferencesTargetDomainEntities_IsAdding != GlobalConstants.ValorTrue)
            {
                base.ElementAdded(e);

                DomainEntity sourceDomainEntity = domainEntityReferencesTargetDomainEntities.SourceDomainEntity;
                DomainEntity targetDomainEntity = domainEntityReferencesTargetDomainEntities.TargetDomainEntity;

                if (sourceDomainEntity != null && targetDomainEntity != null)
                {
                    if (targetDomainEntity.DomainEntityProperties != null)
                    {
                        string IdDomainEntityReferencesTargetDomainEntities = domainEntityReferencesTargetDomainEntities.Id.ToString();

                        string IdDomainEntitySource = sourceDomainEntity.IdDomainEntity;
                        string IdDomainEntityTarget = targetDomainEntity.IdDomainEntity;

                        string NameDomainEntitySource = sourceDomainEntity.Name;
                        string NameDomainEntityTarget = targetDomainEntity.Name;

                        int IdDomainEntityPropertyNumberSource = GlobalFunctions.Get_Max_IdDomainEntityProperty(sourceDomainEntity) + 1;
                        int IdDomainEntityPropertyNumberTarget = GlobalFunctions.Get_Max_IdDomainEntityProperty(targetDomainEntity) + 1;

                        string IdDomainEntityPropertySource = GlobalFunctions.Get_StringId(IdDomainEntityPropertyNumberSource, GlobalConstants.ValorCinco);
                        string IdDomainEntityPropertyTarget = GlobalFunctions.Get_StringId(IdDomainEntityPropertyNumberTarget, GlobalConstants.ValorCinco);

                        IdDomainEntityPropertySource = string.Concat(IdDomainEntitySource, IdDomainEntityPropertySource);
                        IdDomainEntityPropertyTarget = string.Concat(IdDomainEntityTarget, IdDomainEntityPropertyTarget);

                        string NameDomainEntityPropertySource = string.Empty;
                        IdDomainEntityPropertyNumberSource = GlobalFunctions.Get_CountDomainEntityProperties_By_Type(sourceDomainEntity, NameDomainEntityTarget, true);
                        if (IdDomainEntityPropertyNumberSource == 0)
                            NameDomainEntityPropertySource = string.Concat(NameDomainEntitySource);
                        else
                            NameDomainEntityPropertySource = string.Concat(NameDomainEntitySource, IdDomainEntityPropertyNumberSource.ToString());

                        string NameDomainEntityPropertyTarget = string.Empty;
                        IdDomainEntityPropertyNumberTarget = GlobalFunctions.Get_CountDomainEntityProperties_By_Type(targetDomainEntity, NameDomainEntitySource, false);
                        if (IdDomainEntityPropertyNumberTarget == 0)
                            NameDomainEntityPropertyTarget = string.Concat(NameDomainEntityTarget, "s");
                        else
                            NameDomainEntityPropertyTarget = string.Concat(NameDomainEntityTarget, "s", IdDomainEntityPropertyNumberTarget.ToString());

                        //Adding DomainEntityProperty To Source Entity
                        PropertyAssignment[] propertyAssignmentsSource = new PropertyAssignment[7];
                        propertyAssignmentsSource[0] = new PropertyAssignment(DomainEntityProperty.IdDomainEntityDomainPropertyId, IdDomainEntitySource);
                        propertyAssignmentsSource[1] = new PropertyAssignment(DomainEntityProperty.IdDomainEntityPropertyDomainPropertyId, IdDomainEntityPropertySource);
                        propertyAssignmentsSource[2] = new PropertyAssignment(DomainEntityProperty.IdDomainEntityReferencesTargetDomainEntitiesDomainPropertyId, IdDomainEntityReferencesTargetDomainEntities);
                        propertyAssignmentsSource[3] = new PropertyAssignment(DomainEntityProperty.NameDomainPropertyId, NameDomainEntityPropertyTarget);
                        propertyAssignmentsSource[4] = new PropertyAssignment(DomainEntityProperty.DomainEntityTypeDomainPropertyId, NameDomainEntityTarget);
                        propertyAssignmentsSource[5] = new PropertyAssignment(DomainEntityProperty.CollectionTypeDomainPropertyId, TypeConverters.DomainEntityProperty_CollectionType_ICollection);
                        propertyAssignmentsSource[6] = new PropertyAssignment(DomainEntityProperty.IsGeneratedCollectionDomainPropertyId, GlobalConstants.ValorTrue);

                        DomainEntityProperty targetDomainEntityPropertySource = new DomainEntityProperty(sourceDomainEntity.Store, propertyAssignmentsSource);
                        sourceDomainEntity.DomainEntityProperties.Add(targetDomainEntityPropertySource);

                        //Adding DomainEntityProperty To Target Entity
                        PropertyAssignment[] propertyAssignmentsTarget = new PropertyAssignment[6];
                        propertyAssignmentsTarget[0] = new PropertyAssignment(DomainEntityProperty.IdDomainEntityDomainPropertyId, IdDomainEntityTarget);
                        propertyAssignmentsTarget[1] = new PropertyAssignment(DomainEntityProperty.IdDomainEntityPropertyDomainPropertyId, IdDomainEntityPropertyTarget);
                        propertyAssignmentsTarget[2] = new PropertyAssignment(DomainEntityProperty.IdDomainEntityReferencesTargetDomainEntitiesDomainPropertyId, IdDomainEntityReferencesTargetDomainEntities);
                        propertyAssignmentsTarget[3] = new PropertyAssignment(DomainEntityProperty.NameDomainPropertyId, NameDomainEntityPropertySource);
                        propertyAssignmentsTarget[4] = new PropertyAssignment(DomainEntityProperty.DomainEntityTypeDomainPropertyId, NameDomainEntitySource);
                        propertyAssignmentsTarget[5] = new PropertyAssignment(DomainEntityProperty.IsGeneratedCollectionDomainPropertyId, GlobalConstants.ValorFalse);

                        DomainEntityProperty targetDomainEntityPropertyTarget = new DomainEntityProperty(targetDomainEntity.Store, propertyAssignmentsTarget);
                        targetDomainEntity.DomainEntityProperties.Add(targetDomainEntityPropertyTarget);
                    }
                }
            }
        }
    }

    [RuleOn(typeof(DomainEntityReferencesTargetDomainEntities), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainEntityReferencesTargetDomainEntitiesDeletingRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (GlobalVariables.Model_DomainEntityReferencesTargetDomainEntities_IsDeleting == GlobalConstants.ValorTrue)
                return;

            base.ElementDeleting(e);

            DomainEntityReferencesTargetDomainEntities domainEntityReferencesTargetDomainEntities = e.ModelElement as DomainEntityReferencesTargetDomainEntities;
            DomainEntity sourceDomainEntity = domainEntityReferencesTargetDomainEntities.SourceDomainEntity;
            DomainEntity targetDomainEntity = domainEntityReferencesTargetDomainEntities.TargetDomainEntity;

            if (targetDomainEntity != null)
            {
                if (targetDomainEntity.DomainEntityProperties != null)
                {
                    LinkedElementCollection<DomainEntityProperty> domainEntityProperties = targetDomainEntity.DomainEntityProperties;

                    foreach (DomainEntityProperty domainEntityProperty in domainEntityProperties)
                        if (domainEntityProperty.IdDomainEntityReferencesTargetDomainEntities == domainEntityReferencesTargetDomainEntities.Id.ToString())
                        {
                            GlobalVariables.Model_DomainEntityProperty_Deleting = GlobalConstants.ValorTrue;
                            domainEntityProperty.Delete();
                            GlobalVariables.Model_DomainEntityProperty_Deleting = GlobalConstants.ValorFalse;
                            break;
                        }
                }
            }

            if (sourceDomainEntity != null)
            {
                if (sourceDomainEntity.DomainEntityProperties != null)
                {
                    LinkedElementCollection<DomainEntityProperty> domainEntityProperties = sourceDomainEntity.DomainEntityProperties;

                    foreach (DomainEntityProperty domainEntityProperty in domainEntityProperties)
                        if (domainEntityProperty.IdDomainEntityReferencesTargetDomainEntities == domainEntityReferencesTargetDomainEntities.Id.ToString())
                        {
                            GlobalVariables.Model_DomainEntityProperty_Deleting = GlobalConstants.ValorTrue;
                            domainEntityProperty.Delete();
                            GlobalVariables.Model_DomainEntityProperty_Deleting = GlobalConstants.ValorFalse;
                            break;
                        }
                }
            }
        }
    }
}
