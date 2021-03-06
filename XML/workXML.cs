﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace XML
{
    class workXML
    {
        public void SaveSerialazable()
        {
            CollectionXML collection = new CollectionXML();
            collection.Add(new ProductXML(8, "Chocolate", "Roshen", 20, 2000));
            collection.Add(new ProductXML(1, "Noodles", "FineFood", 25, 3100));
            collection.Add(new ProductXML(10, "Sausages", "Yatran", 50, 1000));
            collection.Add(new ProductXML(5, "Cheese", "Como", 50, 84000));
            collection.Add(new ProductXML(3, "Wine", "Shabo", 80, 500));

            Console.WriteLine("Unsorted elements:");
            foreach (ProductXML serial_unsort in collection)
            {
                //code,name,serial,producer,price,amount
                Console.WriteLine(serial_unsort.code + " " + serial_unsort.name + " " + serial_unsort.producer + " " + serial_unsort.price + " " + serial_unsort.amount);
            }

            CompareClasse Compare = new CompareClasse();
            collection.Sort();
            Console.WriteLine("Sorted elements:");
            foreach (ProductXML serial_sorted in collection)
            {
                //code,name,serial,producer,price,amount
                Console.WriteLine(serial_sorted.code + " " + serial_sorted.name + " " + serial_sorted.producer + " " + serial_sorted.price + " " + serial_sorted.amount);
            }
            

            try
            {
                using (Stream stream = File.Open("data.xml", FileMode.Create))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(CollectionXML));
                    XML.Serialize(stream, collection);
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
            CollectionXML serial_read = new CollectionXML();
            try
            {
                using (Stream stream = File.Open("data.xml", FileMode.Open))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(CollectionXML));
                    serial_read = (CollectionXML)XML.Deserialize(stream);
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
            foreach (ProductXML serial in serial_read)
            {
                totalPrice = totalPrice + (serial.amount*serial.price);
                serial.price = serial.price + ((percent * serial.price) / 100);

            }
            Console.WriteLine("Total price of the batch: {0}", totalPrice);
            Console.WriteLine("Outputing all data... All sorted elements:");
            Console.WriteLine("{0,4}{1,10}{2,10}{3,6}{4,7}","Code","Name","Producer","Price","Amount");
            foreach (ProductXML serial in serial_read)
            {
                //code,name,serial,producer,price,amount
                Console.WriteLine("{0,4}{1,10}{2,10}{3,6}{4,7}", serial.code, serial.name, serial.producer, serial.price, serial.amount);
            }
        }
    }
}
