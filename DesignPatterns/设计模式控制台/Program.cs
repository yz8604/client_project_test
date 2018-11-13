using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DesignPatterns;

namespace 设计模式控制台
{
    class Program
    {
        static void Main(string[] args)
        {

            GetTemplate();
            Console.Read();

        }

        //单列模式的调用---多线程
        private static void GetSingleton()
        {
           
            TaskFactory taskfactory = new TaskFactory();
            List<Task> tasklist = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                tasklist.Add(taskfactory.StartNew(() =>
                {
                    Singleton singleton = Singleton.CreateInstance1();
                }));
            }
        }
        //单例模式的调用---单线程
        private static void GetSingleton1()
        {
            Singleton singleton = Singleton.CreateInstance();
            Singleton singleton1 = Singleton.CreateInstance();
        }
        //工厂方法模式的调用
        public static void GetFactory()
        {
            //初始化创建汽车的两个工厂
            Factory hongQiCarFactory = new HongQiCarFactory();
            Factory aodiCarFactory = new AoDiCarFactory();

            //生产一辆红旗汽车
            Car hongqi = hongQiCarFactory.CreateCar();
            hongqi.Go();

            //生产一辆奥迪汽车
            Car aoDi = aodiCarFactory.CreateCar();
            aoDi.Go();

            Console.Read();
        }
        //建造者模式的调用
        public static void GetBuilder()
        {
            Director director = new Director();
            Builder buickCarBuilder = new BuickBuilder();
            Builder aoDiCarBuilder = new AoDiBuilder();

            director.Construct(buickCarBuilder);
            //组装完成了,我来驾驶别克了
            Car1 buickCar = buickCarBuilder.GetCar();
            buickCar.Show();

            director.Construct(aoDiCarBuilder);
            Car1 aoDiCar = aoDiCarBuilder.GetCar();
            aoDiCar.Show();


        }
        //原型模式的调用
        public static void GetPrototype()
        {
            Prototype xingzheSun = new XingZheSunPrototype();
            Prototype xingzheSun2 = xingzheSun.Clone();
            Prototype xingzheSun3 = xingzheSun.Clone();

            Prototype sunXingZhe = new SunXingZhePrototype();
            Prototype sunXingzhe2 = sunXingZhe.Clone();
            Prototype sunxingzhe3 = sunXingZhe.Clone();
            Prototype sunxingzhe4 = sunXingZhe.Clone();
            //1号孙行者打妖怪
            sunXingZhe.Fight();
            //2号孙行者去化缘
            sunXingzhe2.BegAlms();
            //战斗和化缘也可以分类，比如化缘，可以分：水果类化缘，饭食类化缘；
            //战斗可以分为：天界宠物下界成妖的战斗，自然修炼成妖的战斗，大家可以自己去想吧，原型模式还是很有用的
            Console.Read();
        }

        //对象适配器的调用
        public static void GetAdapter()
        {
            TwoHoleTarget homeTwoHole = new ThreeToTowAdapter();
            homeTwoHole.Request();
            Console.Read();
        }
        //类适配器的调用
        public static void GetAdapter1()
        {
            ITwoHoleTarget change = new ThreeToTwoAdapter1();
            change.Request();
            Console.ReadLine();
        }

        //装饰者模式调用
        public static void GetDecorator()
        {
            //这就是我们的饺子馅，需要装饰的房子
            House myselfhouse = new PatrickLiuHouse();
            //房子有安全系统了
            DecorationStrategy securityHouse = new HouseSecurityDecorator(myselfhouse);
            securityHouse.Renovation();
            
            //房子有保暖系统了
            DecorationStrategy WarmHouse = new KeepWarmDecorator(myselfhouse);
            WarmHouse.Renovation();

            //如果我既要安全系统又要保暖呢，继续装饰就行
            DecorationStrategy securityAndWarmHouse = new KeepWarmDecorator(securityHouse);
            securityAndWarmHouse.Renovation();
        }

        //外观模式调用
        public static void GetFacade()
        {
            SystemFacade facade = new SystemFacade();
            facade.Buy();
            Console.Read();
        }

        //享元模式调用
        public static void GetFlyWeight()
        {
            //比如，我们现在需要10000个一般士兵，只需这样
            SoldierFactory facotry = new SoldierFactory();
            AK47 ak47 = new AK47();
            //我们又这么多的士兵，但是使用的内存不是很多，因为我们缓存了
            for (int i = 0; i < 100; i++)
            {
                Soldier soldier = null;
                if (i <= 20)
                {
                    soldier = facotry.GetSoldier("士兵" + (i + 1), ak47, SoldierType.Normal);
                }
                else
                {
                    soldier = facotry.GetSoldier("士兵" + (i+1),ak47,SoldierType.Water);
                }
                soldier.Fight();

            }

            
            Console.Read();
        }

        //代理模式调用
        public static void GetProxy()
        {
            //近期，Fan姓明星关注度有点下降，来点炒作
            AgentAbstract fan = new AgentPerson();
            fan.Speculation("偶尔出来现现身，为炒作造势");
            Console.WriteLine();
            //过了段时间，又不行了，再炒作一次
            fan.Speculation("这段时间不火了，开始离婚炒作");
            Console.Read();
        }

        //模板模式调用
        public static void GetTemplate()
        {
            //现在想吃绿色的面，猪肉大葱馅的饺子
            AbstractClass fan = new ConcreteClass();
            fan.EatDumplings();

            Console.WriteLine();

            //过了段时间，我开始想吃橙色面的，韭菜鸡蛋馅的饺子
            fan = new ConcreteClass2();
            fan.EatDumplings();
            Console.Read();
        }
    }
}

