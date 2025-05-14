using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Common
{
    public class TestUtility
    {
        public static void CompareAlgorithms(Action oop, Action functional, Action procedural)
        {
            Console.WriteLine("Performance Comparison:");
            Console.WriteLine("======================");
            
            // Test OOP Implementation
            Stopwatch watch = new Stopwatch();
            watch.Start();
            oop();
            watch.Stop();
            Console.WriteLine($"OOP Implementation: {watch.ElapsedMilliseconds}ms");
            
            // Test Functional Implementation
            watch.Reset();
            watch.Start();
            functional();
            watch.Stop();
            Console.WriteLine($"Functional Implementation: {watch.ElapsedMilliseconds}ms");
            
            // Test Procedural Implementation
            watch.Reset();
            watch.Start();
            procedural();
            watch.Stop();
            Console.WriteLine($"Procedural Implementation: {watch.ElapsedMilliseconds}ms");
        }
    }
}