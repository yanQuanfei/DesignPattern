using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace DesignPattern
{
    /// <summary>
    /// 电脑类
    /// </summary>
    public class Computer
    {
        private List<string> parts = new List<string>();
       /// <summary>
       /// 添加零件
       /// </summary>
       /// <param name="part">Part.</param>
        public void Add(string part)
        {
            parts.Add(part);
        }
        /// <summary>
        /// 显示进度
        /// </summary>
        public void Show()
        {
            Console.WriteLine("开始组装。。。。。。。。。。。");
            foreach(string item in parts)
            {
                Console.WriteLine("组装" + item);
            }
            Console.WriteLine("组装完成");

        }
    }
   /// <summary>
   /// 抽象工作者
   /// </summary>
    public abstract class Builder
    {
        //装 CPU
        public abstract void BuildPartCPU();
        //装主板
        public abstract void BuildPartMainBoard();

        //组装完成
        public abstract Computer GetComputer();
    }
    /// <summary>
    /// 工作者1
    /// </summary>
    public class ConputerBuider1 : Builder
    {
        Computer computer = new Computer();

        public override void BuildPartCPU()
        {
            computer.Add("CPU_i5");
        }
        public override void BuildPartMainBoard()
        {
            computer.Add("MainBoard_ROG");
        }
        public override Computer GetComputer()
        {
            return computer;
        }
    }
    /// <summary>
    /// 工作者2
    /// </summary>
    public class ComputerBuider2 : Builder
    {
        Computer computer = new Computer();
        public override void BuildPartCPU()
        {
            computer.Add("CUP_i7");
        }
        public override void BuildPartMainBoard()
        {
            computer.Add("MainBoard_JIJIA");
        }
        public override Computer GetComputer()
        {
            return computer;
        }
    }


    public class Director
    {
        /// <summary>
        /// 组装电脑
        /// </summary>
        /// <param name="builder">组装工作人</param>
        public void Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }
    }


    /// <summary>
    /// 主程序类
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //指挥者
            Director director = new Director();
            //工作者
            Builder b1 = new ConputerBuider1();
            Builder b2 = new ComputerBuider2();
            //boss让 b1组装电脑
            director.Construct(b1);
            Computer com1 = b1.GetComputer();
            com1.Show();

            //boss 让 b2 装第二个电脑
            director.Construct(b2);
            Computer com2 = b2.GetComputer();
            com2.Show();

            Console.Read();
        }
    }
}
