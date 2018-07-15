using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    public class DirectedGraph<T> where T : IComparable<T>
    {
        public List<Vertex<T>> vertices = new List<Vertex<T>>();
        public DirectedGraph() { }
        public void AddEdge(Vertex<T> vertex1, Vertex<T> vertex2, double weight)
        {
            vertex1.weightedEdges.Add(new WeightedEdge<T>(vertex1, vertex2, weight));
            vertex2.weightedEdges.Add(new WeightedEdge<T>(vertex1, vertex2, weight));
            vertices.Add(vertex1);
            vertices.Add(vertex2);
        }
        public void RemoveEdge(Vertex<T> vertex1, Vertex<T> vertex2)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].item.CompareTo(vertex1.item) == 0)
                {
                    for (int j = 0; j < vertices[i].weightedEdges.Count; j++)
                    {
                        if (vertices[i].weightedEdges[j].startVertex == vertex1 && vertices[i].weightedEdges[j].endVertex == vertex2)
                        {
                            vertices[i].weightedEdges.RemoveAt(j);
                        }
                    }
                }
                if (vertices[i].item.CompareTo(vertex2.item) == 0)
                {
                    for (int j = 0; j < vertices[i].weightedEdges.Count; j++)
                    {
                        if (vertices[i].weightedEdges[j].startVertex == vertex1 && vertices[i].weightedEdges[j].endVertex == vertex2)
                        {
                            vertices[i].weightedEdges.RemoveAt(j);
                        }
                    }
                }
            }
        }
        public void DFS(Vertex<T> vertex)
        {
            Console.WriteLine(vertex.item);
            for (int i = 0; i < vertex.weightedEdges.Count; i++)
            {
                DFS(vertex.weightedEdges[i].endVertex);
            }
        }
        public void BFS(Vertex<T> vertex)
        {
            Console.WriteLine(vertex.item);
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = 0; j < vertices[i].weightedEdges.Count; j++)
                {
                    stack.Push(vertices[i]);
                }
            }
            Console.WriteLine(Convert.ToString(stack.Pop()));
        }
    }
}
