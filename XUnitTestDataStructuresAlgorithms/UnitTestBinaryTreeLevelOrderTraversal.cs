using DS;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestDataStructuresAlgorithms
{
    public class UnitTestBinaryTreeLevelOrderTraversal
    {
        private IBinaryTreeLevelOrderTraversal binaryTreeLevelOrderTraversal;
        private readonly ITestOutputHelper output;
        public UnitTestBinaryTreeLevelOrderTraversal(IBinaryTreeLevelOrderTraversal binaryTreeLevelOrderTraversal, ITestOutputHelper output)
        {
            this.binaryTreeLevelOrderTraversal = binaryTreeLevelOrderTraversal;
            this.output = output;
        }
        [Fact]
        public void TestSearch1()
        {
            //Arrange
            TreeNode node15 = new TreeNode(15, null, null);
            TreeNode node7 = new TreeNode(7, null, null);
            TreeNode node20 = new TreeNode(20, node15, node7);
            TreeNode node9 = new TreeNode(9, null, null);
            TreeNode node3 = new TreeNode(3, node9, node20);


            IList<IList<int>> expectedList = new List<IList<int>>();
            List<int> list1 = new List<int>();
            list1.Add(3);
            expectedList.Add(list1);

            list1 = new List<int>();
            list1.Add(9);
            list1.Add(20);
            expectedList.Add(list1);

            list1 = new List<int>();
            list1.Add(15);
            list1.Add(7);
            expectedList.Add(list1);





            IList<IList<int>> actualList = new List<IList<int>>();

            //Act
            actualList = this.binaryTreeLevelOrderTraversal.LevelOrder(node3);


            //Assert
            Assert.Equal(expectedList, actualList);
        }



    }
}
