using System;

namespace CSharp.Demo.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Employee);
            var propertyInfos = t.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                //输出属性名
                //Console.WriteLine(propertyInfo.Name);
                //Console.WriteLine(propertyInfo.PropertyType);
            }

        }
    }
}
