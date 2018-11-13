using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //TemplateMethodPattern---模板方法
    class TemplateMethodPattern
    {

    }
    //该类型就是抽象类角色--AbstractClass,定义做饺子的算法骨架，这里有三步骤，当然也可以多个步骤
    public abstract class AbstractClass
    {
        //该方法就是模板方法，方法里面包含了做饺子的算法步骤
        public void EatDumplings()
        {
            //和面
            MarkingDough();
            //包馅
            MarkDumplings();
            //煮饺子
            BoiledDumplings();

            Console.WriteLine("饺子真好吃！");
        }

        public abstract void MarkingDough();
        public abstract void MarkDumplings();
        public abstract void BoiledDumplings();

    }
    //该类型是具体类角色--ConcreteClass,我想吃绿色面皮，猪肉大葱馅饺子
    public sealed class ConcreteClass : AbstractClass
    {
        //要想吃饺子第一步肯定是和面---该方法相当于算法中的某一步
        public override void MarkingDough()
        {
            //我想要面是绿色的
            Console.WriteLine("在和面的时候加入芹菜汁，和好的面就是绿色的");
        }
        //想要吃饺子第二部是“包饺子”---该方法相当于算法中的某一步
        public override void MarkDumplings()
        {
            Console.WriteLine("农家猪肉和农家大葱，制成馅"); 
        }
        //想要吃饺子第三部是“煮饺子”----该方法相当于算法中的某一步
        public override void BoiledDumplings()
        {
            Console.WriteLine("用我家的大铁锅和大木材煮饺子");
        }
    }
    //该类型是具体类角色--ConcreteClass2,我想吃橙色面皮，韭菜鸡蛋馅的饺子
    public sealed class ConcreteClass2 : AbstractClass
    {
        //要想吃饺子第一步肯定是“和面”---该方法相当于算法中的某一步
        public override void MarkingDough()
        {
            //我想要面是橙色的，加入胡萝卜汁，和好的面就是橙色的
            Console.WriteLine("在和面的时候加入胡萝卜汁，和好的面就是橙色的");
        }
        //想要吃饺子第二部是包饺子
        public override void MarkDumplings()
        {
            //我想吃韭菜鸡蛋馅的，在此就可以定制了
            Console.WriteLine("农家鸡蛋和农家韭菜，制作成馅");
        }
        //煮饺子
        public override void BoiledDumplings()
        {
            //此处没要求
            Console.WriteLine("可以用一般煤气和不占锅煮就可以");
        }
    }
    
}
