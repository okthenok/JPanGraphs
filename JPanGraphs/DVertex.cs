using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    public class DVertex<T> where T : IComparable<T>
    {
        public T item;
        public float x;
        public float y;
        public bool Visited { get; set; }
        public float distance;
        public float finalDistance;
        public DVertex<T> founder;

        public DVertex(T value)
        {
            item = value;
        }
        public DVertex(float xvalue, float yvalue)
        {
            x = xvalue;
            y = yvalue;
        }
        //public List<Vertex<T>> connections = new List<Vertex<T>>();
        public List<WeightedEdge<T>> weightedEdges = new List<WeightedEdge<T>>();
    }
}
