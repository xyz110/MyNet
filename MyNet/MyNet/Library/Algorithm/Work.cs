using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNet.Library.Algorithm
{
    public class Work
    {
        /// <summary>
        /// 这是一个数学题,有一头牛它每年生一头小牛,那只小牛四年生一头牛.那么二十年后会
        ///有一头母牛，它每年初生一头小母牛，每头小母牛从第四个年头起，每年年初也生一头小母牛，那么第二十年时，共有多少头牛
        /// </summary>
        /// <param name="n">N年后</param>
        /// <param name="flag">初始牛的状态，true为成年牛，flase为刚生的小牛</param>
        /// <returns></returns>
        public static int CattleNumRecursive(int n ,bool flag)
        {
            if (flag)
            {
                if (n == 1)
                {
                    return 2;
                }
                else if (n == 2)
                {
                    return 3;
                }
                else if (n == 3)
                {
                    return 4;
                }
                else
                {
                    return CattleNumRecursive(n - 3,flag) + CattleNumRecursive(n - 1,flag);
                }
            }
            else
            {
                if (n == 1 || n == 2 || n == 3)
                {
                    return 1;
                }
                else if (n == 4)
                {
                    return 2;
                }
                else if (n == 5)
                {
                    return 3;
                }
                else if (n == 6)
                {
                    return 4;
                }
                else
                {
                    return CattleNumRecursive(n - 3, flag) + CattleNumRecursive(n - 1, flag);
                }
            }
            
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="y">y年可以长大生小牛</param>
        /// <param name="flag">初始牛的状态，true为成年牛，flase为刚生的小牛</param>
        /// <returns></returns>
        public static int CattleNumRecursive(int n,int y, bool flag)
        {
            if (flag)
            {
                if (n < y)
                {
                    return n + 1;
                }
                else
                {
                    return CattleNumRecursive(n - y + 1, flag) + CattleNumRecursive(n - 1, flag);
                }
            }
            else
            {
                if (n < y)
                {
                    return 1;
                }
                if (n <= 2 * (y - 1))
                {
                    return n + 2 - y;
                }
                else
                {
                    return CattleNumRecursive(n - 3, flag) + CattleNumRecursive(n - 1, flag);
                }
            }

        }

        public int NumberOf1(int n)
        {
            int count = 0;

            for (int i = 0; i < 32; i++)
            {

                if (((n >> i) & 1)==1)

                    ++count;

            }

            return count;
        }
        public static double Power(double thebase, int exponent)
        {
            if (exponent == 0)
                return 1;
            double s = 1.0;
            int n = (exponent >= 0) ? exponent : (-1 * exponent);
            for (int i = 1; i <= n; i++)
            {
                s *= thebase;
            }
            
            return s;
        }
    }

    public class Solution
    {

        public void reOrderArray(int[] array)
        {

            int len = array.Length;

            int count1 = 0;

            int count2 = 0;

            int[] arr1 = new int[len];

            int[] arr2 = new int[len];

            for (int i = 0; i < len; i++)
            {

                if (array[i] % 2 == 0)
                {

                    arr2[count2++] = array[i];

                }
                else
                {

                    arr1[count1++] = array[i];

                }

            }

            for (int i = 0; i < count1; i++)
            {

                array[i] = arr1[i];

            }

            for (int i = 0; i < count2; i++)
            {

                array[count1 + i] = arr2[i];

            }

        }

    }

}
