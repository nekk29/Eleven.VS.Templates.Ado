using EnvDTE;
using EnvDTE80;
using System.Collections.Generic;

namespace Eleven.VS.Templates.Ado.Wizard.Utils
{
    public static class SolutionUtils
    {
        public static IList<Project> GetAllProjectsInSolution(Solution2 solution2)
        {
            List<Project> list = new List<Project>();

            var projects = solution2.Projects;
            var item = projects.GetEnumerator();

            while (item.MoveNext())
            {
                var project = item.Current as Project;

                if (project == null)
                    continue;

                if (project.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                    list.AddRange(GetAllProjectsInSolutionFolder(project));
                else
                    list.Add(project);
            }

            return list;
        }

        private static IEnumerable<Project> GetAllProjectsInSolutionFolder(Project solutionFolder)
        {
            List<Project> list = new List<Project>();
            for (var i = 1; i <= solutionFolder.ProjectItems.Count; i++)
            {
                var subProject = solutionFolder.ProjectItems.Item(i).SubProject;

                if (subProject == null)
                    continue;

                if (subProject.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                    list.AddRange(GetAllProjectsInSolutionFolder(subProject));
                else
                    list.Add(subProject);
            }
            return list;
        }
    }
}
