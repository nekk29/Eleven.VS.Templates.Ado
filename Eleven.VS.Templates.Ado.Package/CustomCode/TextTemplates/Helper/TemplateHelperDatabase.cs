using Eleven.VS.Templates.Ado.Dsl;
using System;
using System.Linq;

namespace Eleven.VS.Templates.Ado.Package.TextTemplates.Helper
{
    public class TemplateHelperDatabase
    {
        #region Common Variables

        private static readonly string Dot = ".";
        private static readonly string Comma = ",";
        private static readonly string Equal = "=";
        private static readonly string BreakLine = Environment.NewLine;
        private static readonly string BlankSpace = " ";
        private static readonly string SquareBracketOpen = "[";
        private static readonly string SquareBracketClose = "]";
        private static readonly string ParameterPrefix = "@";
        private static readonly string AndOperator = "AND";
        private static readonly int TabCharacterSize = 4;

        #endregion

        #region Database Object Names

        public static string Get_DataAccess_TableName(DomainEntity domainEntity)
        {
            return string.Concat(SquareBracketOpen, domainEntity.DataAccessSchema, SquareBracketClose, Dot, SquareBracketOpen, domainEntity.DataAccessTable, SquareBracketClose);
        }

        public static string Get_DataAccess_Insert_SPName(DomainEntity domainEntity)
        {
            return Get_DataAccess_SPName(domainEntity, Get_DataAccess_FileName_InsertSP(domainEntity));
        }

        public static string Get_DataAccess_Update_SPName(DomainEntity domainEntity)
        {
            return Get_DataAccess_SPName(domainEntity, Get_DataAccess_FileName_UpdateSP(domainEntity)); ;
        }

        public static string Get_DataAccess_Delete_SPName(DomainEntity domainEntity)
        {
            return Get_DataAccess_SPName(domainEntity, Get_DataAccess_FileName_DeleteSP(domainEntity));
        }

        public static string Get_DataAccess_SelectId_SPName(DomainEntity domainEntity)
        {
            return Get_DataAccess_SPName(domainEntity, Get_DataAccess_FileName_SelectIdSP(domainEntity));
        }

        public static string Get_DataAccess_Select_SPName(DomainEntity domainEntity)
        {
            return Get_DataAccess_SPName(domainEntity, Get_DataAccess_FileName_SelectSP(domainEntity));
        }

        private static string Get_DataAccess_SPName(DomainEntity domainEntity, string storeProcedureName)
        {
            return string.Concat(SquareBracketOpen, domainEntity.DataAccessSchema, SquareBracketClose, Dot, SquareBracketOpen, storeProcedureName, SquareBracketClose);
        }

        #endregion

        #region Database Object File Names

        public static string Get_DataAccess_FileName_Table(DomainEntity domainEntity)
        {
            return domainEntity.Name;
        }

        public static string Get_DataAccess_FileName_InsertSP(DomainEntity domainEntity)
        {
            return string.Concat("Usp_Ins_", domainEntity.DataAccessTable);
        }

        public static string Get_DataAccess_FileName_UpdateSP(DomainEntity domainEntity)
        {
            return string.Concat("Usp_Upd_", domainEntity.DataAccessTable);
        }

        public static string Get_DataAccess_FileName_DeleteSP(DomainEntity domainEntity)
        {
            return string.Concat("Usp_Del_", domainEntity.DataAccessTable);
        }

        public static string Get_DataAccess_FileName_SelectIdSP(DomainEntity domainEntity)
        {
            return string.Concat("Usp_Sel_", domainEntity.DataAccessTable, "_ById");
        }

        public static string Get_DataAccess_FileName_SelectSP(DomainEntity domainEntity)
        {
            return string.Concat("Usp_Sel_", domainEntity.DataAccessTable);
        }

        #endregion

        #region Common Functions

        public static string Get_DataAccess_Columns_CreateTable(DomainEntity domainEntity, int indentSize)
        {
            DomainEntity domainEntityParent;
            string ColumnsText = string.Empty;
            string Indentstring = string.Empty.PadLeft(TabCharacterSize * indentSize, char.Parse(BlankSpace));

            foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
            {
                if (primitiveProperty.IsDataAccessMapping)
                    if (primitiveProperty.IsPrimaryKey)
                        ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose, BlankSpace, primitiveProperty.DataAccessType.ToUpper(), BlankSpace, "IDENTITY(1,1) NOT NULL", Comma, BreakLine);
            }

            foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
            {
                if (domainEntityProperty.CollectionType.CompareTo(Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None) == 0)
                {
                    domainEntityParent = Get_DomainEntity_By_Name(domainEntity, domainEntityProperty.DomainEntityType);

                    if (domainEntityParent != null)
                    {
                        foreach (PrimitiveProperty primitiveProperty in domainEntityParent.PrimitiveProperties)
                        {
                            if (primitiveProperty.IsDataAccessMapping)
                                if (primitiveProperty.IsPrimaryKey)
                                    ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose, BlankSpace, primitiveProperty.DataAccessType.ToUpper(), Comma, BreakLine);
                        }
                    }
                }
            }

            foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
            {
                if (primitiveProperty.IsDataAccessMapping)
                    if (!primitiveProperty.IsPrimaryKey)
                        ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose, BlankSpace, primitiveProperty.DataAccessType.ToUpper(), Comma, BreakLine);
            }

            if (ColumnsText.Length >= Comma.Length + BreakLine.Length)
                ColumnsText = ColumnsText.Substring(0, (ColumnsText.Length - Comma.Length - BreakLine.Length));

            return ColumnsText;
        }

        public static string Get_DataAccess_Parameters_StoreProcedure(DomainEntity domainEntity, int indentSize, bool includePrimaryKey, bool includeNonPrimaryKey, bool includeOutputForPrimaryKey = false)
        {
            DomainEntity domainEntityParent;
            string ColumnsText = string.Empty;
            string Indentstring = string.Empty.PadLeft(TabCharacterSize * indentSize, char.Parse(BlankSpace));
            bool existPrimaryKey = domainEntity.PrimitiveProperties.Any(x => x.IsPrimaryKey);
            string outPutToken = includeOutputForPrimaryKey ? " OUTPUT" : string.Empty;

            if (includePrimaryKey)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                {
                    if (primitiveProperty.IsDataAccessMapping)
                        if (primitiveProperty.IsPrimaryKey)
                            ColumnsText = string.Concat(ColumnsText, Indentstring, ParameterPrefix, primitiveProperty.DataAccessColumn, BlankSpace, primitiveProperty.DataAccessType.ToUpper(), outPutToken, Comma, BreakLine);
                }
            }

            if ((includePrimaryKey && !existPrimaryKey) || includeNonPrimaryKey)
            {
                foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                {
                    if (domainEntityProperty.CollectionType.CompareTo(Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None) == 0)
                    {
                        domainEntityParent = Get_DomainEntity_By_Name(domainEntity, domainEntityProperty.DomainEntityType);

                        if (domainEntityParent != null)
                        {
                            foreach (PrimitiveProperty primitiveProperty in domainEntityParent.PrimitiveProperties)
                            {
                                if (primitiveProperty.IsDataAccessMapping)
                                    if (primitiveProperty.IsPrimaryKey)
                                        ColumnsText = string.Concat(ColumnsText, Indentstring, ParameterPrefix, primitiveProperty.DataAccessColumn, BlankSpace, primitiveProperty.DataAccessType.ToUpper(), Comma, BreakLine);
                            }
                        }
                    }
                }
            }

            if (includeNonPrimaryKey)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                {
                    if (primitiveProperty.IsDataAccessMapping)
                        if (!primitiveProperty.IsPrimaryKey)
                            ColumnsText = string.Concat(ColumnsText, Indentstring, ParameterPrefix, primitiveProperty.DataAccessColumn, BlankSpace, primitiveProperty.DataAccessType.ToUpper(), Comma, BreakLine);
                }
            }

            if (ColumnsText.Length >= Comma.Length + BreakLine.Length)
                ColumnsText = ColumnsText.Substring(0, (ColumnsText.Length - Comma.Length - BreakLine.Length));

            return ColumnsText;
        }

        public static string Get_DataAccess_Columns_StoreProcedure(DomainEntity domainEntity, int indentSize, bool includePrimaryKey, bool includeNonPrimaryKey)
        {
            DomainEntity domainEntityParent;
            string ColumnsText = string.Empty;
            string Indentstring = string.Empty.PadLeft(TabCharacterSize * indentSize, char.Parse(BlankSpace));
            bool existPrimaryKey = domainEntity.PrimitiveProperties.Any(x => x.IsPrimaryKey);

            if (includePrimaryKey)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                {
                    if (primitiveProperty.IsDataAccessMapping)
                        if (primitiveProperty.IsPrimaryKey)
                            ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose, Comma, BreakLine);
                }
            }

            if ((includePrimaryKey && !existPrimaryKey) || includeNonPrimaryKey)
            {
                foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                {
                    if (domainEntityProperty.CollectionType.CompareTo(Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None) == 0)
                    {
                        domainEntityParent = Get_DomainEntity_By_Name(domainEntity, domainEntityProperty.DomainEntityType);

                        if (domainEntityParent != null)
                        {
                            foreach (PrimitiveProperty primitiveProperty in domainEntityParent.PrimitiveProperties)
                            {
                                if (primitiveProperty.IsDataAccessMapping)
                                    if (primitiveProperty.IsPrimaryKey)
                                        ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose, Comma, BreakLine);
                            }
                        }
                    }
                }
            }

            if (includeNonPrimaryKey)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                {
                    if (primitiveProperty.IsDataAccessMapping)
                        if (!primitiveProperty.IsPrimaryKey)
                            ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose, Comma, BreakLine);
                }
            }

            if (ColumnsText.Length >= Comma.Length + BreakLine.Length)
                ColumnsText = ColumnsText.Substring(0, (ColumnsText.Length - Comma.Length - BreakLine.Length));

            return ColumnsText;
        }

        public static string Get_DataAccess_ColumnParameters_StoreProcedure(DomainEntity domainEntity, int indentSize, bool includePrimaryKey, bool includeNonPrimaryKey)
        {
            DomainEntity domainEntityParent;
            string ColumnsText = string.Empty;
            string Indentstring = string.Empty.PadLeft(TabCharacterSize * indentSize, char.Parse(BlankSpace));
            bool existPrimaryKey = domainEntity.PrimitiveProperties.Any(x => x.IsPrimaryKey);

            if (includePrimaryKey)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                {
                    if (primitiveProperty.IsDataAccessMapping)
                        if (primitiveProperty.IsPrimaryKey)
                            ColumnsText = string.Concat(ColumnsText, Indentstring, ParameterPrefix, primitiveProperty.DataAccessColumn, Comma, BreakLine);
                }
            }

            if ((includePrimaryKey && !existPrimaryKey) || includeNonPrimaryKey)
            {
                foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                {
                    if (domainEntityProperty.CollectionType.CompareTo(Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None) == 0)
                    {
                        domainEntityParent = Get_DomainEntity_By_Name(domainEntity, domainEntityProperty.DomainEntityType);

                        if (domainEntityParent != null)
                        {
                            foreach (PrimitiveProperty primitiveProperty in domainEntityParent.PrimitiveProperties)
                            {
                                if (primitiveProperty.IsDataAccessMapping)
                                    if (primitiveProperty.IsPrimaryKey)
                                        ColumnsText = string.Concat(ColumnsText, Indentstring, ParameterPrefix, primitiveProperty.DataAccessColumn, Comma, BreakLine);
                            }
                        }
                    }
                }
            }

            if (includeNonPrimaryKey)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                {
                    if (primitiveProperty.IsDataAccessMapping)
                        if (!primitiveProperty.IsPrimaryKey)
                            ColumnsText = string.Concat(ColumnsText, Indentstring, ParameterPrefix, primitiveProperty.DataAccessColumn, Comma, BreakLine);
                }
            }

            if (ColumnsText.Length >= Comma.Length + BreakLine.Length)
                ColumnsText = ColumnsText.Substring(0, (ColumnsText.Length - Comma.Length - BreakLine.Length));

            return ColumnsText;
        }

        public static string Get_DataAccess_ColumnParameters_Assignment_StoreProcedure(DomainEntity domainEntity, int indentSize, bool includePrimaryKey, bool includeNonPrimaryKey)
        {
            DomainEntity domainEntityParent;
            string ColumnsText = string.Empty;
            string Indentstring = string.Empty.PadLeft(TabCharacterSize * indentSize, char.Parse(BlankSpace));
            bool existPrimaryKey = domainEntity.PrimitiveProperties.Any(x => x.IsPrimaryKey);

            if (includePrimaryKey)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                {
                    if (primitiveProperty.IsDataAccessMapping)
                        if (primitiveProperty.IsPrimaryKey)
                            ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose,
                                BlankSpace, Equal, BlankSpace, ParameterPrefix, primitiveProperty.DataAccessColumn, Comma, BreakLine);
                }
            }

            if ((includePrimaryKey && !existPrimaryKey) || includeNonPrimaryKey)
            {
                foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                {
                    if (domainEntityProperty.CollectionType.CompareTo(Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None) == 0)
                    {
                        domainEntityParent = Get_DomainEntity_By_Name(domainEntity, domainEntityProperty.DomainEntityType);

                        if (domainEntityParent != null)
                        {
                            foreach (PrimitiveProperty primitiveProperty in domainEntityParent.PrimitiveProperties)
                            {
                                if (primitiveProperty.IsDataAccessMapping)
                                    if (primitiveProperty.IsPrimaryKey)
                                        ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose,
                                            BlankSpace, Equal, BlankSpace, ParameterPrefix, primitiveProperty.DataAccessColumn, Comma, BreakLine);
                            }
                        }
                    }
                }
            }

            if (includeNonPrimaryKey)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                {
                    if (primitiveProperty.IsDataAccessMapping)
                        if (!primitiveProperty.IsPrimaryKey)
                            ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose,
                                BlankSpace, Equal, BlankSpace, ParameterPrefix, primitiveProperty.DataAccessColumn, Comma, BreakLine);
                }
            }

            if (ColumnsText.Length >= Comma.Length + BreakLine.Length)
                ColumnsText = ColumnsText.Substring(0, (ColumnsText.Length - Comma.Length - BreakLine.Length));

            return ColumnsText;
        }

        public static string Get_DataAccess_ColumnParameters_Where_StoreProcedure(DomainEntity domainEntity, int indentSize, bool includePrimaryKey, bool includeNonPrimaryKey)
        {
            DomainEntity domainEntityParent;
            string ColumnsText = string.Empty;
            string Indentstring = string.Empty.PadLeft(TabCharacterSize * indentSize, char.Parse(BlankSpace));
            bool existPrimaryKey = domainEntity.PrimitiveProperties.Any(x => x.IsPrimaryKey);

            if (includePrimaryKey)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                {
                    if (primitiveProperty.IsDataAccessMapping)
                        if (primitiveProperty.IsPrimaryKey)
                            ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose,
                                BlankSpace, Equal, BlankSpace, ParameterPrefix, primitiveProperty.DataAccessColumn, BlankSpace, AndOperator, BreakLine);
                }
            }

            if ((includePrimaryKey && !existPrimaryKey) || includeNonPrimaryKey)
            {
                foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                {
                    if (domainEntityProperty.CollectionType.CompareTo(Dsl.Resources.TypeConverters.DomainEntityProperty_CollectionType_None) == 0)
                    {
                        domainEntityParent = Get_DomainEntity_By_Name(domainEntity, domainEntityProperty.DomainEntityType);

                        if (domainEntityParent != null)
                        {
                            foreach (PrimitiveProperty primitiveProperty in domainEntityParent.PrimitiveProperties)
                            {
                                if (primitiveProperty.IsDataAccessMapping)
                                    if (primitiveProperty.IsPrimaryKey)
                                        ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose,
                                            BlankSpace, Equal, BlankSpace, ParameterPrefix, primitiveProperty.DataAccessColumn, BlankSpace, AndOperator, BreakLine);
                            }
                        }
                    }
                }
            }

            if (includeNonPrimaryKey)
            {
                foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                {
                    if (primitiveProperty.IsDataAccessMapping)
                        if (!primitiveProperty.IsPrimaryKey)
                            ColumnsText = string.Concat(ColumnsText, Indentstring, SquareBracketOpen, primitiveProperty.DataAccessColumn, SquareBracketClose,
                                BlankSpace, Equal, BlankSpace, ParameterPrefix, primitiveProperty.DataAccessColumn, BlankSpace, AndOperator, BreakLine);
                }
            }

            if (ColumnsText.Length >= AndOperator.Length + BreakLine.Length)
                ColumnsText = ColumnsText.Substring(0, (ColumnsText.Length - AndOperator.Length - BreakLine.Length));

            return ColumnsText;
        }

        private static DomainEntity Get_DomainEntity_By_Name(DomainEntity domainEntity, string domainEntityName)
        {
            foreach (DomainEntity domainEntityIn in domainEntity.DomainEntityModel.DomainEntities)
                if (domainEntityIn.Name.CompareTo(domainEntityName) == 0)
                    return domainEntityIn;

            return null;
        }

        public static bool DomainEntity_Has_OutputParameters(DomainEntity domainEntity)
        {
            return domainEntity.PrimitiveProperties.Any(x => x.IsPrimaryKey);
        }

        public static string Get_DataAccess_OutputKey(DomainEntity domainEntity, int indentSize)
        {
            string ColumnsText = string.Empty;
            string Indentstring = string.Empty.PadLeft(TabCharacterSize * indentSize, char.Parse(BlankSpace));

            foreach (PrimitiveProperty primitiveProperty in domainEntity.PrimitiveProperties)
                if (primitiveProperty.IsDataAccessMapping)
                    if (primitiveProperty.IsPrimaryKey)
                    {
                        ColumnsText = string.Concat(Indentstring, "SET ", ParameterPrefix, primitiveProperty.Name, " = @@identity");
                        break;
                    }

            return ColumnsText;
        }

        #endregion
    }
}
