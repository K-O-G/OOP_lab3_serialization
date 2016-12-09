using System;
using System.Collections;
using System.Collections.Generic;

namespace XML
{
    [Serializable]
    public class CollectionXML : IEnumerable
    {
        public List<ProductXML> innerList;
        public CollectionXML()
        {
            innerList = new List<ProductXML>();
        }

        public void Add(ProductXML arg)
        {
            innerList.Add(arg);
        }

        public void AddAll(ProductXML[] arg)
        {
            foreach (ProductXML a in arg)
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
        public IEnumerator<ProductXML> GetEnumerator()
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
