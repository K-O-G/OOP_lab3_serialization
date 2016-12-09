using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace JSON
{
    class workJSON
    {
        public void SaveSerialazable()
        {
            CollectionJSON collection = new CollectionJSON();
            collection.Add(new ProductJSON(8, "Chocolate", "Roshen", 20, 2000));
            collection.Add(new ProductJSON(1, "Noodles", "FineFood", 25, 3100));
            collection.Add(new ProductJSON(10, "Sausages", "Yatran", 50, 1000));
            collection.Add(new ProductJSON(5, "Cheese", "Como", 50, 84000));
            collection.Add(new ProductJSON(3, "Wine", "Shabo", 80, 500));

            Console.WriteLine("Unsorted elements:");
            foreach (ProductJSON serial_unsort in collection)
            {
                //code,name,serial,producer,price,amount
                Console.WriteLine(serial_unsort.code + " " + serial_unsort.name + " " + serial_unsort.producer + " " + serial_unsort.price + " " + serial_unsort.amount);
            }

            CompareClasse Compare = new CompareClasse();
            collection.Sort();
            Console.WriteLine("Sorted elements:");
            foreach (ProductJSON serial_sorted in collection)
            {
                //code,name,serial,producer,price,amount
                Console.WriteLine(serial_sorted.code + " " + serial_sorted.name + " " + serial_sorted.producer + " " + serial_sorted.price + " " + serial_sorted.amount);
            }
            

            try
            {
                using (Stream stream = File.Open("data.json", FileMode.Create))
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(CollectionJSON));
                   jsonFormatter.WriteObject(stream, collection);
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
            CollectionJSON serial_read = new CollectionJSON();
            try
            {
                using (FileStream stream = new FileStream("data.json", FileMode.Open))
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(CollectionJSON));
                    serial_read = (CollectionJSON)jsonFormatter.ReadObject(stream);
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
            foreach (ProductJSON serial in serial_read)
            {
                totalPrice = totalPrice + (serial.amount*serial.price);
                serial.price = serial.price + ((percent * serial.price) / 100);

            }
            Console.WriteLine("Total price of the batch: {0}", totalPrice);
            Console.WriteLine("Outputing all data... All sorted elements:");
            Console.WriteLine("{0,4}{1,10}{2,10}{3,6}{4,7}","Code","Name","Producer","Price","Amount");
            foreach (ProductJSON serial in serial_read)
            {
                //code,name,serial,producer,price,amount
                Console.WriteLine("{0,4}{1,10}{2,10}{3,6}{4,7}", serial.code, serial.name, serial.producer, serial.price, serial.amount);
            }
        }
    }
}
