using Eleven.VS.Templates.Ado.Dsl;
using System;

namespace Eleven.VS.Templates.Ado.Package.TextTemplates.Helper
{
    public class TemplateHelperDataAccess
    {
        private static string BreakLine = Environment.NewLine;

        public static string Get_DataAccess_Class_Name(DomainEntity domainEntity)
        {
            return string.Concat(domainEntity.Name, "DataAccess");
        }

        public static string Get_DataAccess_Insert_MethodName(DomainEntity domainEntity)
        {
            return string.Concat("Registrar_", domainEntity.Name);
        }

        public static string Get_DataAccess_Update_MethodName(DomainEntity domainEntity)
        {
            return string.Concat("Actualizar_", domainEntity.Name);
        }

        public static string Get_DataAccess_Delete_MethodName(DomainEntity domainEntity)
        {
            return string.Concat("Eliminar_", domainEntity.Name);
        }

        public static string Get_DataAccess_SelectId_MethodName(DomainEntity domainEntity)
        {
            return string.Concat("Obtener_", domainEntity.Name, "_PorId");
        }

        public static string Get_DataAccess_Select_MethodName(DomainEntity domainEntity)
        {
            return string.Concat("Listar_", domainEntity.Name);
        }

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

        public static string Get_Variable_Name(string VariableName)
        {
            if (!string.IsNullOrEmpty(VariableName))
            {
                string FirstChar = VariableName.Substring(0, 1);
                string OtherChar = VariableName.Substring(1, VariableName.Length - 1);

                return string.Concat(FirstChar.ToLower(), OtherChar);
            }
            else
                return VariableName;
        }

        public static string Get_Parameter_Text(DomainEntity domainEntity, bool OnlyPrimary, bool IsParameter, bool IsInForPrimary, int IndentSize)
        {
            int CountPrimary = 0;
            string ParameText = "@";
            string IndentString = string.Empty;
            string ParameterText = string.Empty;
            string ParamTypeDir = string.Empty;

            if (IsInForPrimary)
                ParamTypeDir = "AddInParameter";
            else
                ParamTypeDir = "AddOutParameter";

            for (int i = 0; i < IndentSize; i++)
                IndentString = string.Concat(IndentString, "    ");

            foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                if (primitiveProperty.IsDataAccessMapping)
                    if (primitiveProperty.IsPrimaryKey)
                        CountPrimary = CountPrimary + 1;

            if (CountPrimary > 0)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                    if (primitiveProperty.IsDataAccessMapping)
                        if (primitiveProperty.IsPrimaryKey)
                        {
                            ParameterText = string.Concat(ParameterText, "oDatabase.", ParamTypeDir, "(oDbCommand, ");
                            ParameterText = string.Concat(ParameterText, "\"", ParameText, primitiveProperty.Name, "\", ");
                            ParameterText = string.Concat(ParameterText, Get_DataBaseType_From_SystemType(primitiveProperty), ", ");

                            if (IsParameter)
                                ParameterText = string.Concat(ParameterText, primitiveProperty.Name);
                            else
                                ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), ".", primitiveProperty.Name);

                            ParameterText = string.Concat(ParameterText, ");", BreakLine, IndentString);
                        }
            }
            else
            {
                foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                {
                    if (domainEntityProperty.CollectionType == Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None)
                    {
                        foreach (DomainEntity domainEntityIn in domainEntity.DomainEntityModel.DomainEntities)
                            if (domainEntityProperty.DomainEntityType == domainEntityIn.Name)
                            {
                                foreach (PrimitiveProperty primitiveProperty in domainEntityIn.PrimitiveProperties)
                                {
                                    if (primitiveProperty.IsPrimaryKey)
                                    {
                                        ParameterText = string.Concat(ParameterText, "oDatabase.AddInParameter(oDbCommand, ");
                                        ParameterText = string.Concat(ParameterText, "\"", ParameText, primitiveProperty.Name, "\", ");
                                        ParameterText = string.Concat(ParameterText, Get_DataBaseType_From_SystemType(primitiveProperty), ", ");
                                        if (IsParameter)
                                            ParameterText = string.Concat(ParameterText, primitiveProperty.Name);
                                        else
                                            ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), ".", domainEntityProperty.Name, ".", primitiveProperty.Name);
                                        ParameterText = string.Concat(ParameterText, ");", BreakLine, IndentString);
                                    }
                                }
                                break;
                            }
                    }
                }

            }

            if (!OnlyPrimary)
            {
                if (CountPrimary > 0)
                {
                    foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                    {
                        if (domainEntityProperty.CollectionType == Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None)
                        {
                            foreach (DomainEntity domainEntityIn in domainEntity.DomainEntityModel.DomainEntities)
                                if (domainEntityProperty.DomainEntityType == domainEntityIn.Name)
                                {
                                    foreach (PrimitiveProperty primitiveProperty in domainEntityIn.PrimitiveProperties)
                                    {
                                        if (primitiveProperty.IsPrimaryKey)
                                        {
                                            ParameterText = string.Concat(ParameterText, "oDatabase.AddInParameter(oDbCommand, ");
                                            ParameterText = string.Concat(ParameterText, "\"", ParameText, primitiveProperty.Name, "\", ");
                                            ParameterText = string.Concat(ParameterText, Get_DataBaseType_From_SystemType(primitiveProperty), ", ");
                                            ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), ".", domainEntityProperty.Name, ".", primitiveProperty.Name);
                                            ParameterText = string.Concat(ParameterText, ");", BreakLine, IndentString);
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }

                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                    if (primitiveProperty.IsDataAccessMapping)
                        if (!primitiveProperty.IsPrimaryKey)
                        {
                            ParameterText = string.Concat(ParameterText, "oDatabase.AddInParameter(oDbCommand, ");
                            ParameterText = string.Concat(ParameterText, "\"", ParameText, primitiveProperty.Name, "\", ");
                            ParameterText = string.Concat(ParameterText, Get_DataBaseType_From_SystemType(primitiveProperty), ", ");
                            ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), ".", primitiveProperty.Name);
                            ParameterText = string.Concat(ParameterText, ");", BreakLine, IndentString);
                        }
            }

            if (ParameterText.Length >= BreakLine.Length + IndentString.Length)
                ParameterText = ParameterText.Substring(0, (ParameterText.Length - BreakLine.Length - IndentString.Length));

            return ParameterText;
        }

        public static string Get_Method_Key_Parameters(DomainEntity domainEntity, int IndentSize)
        {
            int CountPrimary = 0;
            string ParameterText = string.Empty;
            string IndentString = string.Empty;

            for (int i = 0; i < IndentSize; i++)
                IndentString = string.Concat(IndentString, "    ");

            foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                if (primitiveProperty.IsDataAccessMapping)
                    if (primitiveProperty.IsPrimaryKey)
                        CountPrimary = CountPrimary + 1;

            if (CountPrimary > 0)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                    if (primitiveProperty.IsDataAccessMapping)
                        if (primitiveProperty.IsPrimaryKey)
                            ParameterText = string.Concat(ParameterText, primitiveProperty.PrimitiveType, " ", primitiveProperty.Name, ",", BreakLine, IndentString);
            }
            else
            {
                foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                {
                    if (domainEntityProperty.CollectionType == Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None)
                    {
                        foreach (DomainEntity domainEntityIn in domainEntity.DomainEntityModel.DomainEntities)
                        {
                            if (domainEntityProperty.DomainEntityType == domainEntityIn.Name)
                            {
                                foreach (PrimitiveProperty primitiveProperty in domainEntityIn.PrimitiveProperties)
                                {
                                    if (primitiveProperty.IsPrimaryKey)
                                        ParameterText = string.Concat(ParameterText, primitiveProperty.PrimitiveType, " ", primitiveProperty.Name, ",", BreakLine, IndentString);
                                }
                            }
                        }
                    }
                }
            }

            if (ParameterText.Length >= BreakLine.Length + IndentString.Length + 1)
                ParameterText = ParameterText.Substring(0, (ParameterText.Length - BreakLine.Length - IndentString.Length - 1));

            return ParameterText;
        }

        public static string Get_Output_Parameters(DomainEntity domainEntity, int IndentSize)
        {
            int CountPrimary = 0;
            string ParameterText = string.Empty;
            string IndentString = string.Empty;

            for (int i = 0; i < IndentSize; i++)
                IndentString = string.Concat(IndentString, "    ");

            foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                if (primitiveProperty.IsDataAccessMapping)
                    if (primitiveProperty.IsPrimaryKey)
                        CountPrimary = CountPrimary + 1;

            if (CountPrimary > 0)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                    if (primitiveProperty.IsDataAccessMapping)
                        if (primitiveProperty.IsPrimaryKey)
                        {
                            ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), ".", primitiveProperty.Name, " = ");
                            ParameterText = string.Concat(ParameterText, "DataUtil.DbValueToDefault<", TemplateHelperDomainEntity.getPrimitiveType(primitiveProperty.PrimitiveType, false), ">(");
                            ParameterText = string.Concat(ParameterText, "oDatabase.GetParameterValue(oDbCommand, ");
                            ParameterText = string.Concat(ParameterText, "\"@", primitiveProperty.Name, "\"));", BreakLine, IndentString);
                        }
            }
            else
            {
                foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                {
                    if (domainEntityProperty.CollectionType == Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None)
                    {
                        foreach (DomainEntity domainEntityIn in domainEntity.DomainEntityModel.DomainEntities)
                        {
                            if (domainEntityProperty.DomainEntityType == domainEntityIn.Name)
                            {
                                foreach (PrimitiveProperty primitiveProperty in domainEntityIn.PrimitiveProperties)
                                {
                                    if (primitiveProperty.IsPrimaryKey)
                                    {
                                        ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), ".", domainEntityProperty.Name, ".", primitiveProperty.Name, " = ");
                                        ParameterText = string.Concat(ParameterText, "DataUtil.DbValueToDefault<", TemplateHelperDomainEntity.getPrimitiveType(primitiveProperty.PrimitiveType, false), ">(");
                                        ParameterText = string.Concat(ParameterText, "oDatabase.GetParameterValue(oDbCommand, ");
                                        ParameterText = string.Concat(ParameterText, "\"@", primitiveProperty.Name, "\"));", BreakLine, IndentString);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (ParameterText.Length >= BreakLine.Length + IndentString.Length)
                ParameterText = ParameterText.Substring(0, (ParameterText.Length - BreakLine.Length - IndentString.Length));

            return ParameterText;
        }

        public static string Get_Mapping_Text(DomainEntity domainEntity, string ListAdding, int IndentSize)
        {
            string IndentString = string.Empty;
            string ParameterText = string.Empty;

            for (int i = 0; i < IndentSize; i++)
                IndentString = string.Concat(IndentString, "    ");

            if (!string.IsNullOrEmpty(ListAdding))
                ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), "= new ", domainEntity.Name, "();", BreakLine, IndentString);

            foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                if (primitiveProperty.IsDataAccessMapping)
                    if (primitiveProperty.IsPrimaryKey)
                    {
                        ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), ".", primitiveProperty.Name, " = ");
                        ParameterText = string.Concat(ParameterText, "DataUtil.DbValueToDefault<", TemplateHelperDomainEntity.getPrimitiveType(primitiveProperty.PrimitiveType, false), ">(");
                        ParameterText = string.Concat(ParameterText, "oIDataReader[oIDataReader.GetOrdinal(\"", primitiveProperty.Name, "\")]);", BreakLine, IndentString);
                    }

            foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
            {
                if (domainEntityProperty.CollectionType == Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None)
                {
                    foreach (DomainEntity domainEntityIn in domainEntity.DomainEntityModel.DomainEntities)
                        if (domainEntityProperty.DomainEntityType == domainEntityIn.Name)
                        {
                            ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), ".", domainEntityProperty.Name, " = new ", domainEntityIn.Name, "();", BreakLine, IndentString);
                            foreach (PrimitiveProperty primitiveProperty in domainEntityIn.PrimitiveProperties)
                            {
                                if (primitiveProperty.IsPrimaryKey)
                                {
                                    ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), ".", domainEntityProperty.Name, ".", primitiveProperty.Name, " = ");
                                    ParameterText = string.Concat(ParameterText, "DataUtil.DbValueToDefault<", TemplateHelperDomainEntity.getPrimitiveType(primitiveProperty.PrimitiveType, false), ">(");
                                    ParameterText = string.Concat(ParameterText, "oIDataReader[oIDataReader.GetOrdinal(\"", primitiveProperty.Name, "\")]);", BreakLine, IndentString);
                                }
                            }
                            break;
                        }
                }
            }

            foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                if (primitiveProperty.IsDataAccessMapping)
                    if (!primitiveProperty.IsPrimaryKey)
                    {
                        ParameterText = string.Concat(ParameterText, Get_Variable_Name(domainEntity.Name), ".", primitiveProperty.Name, " = ");
                        ParameterText = string.Concat(ParameterText, "DataUtil.DbValueToDefault<", TemplateHelperDomainEntity.getPrimitiveType(primitiveProperty.PrimitiveType, false), ">(");
                        ParameterText = string.Concat(ParameterText, "oIDataReader[oIDataReader.GetOrdinal(\"", primitiveProperty.Name, "\")]);", BreakLine, IndentString);
                    }

            if (!string.IsNullOrEmpty(ListAdding))
                ParameterText = string.Concat(ParameterText, ListAdding, ".Add(", Get_Variable_Name(domainEntity.Name), ");", BreakLine, IndentString);

            if (ParameterText.Length >= BreakLine.Length + IndentString.Length)
                ParameterText = ParameterText.Substring(0, (ParameterText.Length - BreakLine.Length - IndentString.Length));

            return ParameterText;
        }

        public static string Get_DataBaseType_From_SystemType(PrimitiveProperty primitiveProperty)
        {
            string DataBaseType = string.Empty;

            switch (primitiveProperty.PrimitiveType)
            {
                case "System.Boolean":
                    DataBaseType = "DbType.Boolean";
                    break;
                case "System.Byte":
                    DataBaseType = "DbType.Byte";
                    break;
                case "System.Char":
                    DataBaseType = "DbType.Char";
                    break;
                case "System.DateTime":
                    DataBaseType = "DbType.DateTime";
                    break;
                case "System.Decimal":
                    DataBaseType = "DbType.Decimal";
                    break;
                case "System.Double":
                    DataBaseType = "DbType.Double";
                    break;
                case "System.Guid":
                    DataBaseType = "DbType.Guid";
                    break;
                case "System.Int16":
                    DataBaseType = "DbType.Int16";
                    break;
                case "System.Int32":
                    DataBaseType = "DbType.Int32";
                    break;
                case "System.Int64":
                    DataBaseType = "DbType.Int64";
                    break;
                case "System.SByte":
                    DataBaseType = "DbType.SByte";
                    break;
                case "System.Single":
                    DataBaseType = "DbType.Single";
                    break;
                case "System.String":
                    DataBaseType = "DbType.String";
                    break;
                case "System.UInt16":
                    DataBaseType = "DbType.UInt16";
                    break;
                case "System.UInt32":
                    DataBaseType = "DbType.UInt32";
                    break;
                case "System.UInt64":
                    DataBaseType = "DbType.UInt64";
                    break;
            }

            return DataBaseType;
        }

        public static bool DomainEntity_Has_OutputParameters(DomainEntity domainEntity)
        {
            int CountPrimary = 0;

            foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                if (primitiveProperty.IsDataAccessMapping)
                    if (primitiveProperty.IsPrimaryKey)
                        CountPrimary = CountPrimary + 1;

            if (CountPrimary > 0)
                return true;
            else
                return false;
        }

        public static string DomainEntity_Has_DomainEntityCollections(DomainEntity domainEntity)
        {
            string DomainEntityCollectionName = string.Empty;

            foreach (DomainEntityCollection domainEntityCollection in domainEntity.DomainEntityModel.DomainEntityCollections)
            {
                if (domainEntityCollection.DomainEntityType == domainEntity.Name)
                {
                    DomainEntityCollectionName = domainEntityCollection.Name;
                    break;
                }
            }

            return DomainEntityCollectionName;
        }

        public static string Get_DomainEntityCollectionType(DomainEntity domainEntity, string domainEntityCollectionName)
        {
            string CollectionType = string.Empty;

            foreach (DomainEntityCollection domainEntityCollection in domainEntity.DomainEntityModel.DomainEntityCollections)
            {
                if (domainEntityCollection.Name == domainEntityCollectionName)
                {
                    CollectionType = domainEntityCollection.CollectionType;
                    CollectionType = CollectionType.Replace("T", domainEntityCollection.DomainEntityType);
                    break;
                }
            }

            return CollectionType;
        }
    }
}
