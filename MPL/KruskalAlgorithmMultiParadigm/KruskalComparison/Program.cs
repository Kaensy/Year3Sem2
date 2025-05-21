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
            
            // Test with small graph (original)
            TestUtility.CompareAlgorithms(
                "Small Graph Performance (5 vertices, 7 edges)",
                RunOOPImplementationSmall,
                RunFunctionalImplementationSmall,
                RunProceduralImplementationSmall
            );
            
            // Test with medium graph
            TestUtility.CompareAlgorithms(
                "Medium Graph Performance (10 vertices, 20 edges)",
                RunOOPImplementationMedium,
                RunFunctionalImplementationMedium,
                RunProceduralImplementationMedium
            );
            
            // Test with large graph
            TestUtility.CompareAlgorithms(
                "Large Graph Performance (100 vertices, 500 edges)",
                RunOOPImplementationLarge,
                RunFunctionalImplementationLarge,
                RunProceduralImplementationLarge
            );
            
            // Test with extra large graph
            TestUtility.CompareAlgorithms(
                "Extra Large Graph Performance (500 vertices, 2000 edges)",
                RunOOPImplementationExtraLarge,
                RunFunctionalImplementationExtraLarge,
                RunProceduralImplementationExtraLarge
            );
            
            // For more accurate timing on small operations, run multiple iterations
            TestUtility.CompareAlgorithmsWithMultipleRuns(
                "Small Graph Performance",
                RunOOPImplementationSmall,
                RunFunctionalImplementationSmall,
                RunProceduralImplementationSmall,
                10000
            );
            
            TestUtility.CompareAlgorithmsWithMultipleRuns(
                "Medium Graph Performance",
                RunOOPImplementationMedium,
                RunFunctionalImplementationMedium,
                RunProceduralImplementationMedium,
                1000
            );
            
            TestUtility.CompareAlgorithmsWithMultipleRuns(
                "Large Graph Performance",
                RunOOPImplementationLarge,
                RunFunctionalImplementationLarge,
                RunProceduralImplementationLarge,
                10
            );
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Small Graph Tests (Original)
        
        // OOP Implementation Test - Small Graph
        static void RunOOPImplementationSmall()
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
        
        // Functional Implementation Test - Small Graph
        static void RunFunctionalImplementationSmall()
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
            var mst = KruskalFunctional.Program.FindMST(vertices, edges);
        }
        
        // Procedural Implementation Test - Small Graph
        static void RunProceduralImplementationSmall()
        {
            // Call the methods from the procedural implementation
            KruskalProcedural.Program.InitializeGraph();
            KruskalProcedural.Program.KruskalMST();
        }
        
        #endregion
        
        #region Medium Graph Tests (10 vertices, 20 edges)
        
        // OOP Implementation Test - Medium Graph
        static void RunOOPImplementationMedium()
        {
            // Create a medium graph with 10 vertices
            var graph = new KruskalOOP.Graph();
            
            // Add vertices
            var vertices = new KruskalOOP.Vertex[10];
            for (int i = 0; i < 10; i++)
            {
                vertices[i] = new KruskalOOP.Vertex($"V{i}");
                graph.AddVertex(vertices[i]);
            }
            
            // Add edges to create a more complex graph
            var edgeData = new[]
            {
                (0, 1, 4), (0, 2, 8), (0, 3, 5),
                (1, 2, 2), (1, 4, 7), (1, 5, 3),
                (2, 3, 6), (2, 5, 9), (2, 6, 1),
                (3, 6, 3), (3, 7, 8),
                (4, 5, 5), (4, 8, 4),
                (5, 6, 7), (5, 8, 6), (5, 9, 2),
                (6, 7, 9), (6, 9, 8),
                (7, 9, 5),
                (8, 9, 3)
            };
            
            foreach (var (source, dest, weight) in edgeData)
            {
                graph.AddEdge(vertices[source], vertices[dest], weight);
            }
            
            // Apply Kruskal's algorithm
            var kruskal = new KruskalOOP.KruskalMST();
            var mst = kruskal.FindMST(graph);
        }
        
        // Functional Implementation Test - Medium Graph
        static void RunFunctionalImplementationMedium()
        {
            // Create medium graph as a collection of edges and vertices
            var vertices = new string[10];
            for (int i = 0; i < 10; i++)
            {
                vertices[i] = $"V{i}";
            }
            
            var edges = new[]
            {
                (Source: "V0", Destination: "V1", Weight: 4),
                (Source: "V0", Destination: "V2", Weight: 8),
                (Source: "V0", Destination: "V3", Weight: 5),
                (Source: "V1", Destination: "V2", Weight: 2),
                (Source: "V1", Destination: "V4", Weight: 7),
                (Source: "V1", Destination: "V5", Weight: 3),
                (Source: "V2", Destination: "V3", Weight: 6),
                (Source: "V2", Destination: "V5", Weight: 9),
                (Source: "V2", Destination: "V6", Weight: 1),
                (Source: "V3", Destination: "V6", Weight: 3),
                (Source: "V3", Destination: "V7", Weight: 8),
                (Source: "V4", Destination: "V5", Weight: 5),
                (Source: "V4", Destination: "V8", Weight: 4),
                (Source: "V5", Destination: "V6", Weight: 7),
                (Source: "V5", Destination: "V8", Weight: 6),
                (Source: "V5", Destination: "V9", Weight: 2),
                (Source: "V6", Destination: "V7", Weight: 9),
                (Source: "V6", Destination: "V9", Weight: 8),
                (Source: "V7", Destination: "V9", Weight: 5),
                (Source: "V8", Destination: "V9", Weight: 3)
            };
            
            // Call the FindMST method from the functional implementation
            var mst = KruskalFunctional.Program.FindMST(vertices, edges);
        }
        
        // Procedural Implementation Test - Medium Graph
        static void RunProceduralImplementationMedium()
        {
            KruskalProcedural.Program.InitializeMediumGraph();
            KruskalProcedural.Program.KruskalMST();
        }
        
        #endregion
        
        #region Large Graph Tests (100 vertices, 500 edges)
        
        // OOP Implementation Test - Large Graph
        static void RunOOPImplementationLarge()
        {
            // Create a large graph with 100 vertices
            var graph = new KruskalOOP.Graph();
            
            // Add vertices
            var vertices = new KruskalOOP.Vertex[100];
            for (int i = 0; i < 100; i++)
            {
                vertices[i] = new KruskalOOP.Vertex($"V{i}");
                graph.AddVertex(vertices[i]);
            }
            
            // Add many edges to create a dense graph
            var random = new Random(42); // Fixed seed for consistent results
            var edgesAdded = new HashSet<(int, int)>();
            
            // Generate 500 random edges
            for (int edgeCount = 0; edgeCount < 500; edgeCount++)
            {
                int source, dest;
                do
                {
                    source = random.Next(100);
                    dest = random.Next(100);
                } while (source == dest || edgesAdded.Contains((Math.Min(source, dest), Math.Max(source, dest))));
                
                edgesAdded.Add((Math.Min(source, dest), Math.Max(source, dest)));
                int weight = random.Next(1, 100);
                graph.AddEdge(vertices[source], vertices[dest], weight);
            }
            
            // Apply Kruskal's algorithm
            var kruskal = new KruskalOOP.KruskalMST();
            var mst = kruskal.FindMST(graph);
        }
        
        // Functional Implementation Test - Large Graph
        static void RunFunctionalImplementationLarge()
        {
            // Create large graph as a collection of edges and vertices
            var vertices = new string[100];
            for (int i = 0; i < 100; i++)
            {
                vertices[i] = $"V{i}";
            }
            
            // Generate the same edges as OOP implementation
            var random = new Random(42); // Same seed for consistency
            var edgesAdded = new HashSet<(int, int)>();
            var edgesList = new List<(string Source, string Destination, int Weight)>();
            
            for (int edgeCount = 0; edgeCount < 500; edgeCount++)
            {
                int source, dest;
                do
                {
                    source = random.Next(100);
                    dest = random.Next(100);
                } while (source == dest || edgesAdded.Contains((Math.Min(source, dest), Math.Max(source, dest))));
                
                edgesAdded.Add((Math.Min(source, dest), Math.Max(source, dest)));
                int weight = random.Next(1, 100);
                edgesList.Add(($"V{source}", $"V{dest}", weight));
            }
            
            // Call the FindMST method from the functional implementation
            var mst = KruskalFunctional.Program.FindMST(vertices, edgesList);
        }
        
        // Procedural Implementation Test - Large Graph
        static void RunProceduralImplementationLarge()
        {
            KruskalProcedural.Program.InitializeLargeGraph();
            KruskalProcedural.Program.KruskalMST();
        }
        
        #endregion
        
        #region Extra Large Graph Tests (500 vertices, 2000 edges)
        
        // OOP Implementation Test - Extra Large Graph
        static void RunOOPImplementationExtraLarge()
        {
            // Create an extra large graph with 500 vertices
            var graph = new KruskalOOP.Graph();
            
            // Add vertices
            var vertices = new KruskalOOP.Vertex[500];
            for (int i = 0; i < 500; i++)
            {
                vertices[i] = new KruskalOOP.Vertex($"V{i}");
                graph.AddVertex(vertices[i]);
            }
            
            // Add many edges to create a very dense graph
            var random = new Random(42); // Fixed seed for consistent results
            var edgesAdded = new HashSet<(int, int)>();
            
            // Generate 2000 random edges
            for (int edgeCount = 0; edgeCount < 2000; edgeCount++)
            {
                int source, dest;
                do
                {
                    source = random.Next(500);
                    dest = random.Next(500);
                } while (source == dest || edgesAdded.Contains((Math.Min(source, dest), Math.Max(source, dest))));
                
                edgesAdded.Add((Math.Min(source, dest), Math.Max(source, dest)));
                int weight = random.Next(1, 100);
                graph.AddEdge(vertices[source], vertices[dest], weight);
            }
            
            // Apply Kruskal's algorithm
            var kruskal = new KruskalOOP.KruskalMST();
            var mst = kruskal.FindMST(graph);
        }
        
        // Functional Implementation Test - Extra Large Graph
        static void RunFunctionalImplementationExtraLarge()
        {
            // Create extra large graph as a collection of edges and vertices
            var vertices = new string[500];
            for (int i = 0; i < 500; i++)
            {
                vertices[i] = $"V{i}";
            }
            
            // Generate the same edges as OOP implementation
            var random = new Random(42); // Same seed for consistency
            var edgesAdded = new HashSet<(int, int)>();
            var edgesList = new List<(string Source, string Destination, int Weight)>();
            
            for (int edgeCount = 0; edgeCount < 2000; edgeCount++)
            {
                int source, dest;
                do
                {
                    source = random.Next(500);
                    dest = random.Next(500);
                } while (source == dest || edgesAdded.Contains((Math.Min(source, dest), Math.Max(source, dest))));
                
                edgesAdded.Add((Math.Min(source, dest), Math.Max(source, dest)));
                int weight = random.Next(1, 100);
                edgesList.Add(($"V{source}", $"V{dest}", weight));
            }
            
            // Call the FindMST method from the functional implementation
            var mst = KruskalFunctional.Program.FindMST(vertices, edgesList);
        }
        
        // Procedural Implementation Test - Extra Large Graph
        static void RunProceduralImplementationExtraLarge()
        {
            KruskalProcedural.Program.InitializeExtraLargeGraph();
            KruskalProcedural.Program.KruskalMST();
        }
        
        #endregion
    }
}