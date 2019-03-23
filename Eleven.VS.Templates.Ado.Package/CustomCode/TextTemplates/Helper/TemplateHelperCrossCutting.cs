using Eleven.VS.Templates.Ado.Dsl;

namespace Eleven.VS.Templates.Ado.Package.TextTemplates.Helper
{
    public class TemplateHelperCrossCutting
    {
        public static string Get_Insert_SPName_Constant(DomainEntity domainEntity)
        {
            return string.Concat("USP_INS_", domainEntity.Name).ToUpper();
        }

        public static string Get_Update_SPName_Constant(DomainEntity domainEntity)
        {
            return string.Concat("USP_UPD_", domainEntity.Name).ToUpper();
        }

        public static string Get_Delete_SPName_Constant(DomainEntity domainEntity)
        {
            return string.Concat("USP_DEL_", domainEntity.Name).ToUpper();
        }

        public static string Get_SelectId_SPName_Constant(DomainEntity domainEntity)
        {
            return string.Concat("USP_SEL_", domainEntity.Name, "_POR_ID").ToUpper();
        }

        public static string Get_Select_SPName_Constant(DomainEntity domainEntity)
        {
            return string.Concat("USP_SEL_", domainEntity.Name).ToUpper();
        }
    }
}
