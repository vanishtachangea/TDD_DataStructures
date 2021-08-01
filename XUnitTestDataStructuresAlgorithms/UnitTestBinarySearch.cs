using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DS;
using Xunit.Abstractions;

namespace XUnitTestDataStructuresAlgorithms
{
    public class UnitTestBinarySearch
    {
        private IBinarySearch binarySearch;
        private readonly ITestOutputHelper output;
        public UnitTestBinarySearch(IBinarySearch binarySearch, ITestOutputHelper  output)
        {
            this.binarySearch = binarySearch;
            this.output = output;
        }
        [Fact]
        public void TestSearch1()
        {
            //Arrange
            int[] nums = new int[] { 1,2,3,7,8,10};
            int target = 8;

            //Act
            int actualPosition = binarySearch.Search(nums, target);


            //Assert
            Assert.Equal(4, actualPosition);
        }
        [Fact]
        public void TestSearch2()
        {
            //Arrange
            int[] nums = new int[] { 1, 2, 3,4, 7, 8, 10 };
            int target =10;

            //Act
            int actualPosition = binarySearch.Search(nums, target);


            //Assert
            Assert.Equal(6, actualPosition);
        }
        [Fact]
        public void TestSearchRange_3TargetsFound()
        {
            //Arrange
            int[] nums = new int[] { 1,3,3,5,5,5 ,8,9};
            int target = 5;
            int[] expectedArray = new int[] { 3, 5 };

            //Act
            int[] actualArrayPositions = binarySearch.SearchRange(nums, target);


            //Assert
            Assert.Equal(expectedArray, actualArrayPositions);
        }
        [Fact]
        public void TestSearchRange_1TargetFound()
        {
            //Arrange
            int[] nums = new int[] { 1, 3, 3, 5 , 8, 9 };
            int target = 5;
            int[] expectedArray = new int[] { 3, 3 };

            //Act
            int[] actualArrayPositions = binarySearch.SearchRange(nums, target);


            //Assert
            Assert.Equal(expectedArray, actualArrayPositions);
        }
        [Fact]
        public void TestSearchRange_0TargetFound()
        {
            //Arrange
            int[] nums = new int[] { 1, 3, 3, 5, 8, 9 };
            int target = 15;
            int[] expectedArray = new int[] { -1, -1 };

            //Act
            int[] actualArrayPositions = binarySearch.SearchRange(nums, target);


            //Assert
            Assert.Equal(expectedArray, actualArrayPositions);
        }
        [Fact]
        public void TestSearchRange_EmptyArray()
        {
            //Arrange
            int[] nums = new int[] {};
            int target = 15;
            int[] expectedArray = new int[] { -1, -1 };

            //Act
            int[] actualArrayPositions = binarySearch.SearchRange(nums, target);


            //Assert
            Assert.Equal(expectedArray, actualArrayPositions);
        }

    }
}
