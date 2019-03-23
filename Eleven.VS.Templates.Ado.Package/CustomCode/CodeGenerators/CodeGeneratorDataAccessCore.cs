using Eleven.VS.Templates.Ado.Dsl;
using Eleven.VS.Templates.Ado.Package.CodeGenerators.Base;
using Eleven.VS.Templates.Ado.Package.CustomCode.TextTemplates.CrossCutting;
using System;

namespace Eleven.VS.Templates.Ado.Package.CodeGenerators
{
    public class CodeGeneratorDataAccessCore : CodeGeneratorBase
    {
        public CodeGeneratorDataAccessCore(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override void GenerateCodeFiles(DomainEntityModel domainEntityModel)
        {
            string folderName = string.Empty;
            string fileName = string.Empty;
            string extension = ".cs";
            string buildAction = string.Empty;
            string contentFile = string.Empty;
            string projectName = domainEntityModel.ProjectImplementationDataAccessCore;

            CodeGeneratorCrossCuttingConnection codeGeneratorCrossCuttingConnection = new CodeGeneratorCrossCuttingConnection();

            fileName = "Conexion";
            codeGeneratorCrossCuttingConnection.DomainEntityModel = domainEntityModel;
            contentFile = codeGeneratorCrossCuttingConnection.TransformText();
            GenerateCodeFilesInProject(projectName, folderName, fileName, extension, buildAction, contentFile, false);

            CodeGeneratorCrossCuttingProcedures codeGeneratorCrossCuttingProcedures = new CodeGeneratorCrossCuttingProcedures();

            fileName = "Procedimiento";
            codeGeneratorCrossCuttingProcedures.DomainEntityModel = domainEntityModel;
            contentFile = codeGeneratorCrossCuttingProcedures.TransformText();
            GenerateCodeFilesInProject(projectName, folderName, fileName, extension, buildAction, contentFile, false);

            CodeGeneratorCrossCuttingHelper codeGeneratorCrossCuttingHelper = new CodeGeneratorCrossCuttingHelper();

            fileName = "DataUtil";
            codeGeneratorCrossCuttingHelper.DomainEntityModel = domainEntityModel;
            contentFile = codeGeneratorCrossCuttingHelper.TransformText();
            GenerateCodeFilesInProject(projectName, folderName, fileName, extension, buildAction, contentFile, false);
        }
    }
}
