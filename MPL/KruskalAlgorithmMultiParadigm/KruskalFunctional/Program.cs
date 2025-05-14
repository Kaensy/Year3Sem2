
using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalFunctional
{
    public class Program
    {
        public static void Main(string[] args)
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
            
            Console.WriteLine("Original Graph:");
            PrintGraph(vertices, edges);
            
            // Apply Kruskal's algorithm
            var mst = FindMST(vertices, edges);
            
            Console.WriteLine("\nMinimum Spanning Tree using Kruskal's Algorithm (Functional):");
            PrintGraph(vertices, mst);
            
            Console.ReadLine();
        }
        
        // Function to find the MST using Kruskal's algorithm
        public static IEnumerable<(string Source, string Destination, int Weight)> FindMST(
            IEnumerable<string> vertices, 
            IEnumerable<(string Source, string Destination, int Weight)> edges)
        {
            // Initialize disjoint set
            var parent = vertices.ToDictionary(v => v, v => v);
            
            // Find set representative with path compression
            Func<string, string> find = null;
            find = v => parent[v] == v ? v : (parent[v] = find(parent[v]));
            
            // Union by rank (simplified)
            Action<string, string> union = (x, y) => {
                var rootX = find(x);
                var rootY = find(y);
                if (rootX != rootY)
                    parent[rootY] = rootX;
            };
            
            // Sort edges by weight and process them
            return edges
                .OrderBy(e => e.Weight)
                .Aggregate(
                    new List<(string, string, int)>(),
                    (mst, edge) => {
                        var sourceRoot = find(edge.Source);
                        var destRoot = find(edge.Destination);
                        
                        if (sourceRoot != destRoot) {
                            mst.Add(edge);
                            union(edge.Source, edge.Destination);
                        }
                        
                        return mst;
                    });
        }
        
        // Function to print the graph
        public static void PrintGraph(IEnumerable<string> vertices, IEnumerable<(string Source, string Destination, int Weight)> edges)
        {
            Console.WriteLine("Vertices: " + string.Join(", ", vertices));
            Console.WriteLine("Edges:");
            foreach (var edge in edges)
            {
                Console.WriteLine($"{edge.Source} -- {edge.Weight} --> {edge.Destination}");
            }
        }
    }
}