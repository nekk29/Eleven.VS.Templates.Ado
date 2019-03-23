using Eleven.VS.Templates.Ado.Dsl;
using Eleven.VS.Templates.Ado.Dsl.Resources;

namespace Eleven.VS.Templates.Ado.Package.TextTemplates.Helper
{
    public class TemplateHelperDomainEntity
    {
        public static string Get_DataAccess_FileName_DomainEntity(DomainEntity domainEntity)
        {
            return domainEntity.Name;
        }

        public static string Get_DataAccess_FileName_DomainEntityCollection(DomainEntityCollection domainEntityCollection)
        {
            return domainEntityCollection.Name;
        }

        public static string getPrimitiveType(string systemType, bool toSystemType)
        {
            if (toSystemType)
                return systemType;
            else
            {
                switch (systemType)
                {
                    case "System.Boolean":
                        return TypeConverters.PrimitivePropertyType_Bool;
                    case "System.Byte":
                        return TypeConverters.PrimitivePropertyType_Byte;
                    case "System.Char":
                        return TypeConverters.PrimitivePropertyType_Char;
                    case "System.DateTime":
                        return TypeConverters.PrimitivePropertyType_DateTime;
                    case "System.Decimal":
                        return TypeConverters.PrimitivePropertyType_Decimal;
                    case "System.Double":
                        return TypeConverters.PrimitivePropertyType_Double;
                    case "System.Guid":
                        return TypeConverters.PrimitivePropertyType_Guid;
                    case "System.Int16":
                        return TypeConverters.PrimitivePropertyType_Short;
                    case "System.Int32":
                        return TypeConverters.PrimitivePropertyType_Int;
                    case "System.Int64":
                        return TypeConverters.PrimitivePropertyType_Long;
                    case "System.SByte":
                        return TypeConverters.PrimitivePropertyType_SByte;
                    case "System.Single":
                        return TypeConverters.PrimitivePropertyType_Float;
                    case "System.String":
                        return TypeConverters.PrimitivePropertyType_String;
                    case "System.UInt16":
                        return TypeConverters.PrimitivePropertyType_UShort;
                    case "System.UInt32":
                        return TypeConverters.PrimitivePropertyType_UInt;
                    case "System.UInt64":
                        return TypeConverters.PrimitivePropertyType_ULong;
                    default:
                        return TypeConverters.PrimitivePropertyType_String;
                }
            }
        }

        public static bool hasEntityCollectionsGenerated(DomainEntity domainEntity)
        {
            foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                if (domainEntityProperty.IsGeneratedCollection && domainEntityProperty.CollectionType == TypeConverters.DomainEntityProperty_CollectionType_ICollection)
                    return true;
            return false;
        }
    }
}
