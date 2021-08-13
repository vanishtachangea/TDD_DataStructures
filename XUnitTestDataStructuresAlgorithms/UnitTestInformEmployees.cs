using DS;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestDataStructuresAlgorithms
{
    public class UnitTestInformEmployees
    {
        private readonly ITestOutputHelper output;
        public UnitTestInformEmployees(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void TestSearcDFS()
        {
            //Arrange
            ///
            // Input: n = 7, headID = 6, manager = [1, 2, 3, 4, 5, 6, -1], informTime = [0, 6, 5, 4, 3, 2, 1]
            //Output: 21



            InformEmployeesDFS inform = new InformEmployeesDFS();
            int n = 7;
            int headID = 6;
            int[] manager = new int[] { 1, 2, 3, 4, 5, 6, -1 };
            int[] informTime = new int[] { 0, 6, 5, 4, 3, 2, 1 };
            int[] expectedResults = new int[] { 6, 5, 4, 3, 2, 1, 0 };

            int expectedTime = 21;
            inform.SetSubordinatesAdjacencyList(manager);

            //Act

            int actualTime = inform.NumOfMinutes(n, headID, manager, informTime);
            //inform.DFSTraversal(headID);


            //Assert
            Assert.Equal(expectedTime, actualTime);
            // Assert.Equal(expectedResults, inform.traversalResult);
        }

        [Fact]
        public void TestSearcDFS2()
        {
            //Arrange
            ///
            //8
            //0
            //[-1, 5, 0, 6, 7, 0, 0, 0]
            //[89, 0, 0, 0, 0, 523, 241, 519]
            InformEmployeesDFS inform = new InformEmployeesDFS();
            int n = 8;
            int headID = 0;
            int[] manager = new int[] { -1, 5, 0, 6, 7, 0, 0, 0 };
            int[] informTime = new int[] { 89, 0, 0, 0, 0, 523, 241, 519 };
            int[] expectedResults = new int[] { 6, 5, 4, 3, 2, 1, 0 };

            int expectedTime = 612;
            inform.SetSubordinatesAdjacencyList(manager);

            //Act

            int actualTime = inform.NumOfMinutes(n, headID, manager, informTime);
            //inform.DFSTraversal(headID);


            //Assert
            Assert.Equal(expectedTime, actualTime);
            // Assert.Equal(expectedResults, inform.traversalResult);
        }
    }
}
