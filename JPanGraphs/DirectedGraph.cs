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
        public void AddEdge(Vertex<T> vertex1, Vertex<T> vertex2, float weight)
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
        public void Dijkstra(Vertex<T> startVertex, Vertex<T> endVertex)
        {
            Queue<Vertex<T>> priorityQueue = new Queue<Vertex<T>>();
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].distance = float.PositiveInfinity;
                vertices[i].Visited = false;
                vertices[i].founder = null;
            }
            startVertex.distance = 0;
            priorityQueue.Enqueue(startVertex);

            while (priorityQueue.Count > 0)
            {
                var current = priorityQueue.Dequeue();
                //if current is the end vertex, break
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
                    }

                    //if not visited and not in queue, add to queue
                    if (!(neighbor.Visited && priorityQueue.Contains(neighbor)))
                    {
                        priorityQueue.Enqueue(neighbor);
                    }
                }
            }

            //stack and add end
            Stack<Vertex<T>> path = new Stack<Vertex<T>>();
            var curr = endVertex;
            while (curr != startVertex)
            {
                path.Push(curr);
                curr = curr.founder;
            }
            path.Push(startVertex);
            while (path.Count > 0)
            {
                Console.WriteLine(path.Peek().item + " " + path.Pop().distance);
            }
        }
    }
}
