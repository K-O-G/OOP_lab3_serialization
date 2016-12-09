using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CustomSerialization
{
    [Serializable]
    class ProductCustom : ISerializable
    {
        public int code { get; set; }
        public string name { get; set; }
        public string producer { get; set; }
        public int price { get; set; }
        public int amount { get; set; }

        public ProductCustom(int code, string name, string producer, int price, int amount)
        {
            this.code = code;
            this.name = name;
            this.producer = producer;
            this.price = price;
            this.amount = amount;
        }
        private ProductCustom(SerializationInfo info, StreamingContext context)
        {
            code = (int)info.GetValue("Code", typeof(int));
            name = (string)info.GetValue("Name", typeof(string));
            producer = (string)info.GetValue("Producer", typeof(string));
            price = (int)info.GetValue("Price", typeof(int));
            amount = (int)info.GetValue("Amount", typeof(int));
        }


        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Code", code, typeof(int));
            info.AddValue("Name", name, typeof(string));
            info.AddValue("Producer", producer, typeof(string));
            info.AddValue("Price", price, typeof(int));
            info.AddValue("Amount", amount, typeof(int));
        }
    }
    class CompareClasse : IComparer<ProductCustom>
    {
        public int Compare(ProductCustom x, ProductCustom y)
        {
            return ((new CaseInsensitiveComparer()).Compare(x.code, y.code));
        }
    }
}
