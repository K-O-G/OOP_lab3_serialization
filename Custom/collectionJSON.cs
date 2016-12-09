using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JSON
{
    [DataContract]
    class CollectionJSON : IEnumerable
    {
        [DataMember]
        public List<ProductJSON> innerList;
        public CollectionJSON()
        {
            innerList = new List<ProductJSON>();
        }

        public void Add(ProductJSON arg)
        {
            innerList.Add(arg);
        }
        public void RemoveAt(int index)
        {
            if (innerList.Count <= index)
                throw new IndexOutOfRangeException("Error!");
            else
                innerList.RemoveAt(index);
        }
        public IEnumerator<ProductJSON> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
        internal void Sort()
        {
            CompareClasse Comp = new CompareClasse();
            innerList.Sort(Comp);
        }
    }
}
