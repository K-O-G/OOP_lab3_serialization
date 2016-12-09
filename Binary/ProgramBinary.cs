using System;

namespace BinarySerialization
{
    class ProgramBinary
    {
        static void Main(string[] args)
        {

            work execut = new work();
            Console.WriteLine("Serialization process launched");
            execut.SaveSerialazable();
            Console.ReadKey();
            Console.WriteLine("Reading serialized objects");
            execut.LoadSerialazable();
            Console.WriteLine("End of serialization!");
            Console.ReadKey();
            Console.Clear();
            IntData ex = new IntData();
            Console.WriteLine("Stream worker");
            ex.SaveInFile();
            Console.WriteLine("File reading");
            ex.ReadFromFile();
            Console.ReadKey();
        }
    }
}
