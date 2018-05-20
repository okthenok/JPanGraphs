using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    public class UndirectedGraph<T> where T : IComparable<T>
    {
        public UndirectedGraph()
        { }
        public List<Vertex<T>> vertices = new List<Vertex<T>>();
        public void AddVertex(T value)
        {
            Vertex<T> vertex = new Vertex<T>(value);
            vertices.Add(vertex);
        }
        public void RemoveVertex(T value)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].item.CompareTo(value) == 0)
                {
                    for (int j = 0; j < vertices[i].connections.Count; j++)
                    {
                        vertices[i].connections[j].connections.Remove(vertices[i]);
                    }
                }
            }
        }
        public void AddEdge(Vertex<T> vertex, Vertex<T> vertex2)
        {
            vertex.connections.Add(vertex2);
            vertex2.connections.Add(vertex);
        }
        public void RemoveEdge(Vertex<T> vertex, Vertex<T> vertex2)
        {
            vertex.connections.Remove(vertex2);
            vertex2.connections.Remove(vertex);
        }
        public void DFS(Vertex<T> start, Stack<Vertex<T>> path)
        {
            for (int i = 0; i < start.connections.Count; i++)
            {
                if (start.connections[i].Visited != true)
                {
                    DFS(start.connections[i], path);
                    path.Push(start.connections[i]);
                    start.connections[i].Visited = true;
                }
            }
        }
        public void BFS(Vertex<T> start)
        {
            Queue<Vertex<T>> nodes = new Queue<Vertex<T>>();
            nodes.Enqueue(start);
            while (nodes.Count != 0)
            {
                var node = nodes.Dequeue();
                for (int i = 0; i < node.connections.Count; i++)
                {
                    if (node.connections[i] != null && node.Visited != true)
                    {
                        nodes.Enqueue(node.connections[i]);
                        node.connections[i].Visited = true;
                    }
                }
            }
        }
    }
}
