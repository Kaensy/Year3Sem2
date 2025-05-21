using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalProcedural
{
    public class Program
    {
        // Global variables
        static string[] vertices;
        static Edge[] edges;
        static Edge[] mstEdges;
        static int[] parent;
        
        // Structure to represent an edge
        public struct Edge
        {
            public int Source;
            public int Dest;
            public int Weight;
        }
        
        public static void Main(string[] args)
        {
            // Initialize graph
            InitializeGraph();
            
            // Print original graph
            Console.WriteLine("Original Graph:");
            PrintGraph(edges);
            
            // Apply Kruskal's algorithm
            KruskalMST();
            
            // Print minimum spanning tree
            Console.WriteLine("\nMinimum Spanning Tree using Kruskal's Algorithm (Procedural):");
            PrintGraph(mstEdges);
            
            Console.ReadLine();
        }
        
        // Initialize the small graph with vertices and edges
        public static void InitializeGraph()
        {
            // Initialize vertices
            vertices = new string[] { "A", "B", "C", "D", "E" };
            
            // Initialize edges
            edges = new Edge[]
            {
                new Edge { Source = 0, Dest = 1, Weight = 2 }, // A-B
                new Edge { Source = 0, Dest = 2, Weight = 3 }, // A-C
                new Edge { Source = 1, Dest = 2, Weight = 1 }, // B-C
                new Edge { Source = 1, Dest = 3, Weight = 4 }, // B-D
                new Edge { Source = 2, Dest = 3, Weight = 5 }, // C-D
                new Edge { Source = 2, Dest = 4, Weight = 6 }, // C-E
                new Edge { Source = 3, Dest = 4, Weight = 7 }  // D-E
            };
            
            // Allocate space for MST
            mstEdges = new Edge[vertices.Length - 1];
        }
        
        // Initialize the medium graph with vertices and edges (10 vertices, 20 edges)
        public static void InitializeMediumGraph()
        {
            // Initialize vertices (10 vertices)
            vertices = new string[10];
            for (int i = 0; i < 10; i++)
            {
                vertices[i] = $"V{i}";
            }
            
            // Initialize edges (20 edges)
            edges = new Edge[]
            {
                new Edge { Source = 0, Dest = 1, Weight = 4 },  // V0-V1
                new Edge { Source = 0, Dest = 2, Weight = 8 },  // V0-V2
                new Edge { Source = 0, Dest = 3, Weight = 5 },  // V0-V3
                new Edge { Source = 1, Dest = 2, Weight = 2 },  // V1-V2
                new Edge { Source = 1, Dest = 4, Weight = 7 },  // V1-V4
                new Edge { Source = 1, Dest = 5, Weight = 3 },  // V1-V5
                new Edge { Source = 2, Dest = 3, Weight = 6 },  // V2-V3
                new Edge { Source = 2, Dest = 5, Weight = 9 },  // V2-V5
                new Edge { Source = 2, Dest = 6, Weight = 1 },  // V2-V6
                new Edge { Source = 3, Dest = 6, Weight = 3 },  // V3-V6
                new Edge { Source = 3, Dest = 7, Weight = 8 },  // V3-V7
                new Edge { Source = 4, Dest = 5, Weight = 5 },  // V4-V5
                new Edge { Source = 4, Dest = 8, Weight = 4 },  // V4-V8
                new Edge { Source = 5, Dest = 6, Weight = 7 },  // V5-V6
                new Edge { Source = 5, Dest = 8, Weight = 6 },  // V5-V8
                new Edge { Source = 5, Dest = 9, Weight = 2 },  // V5-V9
                new Edge { Source = 6, Dest = 7, Weight = 9 },  // V6-V7
                new Edge { Source = 6, Dest = 9, Weight = 8 },  // V6-V9
                new Edge { Source = 7, Dest = 9, Weight = 5 },  // V7-V9
                new Edge { Source = 8, Dest = 9, Weight = 3 }   // V8-V9
            };
            
            // Allocate space for MST
            mstEdges = new Edge[vertices.Length - 1];
        }
        
        // Initialize the large graph with vertices and edges (100 vertices, 500 edges)
        public static void InitializeLargeGraph()
        {
            // Initialize vertices (100 vertices)
            vertices = new string[100];
            for (int i = 0; i < 100; i++)
            {
                vertices[i] = $"V{i}";
            }
            
            // Generate 500 random edges with same seed for consistency
            var random = new Random(42);
            var edgesAdded = new HashSet<(int, int)>();
            var edgesList = new List<Edge>();
            
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
                edgesList.Add(new Edge { Source = source, Dest = dest, Weight = weight });
            }
            
            edges = edgesList.ToArray();
            
            // Allocate space for MST
            mstEdges = new Edge[vertices.Length - 1];
        }
        
        // Initialize the extra large graph with vertices and edges (500 vertices, 2000 edges)
        public static void InitializeExtraLargeGraph()
        {
            // Initialize vertices (500 vertices)
            vertices = new string[500];
            for (int i = 0; i < 500; i++)
            {
                vertices[i] = $"V{i}";
            }
            
            // Generate 2000 random edges with same seed for consistency
            var random = new Random(42);
            var edgesAdded = new HashSet<(int, int)>();
            var edgesList = new List<Edge>();
            
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
                edgesList.Add(new Edge { Source = source, Dest = dest, Weight = weight });
            }
            
            edges = edgesList.ToArray();
            
            // Allocate space for MST
            mstEdges = new Edge[vertices.Length - 1];
        }
        
        // Find the minimum spanning tree using Kruskal's algorithm
        public static void KruskalMST()
        {
            // Sort edges by weight
            Array.Sort(edges, (a, b) => a.Weight.CompareTo(b.Weight));
            
            // Initialize parent array for union-find
            parent = new int[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
                parent[i] = i;
            
            int mstEdgeCount = 0;
            int edgeIndex = 0;
            
            // Build MST with V-1 edges
            while (mstEdgeCount < vertices.Length - 1 && edgeIndex < edges.Length)
            {
                // Get the smallest edge
                Edge currentEdge = edges[edgeIndex++];
                
                int sourceRoot = Find(currentEdge.Source);
                int destRoot = Find(currentEdge.Dest);
                
                // Add to MST if no cycle forms
                if (sourceRoot != destRoot)
                {
                    mstEdges[mstEdgeCount++] = currentEdge;
                    Union(sourceRoot, destRoot);
                }
            }
        }
        
        // Find set of vertex i
        static int Find(int i)
        {
            if (parent[i] != i)
                parent[i] = Find(parent[i]);
            return parent[i];
        }
        
        // Union of two sets
        static void Union(int x, int y)
        {
            parent[y] = x;
        }
        
        // Print the edges of the graph
        static void PrintGraph(Edge[] graphEdges)
        {
            Console.WriteLine("Vertices: " + string.Join(", ", vertices));
            Console.WriteLine("Edges:");
            foreach (var edge in graphEdges)
            {
                if (edge.Weight > 0) // Skip empty edges in MST array
                    Console.WriteLine($"{vertices[edge.Source]} -- {edge.Weight} --> {vertices[edge.Dest]}");
            }
        }
    }
}