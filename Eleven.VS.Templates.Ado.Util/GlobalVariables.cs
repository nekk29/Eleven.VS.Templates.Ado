namespace Eleven.VS.Templates.Ado.Util
{
    public class GlobalVariables
    {
        #region Id Properties Values

        //DomainEntityReferencesTargetDomainEntities
        public static string IdDomainEntityReferencesTargetDomainEntities { get; set; }

        #endregion

        #region Changing Properties Variables

        //DomainEntityCollection
        public static bool Model_DomainEntityCollection_IsUpdating { get; set; }

        //DomainEntityProperty
        public static bool Model_DomainEntityProperty_IsUpdating { get; set; }
        public static bool Model_DomainEntityProperty_Deleting { get; set; }

        //DomainEntityReferencesTargetDomainEntities
        public static bool Model_DomainEntityReferencesTargetDomainEntities_IsAdding { get; set; }
        public static bool Model_DomainEntityReferencesTargetDomainEntities_IsDeleting { get; set; }

        //DomainEntityReferencesTargetDomainEntities
        public static bool Model_DomainEntityCollectionReferencesDomainEntities_IsAdding { get; set; }
        public static bool Model_DomainEntityCollectionReferencesDomainEntities_IsDeleting { get; set; }

        #endregion
    }
}