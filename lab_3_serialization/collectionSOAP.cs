using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Soap;

namespace SOAP
{
    [Serializable]
    class Collection : IEnumerable
    {
        public List<ProductSOAP> innerList;
        public Collection()
        {
            innerList = new List<ProductSOAP>();
        }

        public void Add(ProductSOAP arg)
        {
            innerList.Add(arg);
        }

        public void AddAll(ProductSOAP[] arg)
        {
            foreach (ProductSOAP a in arg)
            {
                innerList.Add(a);
            }
        }


        public void RemoveAt(int index)
        {
            if (innerList.Count <= index)
                throw new IndexOutOfRangeException("Error!");
            else
                innerList.RemoveAt(index);
        }
        public IEnumerator<ProductSOAP> GetEnumerator()
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
