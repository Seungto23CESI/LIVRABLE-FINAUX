using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using middleware;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Class_CAD obj = new Class_CAD();
            Class_middleware mid = new Class_middleware();

            string test = obj.get_cnx();
            System.Console.WriteLine(test);

            
            System.Console.ReadLine();
        }
    }
}
