using System;
using System.Collections;
using System.Collections.Generic;

namespace SOAP
{
    [Serializable]
    class Collection : IEnumerable
    {
        public List<Product> innerList;
        public Collection()
        {
            innerList = new List<Product>();
        }

        public void Add(Product arg)
        {
            innerList.Add(arg);
        }

        public void AddAll(Product[] arg)
        {
            foreach (Product a in arg)
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
        public IEnumerator<Product> GetEnumerator()
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
