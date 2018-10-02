using Solid.Foundation.Models;
using System.Collections.Generic;

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
