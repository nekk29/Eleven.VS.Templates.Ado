using Eleven.VS.Templates.Ado.Dsl;
using Eleven.VS.Templates.Ado.Package.CodeGenerators.Base;
using Eleven.VS.Templates.Ado.Package.CustomCode.TextTemplates.Domain;
using Eleven.VS.Templates.Ado.Package.TextTemplates.Helper;
using System;

namespace Eleven.VS.Templates.Ado.Package.CodeGenerators
{
    public class CodeGeneratorDomain : CodeGeneratorBase
    {
        public CodeGeneratorDomain(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override void GenerateCodeFiles(DomainEntityModel domainEntityModel)
        {
            string extension = ".cs";
            string buildAction = string.Empty;
            string projectName = domainEntityModel.ProjectImplementationEntity;

            CodeGeneratorDomainEntity codeGeneratorDomainEntity;
            CodeGeneratorDomainEntityCollection codeGeneratorDomainEntityCollection;

            foreach (DomainEntity domainEntity in domainEntityModel.DomainEntities)
            {
                codeGeneratorDomainEntity = new CodeGeneratorDomainEntity();
                codeGeneratorDomainEntity.DomainEntity = domainEntity;

                string folderName = domainEntity.DomainModule;
                string fileName = TemplateHelperDomainEntity.Get_DataAccess_FileName_DomainEntity(domainEntity);
                string contentFile = codeGeneratorDomainEntity.TransformText();

                GenerateCodeFilesInProject(projectName, folderName, fileName, extension, buildAction, contentFile, false);
            }

            foreach (DomainEntityCollection domainEntityCollection in domainEntityModel.DomainEntityCollections)
            {
                codeGeneratorDomainEntityCollection = new CodeGeneratorDomainEntityCollection();
                codeGeneratorDomainEntityCollection.DomainEntityCollection = domainEntityCollection;

                string folderName = domainEntityCollection.DomainModule;
                string fileName = TemplateHelperDomainEntity.Get_DataAccess_FileName_DomainEntityCollection(domainEntityCollection);
                string contentFile = codeGeneratorDomainEntityCollection.TransformText();

                GenerateCodeFilesInProject(projectName, folderName, fileName, extension, buildAction, contentFile, false);
            }
        }
    }
}
