using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomSerialization
{
    [Serializable]
    class CollectionBinary : IEnumerable
    {
        public List<ProductCustom> innerList;
        public CollectionBinary()
        {
            innerList = new List<ProductCustom>();
        }

        public void Add(ProductCustom arg)
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
        public IEnumerator<ProductCustom> GetEnumerator()
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
