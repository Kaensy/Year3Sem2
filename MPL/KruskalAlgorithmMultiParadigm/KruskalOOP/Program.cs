
using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a sample graph
            Graph graph = new Graph();
            
            // Add vertices
            Vertex a = new Vertex("A");
            Vertex b = new Vertex("B");
            Vertex c = new Vertex("C");
            Vertex d = new Vertex("D");
            Vertex e = new Vertex("E");
            
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
            
            Console.WriteLine("Original Graph:");
            graph.PrintGraph();
            
            // Apply Kruskal's algorithm
            KruskalMST kruskal = new KruskalMST();
            Graph mst = kruskal.FindMST(graph);
            
            Console.WriteLine("\nMinimum Spanning Tree using Kruskal's Algorithm (OOP):");
            mst.PrintGraph();
            
            Console.ReadLine();
        }
    }

    // Vertex class representing a node in the graph
    public class Vertex
    {
        public string Name { get; }
        
        public Vertex(string name)
        {
            Name = name;
        }
        
        public override string ToString()
        {
            return Name;
        }
    }

    // Edge class representing a connection between two vertices
    public class Edge : IComparable<Edge>
    {
        public Vertex Source { get; }
        public Vertex Destination { get; }
        public int Weight { get; }
        
        public Edge(Vertex source, Vertex destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }
        
        // For sorting edges by weight
        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
        
        public override string ToString()
        {
            return $"{Source} -- {Weight} --> {Destination}";
        }
    }

    // Graph class representing a collection of vertices and edges
    public class Graph
    {
        private List<Vertex> vertices;
        private List<Edge> edges;
        
        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }
        
        public void AddVertex(Vertex vertex)
        {
            vertices.Add(vertex);
        }
        
        public void AddEdge(Vertex source, Vertex destination, int weight)
        {
            edges.Add(new Edge(source, destination, weight));
        }
        
        public void AddEdge(Edge edge)
        {
            edges.Add(edge);
        }
        
        public List<Vertex> GetVertices()
        {
            return new List<Vertex>(vertices);
        }
        
        public List<Edge> GetEdges()
        {
            return new List<Edge>(edges);
        }
        
        public void PrintGraph()
        {
            Console.WriteLine("Vertices: " + string.Join(", ", vertices));
            Console.WriteLine("Edges:");
            foreach (var edge in edges)
            {
                Console.WriteLine(edge);
            }
        }
    }

    // DisjointSet data structure for cycle detection
    public class DisjointSet
    {
        private Dictionary<Vertex, Vertex> parent;
        private Dictionary<Vertex, int> rank;
        
        public DisjointSet(List<Vertex> vertices)
        {
            parent = new Dictionary<Vertex, Vertex>();
            rank = new Dictionary<Vertex, int>();
            
            // Make set for each vertex
            foreach (var vertex in vertices)
            {
                parent[vertex] = vertex;
                rank[vertex] = 0;
            }
        }
        
        public Vertex Find(Vertex vertex)
        {
            if (parent[vertex] != vertex)
            {
                parent[vertex] = Find(parent[vertex]); // Path compression
            }
            return parent[vertex];
        }
        
        public void Union(Vertex x, Vertex y)
        {
            Vertex rootX = Find(x);
            Vertex rootY = Find(y);
            
            // Union by rank
            if (rootX == rootY) return;
            
            if (rank[rootX] < rank[rootY])
            {
                parent[rootX] = rootY;
            }
            else if (rank[rootX] > rank[rootY])
            {
                parent[rootY] = rootX;
            }
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }
    }

    // Kruskal's MST implementation using OOP
    public class KruskalMST
    {
        public Graph FindMST(Graph graph)
        {
            Graph mst = new Graph();
            
            // Add all vertices to the MST
            foreach (var vertex in graph.GetVertices())
            {
                mst.AddVertex(vertex);
            }
            
            // Sort edges by weight
            List<Edge> sortedEdges = graph.GetEdges();
            sortedEdges.Sort();
            
            // Create disjoint set
            DisjointSet disjointSet = new DisjointSet(graph.GetVertices());
            
            // Process edges
            foreach (var edge in sortedEdges)
            {
                Vertex sourceRoot = disjointSet.Find(edge.Source);
                Vertex destRoot = disjointSet.Find(edge.Destination);
                
                // Add edge to MST if it doesn't create a cycle
                if (sourceRoot != destRoot)
                {
                    mst.AddEdge(edge);
                    disjointSet.Union(edge.Source, edge.Destination);
                }
            }
            
            return mst;
        }
    }
}