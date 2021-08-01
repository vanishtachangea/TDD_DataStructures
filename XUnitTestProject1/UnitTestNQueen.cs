using System;
using System.Collections;
using Xunit;
using DS;
using FluentAssertions;

namespace XUnitTestDataStructuresAlgorithms
{
    public class UnitTestNQueen
    {
        [Fact]
        public void ReturnGoodQueenPlacement()
        {
            int N = 4;
            int[,] board = new int[N, N];
            bool b = NQueenAlgorithm.NQueen(board, N);
            Assert.True(true);

            int[,] expectedBoard =
            {
                { 0, 1, 0, 0 },
                { 0, 0, 0, 1 },
                { 1, 0, 0, 0 },
                { 0, 0, 1, 0 }

            };
            board.Should().BeEquivalentTo(expectedBoard);
        }
    }
}
