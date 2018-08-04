using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPanGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph<int> graph = new DirectedGraph<int>();
            DVertex<int>[,] vertices = new DVertex<int>[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    DVertex<int> temp = new DVertex<int>(i, j);
                    vertices[i, j] = temp;
                    if (i < 9 && vertices[i + 1, j] != null)
                    {
                        graph.AddEdge(vertices[i, j], vertices[i + 1, j], 1);
                    }
                    if (i > 0 && vertices[i - 1, j] != null)
                    {
                        graph.AddEdge(vertices[i, j], vertices[i - 1, j], 1);
                    }
                    if (j < 9 && vertices[i, j + 1] != null)
                    {
                        graph.AddEdge(vertices[i, j], vertices[i, j + 1], 1);
                    }
                    if (j > 0 && vertices[i, j - 1] != null)
                    {
                        graph.AddEdge(vertices[i, j], vertices[i, j - 1], 1);
                    }
                }
            }
            DVertex<int> start = new DVertex<int>(0, 0);
            DVertex<int> end = new DVertex<int>(9, 9);
            graph.AStar(start, end);
            #region oldEdges2
            //DirectedGraph<int> tree = new DirectedGraph<int>();
            //Vertex<int> vertex1 = new Vertex<int>(1);
            //Vertex<int> vertex2 = new Vertex<int>(2);
            //Vertex<int> vertex3 = new Vertex<int>(3);
            //Vertex<int> vertex4 = new Vertex<int>(4);
            //Vertex<int> vertex5 = new Vertex<int>(5);
            //Vertex<int> vertex6 = new Vertex<int>(6);
            //Vertex<int> vertex7 = new Vertex<int>(7);
            //Vertex<int> vertex8 = new Vertex<int>(8);
            //tree.AddEdge(vertex1, vertex2, 5);
            //tree.AddEdge(vertex1, vertex3, 3);
            //tree.AddEdge(vertex2, vertex4, 8);
            //tree.AddEdge(vertex2, vertex5, 9);
            //tree.AddEdge(vertex3, vertex6, 2);
            //tree.AddEdge(vertex3, vertex7, 7);
            //tree.AddEdge(vertex5, vertex8, 4);
            //tree.Dijkstra(vertex1, vertex8);
            #endregion
            #region oldEdges
            //tree.AddEdge(vertex1, vertex2, 5);
            //tree.AddEdge(vertex5, vertex1, 3);
            //tree.AddEdge(vertex3, vertex2, 4);
            //tree.AddEdge(vertex7, vertex3, 8);
            //tree.AddEdge(vertex4, vertex7, 2);
            //tree.AddEdge(vertex6, vertex3, 11);
            //tree.AddEdge(vertex3, vertex7, 9);
            //tree.AddEdge(vertex2, vertex4, 1);
            //tree.AddEdge(vertex6, vertex1, 7);
            //tree.AddEdge(vertex6, vertex8, 14);
            //tree.AddEdge(vertex3, vertex1, 6);
            //tree.AddEdge(vertex7, vertex4, 10);
            //tree.AddEdge(vertex3, vertex5, 12);
            //tree.AddEdge(vertex3, vertex6, 13);
            //graph.DFS(vertex1, 0);
            #endregion
            //tree.BFS(vertex1);
            Console.ReadLine();
            #region old stuff
            //    DirectedGraph<int> graph = new DirectedGraph<int>();
            //    string input;
            //    while (true)
            //    {
            //        Console.WriteLine("Insert a vertex in the graph");
            //        input = Console.ReadLine();
            //        if (input.Contains("AddEdge"))
            //        {
            //            Console.WriteLine("Insert an edge in the graph");
            //            var temp = int.Parse(Console.ReadLine());
            //            var temp2 = int.Parse(Console.ReadLine());
            //            int index = 0;
            //            int index2 = 0;
            //            for (int i = 0; i < graph.vertices.Count; i++)
            //            {
            //                if (graph.vertices[i].item == temp)
            //                {
            //                    index = i;
            //                }
            //                if (graph.vertices[i].item == temp2)
            //                {
            //                    index2 = i;
            //                }
            //            }
            //            graph.AddEdge(graph.vertices[index], graph.vertices[index2]);
            //            continue;
            //        }
            //        else if (input.Contains("RemoveVertex"))
            //        {
            //            Console.WriteLine("Delete a vertex from the graph");
            //            graph.RemoveVertex(int.Parse(Console.ReadLine()));
            //            continue;
            //        }
            //        else if (input.Contains("RemoveEdge"))
            //        {
            //            Console.WriteLine("Insert an edge in the graph");
            //            var temp = int.Parse(Console.ReadLine());
            //            var temp2 = int.Parse(Console.ReadLine());
            //            int index = 0;
            //            int index2 = 0;
            //            for (int i = 0; i < graph.vertices.Count; i++)
            //            {
            //                if (graph.vertices[i].item == temp)
            //                {
            //                    index = i;
            //                }
            //                if (graph.vertices[i].item == temp2)
            //                {
            //                    index2 = i;
            //                }
            //            }
            //            graph.RemoveEdge(graph.vertices[index], graph.vertices[index2]);
            //            continue;
            //        }
            //        else if (input.Contains("DFS"))
            //        {
            //            Console.WriteLine("Give a starting point");
            //            Stack<Vertex<int>> stack = new Stack<Vertex<int>>();
            //            var temp = int.Parse(Console.ReadLine());
            //            int index = 0;
            //            for (int i = 0; i < graph.vertices.Count; i++)
            //            {
            //                if (graph.vertices[i].item == temp)
            //                {
            //                    index = i;
            //                }
            //            }
            //            graph.DFS(graph.vertices[index], stack);
            //            continue;
            //        }
            //        else if (input.Contains("BFS"))
            //        {
            //            Console.WriteLine("Give a starting point");
            //            var temp = int.Parse(Console.ReadLine());
            //            int index = 0;
            //            for (int i = 0; i < graph.vertices.Count; i++)
            //            {
            //                if (graph.vertices[i].item == temp)
            //                {
            //                    index = i;
            //                }
            //            }
            //            graph.BFS(graph.vertices[index]);
            //            continue;
            //        }
            //        graph.AddVertex(int.Parse(input));
            //    }
            #endregion
        }
    }
}
