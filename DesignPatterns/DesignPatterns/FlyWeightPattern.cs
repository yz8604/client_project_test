using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //该模式是【享元模式】，英文名称是：Flyweight Pattern。还是老套路，先从名字上来看看。“享元”是不是可以这样理解，共享“单元”，单元是什么呢，举例说明，对于图形而言就是图元，对于英文来说就只26个英文字母，对于汉语来说就是每个汉字，也可以这样理解“元”，构成事物的最小单元，这些单元如果大量、且重复出现，可以缓存重复出现的单元，达到节省内存的目的，换句说法就是享元是为了节省空间，对于计算机而言就是内存。面向对象很好地解决了系统抽象性的问题（系统抽象性指把系统里面的事物写成类，类可以实例化成为对象，用对象和对象之间的关系来设计系统），在大多数情况下，这样做是不会损及系统的性能的。但是，在某些特殊的应用中，由于对象的数量太大，并且这些大量的对象中有很多是重复的，如果每个对象都单独的创建（C#的语法是new）出来，会给系统带来难以承受的内存开销。比如图形应用中的图元等对象、字处理应用中的字符对象等。
    //   在软件系统中，采用纯粹对象方案的问题在于大量细粒度的对象会很快充斥在系统中，从而带来很高的运行时代价——主要指内存需求方面的代价。如何在避免大量细粒度对象问题的同时，让外部客户程序仍然能够透明地使用面向对象的方式来进行操作？
    //运用共享技术有效地支持大量细粒度的对象。　　　　                                       　　——《设计模式》GoF
    class FlyWeightPattern
    {
    }
    //说起“享元模式”，我这里有一个很好的场景可以进行说明。我们知道在战斗的游戏场景中，会有很多战士，基本上战士都是差不多的，小区别战士忽略，最大的区别就是拿的武器不同而已。在大型的战争游戏中，会有大量的士兵出来战斗，我们写程序的时候就可以用“享元”来解决大量战士的情况。
    
        
        //这些是辅助类型
    public enum SoldierType
    {
        Normal,
        Water
    }

    //该类型就是抽象战士Soldier--该类型相当于抽象享元角色
    public abstract class Soldier
    {
        public string Name { get; private set; }
        //通过构造函数初始化士兵的名称
        protected Soldier(string name)
        {
            this.Name = name;
        }
        //可以传入不同的武器就用不同的活力--该方法相当于抽象Flyweight的Operation方法
        public abstract void Fight();
        public WeaPen WeapenInstance { get; set; }
    }

    //一般类型的战士，武器就是步枪--相当于具体的Flyweight角色
    public sealed class NormalSoldier:Soldier
    {
        //通过构造函数初始化士兵的名称
        public NormalSoldier(string name) : base(name) { }
        //执行享元的方法--就是Flyweight类型的Operation方法
        public override void Fight()
        {
            WeapenInstance.Fire("士兵:" +Name+"在陆地执行击毙任务");
        }
    }

    public sealed class WaterSoldier : Soldier
    {
        //通过构造函数初始化士兵的名称
        public WaterSoldier(string name) : base(name) { }
        //执行享元的方法---就是Flyweight类型的Operation方法
        public override void Fight()
        {
            WeapenInstance.Fire("士兵：" + Name + "在海中执行击毙任务");
        }
    }
    //此类型和享元没太大关系，可以算是享元对象的状态把，需要从外部定义
    public abstract class WeaPen
    {
        public abstract void Fire(string jobName);
    }
    public sealed class AK47 : WeaPen
    {
        public override void Fire(string jobName)
        {
            Console.WriteLine(jobName);
        }
        //该类型相当于享元的工厂--相当于FlyweightFactory类型
        
    }

    public sealed class SoldierFactory
    {
        private static IList<Soldier> soldiers;

        static SoldierFactory()
        {
            soldiers = new List<Soldier>();
        }

        Soldier mySoldier = null;
        //因为我这里有两种士兵，所以在这里可以增加另外一个参数，士兵类型，原模式里面没有
        public Soldier GetSoldier(string name, WeaPen weapen, SoldierType soldierType)
        {
            foreach (Soldier soldier in soldiers)
            {
                if (string.Compare(soldier.Name, name, true) == 0)
                {
                    mySoldier = soldier;
                    return mySoldier;
                }
            }
            //我们这里就任务名称是唯一的
            if (soldierType == SoldierType.Normal)
            {
                mySoldier = new NormalSoldier(name);
            }
            else
            {
                mySoldier = new WaterSoldier(name);
            }
            mySoldier.WeapenInstance = weapen;

            soldiers.Add(mySoldier);
            return mySoldier;
        }
    }
}
