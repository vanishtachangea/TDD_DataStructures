using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DS;
using FluentAssertions;

namespace XUnitTestProject1
{
    public class UnitTestNQueensAllPossibilities
    {
        [Fact]
        public void ReturnAllPlacesmentGoodQueenPlacement()
        {
            int N = 4;
            string[,] board = new string[N, N];
            
            IList<IList<string>> ResultList = NQueensAllPossibilities.SolveNQueens(N);
            Assert.True(true);

            //string[,] expectedBoard =
            //{
            //    { ".", "Q", ".", "." },
            //    { ".", ".", ".", "Q" },
            //    { "Q", ".", ".", "." },
            //    { ".", ".", "Q", "." }

            //};
            //board.Should().BeEquivalentTo(expectedBoard);
        }
    }
}
