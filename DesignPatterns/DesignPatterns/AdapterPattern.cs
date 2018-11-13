using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //【结构型】设计模式解决的是类和对象的组合关系的问题。今天我们就开始讲【结构型】设计模式里面的第一个设计模式，中文名称：适配器模式，英文名称：Adapter Pattern。
    //说起这个模式其实很简单，在现实生活中也有很多实例，比如：我们手机的充电器，充电器的接头，有的是把两相电转换为三相电的，当然也有把三相电转换成两相电的。
    //我们经常使用笔记本电脑，笔记本电脑的工作电压和我们家里照明电压是不一致的，当然也就需要充电器把照明电压转换成笔记本的工作电压，只有这样笔记本电脑才可以正常工作。
    //太多了，就不一一列举了。
    //----------------定义：我们只要记住一点，适配就是转换，把不能在一起工作的两样东西通过转换，让他们可以在一起工作。------------------------
    //在软件系统中，由于应用环境的变化，常常需要将“一些现存的对象”放在新的环境中应用，但是新环境要求的接口是这些现存对象所不满足的。
    //如何应对这种“迁移的变化”？如何既能利用现有对象的良好实现，同时又能满足新的应用环境所要求的接口？

    //将一个类的接口转换成客户希望的另一个接口。Adapter模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作。

  //      三、适配器模式的实现要点：
    
  //    1、Adapter模式主要应用于“希望复用一些现存的类，但是接口又与复用环境要求不一致的情况”，在遗留代码复用、类库迁移等方面非常有用。

　　//2、GoF23定义了两种Adapter模式的实现结构：对象适配器和类适配器。类适配器采用“多继承”的实现方式，在C#语言中，如果被适配角色是类，Target的实现只能是接口，因为C#语言只支持接口的多继承的特性。在C#语言中类适配器也很难支持适配多个对象的情况，同时也会带来了不良的高耦合和违反类的职责单一的原则，所以一般不推荐使用。对象适配器采用“对象组合”的方式，更符合松耦合精神，对适配的对象也没限制，可以一个，也可以多个，但是，使得重定义Adaptee的行为较困难，这就需要生成Adaptee的子类并且使得Adapter引用这个子类而不是引用Adaptee本身。Adapter模式可以实现的非常灵活，不必拘泥于GoF23中定义的两种结构。例如，完全可以将Adapter模式中的“现存对象”作为新的接口方法参数，来达到适配的目的。

　　//3、Adapter模式本身要求我们尽可能地使用“面向接口的编程”风格，这样才能在后期很方便地适配。
    public class AdapterPattern
    {

    }

    //----------对象适配器模式----------------
    /// <summary>
    /// 我家只有2个孔的插座，也就是适配器模式中的目标(Target)角色，这里可以写成抽象类或者接口
    /// </summary>
    public class TwoHoleTarget
    {
        //客户端需要的方法
        public virtual void Request()
        {
            Console.WriteLine("两孔的充电器可以使用");
        }
    }
    /// <summary>
    /// 手机充电器是有3个柱子的插头，源角色需要适配的类
    /// </summary>
    public class ThreeHoleAdapter
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是3个孔的插头也可以使用了");
        }
    }
    /// <summary>
    /// 适配器类，TwoHole这个对象写成接口或者抽象类更好，面向接口编程嘛
    /// </summary>
    public class ThreeToTowAdapter : TwoHoleTarget
    {
        //引用两个孔插头的实例，从而将客户端与TwoHole联系起来
        private ThreeHoleAdapter threeHoleAdapter = new ThreeHoleAdapter();

        public override void Request()
        {
            //可以做具体的转换工作‘
            threeHoleAdapter.SpecificRequest();
        }
    }


    //-------------------类适配器模式--------------------
    /// <summary>
    /// 我家只有2个孔的插座，也就是适配器模式中的目标角色(Target),这里只能是接口，也是类适配器的限制
    /// </summary>
    public interface ITwoHoleTarget
    {
        void Request();
    }
    /// <summary>
    /// 3个孔的插头，源角色--需要适配的类
    /// </summary>
    public abstract class ThreeHoleAdapter1
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是三个孔的插头");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ThreeToTwoAdapter1: ThreeHoleAdapter1, ITwoHoleTarget
    {
        /// <summary>
        /// 实现2个孔插头接口方法
        /// </summary>
        public void Request()
        {
            //调用3个孔插头方法
            this.SpecificRequest();
        }
    }





}
