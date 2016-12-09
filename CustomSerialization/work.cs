using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomSerialization
{
    class work
    {
        public void SaveSerialazable()
        {
            Collection collection = new Collection();
            collection.Add(new Product(8, "Chocolate", "Roshen", 20, 2000));
            collection.Add(new Product(1, "Noodles", "FineFood", 25, 3100));
            collection.Add(new Product(10, "Sausages", "Yatran", 50, 1000));
            collection.Add(new Product(5, "Cheese", "Como", 50, 84000));
            collection.Add(new Product(3, "Wine", "Shabo", 80, 500));

            Console.WriteLine("Unsorted elements:");
            foreach (Product serial_unsort in collection)
            {
                //code,name,serial,producer,price,amount
                Console.WriteLine(serial_unsort.code + " " + serial_unsort.name + " " + serial_unsort.producer + " " + serial_unsort.price + " " + serial_unsort.amount);
            }

            CompareClasse Compare = new CompareClasse();
            collection.Sort();
            Console.WriteLine("Sorted elements:");
            foreach (Product serial_sorted in collection)
            {
                //code,name,serial,producer,price,amount
                Console.WriteLine(serial_sorted.code + " " + serial_sorted.name + " " + serial_sorted.producer + " " + serial_sorted.price + " " + serial_sorted.amount);
            }
            

            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, collection);
                }
                Console.WriteLine("Writed successful...");
            }
            catch (IOException)
            {
                Console.WriteLine("Error saving!");
            }

        }

        public void LoadSerialazable()
        {
            Collection serial_read = new Collection();
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    serial_read = (Collection)bin.Deserialize(stream);
                }
                Console.WriteLine("Reading successfully!");
            }
            catch (IOException)
            {
                Console.WriteLine("Error loading!");
            }

            //Total price of the batch;
            //certain percent price increasing;
            //output the information about the product;
            int totalPrice = 0,percent=0;
            Console.WriteLine("At what percentage increase the price?");
            percent=Convert.ToInt16(Console.ReadLine());
            foreach (Product serial in serial_read)
            {
                totalPrice = totalPrice + (serial.amount*serial.price);
                serial.price = serial.price + ((percent * serial.price) / 100);

            }
            Console.WriteLine("Total price of the batch: {0}", totalPrice);
            Console.WriteLine("Outputing all data... All sorted elements:");
            Console.WriteLine("{0,4}{1,10}{2,10}{3,6}{4,7}","Code","Name","Producer","Price","Amount");
            foreach (Product serial in serial_read)
            {
                //code,name,serial,producer,price,amount
                Console.WriteLine("{0,4}{1,10}{2,10}{3,6}{4,7}", serial.code, serial.name, serial.producer, serial.price, serial.amount);
            }
        }
    }
}
