using Solid.Foundation.DependencyInjection;
using Solid.Foundation.Models;
using Solid.Foundation.Repository;
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
            IocContainer.Configure();
            var programRunner = new ProgramService(new ShapeRepository());
            programRunner.Execute();
        }
    }
}
