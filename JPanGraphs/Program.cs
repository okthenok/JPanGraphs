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
                Console.WriteLine("Insert a number in the graph");
                input = Console.ReadLine();
                if (input.Contains("RemoveVertex"))
                {
                    Console.WriteLine("Delete a value from the graph");
                    input = Console.ReadLine();
                    graph.RemoveVertex(int.Parse(input));
                    continue;
                }
                else if (input.Contains("RemoveEdge"))
                {
                    graph.RemoveEdge();
                    continue;
                }
                graph.AddVertex(int.Parse(input));
            }
        }
    }
}
