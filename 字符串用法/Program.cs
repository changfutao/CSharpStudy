using System;

namespace 字符串用法
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "我爱北京天安门";
            str = str.Remove(2, 2);
            Console.WriteLine(str);
        }
    }
}
