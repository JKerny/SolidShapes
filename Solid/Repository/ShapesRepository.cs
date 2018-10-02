using Solid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Repository
{
    public class ShapesRepository
    {
        public List<IShape>AllShapes => GetShapes();
        private List<IShape> GetShapes()
        {
            return ShapeList.Shapes();
        }
    }
}
