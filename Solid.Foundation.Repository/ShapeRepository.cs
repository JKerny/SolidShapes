using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Foundation.Models;
using Solid.Foundation.Repository.Data;

namespace Solid.Foundation.Repository
{
    public class ShapeRepository : IShapeRepository
    {
        public List<IShape> GetShapes()
        {
            return ShapeList.Shapes();
        }
    }
}
