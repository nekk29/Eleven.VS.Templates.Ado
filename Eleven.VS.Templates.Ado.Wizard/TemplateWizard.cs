using Eleven.VS.Templates.Ado.Wizard.Resources;
using Eleven.VS.Templates.Ado.Wizard.Utils;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VSLangProj;

namespace Eleven.VS.Templates.Ado.Wizard
{
    public class TemplateWizard : IWizard
    {
        _DTE dte;
        Solution2 solution;
        SolutionFolder solutionFolder;

        private bool IsSolution = true;
        private string SafeProjectName;

        public void BeforeOpeningFile(ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(Project project)
        {

        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {

        }

        public void RunFinished()
        {
            try
            {
                Solution2 solution2 = (Solution2)dte.Solution;
                IList<Project> projects = SolutionUtils.GetAllProjectsInSolution(solution2);

                Project projectDataAccess = projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Data.MainModule"));
                Project projectDataEntity = projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Core.Entities"));
                Project projectDataCommon = projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("CrossCutting.Common"));

                if (projectDataAccess != null && projectDataEntity != null && projectDataCommon != null)
                {
                    VSProject vsProjectDataAccess = projectDataAccess.Object as VSProject;
                    VSProject vsProjectDataEntity = projectDataEntity.Object as VSProject;
                    VSProject vsProjectDataCommon = projectDataCommon.Object as VSProject;

                    vsProjectDataAccess.References.AddProject(projectDataEntity);
                    vsProjectDataAccess.References.AddProject(projectDataCommon);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message);
                else
                    MessageBox.Show(ex.InnerException.Message);
            }
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            dte = automationObject as _DTE;

            if (IsSolution)
            {
                InitializeReplacementsDictionary(replacementsDictionary);
                IsSolution = false;
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        private void InitializeReplacementsDictionary(Dictionary<string, string> replacementsDictionary)
        {
            SafeProjectName = replacementsDictionary["$safeprojectname$"];

            replacementsDictionary["$safesolutionname$"] = replacementsDictionary["$safeprojectname$"];

            //0 Modeling and Design
            replacementsDictionary["$a_solutionfoldermodeling$"] = SolutionTemplate.A_SolutionFolder_Modeling;

            //1 Layers
            replacementsDictionary["$b_solutionfolder_layers$"] = SolutionTemplate.B_SolutionFolder_Layers;
            //1 Layers -> 1.1 Presentation
            replacementsDictionary["$b_solutionfolder_layers_1_presentation$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation;
            //1 Layers -> 1.1 Presentation -> Mobile
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_1_mobile$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_1_Mobile;
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_1_mobile_1_android$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_1_Mobile_1_Android;
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_1_mobile_2_windowsphone$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_1_Mobile_2_WindowsPhone;

            //1 Layers -> 1.1 Presentation -> RIA
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_2_ria$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_2_RIA;
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_2_ria_1_silverlightclient$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_2_RIA_1_SilverlightClient;
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_2_ria_2_silverlightmobile$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_2_RIA_2_SilverlightMobile;

            //1 Layers -> 1.1 Presentation -> Web
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_3_web$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_3_Web;
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_3_web_1_aspnetcient$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_3_Web_1_ASPNETCient;
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_3_web_2_aspnetmvccient$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_3_Web_2_ASPNETMVCCient;

            //1 Layers -> 1.1 Presentation -> Windows
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_4_windows$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_4_Windows;
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_4_windows_1_obaclient$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_4_Windows_1_OBAClient;
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_4_windows_2_winformclient$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_4_Windows_2_WinFormClient;
            replacementsDictionary["$b_solutionfolder_layers_1_presentation_4_windows_3_wpfclient$"] = SolutionTemplate.B_SolutionFolder_Layers_1_Presentation_4_Windows_3_WPFClient;

            //1 Layers -> 1.2 Distributed Services
            replacementsDictionary["$b_solutionfolder_layers_2_distributedservices$"] = SolutionTemplate.B_SolutionFolder_Layers_2_DistributedServices;
            //1 Layers -> 1.2 Distributed Services -> 1.2.1 Core
            replacementsDictionary["$b_solutionfolder_layers_2_distributedservices_1_core$"] = SolutionTemplate.B_SolutionFolder_Layers_2_DistributedServices_1_Core;
            //1 Layers -> 1.2 Distributed Services -> 1.2.2 MainModule
            replacementsDictionary["$b_solutionfolder_layers_2_distributedservices_2_mainmodule$"] = SolutionTemplate.B_SolutionFolder_Layers_2_DistributedServices_2_MainModule;
            //1 Layers -> 1.2 Distributed Services -> 1.2.3 Deployment
            replacementsDictionary["$b_solutionfolder_layers_2_distributedservices_3_deployment$"] = SolutionTemplate.B_SolutionFolder_Layers_2_DistributedServices_3_Deployment;
            //1 Layers -> 1.3 Application
            replacementsDictionary["$b_solutionfolder_layers_3_application$"] = SolutionTemplate.B_SolutionFolder_Layers_3_Application;
            //1 Layers -> 1.3 Application -> 1.3.1 Core
            replacementsDictionary["$b_solutionfolder_layers_3_application_1_core$"] = SolutionTemplate.B_SolutionFolder_Layers_3_Application_1_Core;
            //1 Layers -> 1.3 Application -> 1.3.2 MainModule
            replacementsDictionary["$b_solutionfolder_layers_3_application_2_mainmodule$"] = SolutionTemplate.B_SolutionFolder_Layers_3_Application_2_MainModule;
            //1 Layers -> 1.4 Domain
            replacementsDictionary["$b_solutionfolder_layers_4_domain$"] = SolutionTemplate.B_SolutionFolder_Layers_4_Domain;
            //1 Layers -> 1.4 Domain -> 1.4.1 Core
            replacementsDictionary["$b_solutionfolder_layers_4_domain_1_core$"] = SolutionTemplate.B_SolutionFolder_Layers_4_Domain_1_Core;
            //1 Layers -> 1.4 Domain -> 1.4.2 MainModule
            replacementsDictionary["$b_solutionfolder_layers_4_domain_2_mainmodule$"] = SolutionTemplate.B_SolutionFolder_Layers_4_Domain_2_MainModule;
            //1 Layers -> 1.5 Infraestructure
            replacementsDictionary["$b_solutionfolder_layers_5_infraestructure$"] = SolutionTemplate.B_SolutionFolder_Layers_5_Infraestructure;
            //1 Layers -> 1.5 Infraestructure -> 1.5.1 Data
            replacementsDictionary["$b_solutionfolder_layers_5_infraestructure_1_data$"] = SolutionTemplate.B_SolutionFolder_Layers_5_Infraestructure_1_Data;
            //1 Layers -> 1.5 Infraestructure -> 1.5.2 Cross Cutting
            replacementsDictionary["$b_solutionfolder_layers_5_infraestructure_2_crosscutting$"] = SolutionTemplate.B_SolutionFolder_Layers_5_Infraestructure_2_CrossCutting;

            //2 Database
            replacementsDictionary["$c_solutionfolder_database$"] = SolutionTemplate.C_SolutionFolder_Database;

            //3 Solution Items
            replacementsDictionary["$d_solutionfolder_solutionitems$"] = SolutionTemplate.D_SolutionFolder_SolutionItems;
        }

        protected string GetCompleteProjectNameBySufix(string projectSufix)
        {
            return string.Concat(SafeProjectName, ".", projectSufix);
        }
    }
}
