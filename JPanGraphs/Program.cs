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
            UndirectedGraph<int> graph = new UndirectedGraph<int>();
            string input;
            while (true)
            {
                Console.WriteLine("Insert a vertex in the graph");
                input = Console.ReadLine();
                if (input.Contains("AddEdge"))
                {
                    Console.WriteLine("Insert an edge in the graph");
                    var temp = int.Parse(Console.ReadLine());
                    var temp2 = int.Parse(Console.ReadLine());
                    int index = 0;
                    int index2 = 0;
                    for (int i = 0; i < graph.vertices.Count; i++)
                    {
                        if (graph.vertices[i].item == temp)
                        {
                            index = i;
                        }
                        if (graph.vertices[i].item == temp2)
                        {
                            index2 = i;
                        }
                    }
                    graph.AddEdge(graph.vertices[index], graph.vertices[index2]);
                    continue;
                }
                else if (input.Contains("RemoveVertex"))
                {
                    Console.WriteLine("Delete a vertex from the graph");
                    graph.RemoveVertex(int.Parse(Console.ReadLine()));
                    continue;
                }
                else if (input.Contains("RemoveEdge"))
                {
                    Console.WriteLine("Insert an edge in the graph");
                    var temp = int.Parse(Console.ReadLine());
                    var temp2 = int.Parse(Console.ReadLine());
                    int index = 0;
                    int index2 = 0;
                    for (int i = 0; i < graph.vertices.Count; i++)
                    {
                        if (graph.vertices[i].item == temp)
                        {
                            index = i;
                        }
                        if (graph.vertices[i].item == temp2)
                        {
                            index2 = i;
                        }
                    }
                    graph.RemoveEdge(graph.vertices[index], graph.vertices[index2]);
                    continue;
                }
                else if (input.Contains("DFS"))
                {
                    Console.WriteLine("Give a starting point");
                    Stack<Vertex<int>> stack = new Stack<Vertex<int>>();
                    var temp = int.Parse(Console.ReadLine());
                    int index = 0;
                    for (int i = 0; i < graph.vertices.Count; i++)
                    {
                        if (graph.vertices[i].item == temp)
                        {
                            index = i;
                        }
                    }
                    graph.DFS(graph.vertices[index], stack);
                    continue;
                }
                else if (input.Contains("BFS"))
                {
                    Console.WriteLine("Give a starting point");
                    var temp = int.Parse(Console.ReadLine());
                    int index = 0;
                    for (int i = 0; i < graph.vertices.Count; i++)
                    {
                        if (graph.vertices[i].item == temp)
                        {
                            index = i;
                        }
                    }
                    graph.BFS(graph.vertices[index]);
                    continue;
                }
                graph.AddVertex(int.Parse(input));
            }
        }
    }
}
