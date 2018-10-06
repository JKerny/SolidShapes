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
        [Fact]
        public void RectangleAreaCalculationTest()
        {
            //arrange
            var expected = 8;

            //act
            var rectangle = new Rectangle();
            rectangle.Length = 4;
            rectangle.Width = 2;
            var actual = rectangle.Area();

            //assert
            Assert.Equal(actual, expected);
            
        }
    }
}
