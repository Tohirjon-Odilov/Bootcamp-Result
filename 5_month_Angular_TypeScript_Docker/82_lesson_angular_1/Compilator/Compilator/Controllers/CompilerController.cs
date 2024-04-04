using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.IO;
using System.Reflection;

namespace Compiler.Controllers
{
    public class CompilerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Compile(string code)
        {
            try
            {
                SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

                string assemblyName = Path.GetRandomFileName();
                MetadataReference[] references = {
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Console).Assembly.Location)
                };

                CSharpCompilation compilation = CSharpCompilation.Create(
                    assemblyName,
                    syntaxTrees: new[] { syntaxTree },
                    references: references,
                    options: new CSharpCompilationOptions(OutputKind.ConsoleApplication)
                );

                using (var ms = new MemoryStream())
                {
                    var result = compilation.Emit(ms);

                    if (!result.Success)
                    {
                        ViewBag.Result = "Compilation failed:";
                        foreach (var diagnostic in result.Diagnostics)
                        {
                            ViewBag.Result += $"{Environment.NewLine}{diagnostic}";
                        }
                    }
                    else
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        Assembly assembly = Assembly.Load(ms.ToArray());
                        MethodInfo entryPoint = assembly.EntryPoint;
                        object obj = assembly.CreateInstance(entryPoint.Name);
                        entryPoint.Invoke(obj, null);
                        ViewBag.Result = "Compilation succeeded";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Result = $"Error: {ex.Message}";
            }

            return View("Index");
        }
    }
}
