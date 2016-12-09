using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace JSON
{
    [DataContract]
    public class ProductJSON
    {
        [DataMember]
        public int code { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string producer { get; set; }
        [DataMember]
        public int price { get; set; }
        [DataMember]
        public int amount { get; set; }

        public ProductJSON(int code, string name, string producer, int price, int amount)
        {
            this.code = code;
            this.name = name;
            this.producer = producer;
            this.price = price;
            this.amount = amount;
        }
        public ProductJSON(SerializationInfo info, StreamingContext context)
        {
            code = (int)info.GetValue("Code", typeof(int));
            name = (string)info.GetValue("Name", typeof(string));
            producer = (string)info.GetValue("Producer", typeof(string));
            price = (int)info.GetValue("Price", typeof(int));
            amount = (int)info.GetValue("Amount", typeof(int));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Code", code, typeof(int));
            info.AddValue("Name", name, typeof(string));
            info.AddValue("Producer", producer, typeof(string));
            info.AddValue("Price", price, typeof(int));
            info.AddValue("Amount", amount, typeof(int));
        }
        
    }
    class CompareClasse : IComparer<ProductJSON>
    {
        public int Compare(ProductJSON x, ProductJSON y)
        {
            return ((new CaseInsensitiveComparer()).Compare(x.code, y.code));
        }
    }
}
