using System;

namespace 委托用法
{
    class Program
    {
        #region 1.0委托基础
        //声明委托类
        public delegate void MyFirstDelegate(int x, int y);
        public void Sum(int x, int y)
        {
            Console.WriteLine(x + y);
        }
        #endregion

        #region 1.1多播委托
        delegate int MySumDelegate(int x, int y);
        int SumA(int x, int y)
        {
            return x + y;
        }
        static int SumB(int x, int y)
        {
            return 2 * x + y;
        }
        #endregion

        #region 1.2调用委托
        delegate void SubDelegate(ref int x);
        static void SubA(ref int x)
        {
            x--;
        }
        static void SubB(ref int x)
        {
            x -= 2;
        }
        #endregion

        #region 1.3匿名方法
        delegate int OtherDel(int x);
        #endregion
        static void Main(string[] args)
        {
            #region 1.0委托基础
            //声明委托类型变量
            MyFirstDelegate myDelegate;
            Program p = new Program();
            //创建委托类型实例并将与委托签名和返回值一致的方法传入并赋值给委托类型变量
            //签名一致表示 参数数量和位置以及类型一致并且返回值一致(包括ref和out修饰符)
            //myDelegate = new MyFirstDelegate(p.Sum);
            //默认编译器会new 委托对象(方法引用)
            //传入的方法可以是实例方法也可以是静态方法
            myDelegate = p.Sum;
            //调用委托(调用委托时,其包含的每一个方法都会被执行)
            //myDelegate(1, 2);
            //实际是调用委托实例的Invoke()方法
            myDelegate.Invoke(1, 2);
            Console.WriteLine("==========================================================");
            #endregion

            #region 1.1多播委托
            Program pA = new Program();
            //1.创建委托变量
            MySumDelegate sumDelegateA = new MySumDelegate(pA.SumA);
            MySumDelegate sumDelegateB = new MySumDelegate(SumB);
            //委托是类,引用类型,要在堆内存中开辟空间,保存了方法引用(地址)
            //第三个委托是前两个委托的合并
            MySumDelegate sumDelegateC = sumDelegateA + sumDelegateB;
            int result = sumDelegateC(2, 3);
            Console.WriteLine(result);

            //为委托添加方法(使用 += 运算符)
            MySumDelegate myDel = pA.SumA;
            //使用 += 运算符时,实际发生的是创建了一个新的委托,其调用列表是左边委托加上右边方法的组合，然后将这个新的委托赋值给myDel
            myDel += SumB;
            int sum1 = myDel(1, 1);
            Console.WriteLine(sum1);

            //从委托移除方法
            //使用 -= 运算符时,实际发生的是创建了一个新的委托。新的委托是就委托的副本-只是没有了已经被移除方法的引用
            //如果在调用列表中的方法有多个实例, -=运算符将从列表最后开始搜索,并且移除第一个与方法匹配的实例
            //试图删除委托中不存在的方法没有效果
            //试图调用空委托会抛出异常。
            myDel -= SumB;
            int sum2 = myDel(1, 1);
            Console.WriteLine(sum2);
            #endregion

            #region 1.2调用委托
            //调用带返回值的委托
            //调用列表中最后一个方法返回的值就是委托调用返回的值
            //调用列表中所有其他方法的返回值都会被忽略

            //调用带引用参数的委托
            //如果委托有引用参数,参数值会根据调用列表中的一个或多个方法的返回值而改变
            int x = 10;
            SubDelegate subDel = SubA;
            subDel += SubB;
            subDel(ref x);
            Console.WriteLine(x);
            #endregion

            #region 1.3匿名方法
            //如果方法只会被使用一次,就没必要创建独立的具名方法。匿名方法允许我们避免使用独立的具名方法
            //匿名方法是在初始化委托时内联声明的方法
            OtherDel otherDel = delegate (int x)
            {
                return x + 1;
            };
            int num = otherDel(5);
            Console.WriteLine(num);
            //使用匿名方法
            //1.声明委托变量时作为初始化表达式
            //2.组合委托时在赋值语句的右边
            //3.为委托增加事件时在赋值语句的右边
            
            //匿名方法表达式语法
            //1.delegate关键字
            //2.参数列表
            //3.语句块
            //注意:匿名方法不会显式声明返回值
            #endregion


        }
    }
}
