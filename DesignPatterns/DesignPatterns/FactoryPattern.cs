using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //简单工厂：是把各个子类的创建及实例化移到简单工厂类中完成。
    //工厂模式:工厂方法用来处理对象的创建，并把这种创建对象的实现延迟到子类中去实现，这样，客户代码中关于基类的代码就和子类对象创建代码解耦了。
    public class FactoryPattern
    {

    }
    /// <summary>
    /// 汽车抽象类
    /// </summary>
    public abstract class Car
    {
        //开始行驶
        public abstract void Go();
    }

    public class HongQiCar : Car
    {
        public override void Go()
        {
            Console.WriteLine("红旗汽车开始行驶了！");
        }
    }

    public class AoDiCar : Car
    {
        public override void Go()
        {
            Console.WriteLine("奥迪汽车开始行驶了");
        }
    }
    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Factory
    {
        //工厂方法
        public abstract Car CreateCar();
    }
    /// <summary>
    /// 红旗汽车工厂类
    /// </summary>
    public class HongQiCarFactory : Factory
    {
        /// <summary>
        /// 负责生产红旗汽车
        /// </summary>
        /// <returns></returns>
        public override Car CreateCar()
        {
            return new HongQiCar();
        }
    }

    public class AoDiCarFactory : Factory
    {
        /// <summary>
        /// 负责创建奥迪汽车
        /// </summary>
        /// <returns></returns>
        public override Car CreateCar()
        {
            return new AoDiCar();
        }
    }



}
