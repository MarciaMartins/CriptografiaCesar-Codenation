using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptografiaCesar
{
    class Program
    {
        static void Main(string[] args)
        {
            CesarCypher cesar = new CesarCypher();
            cesar.Crypt("ZA MARCIA198 ");
            cesar.Decrypt("cd pdufld198");
            Console.ReadLine();
        }
    }
}
