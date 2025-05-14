
using System;

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
        
        // Initialize the graph with vertices and edges
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