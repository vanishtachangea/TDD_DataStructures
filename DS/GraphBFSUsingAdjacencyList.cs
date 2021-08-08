using System;
using System.Collections.Generic;

namespace DS
{
    public class GraphBFSUsingAdjacencyList
    {
        Dictionary<int, int[]> adjacencyList;
        public GraphBFSUsingAdjacencyList()
        {
            adjacencyList = new Dictionary<int, int[]>();
            adjacencyList.Add(0, new int[] { 1, 3 });
            adjacencyList.Add(1, new int[] { 2 });
            adjacencyList.Add(2, new int[] { 3, 8 });
            adjacencyList.Add(3, new int[] { 0, 4, 5 });
            adjacencyList.Add(4, new int[] { 3, 6 });
            adjacencyList.Add(5, new int[] { 3 });
            adjacencyList.Add(6, new int[] { 4, 7 });
            adjacencyList.Add(7, new int[] { 6 });
            adjacencyList.Add(8, new int[] { 2 });
        }
        public int[] BFS()
        {
            Queue<int> processQueue = new Queue<int>();
            List<int> resultArray = new List<int>();
            Dictionary<int, int> visited = new Dictionary<int, int>();

            processQueue.Enqueue(0);
            while (processQueue.Count > 0)
            {
                int currentValue = processQueue.Dequeue();

                if (!visited.ContainsKey(currentValue))
                {
                    resultArray.Add(currentValue);
                    Console.WriteLine(currentValue.ToString());
                    visited.Add(currentValue, 1);
                }

                for (int i = 0; i < adjacencyList[currentValue].Length; i++)
                {
                    if (!visited.ContainsKey(adjacencyList[currentValue][i]))
                        processQueue.Enqueue(adjacencyList[currentValue][i]);
                }

            }
            return resultArray.ToArray();
        }
    }
}
