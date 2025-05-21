using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Common
{
    public class TestUtility
    {
        public static void CompareAlgorithms(string testName, Action oop, Action functional, Action procedural)
        {
            Console.WriteLine($"\n{testName}");
            Console.WriteLine(new string('=', testName.Length + 2));
            
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
        
        // Helper method to run the same test multiple times for more accurate timing
        public static void CompareAlgorithmsWithMultipleRuns(string testName, Action oop, Action functional, Action procedural, int iterations = 1000)
        {
            Console.WriteLine($"\n{testName} (Average over {iterations} runs)");
            Console.WriteLine(new string('=', testName.Length + iterations.ToString().Length + 20));
            
            // Test OOP Implementation
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                oop();
            }
            watch.Stop();
            Console.WriteLine($"OOP Implementation: {watch.ElapsedMilliseconds / (double)iterations:F3}ms average");
            
            // Test Functional Implementation
            watch.Reset();
            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                functional();
            }
            watch.Stop();
            Console.WriteLine($"Functional Implementation: {watch.ElapsedMilliseconds / (double)iterations:F3}ms average");
            
            // Test Procedural Implementation
            watch.Reset();
            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                procedural();
            }
            watch.Stop();
            Console.WriteLine($"Procedural Implementation: {watch.ElapsedMilliseconds / (double)iterations:F3}ms average");
        }
    }
}