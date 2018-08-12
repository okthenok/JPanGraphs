using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    public class UndirectedGraph<T> where T : IComparable<T>
    {
        List<UVertex<T>> vertices = new List<UVertex<T>>();
        public UndirectedGraph() { }
        public void AddVertex(UVertex<T> vertex)
        {
            vertices.Add(vertex);
        }
        public void RemoveVertex(UVertex<T> vertex)
        {
            vertices.Remove(vertex);
            for (int i = 0; i < vertex.weightedEdges.Count; i++)
            {
                for (int j = 0; j < vertex.weightedEdges[i].endVertex.weightedEdges.Count; j++)
                {
                    vertex.weightedEdges[i].endVertex.weightedEdges[j].endVertex = null;
                    vertex.weightedEdges[i].endVertex = null;
                }
            }
        }
        public void AddEdge(UVertex<T> vertex1, UVertex<T> vertex2, float weight)
        {
            vertex1.weightedEdges.Add(new UWeightedEdge<T>(vertex1, vertex2, weight));
            vertex2.weightedEdges.Add(new UWeightedEdge<T>(vertex1, vertex2, weight));
            if (!(vertices.Contains(vertex1)))
            {
                vertices.Add(vertex1);
            }
            if (!(vertices.Contains(vertex2)))
            {
                vertices.Add(vertex2);
            }
        }
        public void RemoveEdge(UVertex<T> vertex1, UVertex<T> vertex2)
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
        public IEnumerable<UVertex<T>> AStar(UVertex<T> startVertex, UVertex<T> endVertex)
        {
            Queue<UVertex<T>> priorityQueue = new Queue<UVertex<T>>();
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].distance = float.PositiveInfinity;
                vertices[i].finalDistance = float.PositiveInfinity;
                vertices[i].Visited = false;
                vertices[i].founder = null;
            }
            startVertex.distance = 0;
            startVertex.finalDistance = Mathattan(startVertex, endVertex);
            priorityQueue.Enqueue(startVertex);

            while (priorityQueue.Count > 0)
            {
                var current = priorityQueue.Dequeue();
                current.Visited = true;

                if (current == endVertex)
                {
                    break;
                }

                for (int i = 0; i < current.weightedEdges.Count; i++)
                {
                    var neighbor = current.weightedEdges[i].endVertex;

                    float tentativeDistance = current.distance + current.weightedEdges[i].weight;
                    if (tentativeDistance < neighbor.distance)
                    {
                        neighbor.distance = tentativeDistance;
                        neighbor.founder = current;
                        neighbor.Visited = false;
                        neighbor.finalDistance = neighbor.distance + Mathattan(neighbor, endVertex);
                    }

                    if (!neighbor.Visited && !priorityQueue.Contains(neighbor))
                    {
                        priorityQueue.Enqueue(neighbor);
                    }
                }
            }

            //stack and add end
            Stack<UVertex<T>> path = new Stack<UVertex<T>>();
            var curr = endVertex;
            while (curr.founder != null)
            {
                path.Push(curr);
                curr = curr.founder;
            }
            path.Push(startVertex);

            return path;
        }
        private float Mathattan(UVertex<T> vertex, UVertex<T> endVertex)
        {
            float dx = Math.Abs(vertex.x - endVertex.x);
            float dy = Math.Abs(vertex.y - endVertex.y);
            float D = float.PositiveInfinity;
            for (int i = 0; i < vertex.weightedEdges.Count; i++)
            {
                if (vertex.weightedEdges[i].weight < D)
                {
                    D = vertex.weightedEdges[i].weight;
                }
            }
            return D * (dx + dy);
        }
    }
}
