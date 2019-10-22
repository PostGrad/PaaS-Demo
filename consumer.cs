using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using consumer_compile.ServiceReference1;

namespace consumer_compile
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            Console.WriteLine("Enter absolute name of the output file i.e.: D:\test.exe  :");
            string compile_str = Console.ReadLine();
            s.DoCompilation("class test{ public static void Main(){System.Console.WriteLine(\"hello from remote code\");System.Console.Read();} }", compile_str);
            string output = s.DoExecute(compile_str);
            Console.WriteLine(output);
            Console.Read();
        }
    }
}