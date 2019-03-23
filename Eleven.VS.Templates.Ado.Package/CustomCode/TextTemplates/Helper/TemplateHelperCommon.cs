using Eleven.VS.Templates.Ado.Dsl;

namespace Eleven.VS.Templates.Ado.Package.TextTemplates.Helper
{
    public class TemplateHelperCommon
    {
        public static string Get_StringType(DomainEntityCollection domainEntityCollection)
        {
            string CollectionType = string.Empty;

            CollectionType = domainEntityCollection.CollectionType.ToString();
            CollectionType = CollectionType.Replace("T", domainEntityCollection.DomainEntityType);

            return CollectionType;
        }

        public static string Get_StringType(DomainEntityProperty domainEntityProperty)
        {
            if (string.Compare(domainEntityProperty.CollectionType, "(none)") == 0)
                return domainEntityProperty.DomainEntityType;

            string CollectionType = string.Empty;

            CollectionType = domainEntityProperty.CollectionType.ToString();
            CollectionType = CollectionType.Replace("T", domainEntityProperty.DomainEntityType);

            return CollectionType;
        }

        public static string Get_StringType(PrimitiveProperty primitiveProperty)
        {
            if (string.Compare(primitiveProperty.CollectionType, "(none)") == 0)
                return TemplateHelperDomainEntity.getPrimitiveType(primitiveProperty.PrimitiveType, false);

            string CollectionType = string.Empty;

            CollectionType = primitiveProperty.CollectionType.ToString();
            CollectionType = CollectionType.Replace("T", TemplateHelperDomainEntity.getPrimitiveType(primitiveProperty.PrimitiveType, false));

            return CollectionType;
        }
    }
}
