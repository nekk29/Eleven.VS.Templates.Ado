using Eleven.VS.Templates.Ado.Dsl.CustomCode.DomainTypes.Base;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Modeling;
using System;
using System.Collections.Generic;

namespace Eleven.VS.Templates.Ado.Dsl.CustomCode.DomainTypes
{
    public class ProjectImplementation_TypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            Store store = GetStore(context.Instance);
            DTE dte = store.GetService(typeof(DTE)) as DTE;

            values = AddProjectToTypeConverterList(dte, values);

            return new StandardValuesCollection(values);
        }

        private List<string> AddProjectToTypeConverterList(DTE solution, List<string> values)
        {
            foreach (Project project in solution.Solution.Projects)
            {
                try
                {
                    if (project.Object is SolutionFolder solutionFolder)
                        AddProjectToTypeConverterList(project, values);
                    else
                        values.Add(project.Name);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return values;
        }

        private List<string> AddProjectToTypeConverterList(Project project, List<string> values)
        {
            if (project.ProjectItems != null)
            {
                foreach (ProjectItem projectItem in project.ProjectItems)
                {
                    try
                    {
                        Project projectIn = projectItem.Object as Project;

                        if (projectIn.Object is SolutionFolder solutionFolder)
                            AddProjectToTypeConverterList(projectIn, values);
                        else
                            values.Add(projectIn.Name);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            return values;
        }
    }
}
