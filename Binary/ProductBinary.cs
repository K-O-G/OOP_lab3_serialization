using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BinarySerialization
{
    [Serializable]
    class Product
    {
        public int code { get; set; }
        public string name { get; set; }
        public string producer { get; set; }
        public int price { get; set; }
        public int amount { get; set; }

        public Product(int code, string name, string producer, int price, int amount)
        {
            this.code = code;
            this.name = name;
            this.producer = producer;
            this.price = price;
            this.amount = amount;
        }

        
    }
    class CompareClasse : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return ((new CaseInsensitiveComparer()).Compare(x.code, y.code));
        }
    }
}
