using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    public class WeightedEdge<T> where T : IComparable<T>
    {
        public Vertex<T> startVertex;
        public Vertex<T> endVertex;
        public float weight;
        public WeightedEdge(Vertex<T> StartVertex, Vertex<T> EndVertex, float Weight)
        {
            startVertex = StartVertex;
            endVertex = EndVertex;
            weight = Weight;
        }
    }
}
