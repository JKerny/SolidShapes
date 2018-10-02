using Solid.Foundation.DependencyInjection;
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
            ConfigureDI();
            PrintShapes();
        }

        private static void ConfigureDI()
        {
            var iocContainer = new IocContainer();
            iocContainer.Configure();
        }

        private static void PrintShapes()
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
