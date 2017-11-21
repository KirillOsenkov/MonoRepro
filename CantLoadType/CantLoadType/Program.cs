using System;
using System.Reflection;

namespace CantLoadType
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var assembly = Assembly.Load("Microsoft.CodeAnalysis.EditorFeatures");
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Reflect(type);
            }
        }

        private static void Reflect(Type type)
        {
            foreach (var property in type.GetProperties())
            {

            }
        }
    }
}
