﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Eleven.VS.Templates.Ado.Package.CustomCode.TextTemplates.Domain
{
    using Eleven.VS.Templates.Ado.Package.TextTemplates.Helper;
    using Eleven.VS.Templates.Ado.Dsl.Util;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\Domain\CodeGeneratorDomainEntityCollection.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class CodeGeneratorDomainEntityCollection : Eleven.VS.Templates.Ado.Dsl.Util.CodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("namespace ");
            
            #line 8 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\Domain\CodeGeneratorDomainEntityCollection.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.DomainEntityCollection.DomainEntityModel.ProjectImplementationEntity));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 10 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\Domain\CodeGeneratorDomainEntityCollection.tt"

PushIndent("    ");

            
            #line default
            #line hidden
            
            #line 13 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\Domain\CodeGeneratorDomainEntityCollection.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainEntityCollection.AccessModifier));
            
            #line default
            #line hidden
            this.Write(" partial class ");
            
            #line 13 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\Domain\CodeGeneratorDomainEntityCollection.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DomainEntityCollection.Name));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 13 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\Domain\CodeGeneratorDomainEntityCollection.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TemplateHelperCommon.Get_StringType(DomainEntityCollection)));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 15 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\Domain\CodeGeneratorDomainEntityCollection.tt"

	PushIndent("    ");

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 19 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\Domain\CodeGeneratorDomainEntityCollection.tt"

	PopIndent();

            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 23 "D:\Projects\Eleven.VS.Templates.Ado\Eleven.VS.Templates.Ado.Package\CustomCode\TextTemplates\Domain\CodeGeneratorDomainEntityCollection.tt"

	PopIndent();

            
            #line default
            #line hidden
            this.Write("}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}