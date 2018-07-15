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
        private double weight;
        public WeightedEdge(Vertex<T> StartVertex, Vertex<T> EndVertex, double Weight)
        {
            startVertex = StartVertex;
            endVertex = EndVertex;
            weight = Weight;
        }
    }
}
