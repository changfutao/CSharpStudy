using System;
using System.Collections.Generic;
using System.Text;

namespace 反射和特性的用法
{
    public class Student<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public void Write(T num)
        {
            Console.WriteLine(num);
        }
    }

    public class Student:Student<long>
    { }
}
