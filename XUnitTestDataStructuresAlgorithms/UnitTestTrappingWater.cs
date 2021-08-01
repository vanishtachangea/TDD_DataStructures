using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DS;
using Xunit.Abstractions;

namespace XUnitTestDataStructuresAlgorithms
{
    public class UnitTestTrappingWater
    {
        private ITrappingWater trappingWater;
        private readonly ITestOutputHelper output;
        public UnitTestTrappingWater(ITrappingWater trappingWater, ITestOutputHelper  output)
        {
            this.trappingWater = trappingWater;
            this.output = output;
        }
        [Fact]
        public void ShouldReturnAmountOfWaterTrapped()
        {
            //Arrange
            int[] height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            //Act
            int actualValue = trappingWater.Trap(height);
            output.WriteLine("heights",height[0]);

            //Assert
            Assert.Equal(6, actualValue);

        }

        [Fact]
        public void ShouldReturnAmountOfWaterTrapped2()
        {
            //Arrange
            int[] height = new int[] { 4, 2, 0, 3, 2, 5 };

            //Act
            int actualValue = trappingWater.Trap(height);
            output.WriteLine("heights", height[0]);

            //Assert
            Assert.Equal(9, actualValue);

        }


    }
}
