using Eleven.VS.Templates.Ado.Dsl;
using Eleven.VS.Templates.Ado.Package.CodeGenerators;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Shell;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;

namespace Eleven.VS.Templates.Ado.Package
{
    internal partial class ElevenEntityModelCommandSet : ElevenEntityModelCommandSetBase
    {
        private Guid guidNLayerDSLToolsCmdSet = new Guid("55D35A6F-AA65-4A0E-B022-761F59DDD30A");
        private const int cmdidNLayerDSLToolsGenerateMenuCommand = 0x0200;

        public ElevenEntityModelCommandSet(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        protected override IList<MenuCommand> GetMenuCommands()
        {
            IList<MenuCommand> commands = base.GetMenuCommands();

            DynamicStatusMenuCommand myContextGenerateMenuCommand = new DynamicStatusMenuCommand(
                new EventHandler(OnStatusMyContextGenerateMenuCommand),
                new EventHandler(OnMenuMyContextGenerateMenuCommand),
                new CommandID(guidNLayerDSLToolsCmdSet, cmdidNLayerDSLToolsGenerateMenuCommand)
            );

            commands.Add(myContextGenerateMenuCommand);

            return commands;
        }

        private void OnStatusMyContextOrderMenuCommand(object sender, EventArgs e)
        {
            MenuCommand command = sender as MenuCommand;
            command.Visible = command.Enabled = false;

            if (IsDiagramSelected())
            {
                command.Visible = command.Enabled = true;
                return;
            }
        }

        private void OnStatusMyContextGenerateMenuCommand(object sender, EventArgs e)
        {
            MenuCommand command = sender as MenuCommand;
            command.Visible = command.Enabled = false;

            if (IsDiagramSelected())
            {
                command.Visible = command.Enabled = true;
                return;
            }
        }

        private void OnMenuMyContextGenerateMenuCommand(object sender, EventArgs e)
        {
            try
            {
                Store store = this.CurrentDocData.Store;
                ReadOnlyCollection<DomainEntityModel> domainEntityModelList = store.ElementDirectory.FindElements<DomainEntityModel>();

                if (domainEntityModelList != null)
                {
                    if (domainEntityModelList.Count > 0)
                    {
                        new CodeGeneratorDatabase(ServiceProvider).GenerateCodeFiles(domainEntityModelList[0]);
                        new CodeGeneratorDomain(ServiceProvider).GenerateCodeFiles(domainEntityModelList[0]);
                        new CodeGeneratorDataAccessCore(ServiceProvider).GenerateCodeFiles(domainEntityModelList[0]);
                        new CodeGeneratorDataAccess(ServiceProvider).GenerateCodeFiles(domainEntityModelList[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
