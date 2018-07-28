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
            if (!(vertices.Contains(vertex1)))
            {
                vertices.Add(vertex1);
            }
            if (!(vertices.Contains(vertex2)))
            {
                vertices.Add(vertex2);
            }
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
        public void DFS(Vertex<T> vertex, double weight)
        {
            Console.WriteLine(vertex.item + " " + weight);
            vertex.Visited = true;
            for (int i = 0; i < vertex.weightedEdges.Count; i++)
            {
                if (vertex.weightedEdges[i].endVertex.Visited == false)
                {
                    weight += vertex.weightedEdges[i].weight;
                    DFS(vertex.weightedEdges[i].endVertex, weight);
                }
            }
        }
        public void BFS(Vertex<T> vertex)
        {
            double totalWeight = 0;
            Console.WriteLine(vertex.item);
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = 0; j < vertices[i].weightedEdges.Count; j++)
                {
                    if (vertices[i].weightedEdges[j].endVertex.Visited == false)
                    {
                        vertices[i].weightedEdges[j].endVertex.Visited = true;
                        totalWeight += vertices[i].weightedEdges[j].weight;
                        queue.Enqueue(vertices[i].weightedEdges[j].endVertex);
                    }
                }
            }
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue().item);
            }
            Console.WriteLine("Total weight: " + totalWeight);
        }
    }
}
