using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    public class UWeightedEdge<T> where T : IComparable<T>
    {
        public UVertex<T> startVertex;
        public UVertex<T> endVertex;
        public float weight;
        public UWeightedEdge(UVertex<T> StartVertex, UVertex<T> EndVertex, float Weight)
        {
            startVertex = StartVertex;
            endVertex = EndVertex;
            weight = Weight;
        }
    }
}
