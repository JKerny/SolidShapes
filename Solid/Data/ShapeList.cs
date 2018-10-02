using Solid.Foundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Foundation.Models
{
    public static class ShapeList
    {
        public static List<IShape> Shapes()
        {
            var shapes = new List<IShape>();
            shapes.Add(new Rectangle
            {
                Length = 3,
                Width = 5
            });
            shapes.Add(new Circle
            {
                Radius = 6
            });
            return shapes;
        }
    }
}
