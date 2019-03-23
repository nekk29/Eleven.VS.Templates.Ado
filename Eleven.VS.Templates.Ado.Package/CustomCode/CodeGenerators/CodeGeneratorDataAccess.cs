using Eleven.VS.Templates.Ado.Dsl;
using Eleven.VS.Templates.Ado.Package.CodeGenerators.Base;
using Eleven.VS.Templates.Ado.Package.CustomCode.TextTemplates.DataAccess;
using Eleven.VS.Templates.Ado.Package.TextTemplates.Helper;
using System;

namespace Eleven.VS.Templates.Ado.Package.CodeGenerators
{
    public class CodeGeneratorDataAccess : CodeGeneratorBase
    {
        public CodeGeneratorDataAccess(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override void GenerateCodeFiles(DomainEntityModel domainEntityModel)
        {
            string extension = ".cs";
            string buildAction = string.Empty;
            string projectName = domainEntityModel.ProjectImplementationDataAccess;

            CodeGeneratorDataAccessClass codeGeneratorDataAccessClass;

            foreach (DomainEntity domainEntity in domainEntityModel.DomainEntities)
            {
                codeGeneratorDataAccessClass = new CodeGeneratorDataAccessClass();
                codeGeneratorDataAccessClass.DomainEntity = domainEntity;

                string folderName = domainEntity.DomainModule;
                string fileName = TemplateHelperDataAccess.Get_DataAccess_Class_Name(domainEntity);
                string contentFile = codeGeneratorDataAccessClass.TransformText();

                GenerateCodeFilesInProject(projectName, folderName, fileName, extension, buildAction, contentFile, false);
            }
        }
    }
}
