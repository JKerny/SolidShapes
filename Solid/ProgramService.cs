﻿using Solid.Foundation.Repository;
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
        private readonly IShapeRepository _shapeRepository;
        public ProgramService()
        {
            _shapeRepository = new ShapeRepository();
        }

        public ProgramService(IShapeRepository shapeRepository)
        {
            _shapeRepository = shapeRepository;
        }            

        public void Execute()
        {
            Console.WriteLine(Constants.EnterShapeName);            
            var shape = DetermineShape(Console.ReadLine());
            List<double> number = new List<double>();
            if(shape != null)
            {                
                foreach(var property in GetProperties(shape))
                {
                    Console.WriteLine("Please the measure of the " + property);
                    double length = double.Parse(Console.ReadLine()); 
                    var shapeProperty = shape.GetPropValue(property,length);
                }
                string shapeClassName = shape.GetType().ToString();
                int lastChars = shapeClassName.LastIndexOf('.') + 1;
                string shapeName = shapeClassName.Substring(lastChars, shapeClassName.Length - lastChars);
                var response = string.Format("The area of the {0} is {1}",shapeName , shape.Area());
                Console.WriteLine(response);
                Console.ReadLine();
            }
        }

        private List<string> GetProperties(object shape)
        {
            List<string> properties = new List<string>();
            Type t = shape.GetType();
            PropertyInfo[] props = t.GetProperties();            
            foreach (PropertyInfo property in props)
            {
                properties.Add(property.Name);
            }
            return properties;
        }

        private IShape DetermineShape(string input)
        {            
            var shapeAssembly = typeof(IShape).Assembly;
            var shapeType = shapeAssembly.GetTypes().Where(t => t.GetInterface("IShape") == typeof(IShape));
            var type = shapeType.Where(x => x.Name.ToLower()[0] == input.ToLower()[0]).FirstOrDefault();
            var shape = Activator.CreateInstance(shapeAssembly.FullName, type.FullName);
            return (IShape)shape.Unwrap();
        }

        public static T Cast<T>(object o)
        {
            return (T)o;
        }
    }
}