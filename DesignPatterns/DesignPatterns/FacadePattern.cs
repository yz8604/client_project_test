using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //结构型：外观模式：在软件系统中，要完成一个功能，需要很多接口调用，不仅增加了开发难度，也增加了调试成本和维护的复杂度。不如我们把这些接口再封装一次，给一个很好的“外观”，让使用者使用更方便，只需调用一个接口，就可以完成以前调用多个接口的来完成任务，这就方便了。这个模式很简单，大家很容易理解，可能大家在编码的过程中已经不止一次使用过该模式了，只是不知道名字罢了。现实生活中这样的例子很多，举不胜举，来一幅图，大家看看就明白了。
    //为子系统中的一组接口提供一个一致的界面，Facade模式定义了一个高层接口，这个接口使得这一子系统更加容易使用。　　　　　　——《设计模式》GoF
    /// <summary>
    /// 不使用外观模式的情况
    /// 此时客户端与三个子系统发生了耦合，使得客户端程序依赖与子系统
    /// 为了解决这样的问题，我们可以使用外观模式来为所有子系统设计一个统一的接口
    /// 客户端只需要调用外观类中的方法就可以了，简化了客户端的操作
    /// 从而让客户和子系统之间避免了紧耦合
    /// </summary>
    public class FacadePattern
    {

    }
    //身份认证子系统A
    public class AuthoriationSystemA
    {
        public void MethodA()
        {
            Console.WriteLine("执行身份认证");
        }
    }
    //系统安全子系统B
    public class SecuitySystemB
    {
        public void MethodB()
        {
            Console.WriteLine("执行系统安全检查");
        }
    }

    //网银安全子系统C
    public class NetBankSystemC
    {
        public void MethodC()
        {
            Console.WriteLine("执行网银安全检测");
        }
    }
    //更高层的Facade
    public class SystemFacade
    {
        private AuthoriationSystemA auth;
        private SecuitySystemB secuity;
        private NetBankSystemC netbank;

        public SystemFacade()
        {
            auth = new AuthoriationSystemA();
            secuity = new SecuitySystemB();
            netbank = new NetBankSystemC();

            
        }

        public void Buy()
        {
            auth.MethodA();//身份认证子系统
            secuity.MethodB();//系统安全子系统
            netbank.MethodC();//网银安全子系统

            Console.WriteLine("我已经成功购买了！");
        }
    }


}
