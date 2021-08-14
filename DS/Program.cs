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
            ///graph.BFS();
            ///
            //String Manipulation
            //StringManipulation sm = new StringManipulation();
            //Console.WriteLine(sm.Decompress("3[abc]"));
            //Console.WriteLine(sm.Decompress("3[abc2[hi]]"));
            //Console.WriteLine(sm.Decompress("3[abc]4[ab]c"));
            //Console.WriteLine(sm.Decompress("2[3[a]b]"));
            //Console.WriteLine("2[a]"[0]);


            WaysToGetN waysToGetN = new WaysToGetN();
            Console.WriteLine(waysToGetN.WaysToGetN_DC(5));
            Console.WriteLine(waysToGetN.WaysToGetN_DP_TopDown(5));

            Console.WriteLine(waysToGetN.WaysToGetN_DC(6));
            Console.WriteLine(waysToGetN.WaysToGetN_DP_TopDown(6));


            Console.WriteLine(waysToGetN.WaysToGetN_DC(7));
            Console.WriteLine(waysToGetN.WaysToGetN_DP_TopDown(7));

            Console.WriteLine(waysToGetN.WaysToGetN_DP_BottomUp(7));
            Console.WriteLine(waysToGetN.WaysToGetN_DP_BottomUp(7));


            Console.ReadLine();

          
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }


    }
}
