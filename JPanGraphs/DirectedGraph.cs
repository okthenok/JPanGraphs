using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    public class DirectedGraph<T> where T : IComparable<T>
    {
        public List<DVertex<T>> vertices = new List<DVertex<T>>();
        public DirectedGraph() { }
        public void AddEdge(DVertex<T> vertex1, DVertex<T> vertex2, float weight)
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
        public void RemoveEdge(DVertex<T> vertex1, DVertex<T> vertex2)
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
        public void DFS(DVertex<T> vertex, double weight)
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
        public void BFS(DVertex<T> vertex)
        {
            double totalWeight = 0;
            Console.WriteLine(vertex.item);
            Queue<DVertex<T>> queue = new Queue<DVertex<T>>();
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
        public void Dijkstra(DVertex<T> startVertex, DVertex<T> endVertex)
        {
            Queue<DVertex<T>> priorityQueue = new Queue<DVertex<T>>();
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
            Stack<DVertex<T>> path = new Stack<DVertex<T>>();
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
        public void AStar(DVertex<T> startVertex, DVertex<T> endVertex)
        {
            Queue<DVertex<T>> priorityQueue = new Queue<DVertex<T>>();
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

                    //if not visited and not in queue, add to queue
                    if (!(neighbor.Visited && priorityQueue.Contains(neighbor)))
                    {
                        priorityQueue.Enqueue(neighbor);
                    }
                }
            }

            //stack and add end
            Stack<DVertex<T>> path = new Stack<DVertex<T>>();
            var curr = endVertex;
            while (curr.founder != null)
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
        private float Mathattan(DVertex<T> vertex, DVertex<T> endVertex)
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
