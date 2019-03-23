#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle(@"")]
[assembly: AssemblyDescription(@"")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(@"Eleven")]
[assembly: AssemblyProduct(@"Eleven Entity Model")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Resources.NeutralResourcesLanguage("en")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion(@"1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]

//
// Make the Dsl project internally visible to the Eleven.VS.Templates.Ado.Package assembly
//
[assembly: InternalsVisibleTo(@"Eleven.VS.Templates.Ado.Package, PublicKey=0024000004800000940000000602000000240000525341310004000001000100BDE66F7E32354B75F97A04BC45424A11806F2814298C8F2EE39D6F1F4FCAA5CBBAF36585E0D6DDB2583F10390EC7112ED4AC8D2F2A38EC64F106AE90494CD206D7DCC86FEBA04145C2B93714159910B19CDAF1E4E41DEA3020FF3B1AA93601A00F29E66FEBEB7C8ED8D0E6D94B5C7A2CCE26D2B8F926B80A26ADAEDDF0747AC0")]