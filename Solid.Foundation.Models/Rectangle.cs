using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Foundation.Models
{
    public class Rectangle : IShape
    {
        public int Length { get; set; }
        public int Width { get; set; } 
        public double Area()
        {
            return Length * Width;
        }
    }
}
