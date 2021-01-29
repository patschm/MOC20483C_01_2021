using System.CodeDom;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;


namespace GenerateProgram
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            CodeCompileUnit cu = new CodeCompileUnit();
            CodeNamespaceImport system = new CodeNamespaceImport("System");
           
            CodeNamespace ns = new CodeNamespace("Custom");
            ns.Imports.Add(system);
            cu.Namespaces.Add(ns);

            CodeTypeDeclaration prog = new CodeTypeDeclaration("Program");
            ns.Types.Add(prog);

            CodeEntryPointMethod main = new CodeEntryPointMethod();
            prog.Members.Add(main);

            CodeTypeReferenceExpression console = new CodeTypeReferenceExpression("Console");
            CodeMethodInvokeExpression wl =
                new CodeMethodInvokeExpression(console, "WriteLine",
                new CodePrimitiveExpression("Hello World"));
            main.Statements.Add(wl);
            CodeMethodInvokeExpression rl = new CodeMethodInvokeExpression(console, "ReadLine");
            main.Statements.Add(rl);


            CSharpCodeProvider prov = new CSharpCodeProvider();
            using (StreamWriter wrt = new StreamWriter("E:\\Custom.cs")) 
            {
                prov.GenerateCodeFromCompileUnit(cu, wrt, new CodeGeneratorOptions { BlankLinesBetweenMembers = true });
            }


            CompilerParameters pars = new CompilerParameters
            {
                GenerateExecutable = true,
                OutputAssembly = "Custom.exe"
            };
            //pars.ReferencedAssemblies.Add("System.dll");
            var errors = prov.CompileAssemblyFromDom(pars, cu);
            foreach(var error in errors.Errors)
            {
                Console.WriteLine(error);
            }


            Console.WriteLine("Done");
        }
    }
}
