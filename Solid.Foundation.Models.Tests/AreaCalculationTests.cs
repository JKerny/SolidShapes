using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Solid.Foundation.Models.Tests
{
    public class AreaCalculationTests
    {
        [Theory]
        [InlineData(2,4,8)]
        [InlineData(3,5,15)]
        public void RectangleAreaCalculationTest(int width, int length, int expected)
        {
            //act
            var rectangle = new Rectangle();
            rectangle.Length = length;
            rectangle.Width = width;
            var actual = rectangle.Area();

            //assert
            Assert.Equal(actual, expected);
            
        }
    }
}
