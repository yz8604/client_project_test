using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //原型模式： 原型设计模式，每个具体原型是一类对象的原始对象，通过每个原型对象克隆出来的对象也可以进行设置，在原型的基础之上丰富克隆出来的对象，所以要设计好抽象原型的接口
    //《大话西游之大圣娶亲》这部电影，没看过的人不多吧，里面有这样一个场景。牛魔王使用无敌牛虱大战至尊宝，至尊宝的应对之策就是，从脑后把下一撮猴毛，吹了口仙气，无数猴子猴孙现身，
    //来大战牛魔王的无敌牛虱。至尊宝的猴子猴孙就是该原型模式的最好体现。至尊宝创建自己的一个副本，不用还要重新孕育五百年，然后出世，再学艺，最后来和老牛大战，估计黄花菜都凉了。
    //他有3根救命猴毛，轻轻一吹，想要多少个自己就有多少个，方便，快捷。
    //（1）、原型类（Prototype）：原型类，声明一个Clone自身的接口；

　  //（2）、具体原型类（ConcretePrototype）：实现一个Clone自身的操作。

　   //在原型模式中，Prototype通常提供一个包含Clone方法的接口，具体的原型ConcretePrototype使用Clone方法完成对象的创建。
    public class PrototypePattern
    {

    }
    /// <summary>
    /// 抽象原型，定义了原型本身所具有特征和动作，该类型就是至尊宝
    /// </summary>
    public abstract class Prototype
    {
        //战斗--保护师傅
        public abstract void Fight();
        //化缘--不要饿着师傅
        public abstract void BegAlms();
        //吹口仙气--变化一个自己出来
        public abstract Prototype Clone();

    }
    /// <summary>
    /// 具体原型，例如：行者孙，他只负责化斋饭食和与与自然修炼成妖的战斗
    /// </summary>
    public sealed class XingZheSunPrototype : Prototype
    {
        //战斗--保护师傅--与自然修炼成妖的战斗
        public override void Fight()
        {
            Console.WriteLine("腾云驾雾，各种武艺--自然修炼成妖的战斗");
        }
        //化缘--不要饿着师傅--饭食类
        public override void BegAlms()
        {
            Console.WriteLine("化缘-饭食类");
        }

        public override Prototype Clone()
        {
            //Prototype模式中的Clone方法可以利用.NET中的Object类的MemberwiseClone()方法或者序列化来实现深拷贝。
            return (XingZheSunPrototype)this.MemberwiseClone();
        }
    }
    /// <summary>
    /// 具体原型，例如：孙行者，他只负责化斋水果和与天界宠物下界的妖怪战斗
    /// </summary>
    public sealed class SunXingZhePrototype : Prototype
    {
        //战斗--保护师傅-与天界宠物战斗
        public override void Fight()
        {
            Console.WriteLine("腾云驾雾，各种武艺--与天界宠物战斗");
        }
        //化缘--不要饿着师傅--水果类
        public override void BegAlms()
        {
            Console.WriteLine("化缘水果类");
        }
        //吹一个口仙气--变化一个自己出来
        public override Prototype Clone()
        {
            return (SunXingZhePrototype)this.MemberwiseClone();
        }
    }
}
