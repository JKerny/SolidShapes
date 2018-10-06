using Solid.Foundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Foundation.Repository
{
    public interface IShapeRepository
    {
        List<IShape> GetShapes();
    }
}
