using Eleven.VS.Templates.Ado.Dsl.CustomRules.DomainClasses;
using Eleven.VS.Templates.Ado.Dsl.CustomRules.DomainRelationships;
using System;
using System.Collections.Generic;

namespace Eleven.VS.Templates.Ado.Dsl
{
    public partial class ElevenEntityModelDomainModel
    {
        protected override Type[] GetCustomDomainModelTypes()
        {
            List<Type> types = new List<Type>(base.GetCustomDomainModelTypes());

            #region Domain Class Rules

            //DomainEntity
            types.Add(typeof(DomainEntityAddRule));
            types.Add(typeof(DomainEntityChangeRule));
            types.Add(typeof(DomainEntityDeletingRule));

            //DomainEntityCollection
            types.Add(typeof(DomainEntityCollectionAddRule));
            types.Add(typeof(DomainEntityCollectionChangeRule));

            //DomainEntityProperty
            types.Add(typeof(DomainEntityPropertyChangeRule));
            types.Add(typeof(DomainEntityPropertyDeletingRule));

            //PrimitiveProperty
            types.Add(typeof(PrimitivePropertyChangeRule));

            #endregion

            #region Domain Relashionships Rules

            //DomainEntityReferencesTargetDomainEntities
            types.Add(typeof(DomainEntityReferencesTargetDomainEntitiesAddRule));
            types.Add(typeof(DomainEntityReferencesTargetDomainEntitiesDeletingRule));

            //DomainEntityCollectionReferencesDomainEntities
            types.Add(typeof(DomainEntityReferencesDomainEntityCollectionsAddRule));
            types.Add(typeof(DomainEntityReferencesDomainEntityCollectionsDeletingRule));

            #endregion

            return types.ToArray();
        }
    }
}
