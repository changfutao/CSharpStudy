using System;
using System.Reflection;

namespace 反射和特性的用法
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 反射
            /*
                   元数据: 有关程序及其类型的数据,它们保存在程序的程序集中。
                   反射: 程序在运行时,可以查看其他程序集或其本身的元数据。一个运行的程序查看本身的元数据或其他程序的元数据的行为
                   使用反射,必须使用System.Reflection命名空间
                   Type: 被设计用来包含类型的特性。使用这个类的对象能让我们获取程序使用的类型的信息
                       1.对于程序中用到的每一个类型,CLR都会创建一个包含这个类型信息的Type类型的对象
                       2.程序中用到的每一个类型都会关联到独立的Type类的对象
                       3.不管创建的类型有多少个实例,只有一个Type对象会关联到所有这些实例
               */
            Person p = new Person();
            //第一种获取类的Type类型
            Type tt = p.GetType();
            //第二种获取类的Type类型
            Type t = typeof(Person);
            //返回类的名称
            string name = t.Name;
            //返回包含类声明的命名空间
            string nameSpace = t.Namespace;
            //返回声明类型的程序集。如果类型时泛型的,返回定义这个类型的程序集
            Assembly assembly = t.Assembly;
            FieldInfo[] fieldInfos = t.GetFields();
            #endregion

            #region 特性
            /*
                特性: 是一种允许我们向程序的程序集增加元数据的语言结构。它是用于保存程序结构信息的某种特殊类型的类
                    1.将应用了特性的程序机构叫做目标
                    2.设计用来获取和使用元数据的程序叫做特性的消费者
            */
            #endregion

        }
    }
}
