using Eleven.VS.Templates.Ado.Dsl;
using Eleven.VS.Templates.Ado.Dsl.CustomCode.CustomClasses;
using Eleven.VS.Templates.Ado.Package.CodeGenerators.Base;
using Eleven.VS.Templates.Ado.Package.CustomCode.TextTemplates.Database;
using Eleven.VS.Templates.Ado.Package.TextTemplates.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eleven.VS.Templates.Ado.Package.CodeGenerators
{
    public class CodeGeneratorDatabase : CodeGeneratorBase
    {
        private string FolderName { get; set; }
        private string FileName { get; set; }
        private string ContentFile { get; set; }

        public CodeGeneratorDatabase(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override void GenerateCodeFiles(DomainEntityModel domainEntityModel)
        {
            string projectName = domainEntityModel.ProjectImplementationDatabase;
            string subFolderSeparator = "\\";
            string defaultSchema = "dbo";
            string extension = ".sql";
            string buildAction = string.Empty;

            GenerateSchemas(domainEntityModel, projectName, subFolderSeparator, defaultSchema, extension, buildAction);
            GenerateTableObjects(domainEntityModel, projectName, subFolderSeparator, defaultSchema, extension, buildAction);
            GenerateStoreProcedureObjects(domainEntityModel, projectName, subFolderSeparator, defaultSchema, extension, buildAction);
        }

        private void GenerateSchemas(DomainEntityModel domainEntityModel, string projectName, string subFolderSeparator, string defaultSchema, string extension, string buildAction)
        {
            List<DatabaseSchema> databaseSchemaList = new List<DatabaseSchema>();
            CodeGeneratorDatabaseSchema codeGeneratorDatabaseSchema;

            foreach (DomainEntity domainEntity in domainEntityModel.DomainEntities)
            {
                if (domainEntity.IsDataAccessMapping)
                    if (!databaseSchemaList.Any(x => x.Name.Equals(domainEntity.DataAccessSchema)))
                        databaseSchemaList.Add(new DatabaseSchema() { Name = domainEntity.DataAccessSchema, Owner = defaultSchema });
            }

            foreach (DatabaseSchema databaseSchema in databaseSchemaList)
            {
                codeGeneratorDatabaseSchema = new CodeGeneratorDatabaseSchema();
                codeGeneratorDatabaseSchema.DatabaseSchema = databaseSchema;

                FolderName = "Security";
                FileName = databaseSchema.Name;
                ContentFile = codeGeneratorDatabaseSchema.TransformText();

                GenerateCodeFilesInProject(projectName, FolderName, FileName, extension, buildAction, ContentFile, true);
            }
        }

        private void GenerateTableObjects(DomainEntityModel domainEntityModel, string projectName, string subFolderSeparator, string defaultSchema, string extension, string buildAction)
        {
            CodeGeneratorDatabaseTable codeGeneratorDatabaseTable;

            foreach (DomainEntity domainEntity in domainEntityModel.DomainEntities)
            {
                if (domainEntity.IsDataAccessMapping)
                {
                    codeGeneratorDatabaseTable = new CodeGeneratorDatabaseTable();
                    codeGeneratorDatabaseTable.DomainEntity = domainEntity;

                    FolderName = string.Concat((string.IsNullOrEmpty(domainEntity.DataAccessSchema) ? defaultSchema : domainEntity.DataAccessSchema), subFolderSeparator, "Tables");
                    FileName = TemplateHelperDatabase.Get_DataAccess_FileName_Table(domainEntity);
                    ContentFile = codeGeneratorDatabaseTable.TransformText();

                    GenerateCodeFilesInProject(projectName, FolderName, FileName, extension, buildAction, ContentFile, true);
                }
            }
        }

        private void GenerateStoreProcedureObjects(DomainEntityModel domainEntityModel, string projectName, string subFolderSeparator, string defaultSchema, string extension, string buildAction)
        {
            CodeGeneratorDatabaseSPInsert codeGeneratorDatabaseSPInsert;
            CodeGeneratorDatabaseSPUpdate codeGeneratorDatabaseSPUpdate;
            CodeGeneratorDatabaseSPDelete codeGeneratorDatabaseSPDelete;
            CodeGeneratorDatabaseSPSelectById codeGeneratorDatabaseSPSelectById;
            CodeGeneratorDatabaseSPSelect codeGeneratorDatabaseSPSelect;

            foreach (DomainEntity domainEntity in domainEntityModel.DomainEntities)
            {
                if (domainEntity.IsDataAccessMapping)
                {
                    FolderName = string.Concat((string.IsNullOrEmpty(domainEntity.DataAccessSchema) ? defaultSchema : domainEntity.DataAccessSchema), subFolderSeparator, "Stored Procedures");

                    #region Insert Store Procedure

                    codeGeneratorDatabaseSPInsert = new CodeGeneratorDatabaseSPInsert();
                    codeGeneratorDatabaseSPInsert.DomainEntity = domainEntity;

                    FileName = TemplateHelperDatabase.Get_DataAccess_FileName_InsertSP(domainEntity);
                    ContentFile = codeGeneratorDatabaseSPInsert.TransformText();

                    GenerateCodeFilesInProject(projectName, FolderName, FileName, extension, buildAction, ContentFile, true);

                    #endregion

                    #region Update Store Procedure

                    codeGeneratorDatabaseSPUpdate = new CodeGeneratorDatabaseSPUpdate();
                    codeGeneratorDatabaseSPUpdate.DomainEntity = domainEntity;

                    FileName = TemplateHelperDatabase.Get_DataAccess_FileName_UpdateSP(domainEntity);
                    ContentFile = codeGeneratorDatabaseSPUpdate.TransformText();

                    GenerateCodeFilesInProject(projectName, FolderName, FileName, extension, buildAction, ContentFile, true);

                    #endregion

                    #region Delete Store Procedure

                    codeGeneratorDatabaseSPDelete = new CodeGeneratorDatabaseSPDelete();
                    codeGeneratorDatabaseSPDelete.DomainEntity = domainEntity;

                    FileName = TemplateHelperDatabase.Get_DataAccess_FileName_DeleteSP(domainEntity);
                    ContentFile = codeGeneratorDatabaseSPDelete.TransformText();

                    GenerateCodeFilesInProject(projectName, FolderName, FileName, extension, buildAction, ContentFile, true);

                    #endregion

                    #region SelectById Store Procedure

                    codeGeneratorDatabaseSPSelectById = new CodeGeneratorDatabaseSPSelectById();
                    codeGeneratorDatabaseSPSelectById.DomainEntity = domainEntity;

                    FileName = TemplateHelperDatabase.Get_DataAccess_FileName_SelectIdSP(domainEntity);
                    ContentFile = codeGeneratorDatabaseSPSelectById.TransformText();

                    GenerateCodeFilesInProject(projectName, FolderName, FileName, extension, buildAction, ContentFile, true);

                    #endregion

                    #region Select Store Procedure

                    codeGeneratorDatabaseSPSelect = new CodeGeneratorDatabaseSPSelect();
                    codeGeneratorDatabaseSPSelect.DomainEntity = domainEntity;

                    FileName = TemplateHelperDatabase.Get_DataAccess_FileName_SelectSP(domainEntity);
                    ContentFile = codeGeneratorDatabaseSPSelect.TransformText();

                    GenerateCodeFilesInProject(projectName, FolderName, FileName, extension, buildAction, ContentFile, true);

                    #endregion
                }
            }
        }
    }
}
