﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Eleven.VS.Templates.Ado.Package.CustomCode.TextTemplates.CrossCutting
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\CrossCutting\CodeGeneratorCrossCuttingHelper.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class CodeGeneratorCrossCuttingHelper : Eleven.VS.Templates.Ado.Dsl.Util.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\n\r\nnamespace ");
            
            #line 7 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\CrossCutting\CodeGeneratorCrossCuttingHelper.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.DomainEntityModel.ProjectImplementationDataAccessCore));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 9 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\CrossCutting\CodeGeneratorCrossCuttingHelper.tt"
 PushIndent("    "); 
            
            #line default
            #line hidden
            this.Write(@"public static class DataUtil
{
    public static Nullable<T> DbValueToNullable<T>(object dbValue) where T : struct
    {
        Nullable<T> returnValue = null;

        if ((dbValue != null) && (dbValue != DBNull.Value))
        {
            returnValue = (T)dbValue;
        }

        return returnValue;
    }

    public static T DbValueToDefault<T>(object obj)
    {
        if (obj == null || obj == DBNull.Value) return default(T);
        else { return (T)obj; }
    }
}
");
            
            #line 30 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\CrossCutting\CodeGeneratorCrossCuttingHelper.tt"
 PopIndent(); 
            
            #line default
            #line hidden
            this.Write("}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}