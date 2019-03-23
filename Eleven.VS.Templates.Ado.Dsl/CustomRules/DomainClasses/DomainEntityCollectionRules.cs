using Eleven.VS.Templates.Ado.Dsl.Util;
using Eleven.VS.Templates.Ado.Util;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Eleven.VS.Templates.Ado.Dsl.CustomRules.DomainClasses
{
    [RuleOn(typeof(DomainEntityCollection), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainEntityCollectionAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            base.ElementAdded(e);

            if (e.ModelElement is DomainEntityCollection domainEntityCollection)
            {
                if (!string.IsNullOrEmpty(domainEntityCollection.Name))
                {
                    DomainEntityModel domainEntityModel = domainEntityCollection.DomainEntityModel;
                    if (domainEntityModel != null)
                    {
                        int IdDomainEntityCollection = GlobalFunctions.Get_Max_IdDomainEntityCollection(domainEntityModel) + 1;
                        domainEntityCollection.IdDomainEntityCollection = GlobalFunctions.Get_StringId(IdDomainEntityCollection, GlobalConstants.ValorCinco);
                    }
                }
            }
        }
    }

    [RuleOn(typeof(DomainEntityCollection), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainEntityCollectionChangeRule : ChangeRule
    {
        private const string DomainEntityCollection_DomainEntityType = "DomainEntityType";

        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            if (GlobalVariables.Model_DomainEntityCollection_IsUpdating == GlobalConstants.ValorTrue)
                return;

            base.ElementPropertyChanged(e);

            switch (e.DomainProperty.Name)
            {
                case DomainEntityCollection_DomainEntityType:
                    ElementPropertyChanged_DomainEntityType(e);
                    break;
            }
        }

        public void ElementPropertyChanged_DomainEntityType(ElementPropertyChangedEventArgs e)
        {
            ReadOnlyCollection<DomainEntityReferencesDomainEntityCollections> domainEntityReferencesDomainEntityCollectionsList;

            if (e.ModelElement is DomainEntityCollection domainEntityCollection)
            {
                bool sourceDomainEntityOldExists = GlobalConstants.ValorFalse;
                bool sourceDomainEntityNewExists = GlobalConstants.ValorFalse;
                DomainEntity sourceDomainEntityOld = domainEntityCollection.DomainEntity;
                DomainEntity sourceDomainEntityNew = domainEntityCollection.DomainEntity;

                DomainEntityModel domainEntityModel = domainEntityCollection.DomainEntityModel;

                if (domainEntityModel != null)
                {
                    foreach (DomainEntity sourceDomainEntity in domainEntityModel.DomainEntities)
                        if (sourceDomainEntity.Name.CompareTo(e.OldValue) == 0)
                        {
                            sourceDomainEntityOldExists = GlobalConstants.ValorTrue;
                            sourceDomainEntityOld = sourceDomainEntity;
                        }

                    foreach (DomainEntity sourceDomainEntity in domainEntityModel.DomainEntities)
                        if (sourceDomainEntity.Name.CompareTo(e.NewValue) == 0)
                        {
                            sourceDomainEntityNewExists = GlobalConstants.ValorTrue;
                            sourceDomainEntityNew = sourceDomainEntity;
                        }

                    if (sourceDomainEntityOldExists)
                    {
                        domainEntityReferencesDomainEntityCollectionsList = DomainEntityReferencesDomainEntityCollections.GetLinks(sourceDomainEntityOld, domainEntityCollection);
                        if (domainEntityReferencesDomainEntityCollectionsList != null)
                            foreach (DomainEntityReferencesDomainEntityCollections domainEntityReferencesDomainEntityCollections in domainEntityReferencesDomainEntityCollectionsList)
                            {
                                GlobalVariables.Model_DomainEntityCollectionReferencesDomainEntities_IsDeleting = GlobalConstants.ValorTrue;
                                domainEntityReferencesDomainEntityCollections.Delete();
                                GlobalVariables.Model_DomainEntityCollectionReferencesDomainEntities_IsDeleting = GlobalConstants.ValorFalse;
                            }
                    }

                    if (sourceDomainEntityNewExists)
                    {
                        domainEntityReferencesDomainEntityCollectionsList = DomainEntityReferencesDomainEntityCollections.GetLinks(sourceDomainEntityNew, domainEntityCollection);
                        if (domainEntityReferencesDomainEntityCollectionsList != null)
                        {
                            if (domainEntityReferencesDomainEntityCollectionsList.Count == 0)
                            {
                                GlobalVariables.Model_DomainEntityCollectionReferencesDomainEntities_IsAdding = GlobalConstants.ValorTrue;
                                DomainEntityReferencesDomainEntityCollectionsBuilder.Connect(sourceDomainEntityNew, domainEntityCollection);
                                GlobalVariables.Model_DomainEntityCollectionReferencesDomainEntities_IsAdding = GlobalConstants.ValorFalse;
                            }
                        }
                    }
                }
            }
        }
    }
}
