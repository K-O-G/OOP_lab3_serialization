using System;

namespace JSON
{
    class ProgramJSON
    {
        static void Main(string[] args)
        {
            workJSON execut = new workJSON();
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
