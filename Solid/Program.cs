using Solid.Data;
using Solid.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapeRepository = new ShapesRepository();
            foreach (var shape in shapeRepository.AllShapes)
            {
                Console.WriteLine(shape.Area());
            }
            Console.ReadLine();
        }
    }
}
