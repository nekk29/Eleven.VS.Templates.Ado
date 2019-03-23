using Eleven.VS.Templates.Ado.Dsl.Util;
using Eleven.VS.Templates.Ado.Util;
using Microsoft.VisualStudio.Modeling;

namespace Eleven.VS.Templates.Ado.Dsl.CustomRules.DomainClasses
{
    [RuleOn(typeof(DomainEntity), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainEntityAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            base.ElementAdded(e);

            if (e.ModelElement is DomainEntity domainEntity)
            {
                if (!string.IsNullOrEmpty(domainEntity.Name))
                {
                    DomainEntityModel domainEntityModel = domainEntity.DomainEntityModel;
                    if (domainEntityModel != null)
                    {
                        int IdDomainEntity = GlobalFunctions.Get_Max_IdDomainEntity(domainEntityModel) + 1;
                        domainEntity.IdDomainEntity = GlobalFunctions.Get_StringId(IdDomainEntity, GlobalConstants.ValorCinco);
                        domainEntity.DataAccessTable = domainEntity.Name;
                    }
                }
            }
        }
    }

    [RuleOn(typeof(DomainEntity))]
    public class DomainEntityChangeRule : ChangeRule
    {
        private const string DomainProperty_Name = "Name";

        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            switch (e.DomainProperty.Name)
            {
                case DomainProperty_Name:
                    ElementPropertyChanged_Name(e);
                    break;
            }
        }

        public void ElementPropertyChanged_Name(ElementPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
                if (string.IsNullOrEmpty(e.OldValue.ToString()))
                    return;

            base.ElementPropertyChanged(e);

            if (e.ModelElement is DomainEntity domainEntity)
            {
                domainEntity.DataAccessTable = domainEntity.Name;
                DomainEntityModel domainEntityModel = domainEntity.DomainEntityModel;

                foreach (DomainEntityCollection domainEntityCollection in domainEntityModel.DomainEntityCollections)
                {
                    if (domainEntityCollection.DomainEntityType.CompareTo(e.OldValue) == 0)
                    {
                        GlobalVariables.Model_DomainEntityCollection_IsUpdating = GlobalConstants.ValorTrue;
                        domainEntityCollection.DomainEntityType = domainEntity.Name;
                        GlobalVariables.Model_DomainEntityCollection_IsUpdating = GlobalConstants.ValorFalse;
                    }
                }

                foreach (DomainEntity domainEntityTarget in domainEntityModel.DomainEntities)
                {
                    if (domainEntityTarget.DomainEntityProperties != null)
                    {
                        foreach (DomainEntityProperty domainEntityProperty in domainEntityTarget.DomainEntityProperties)
                        {
                            if (domainEntityProperty.DomainEntityType.CompareTo(e.OldValue) == 0)
                            {
                                GlobalVariables.Model_DomainEntityProperty_IsUpdating = GlobalConstants.ValorTrue;
                                domainEntityProperty.DomainEntityType = domainEntity.Name;
                                GlobalVariables.Model_DomainEntityProperty_IsUpdating = GlobalConstants.ValorFalse;
                            }
                        }
                    }
                }
            }
        }
    }

    [RuleOn(typeof(DomainEntity), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainEntityDeletingRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (GlobalVariables.Model_DomainEntityCollectionReferencesDomainEntities_IsDeleting == GlobalConstants.ValorTrue)
                return;

            base.ElementDeleting(e);

            if (e.ModelElement is DomainEntity domainEntity)
            {
                DomainEntityModel domainEntityModel = domainEntity.DomainEntityModel;

                foreach (DomainEntityCollection domainEntityCollection in domainEntityModel.DomainEntityCollections)
                {
                    if (domainEntityCollection.DomainEntityType.CompareTo(domainEntity.Name) == 0)
                    {
                        GlobalVariables.Model_DomainEntityCollection_IsUpdating = GlobalConstants.ValorTrue;
                        domainEntityCollection.DomainEntityType = string.Empty;
                        GlobalVariables.Model_DomainEntityCollection_IsUpdating = GlobalConstants.ValorFalse;
                    }
                }

                foreach (DomainEntity domainEntityTarget in domainEntityModel.DomainEntities)
                {
                    if (domainEntityTarget.DomainEntityProperties != null)
                    {
                        foreach (DomainEntityProperty domainEntityProperty in domainEntityTarget.DomainEntityProperties)
                        {
                            if (domainEntityProperty.DomainEntityType.CompareTo(domainEntity.Name) == 0)
                            {
                                GlobalVariables.Model_DomainEntityProperty_IsUpdating = GlobalConstants.ValorTrue;
                                domainEntityProperty.DomainEntityType = string.Empty;
                                GlobalVariables.Model_DomainEntityProperty_IsUpdating = GlobalConstants.ValorFalse;
                            }
                        }
                    }
                }
            }
        }
    }
}
