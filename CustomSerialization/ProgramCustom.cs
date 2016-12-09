using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerialization
{
    class ProgramCustom
    {
        static void Main(string[] args)
        {
            workCustom execut = new workCustom();
            Console.WriteLine("Serialization process launched");
            execut.SaveSerialazable();
            Console.ReadKey();
            Console.WriteLine("Reading serialized objects");
            execut.LoadSerialazable();
            Console.WriteLine("End of serialization!");
            Console.ReadKey();
        }
    }
}
