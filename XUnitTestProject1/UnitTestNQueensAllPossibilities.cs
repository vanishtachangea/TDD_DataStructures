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

            NQueensAllPossibilities qp = new NQueensAllPossibilities();


            IList<IList<string>> ResultList = qp.SolveNQueens(N);
            Assert.True(true);

            //string[,] expectedBoard =
            //{
            //    { ".", "Q", ".", "." },
            //    { ".", ".", ".", "Q" },
            //    { "Q", ".", ".", "." },
            //    { ".", ".", "Q", "." }

            //};
            //board.Should().BeEquivalentTo(expectedBoard);
            IList<IList<string>> expectedResult = new List<IList<string>>();
            List<String> pos1 = new List<string>();
            string row1 = ".Q..";
            pos1.Add(row1);
            row1 = "...Q";
            pos1.Add(row1);
            row1 = "Q...";
            pos1.Add(row1);
            row1 = "..Q.";
            pos1.Add(row1);

            expectedResult.Add(pos1);

            pos1 = new List<string>();
            row1 = "..Q.";
            pos1.Add(row1);
            row1 = "Q...";
            pos1.Add(row1);
            row1 = "...Q";
            pos1.Add(row1);
            row1 = ".Q..";
            pos1.Add(row1);

            expectedResult.Add(pos1);
            ResultList.Should().BeEquivalentTo(expectedResult);
        }
    }
}
