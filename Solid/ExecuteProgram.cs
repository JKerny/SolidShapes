using Solid.Foundation.Repository;
using System;

namespace Solid
{
    public class ProgramService
    {
        private readonly IShapeRepository _shapeRepository;
        public ProgramService(IShapeRepository shapeRepository)
        {
            _shapeRepository = shapeRepository;
        }            

        public void Execute()
        {
            var shapes = _shapeRepository.GetShapes();
            foreach(var shape in shapes)
            {
                Console.WriteLine(shape.Area());
            }
            Console.ReadLine();
        }
    }
}