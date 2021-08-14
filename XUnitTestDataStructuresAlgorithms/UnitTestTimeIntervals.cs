using System;
using System.Collections;
using Xunit;
using DS;
using System.Collections.Generic;

namespace XUnitTestDataStructuresAlgorithms
{
    /// <summary>
    /// [a, b] [c, d]
    ///M   | MMMM   MMMMMMMMMMMMMMMM    MMM
    // |  M
    //  MMM          MMMMMMMMM MM
    //--------------------------------------------> t
    ///RES | MMMMM MMMMMMMMMMMMMMMMM   MMM MM
    /// </summary>
    public class UnitTestTimeIntervals
    {
        [Fact]
        public void TestIsOverLapping()
        {
            TimeIntervals timeIntervals = new TimeIntervals();
            int[] interval1 = { 2,4 };
            int[] interval2 = { 3, 6 };
            bool isOverlapping = timeIntervals.IsOverlapping(interval1[0], interval1[1], interval2[0], interval2[1]);

            Assert.True(isOverlapping);

        }
        [Fact]
        public void TestIsNotOverLapping()
        {
            TimeIntervals timeIntervals = new TimeIntervals();
            int[] interval1 = { 2, 4 };
            int[] interval2 = { 5, 6 };
            bool isOverlapping = timeIntervals.IsOverlapping(interval1[0], interval1[1], interval2[0], interval2[1]);

            Assert.False(isOverlapping);

        }
        [Fact]
        public void TestMergedIntervals1()
        {
            TimeIntervals timeIntervals = new TimeIntervals();
            int[] interval1 = { 2, 4 };
            int[] interval2 = { 5, 6 };
            int[] interval3 = { 7, 8 };
            int[][] testIntervals = new int[3][];
            testIntervals[0] = interval1;
            testIntervals[1] = interval2;
            testIntervals[2] = interval3;
            int[][] actualMergedInterval = timeIntervals.GetOverallMergedIntervals(testIntervals);

            int[][] expectedMergedIntervals = new int[3][];
            //[{2,4},{5,6},{7,8}]

            int[] resultInterval1 = { 2, 4 };
            int[] resultinterval2 = { 5, 6 };
            int[] resultinterval3 = { 7, 8 };
            expectedMergedIntervals[0] = resultInterval1;
            expectedMergedIntervals[1] = resultinterval2;
            expectedMergedIntervals[2] = resultinterval3;

            Assert.Equal(expectedMergedIntervals, actualMergedInterval);

        }

        [Fact]
        public void TestMergedIntervals2()
        {
            TimeIntervals timeIntervals = new TimeIntervals();
            int[] interval1 = { 2, 4 };
            int[] interval2 = { 3, 6 };
            int[] interval3 = { 7, 8 };
            int[][] testIntervals = new int[3][];
            testIntervals[0] = interval1;
            testIntervals[1] = interval2;
            testIntervals[2] = interval3;
            int[][] actualMergedInterval = timeIntervals.GetOverallMergedIntervals(testIntervals);

            int[][] expectedMergedIntervals = new int[2][];
            //[{2,6},{7,8}]
            int[] resultInterval1 = { 2, 6 };
            int[] resultinterval3 = { 7, 8 };
            expectedMergedIntervals[0] = resultInterval1;
            expectedMergedIntervals[1] = resultinterval3;

            Assert.Equal(expectedMergedIntervals, actualMergedInterval);

        }

        [Fact]
        public void TestMergedIntervals3()
        {
            TimeIntervals timeIntervals = new TimeIntervals();
            int[] interval1 = { 2, 4 };
            int[] interval2 = { 3, 6 };
            int[] interval3 = { 7, 8 };
            int[][] testIntervals = new int[3][];
            testIntervals[1] = interval1;
            testIntervals[0] = interval2;
            testIntervals[2] = interval3;
            int[][] actualMergedInterval = timeIntervals.GetOverallMergedIntervals(testIntervals);

            int[][] expectedMergedIntervals = new int[2][];
            //[{2,6},{7,8}]
            int[] resultInterval1 = { 2, 6 };
            int[] resultinterval3 = { 7, 8 };
            expectedMergedIntervals[0] = resultInterval1;
            expectedMergedIntervals[1] = resultinterval3;

            Assert.Equal(expectedMergedIntervals, actualMergedInterval);

        }
    }



    }


