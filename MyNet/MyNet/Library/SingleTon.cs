using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyNet.Library
{
    /// <summary>
    /// 用lock实现单例模式
    /// </summary>
    public class SingleTon
    {
        private static SingleTon singleton = new SingleTon();

        private SingleTon() { }

        public static SingleTon GetInstance()
        {
            if (singleton == null)
            {
                lock (singleton)
                {
                    if(singleton == null)
                        singleton = new SingleTon();
                }
            }
            return singleton;
        }

        public static void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() => { Console.WriteLine(GetInstance().GetHashCode()); });
                thread.Start();
            }

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() => { Console.WriteLine(new B().GetHashCode()); });
                thread.Start();
            }
        }

        public class B
        {

        }

        
    }
}
