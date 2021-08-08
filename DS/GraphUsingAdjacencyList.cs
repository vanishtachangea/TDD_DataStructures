using System;
using System.Collections.Generic;

namespace DS
{
    public class GraphUsingAdjacencyList
    {
        Dictionary<int, int[]> adjacencyList;
        List<int> resultArray;
        Dictionary<int, int> visited;

        public GraphUsingAdjacencyList()
        {
            adjacencyList = new Dictionary<int, int[]>();
            adjacencyList.Add(0, new int[] { 1, 3 });
            adjacencyList.Add(1, new int[] {  0});
            adjacencyList.Add(2, new int[] { 3, 8 });
            adjacencyList.Add(3, new int[] { 0,2, 4, 5 });
            adjacencyList.Add(4, new int[] { 3, 6 });
            adjacencyList.Add(5, new int[] { 3 });
            adjacencyList.Add(6, new int[] { 4, 7 });
            adjacencyList.Add(7, new int[] { 6 });
            adjacencyList.Add(8, new int[] { 2 });
        }
        public int[] BFS()
        {
            Queue<int> processQueue = new Queue<int>();
            resultArray = new List<int>();
            visited = new Dictionary<int, int>();

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

        public int[] DFS()
        {
           resultArray = new List<int>();
           visited = new Dictionary<int, int>();

            DFSRecursive(0);



           return resultArray.ToArray();
        }
        public void DFSRecursive(int currentPosition)
        {
            
            if (!visited.ContainsKey(currentPosition))
            {
                visited.Add(currentPosition, 1);
                resultArray.Add(currentPosition);
            }
            for (int i = 0; i <adjacencyList[currentPosition].Length;i++)
            {
                if(!visited.ContainsKey(adjacencyList[currentPosition][i]))
                {
                    DFSRecursive(adjacencyList[currentPosition][i]);
                }
            }
        }
    }
}
