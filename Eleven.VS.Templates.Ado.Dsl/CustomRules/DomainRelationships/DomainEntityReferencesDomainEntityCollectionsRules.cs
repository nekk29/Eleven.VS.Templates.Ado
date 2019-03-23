using Eleven.VS.Templates.Ado.Util;
using Microsoft.VisualStudio.Modeling;

namespace Eleven.VS.Templates.Ado.Dsl.CustomRules.DomainRelationships
{
    [RuleOn(typeof(DomainEntityReferencesDomainEntityCollections))]
    public class DomainEntityReferencesDomainEntityCollectionsAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            if (GlobalVariables.Model_DomainEntityCollectionReferencesDomainEntities_IsAdding == GlobalConstants.ValorTrue)
                return;

            base.ElementAdded(e);

            DomainEntityReferencesDomainEntityCollections link = e.ModelElement as DomainEntityReferencesDomainEntityCollections;
            DomainEntityCollection domainEntityCollection = link.DomainEntityCollection;
            DomainEntity domainEntity = link.DomainEntity;

            if (domainEntityCollection != null)
                if (domainEntity != null)
                {
                    GlobalVariables.Model_DomainEntityCollection_IsUpdating = GlobalConstants.ValorTrue;
                    domainEntityCollection.DomainEntityType = domainEntity.Name;
                    GlobalVariables.Model_DomainEntityCollection_IsUpdating = GlobalConstants.ValorFalse;
                }
        }
    }

    [RuleOn(typeof(DomainEntityReferencesDomainEntityCollections), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainEntityReferencesDomainEntityCollectionsDeletingRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (GlobalVariables.Model_DomainEntityCollectionReferencesDomainEntities_IsDeleting == GlobalConstants.ValorTrue)
                return;

            base.ElementDeleting(e);

            DomainEntityReferencesDomainEntityCollections link = e.ModelElement as DomainEntityReferencesDomainEntityCollections;
            DomainEntityCollection domainEntityCollection = link.DomainEntityCollection;

            if (domainEntityCollection != null)
            {
                GlobalVariables.Model_DomainEntityCollection_IsUpdating = GlobalConstants.ValorTrue;
                domainEntityCollection.DomainEntityType = string.Empty;
                GlobalVariables.Model_DomainEntityCollection_IsUpdating = GlobalConstants.ValorFalse;
            }
        }
    }
}
