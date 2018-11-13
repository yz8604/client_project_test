using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //建造者模式：
    public class BuilderPattern
    {

    }

    public class Director
    {
        //组装汽车
        public void Construct(Builder builder)
        {
            builder.BuildCarDoor();
            builder.BuildCarWheel();
            builder.BuildCarEngine();
        }
    }

    public sealed class Car1
    {
        //汽车部件集合
        private IList<string> parts = new List<string>();
        //把单个部件添加到汽车部件集合中
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("汽车开始在组装.......");
            foreach (string part in parts)
            {
                Console.WriteLine("组件" + part + "已装好");
            }

            Console.WriteLine("汽车组装好了");
        }

    }
    /// <summary>
    /// 抽象建造者，它定义了要创建什么部件和最后创建的结果，但是不是组装的类型，切记
    /// </summary>
    public abstract class Builder
    {
        //创建车门
        public abstract void BuildCarDoor();
        //创建车轮
        public abstract void BuildCarWheel();
        //创建车引擎
        public abstract void BuildCarEngine();
        //获得组装好的汽车
        public abstract Car1 GetCar();
    }
    /// <summary>
    /// 具体的创建者，具体的车型的创建者，例如：别克
    /// </summary>
    public sealed class BuickBuilder : Builder
    {
        Car1 buickCar = new Car1();
        public override void BuildCarDoor()
        {
            buickCar.Add("Buick's Door");
        }
        public override void BuildCarWheel()
        {
            buickCar.Add("Buick'sWheel");
        }
        public override void BuildCarEngine()
        {
            buickCar.Add("Buick's Engine");
        }
        public override Car1 GetCar()
        {
            return buickCar;
        }
    }
    /// <summary>
    /// 具体创建者，具体的车型的创建者，例如：奥迪
    /// </summary>
    public sealed class AoDiBuilder : Builder
    {
        Car1 aoDiCar = new Car1();
        public override void BuildCarDoor()
        {
            aoDiCar.Add("Aodi's Door");
        }
        public override void BuildCarWheel()
        {
            aoDiCar.Add("Aodi's Wheel");
        }
        public override void BuildCarEngine()
        {
            aoDiCar.Add("Aodi's Engine");
        }

        public override Car1 GetCar()
        {
            return aoDiCar;
        }
    }

}
