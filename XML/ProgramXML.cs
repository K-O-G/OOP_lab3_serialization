using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    class ProgramXML
    {
        static void Main(string[] args)
        {
            workXML execut = new workXML();
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
