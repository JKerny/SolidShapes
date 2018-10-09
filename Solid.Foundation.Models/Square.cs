using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Foundation.Models
{
    class Square : IShape
    {
        public double Side { get; set; }
        public double Area()
        {
            return Side * Side; 
        }
    }
}
