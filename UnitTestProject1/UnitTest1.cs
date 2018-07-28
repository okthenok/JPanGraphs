using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DirectedDFS()
        {
            JPanGraphs.DirectedGraph<int> graph = new JPanGraphs.DirectedGraph<int>();
            JPanGraphs.Vertex<int> vertex1 = new JPanGraphs.Vertex<int>(1);
            JPanGraphs.Vertex<int> vertex2 = new JPanGraphs.Vertex<int>(2);
            JPanGraphs.Vertex<int> vertex3 = new JPanGraphs.Vertex<int>(3);
            JPanGraphs.Vertex<int> vertex4 = new JPanGraphs.Vertex<int>(4);
            JPanGraphs.Vertex<int> vertex5 = new JPanGraphs.Vertex<int>(5);
            JPanGraphs.Vertex<int> vertex6 = new JPanGraphs.Vertex<int>(6);
            JPanGraphs.Vertex<int> vertex7 = new JPanGraphs.Vertex<int>(7);
            graph.AddEdge(vertex1, vertex2, 5);
            graph.AddEdge(vertex5, vertex1, 3);
            graph.AddEdge(vertex3, vertex2, 4);
            graph.AddEdge(vertex7, vertex3, 8);
            graph.AddEdge(vertex4, vertex7, 2);
            graph.AddEdge(vertex6, vertex3, 11);
            graph.AddEdge(vertex3, vertex7, 9);
            graph.AddEdge(vertex2, vertex4, 1);
            graph.AddEdge(vertex6, vertex1, 7);
            graph.DFS(vertex1);

        }
    }
}
