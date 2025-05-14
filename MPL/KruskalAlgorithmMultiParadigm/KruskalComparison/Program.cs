using System;
using Common;
using KruskalOOP;
using KruskalFunctional;
using KruskalProcedural;

namespace KruskalComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kruskal's Algorithm - Multi-Paradigm Implementation Comparison");
            Console.WriteLine("=========================================================");
            
            // Create a test graph for all implementations
            TestUtility.CompareAlgorithms(
                RunOOPImplementation,
                RunFunctionalImplementation,
                RunProceduralImplementation
            );
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        // OOP Implementation Test
        static void RunOOPImplementation()
        {
            // Create the graph
            var graph = new KruskalOOP.Graph();
            
            // Add vertices
            var a = new KruskalOOP.Vertex("A");
            var b = new KruskalOOP.Vertex("B");
            var c = new KruskalOOP.Vertex("C");
            var d = new KruskalOOP.Vertex("D");
            var e = new KruskalOOP.Vertex("E");
            
            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            
            // Add edges with weights
            graph.AddEdge(a, b, 2);
            graph.AddEdge(a, c, 3);
            graph.AddEdge(b, c, 1);
            graph.AddEdge(b, d, 4);
            graph.AddEdge(c, d, 5);
            graph.AddEdge(c, e, 6);
            graph.AddEdge(d, e, 7);
            
            // Apply Kruskal's algorithm
            var kruskal = new KruskalOOP.KruskalMST();
            var mst = kruskal.FindMST(graph);
        }
        
        // Functional Implementation Test
        static void RunFunctionalImplementation()
        {
            // Create graph as a collection of edges and vertices
            var vertices = new[] { "A", "B", "C", "D", "E" };
            
            var edges = new[]
            {
                (Source: "A", Destination: "B", Weight: 2),
                (Source: "A", Destination: "C", Weight: 3),
                (Source: "B", Destination: "C", Weight: 1),
                (Source: "B", Destination: "D", Weight: 4),
                (Source: "C", Destination: "D", Weight: 5),
                (Source: "C", Destination: "E", Weight: 6),
                (Source: "D", Destination: "E", Weight: 7)
            };
            
            // Call the FindMST method from the functional implementation
            // We'll need to make it public and static to access it here
            var mst = KruskalFunctional.Program.FindMST(vertices, edges);
        }
        
        // Procedural Implementation Test
        static void RunProceduralImplementation()
        {
            // Call the methods from the procedural implementation
            // We'll need to make them public to access them here
            KruskalProcedural.Program.InitializeGraph();
            KruskalProcedural.Program.KruskalMST();
        }
    }
}