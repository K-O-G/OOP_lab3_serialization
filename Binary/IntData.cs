using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerialization
{
    class IntData
    {
        public void SaveInFile()
        {
            Console.WriteLine("Saving in file...");
            int[,] arr =    { { 1, 12, 3, 4, 50, 60, 7, 8 },
                              { 2, 13, 2, 3, 18, 20, 48, 6 },
                              { 3, 14, 3, 4, 8, 15, 17, 3 },
                              { 4, 15, 4, 5, 8, 9, 6, 34 },
                              { 5, 16, 5, 1, 18, 20, 4, 78 },
                              { 6, 17, 4, 3, 37, 15, 3, 4 },
                              { 7, 18, 5, 4, 48, 35, 74, 2 },
                              { 8, 34, 6, 5, 85, 34, 87, 3 } };
            try
            {
                string filename = "int.txt";
                FileStream stream = new FileStream(filename, FileMode.Truncate);
                string write_text = "";
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        write_text = write_text + arr[i, j] + "|";
                    }
                    write_text = write_text + "\\";
                }
                using (StreamWriter writer = new StreamWriter(stream, Encoding.Default))
                {
                    writer.Write(write_text);
                }
                Console.WriteLine("Saved");
            }
            catch
            {
                Console.WriteLine("Error saving!");
            }
        }
        public void ReadFromFile()
        {
            Console.WriteLine("Reading from file...");
            string str = "";
            try
            {
                StreamReader streamReader = new StreamReader("int.txt");
                while (!streamReader.EndOfStream)
                {
                    str += streamReader.ReadLine();
                }
                streamReader.Close();
                Console.WriteLine("Read successfully!");
            }
            catch
            {
                Console.WriteLine("Error reading from file");
            }
            try
            {
                Console.WriteLine("Parsing...");
                string[] split1;
                split1 = str.Split(new Char[] { '\\' });
                string[][] split = new string[split1.Length][];
                for (int i = 0; i < split1.Length; i++)
                {
                    split[i] = split1[i].Split(new Char[] { '|' });
                }
                for (int i = 0; i < split.Length; i++)
                {
                    for (int j = 0; j < split[i].Length; j++)
                    {

                        Console.Write("{0,4}", split[i][j]);
                    }
                    Console.WriteLine();
                }
            }
            catch { }
            Console.WriteLine();
        }
    }
}
