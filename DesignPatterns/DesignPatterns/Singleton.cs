using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //创建型：单列模式：保证类仅有一个实例，并提供一个全局访问的入口点。
    //动机：对于系统中的某些类来说，只有一个实例很重要，例如，一个系统中可以存在多个打印任务，但是只能有一个正在工作的任务；一个系统只能有一个窗口管理器或文件系统；
    //一个系统只能有一个计时工具或ID(序号)生成器。如在Windows中就只能打开一个任务管理器。如果不使用机制对窗口对象进行唯一化，将弹出多个窗口，如果这些窗口显示的内容完全一致，
    //则是重复对象，浪费内存资源；如果这些窗口显示的内容不一致，则意味着在某一瞬间系统有多个状态，与实际不符，也会给用户带来误解，不知道哪一个才是真实的状态。
    //因此有时确保系统中某个对象的唯一性即一个类只能有一个实例非常重要。
    //如何保证一个类只有一个实例并且这个实例易于被访问呢？定义一个全局变量可以确保对象随时都可以被访问，但不能防止我们实例化多个对象。
    //一个更好的解决办法是让类自身负责保存它的唯一实例。这个类可以保证没有其他实例被创建，并且它可以提供一个访问该实例的方法。这就是单例模式的模式动机。
   //弊端：它的一点弊端就是它不支持参数化的实例化方法。在.NET里静态构造器只能声明一个，而且必须是无参数的，私有的。因此这种方式只适用于无参数的构造器。
   //需要说明的是：HttpContext.Current就是一个单例，他们是通过Singleton的扩展方式实现的，他们的单例也并不是覆盖所有领域，只是针对某些局部领域中，是单例的，不同的领域中还是会有不同的实例。
    public class Singleton
    {
        private static  Singleton _Singleton = null;
        private static  object Singleton_Lock = new object();//锁同步

        //防止外界被调用
        private Singleton()
        {

        }
        //在单线程中，这个方法可以适用，但是在多线程中，2个线程实例化类是会判断_Singleton!=null,会实例化两个对象，这就不能保证是单例模式。
        public static Singleton CreateInstance()
        {
            if (_Singleton == null)
            {
                Console.WriteLine("被创建");
                _Singleton = new Singleton();
            }
            return _Singleton;
        }

        public static Singleton CreateInstance1()
        {

            if (_Singleton == null)
            {
                lock (Singleton_Lock)
                {
                    Console.WriteLine("路过");
                    if (_Singleton == null)
                    {
                        Console.WriteLine("被创建");
                        _Singleton = new Singleton();
                    }
                }
            }

         
            return _Singleton;
        }

    }
}
