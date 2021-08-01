using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DS;

namespace XUnitTestDataStructuresAlgorithms
{
    public class UnitTestTrappingWater
    {
        private ITrappingWater trappingWater;
        public UnitTestTrappingWater(ITrappingWater trappingWater)
        {
            this.trappingWater = trappingWater;
        }
        [Fact]
        public void ShouldReturnAmountOfWaterTrapped()
        {
            //Arrange
            int[] height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            //Act
            int actualValue = trappingWater.Trap(height);

            //Assert
            Assert.Equal(6, actualValue);

        }
    }
}
