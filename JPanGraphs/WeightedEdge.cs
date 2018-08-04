using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    public class WeightedEdge<T> where T : IComparable<T>
    {
        public DVertex<T> startVertex;
        public DVertex<T> endVertex;
        public float weight;
        public WeightedEdge(DVertex<T> StartVertex, DVertex<T> EndVertex, float Weight)
        {
            startVertex = StartVertex;
            endVertex = EndVertex;
            weight = Weight;
        }
    }
}
