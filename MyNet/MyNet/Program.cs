using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace MyNet
{
    public class Program
    {
        public static void Main(String[] args)
        {
            double n = Library.Algorithm.Work.Power(2.0, 3);
            Console.WriteLine(n);
        }
    }
    
}


   
