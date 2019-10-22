using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace csharp_compiler
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string DoCompilation(string code, string name)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            ICodeCompiler compiler = provider.CreateCompiler();
            CompilerParameters parameters = new CompilerParameters();
            parameters.OutputAssembly = @name;
            parameters.GenerateExecutable = true;
            CompilerResults results = compiler.CompileAssemblyFromSource(parameters, code);
            System.Threading.Thread.Sleep(10000);

            if (results.Output.Count == 0)
            {
                return "success";
            }
            else
            {
                CompilerErrorCollection CErros = results.Errors;
                foreach (CompilerError err in CErros)
                {
                    string msg = string.Format("Erro:{0} on line{1} file name:{2}", err.Line, err.ErrorText, err.FileName);

                    return msg;
                }
            }
            return "not working";
        }

        public string DoExecute(string filename)
        {
            // ProcessStartInfo pi = filename;
            try
            {
                ProcessStartInfo start = new ProcessStartInfo();

                start.Arguments = null;

                start.FileName = filename;

                int exitCode;

                using (Process proc = Process.Start(start))
                {
                }
                return "success";
            }
            catch (Exception e) { return e.ToString(); }
        }
    }
}