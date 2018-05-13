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
        public void RemoveEdge()
        {

        }
        public void DFS()
        {

        }
        public void BFS()
        {

        }
    }
}
