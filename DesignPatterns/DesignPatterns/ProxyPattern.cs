using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //代理模式：“代理”可以理解为“代替”，代替“主人”做一些事情，为什么需要“代理”，是因为某些原因（比如：安全方面的原因），不想让“主人”直接面对这些繁琐、复杂的问题，但是这些事情是经“主人”同意或者授意的，如同“主人”亲自完成的一样。这个模式很简单，生活中的例子也很多。举例说明，歌星、影星的经纪人就是现实生活中一个代理模式的很好例子，还有操作系统中的防火墙，也是代理的例子，要访问系统，先过防火墙这关，否则免谈。还有很多了，就不一一列举了，大家在生活中慢慢的体会吧。
    public class ProxyPattern
    {
    }
    //该类型就是抽象Subject角色，定义代理角色和真是主体角色共有的接口方法
    public abstract class AgentAbstract
    {
        public virtual void Speculation(string thing)
        {
            Console.WriteLine(thing);
        }
    }
    //该类型是Fan姓明星，有钱有势，想炒什么炒什么---相当于具体的RealSubject角色
    public sealed class FanStar : AgentAbstract
    {
        //有钱有势，有背景
        public FanStar() { }
        //要有名气，定期要炒作---就是RealSubject类型的Request方法
        public override void Speculation(string thing)
        {
            Console.WriteLine(thing);
        }

    }
    //该类型是代理类型--相当于具体的Proxy角色
    public sealed class AgentPerson : AgentAbstract
    {
        //这是背后的老板
        private FanStar boss;
        //老板在后面发号指令
        public AgentPerson()
        {
            boss = new FanStar();
        }
        //炒作的方法，执行具体的炒作--就是Proxy类型的Request方法
        public override void Speculation(string thing)
        {
            Console.WriteLine("前期弄点绯闻，拍点野照");
            base.Speculation(thing);
            Console.WriteLine("然后开发布会，伤心哭泣，继续捞钱");
        }
    }
}
