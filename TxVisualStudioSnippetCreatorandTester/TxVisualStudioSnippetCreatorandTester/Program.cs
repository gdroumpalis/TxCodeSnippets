using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxVisualStudioSnippetCreatorandTester
{

    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine(methodname(5,6)); 
            Console.ReadKey();
        }
        public static string Test()
        {
            return "tetststs";
        }
        public static string methodname(int x, int y)
        {
            return $"{x}+{y}";
        }

    }

    


}
