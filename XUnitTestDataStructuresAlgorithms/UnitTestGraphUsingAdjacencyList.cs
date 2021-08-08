using DS;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestDataStructuresAlgorithms
{
    public class UnitTestGraphBFSUsingAdjacencyList
    {
        private IBinaryTreeLevelOrderTraversal binaryTreeLevelOrderTraversal;
        private readonly ITestOutputHelper output;
        public UnitTestGraphBFSUsingAdjacencyList(IBinaryTreeLevelOrderTraversal binaryTreeLevelOrderTraversal, ITestOutputHelper output)
        {
            this.binaryTreeLevelOrderTraversal = binaryTreeLevelOrderTraversal;
            this.output = output;
        }
        [Fact]
        public void TestSearchBFS()
        {
            //Arrange
            GraphUsingAdjacencyList graph = new GraphUsingAdjacencyList();
            int[] expectedArray = new int[] { 0, 1, 3, 2, 4, 5, 8, 6, 7 };

            //Act
            int[] actualArray = graph.BFS();


            //Assert
            Assert.Equal(expectedArray, actualArray);
        }
        [Fact]
        public void TestSearchDFS()
        {
            //Arrange
            GraphUsingAdjacencyList graph = new GraphUsingAdjacencyList();
            int[] expectedArray = new int[] { 0, 1, 3, 2, 8, 4, 6, 7, 5 };




            //Act
            int[] actualArray = graph.DFS();


            //Assert
            Assert.Equal(expectedArray, actualArray);
        }



    }
}
