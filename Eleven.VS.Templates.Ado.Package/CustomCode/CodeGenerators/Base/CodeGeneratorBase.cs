using Eleven.VS.Templates.Ado.Dsl;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Eleven.VS.Templates.Ado.Package.CodeGenerators.Base
{
    public abstract class CodeGeneratorBase
    {
        IServiceProvider serviceProvider;
        public IServiceProvider ServiceProvider
        {
            get { return serviceProvider; }
            set { serviceProvider = value; }
        }

        public CodeGeneratorBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public abstract void GenerateCodeFiles(DomainEntityModel domainEntityModel);

        public void GenerateCodeFilesInProject(string projectName, string folderName, string fileName, string extension, string buildAction, string fileContent, bool useAbsolutePath)
        {
            bool printTree = false;
            bool existFolder = false;
            StringBuilder stringProjectTree = new StringBuilder();

            DTE dte = ServiceProvider.GetService(typeof(DTE)) as DTE;
            Project targetProject = FindProjectInSolution(dte, projectName, printTree, ref stringProjectTree);

            if (targetProject != null)
            {
                object targetProjectIn = dte.Solution.FindProjectItem(targetProject.FullName) as object;

                ProjectItem projectItem;
                string folderPath = string.Empty;
                string fileGeneratedPath = string.Empty;

                if (string.IsNullOrEmpty(folderName))
                {
                    folderPath = Path.GetDirectoryName(targetProject.FullName);
                    fileGeneratedPath = Path.Combine(folderPath, string.Concat(fileName, extension));

                    File.WriteAllText(fileGeneratedPath, fileContent, Encoding.UTF8);
                    projectItem = targetProject.ProjectItems.AddFromFile(fileGeneratedPath);
                }
                else
                {
                    folderPath = string.Concat(Path.GetDirectoryName(targetProject.FullName), "\\", folderName).Trim();
                    fileGeneratedPath = Path.Combine(folderPath, string.Concat(fileName, extension));

                    if (Directory.Exists(folderPath))
                        existFolder = true;
                    else
                    {
                        existFolder = false;
                        Directory.CreateDirectory(folderPath);
                    }

                    ProjectItem projectItemFolder;
                    File.WriteAllText(fileGeneratedPath, fileContent, Encoding.UTF8);

                    if (useAbsolutePath)
                    {
                        projectItemFolder = targetProject.ProjectItems.AddFolder(folderPath);
                        projectItem = FindProjectItemInProjectItems(targetProject.ProjectItems, fileGeneratedPath);
                        if (projectItem == null)
                            projectItem = projectItemFolder.ProjectItems.AddFromFile(fileGeneratedPath);
                    }
                    else
                    {
                        projectItemFolder = FindFolderInProject(targetProject, folderName);
                        if (!existFolder && projectItemFolder == null)
                        {
                            projectItemFolder = targetProject.ProjectItems.AddFolder(folderName);
                            projectItem = FindProjectItemInProjectItems(targetProject.ProjectItems, fileGeneratedPath);
                            if (projectItem == null)
                                projectItem = projectItemFolder.ProjectItems.AddFromFile(fileGeneratedPath);
                        }
                        else
                        {
                            projectItem = FindProjectItemInProjectItems(targetProject.ProjectItems, fileGeneratedPath);
                            if (projectItem == null)
                                projectItem = targetProject.ProjectItems.AddFromFile(fileGeneratedPath);
                        }
                    }

                }

                if (!string.IsNullOrEmpty(buildAction))
                {
                    if (projectItem != null)
                        projectItem.Properties.Item("BuildAction").Value = buildAction;
                }
            }
        }

        private Project FindProjectInSolution(DTE dte, string projectName, bool printTree, ref StringBuilder stringProjectTree)
        {
            if (stringProjectTree == null)
                stringProjectTree = new StringBuilder();

            foreach (Project projectIn in dte.Solution.Projects)
            {
                string ident = "-> ";
                if (printTree)
                    stringProjectTree.AppendLine(string.Concat(ident, " ", projectIn.Name));

                if (projectIn.Name.CompareTo(projectName) == 0)
                    return projectIn;
                else
                {
                    ident = string.Concat("-", ident);
                    Project projectReturn = FindProjectInProject(projectIn, projectName, ident, printTree, ref stringProjectTree);
                    if (projectReturn != null)
                        if (projectReturn.Name.CompareTo(projectName) == 0)
                            return projectReturn;
                }
            }

            if (printTree)
                File.WriteAllText("D:/ProjectTree.txt", stringProjectTree.ToString());

            return null;
        }

        private Project FindProjectInProject(Project project, string projectName, string ident, bool printTree, ref StringBuilder stringProjectTree)
        {
            if (project.ProjectItems != null)
            {
                foreach (ProjectItem projectItem in project.ProjectItems)
                {
                    try
                    {
                        if (printTree)
                            stringProjectTree.AppendLine(string.Concat(ident, " ", projectItem.Name));

                        Project projectIn = projectItem.Object as Project;
                        if (projectIn.Name.CompareTo(projectName) == 0)
                            return projectIn;
                        else
                        {
                            ident = string.Concat("-", ident);
                            Project projectReturn = FindProjectInProject(projectIn, projectName, ident, printTree, ref stringProjectTree);
                            if (projectReturn != null)
                                if (projectReturn.Name.CompareTo(projectName) == 0)
                                    return projectReturn;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            return null;
        }

        private IList<Project> GetSolutionProjects(DTE2 dte2)
        {
            List<Project> projectsList = new List<Project>();
            Projects projects = dte2.Solution.Projects;

            var item = projects.GetEnumerator();
            while (item.MoveNext())
            {
                if (!(item.Current is Project project))
                    continue;
                if (project.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                    projectsList.AddRange(GetSolutionFolderProjects(project));
                else
                    projectsList.Add(project);
            }

            return projectsList;
        }

        public IEnumerable<Project> GetSolutionFolderProjects(Project solutionFolder)
        {
            List<Project> projectsList = new List<Project>();

            foreach (ProjectItem projectItem in solutionFolder.ProjectItems)
            {
                var subProject = projectItem.SubProject;
                if (subProject == null)
                    continue;
                if (subProject.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                    projectsList.AddRange(GetSolutionFolderProjects(subProject));
                else
                    projectsList.Add(subProject);
            }

            return projectsList;
        }

        public ProjectItem FindFolderInProject(Project project, string folderName)
        {
            foreach (ProjectItem projectItem in project.ProjectItems)
                if (projectItem.Name.CompareTo(folderName) == 0 && projectItem.Kind == EnvDTE.Constants.vsProjectItemKindPhysicalFolder)
                    return projectItem;

            return null;
        }

        public ProjectItem FindProjectItemInProjectItems(ProjectItems projectItems, string filePath)
        {
            ProjectItem projectItemReturn = null;

            if (projectItems != null)
            {
                string physicalFolder = string.Concat("{", VSConstants.GUID_ItemType_PhysicalFolder.ToString(), "}");

                foreach (ProjectItem projectItem in projectItems)
                {
                    if (projectItem.Kind.Equals(physicalFolder, StringComparison.OrdinalIgnoreCase))
                        projectItemReturn = FindProjectItemInProjectItems(projectItem.ProjectItems, filePath);
                    else
                    {
                        if (projectItem.Properties != null)
                            if (projectItem.Properties.Item("FullPath")?.Value.ToString() == filePath)
                                projectItemReturn = projectItem;
                    }

                    if (projectItemReturn != null)
                        break;
                }
            }

            return projectItemReturn;
        }
    }
}
