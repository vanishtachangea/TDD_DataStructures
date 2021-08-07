using DS;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestDataStructuresAlgorithms
{
    public class UnitTestDFS_2DArrays
    {
        private IDFS_2DArrays dFS_2DArrays;
        private readonly ITestOutputHelper output;
        public UnitTestDFS_2DArrays(IDFS_2DArrays dFS_2DArrays, ITestOutputHelper output)
        {
            this.dFS_2DArrays = dFS_2DArrays;
            this.output = output;
        }
        [Fact]
        public void TestDFS()
        {
            //Arrange
            //int[,] array2d = new int[,] { { 10, 20, 30, 40 }, { 11, 21, 31, 41 }, { 12, 22, 32, 42 }, { 13, 23, 33, 43 } };
            int[,] array2d = new int[,] { { 10, 20 }, { 11, 21 } };


            int[] expectedList = new int[] { 10, 20, 21, 11 };


            int[] actualList;

            //Act
            actualList = this.dFS_2DArrays.Traverse(array2d);


            //Assert
            Assert.Equal(expectedList, actualList);
        }
        [Fact]
        public void TestBFS()
        {
            //Arrange
            //int[,] array2d = new int[,] { { 10, 20, 30, 40 }, { 11, 21, 31, 41 }, { 12, 22, 32, 42 }, { 13, 23, 33, 43 } };
            int[,] array2d = new int[,] { { 10, 20 }, { 11, 21 } };


            int[] expectedList = new int[] { 10, 20, 11, 21 };


            int[] actualList;

            //Act
            actualList = this.dFS_2DArrays.TraverseBFS(array2d);


            //Assert
            Assert.Equal(expectedList, actualList);
        }


    }
}
