using System;
using DS;

namespace DS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.Write(i);
            //}
            GraphUsingAdjacencyList graph = new GraphUsingAdjacencyList();

            //Act
            graph.BFS();
            Console.ReadLine();

            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }


    }
}
