using Solid.Foundation.Repository;
using System;
using Solid.Foundation.Models;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Solid.Extensions;

namespace Solid
{
    public class ProgramService
    {
        public void Execute()
        {
            while (true)
            {
                Console.WriteLine(Constants.EnterShapeName);
                var shape = DetermineShape(Console.ReadLine());                
                List<double> number = new List<double>();
                if (shape != null)
                {
                    var properties = GetProperties(shape);
                    for(int i = 0; i < properties.Count();i++)
                    {
                        Console.WriteLine("Please enter the measure of the " + properties[i]);
                        double measure = 0;
                        bool isValidDouble = double.TryParse(Console.ReadLine(),out measure);
                        if(!isValidDouble)
                        {
                            Console.WriteLine("Please enter a number");
                            i --;
                            continue;
                        }
                        shape.SetPropValue(properties[i], measure);
                    }
                    string response = ShapeAreaResponse(shape);
                    Console.WriteLine(response);
                }
            }
        }

        private static string ShapeAreaResponse(IShape shape)
        {
            string shapeClassName = shape.GetType().ToString();
            int lastChars = shapeClassName.LastIndexOf('.') + 1;
            string shapeName = shapeClassName.Substring(lastChars, shapeClassName.Length - lastChars);
            var response = string.Format("The area of the {0} is {1}", shapeName, shape.Area());
            return response;
        }

        private List<string> GetProperties(object shape)
        {
            List<string> properties = new List<string>();
            Type type = shape.GetType();
            PropertyInfo[] props = type.GetProperties();            
            foreach (PropertyInfo property in props)
            {
                properties.Add(property.Name);
            }
            return properties;
        }

        private IShape DetermineShape(string input)
        {
            Assembly shapeAssembly = typeof(IShape).Assembly;
            var type = GetType(input, shapeAssembly);
            
            if (type == null)
            {
                Console.WriteLine(input + " is not a valid shape");
                return null;
            }

            var shape = Activator.CreateInstance(shapeAssembly.FullName, type.FullName);
            return (IShape)shape.Unwrap();
        }

        private Type GetType(string input,Assembly assembly)
        {            
            var shapeType = assembly.GetTypes().Where(t => t.GetInterface("IShape") == typeof(IShape));
            return shapeType.Where(x => x.Name.ToLower()[0] == input.ToLower()[0]).FirstOrDefault();
        }
    }
}