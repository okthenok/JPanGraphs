using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    public class UVertex<T> where T : ICollection<T>
    {
        public T item;
        public UVertex(T value)
        {
            item = value;
        }
    }
}
