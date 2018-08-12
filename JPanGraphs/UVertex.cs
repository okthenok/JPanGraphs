using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    public class UVertex<T> where T : IComparable<T>
    {
        public T item;
        public float x;
        public float y;
        public bool Visited { get; set; }
        public float distance;
        public float finalDistance;
        public UVertex<T> founder;
        public UVertex(T value)
        {
            item = value;
        }
        public UVertex(float xvalue, float yvalue)
        {
            x = xvalue;
            y = yvalue;
        }
        public List<UWeightedEdge<T>> weightedEdges = new List<UWeightedEdge<T>>();
    }
}
