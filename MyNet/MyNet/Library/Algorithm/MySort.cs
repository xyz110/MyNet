using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNet.Library.Algorithm
{


    public class MySort
    {

        //public static void Main(String[] args)
        //{
        //    // TODO Auto-generated method stub
        //    int[] data = new int[10];
        //    for (int i = 0; i < 10; i++)
        //    {
        //        data[i] = (int)(new Random().Next(100));
        //        for (int j = 0; j < i; j++)
        //        {
        //            if (data[j] == data[i])
        //            {
        //                i--;
        //                break;
        //            }
        //        }
        //    }
        //    print(data);
        //    // insertSort(data);
        //    // bubbleSort(data);
        //    // shellSort(data);
        //    // selectSort(data);
        //    // heapSort(data);
        //    // quickSort(data);
        //    //mergeSort(data);
        //    radixSort(data);
        //    print(data);
        //}


        // 冒泡排序

        public static void bubbleSort(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        int temp = data[j + 1];
                        data[j + 1] = data[j];
                        data[j] = temp;
                    }
                }
            }
        }

        // 插入排序
        public static void insertSort(int[] data)
        {
            int j;
            for (int i = 1; i < data.Length; i++)
            {
                int currentData = data[i];
                for (j = i; j >= 1 && currentData < data[j]; j--)
                {
                    data[j] = data[j - 1];
                }
                data[j] = currentData;
            }
        }

        // 希尔排序
        public static void shellSort(int[] data)
        {
            int j;
            for (int gaps = data.Length / 2; gaps > 0; gaps /= 2)
            {
                for (int i = gaps; i < data.Length; i++)
                {
                    int currentData = data[i];
                    for (j = i; j >= gaps && currentData < data[j - gaps]; j -= gaps)
                    {
                        data[j] = data[j - gaps];
                    }
                    data[j] = currentData;
                }
            }
        }

        // 选择排序
        public static void selectSort(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                int min = data[i];
                int index = i;
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[j] < min)
                    {
                        min = data[j];
                        index = j;
                    }
                }
                data[index] = data[i];
                data[i] = min;
            }
        }

        private static int leftChild(int i)
        {
            return 2 * i + 1;
        }

        private static void swap(int[] data, int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        // 构建二叉堆
        private static void buildMaxHeap(int[] data, int lastIndex)
        {
            for (int i = data.Length / 2 - 1; i >= 0; i--)
            {
                int child;
                int temp;
                for (temp = data[i]; leftChild(i) < lastIndex; i = child)
                {
                    child = leftChild(i);
                    if (child != lastIndex - 1 && data[child] < data[child + 1])
                        child++;
                    if (temp < data[child])
                        data[i] = data[child];
                    else
                        break;
                }
                data[i] = temp;
            }
        }

        // 堆排序
        public static void heapSort(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                buildMaxHeap(data, data.Length - 1 - i);
                swap(data, 0, data.Length - 1 - i);
            }
        }

        private static int getMiddle(int[] data, int left, int right)
        {
            int temp = data[left];
            while (left < right)
            {
                while (left < right && data[right] > temp)
                {
                    right--;
                }
                data[left] = data[right];
                while (left < right && data[left] < temp)
                {
                    left++;
                }
                data[right] = data[left];
            }
            data[left] = temp;
            return left;
        }

        private static void quickSort(int[] data, int left, int right)
        {
            if (left < right)
            {
                int middle = getMiddle(data, left, right);
                quickSort(data, left, middle - 1);
                quickSort(data, middle + 1, right);
            }
        }

        // 快速排序
        public static void quickSort(int[] data)
        {
            quickSort(data, 0, data.Length - 1);
        }

        private static void merge(int[] data, int[] temp, int leftPos, int rightPos, int rightEnd)
        {
            int leftEnd = rightPos - 1;
            int numElement = rightEnd - leftPos + 1;
            int tempPos = leftPos;
            while (leftPos <= leftEnd && rightPos <= rightEnd)
            {
                if (data[leftPos] <= data[rightPos])
                {
                    temp[tempPos++] = data[leftPos++];
                }
                else
                {
                    temp[tempPos++] = data[rightPos++];
                }
            }
            while (leftPos <= leftEnd)
                temp[tempPos++] = data[leftPos++];
            while (rightPos <= rightEnd)
                temp[tempPos++] = data[rightPos++];
            for (int i = 0; i < numElement; i++, rightEnd--)
            {
                data[rightEnd] = temp[rightEnd];
            }

        }

        private static void mergeSort(int[] data, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int middel = (left + right) / 2;
                mergeSort(data, temp, left, middel);
                mergeSort(data, temp, middel + 1, right);
                merge(data, temp, left, middel + 1, right);
            }
        }

        // 归并排序
        public static void mergeSort(int[] data)
        {
            int[] temp = new int[data.Length];
            mergeSort(data, temp, 0, data.Length - 1);
        }

        /**
         * 
         * @param a
         * @param radix
         *            基数
         * @param distance
         *            数组中最大的位数
         */
        public static void radixSort(int[] data, int radix, int distance)
        {
            int divide = 1;
            int[] count = new int[radix];
            for (int i = 0; i < distance; i++)
            {
                int[] tmp = new int[data.Length];
                data.CopyTo(tmp, 0);
                ArrayList.Repeat(0, count.Length).CopyTo(count);
                // 计算基数
                for (int j = 0; j < data.Length; j++)
                {
                    int key = tmp[j] / divide % radix;
                    count[key]++;
                }
                // 储存每个基数个数
                for (int j = 1; j < count.Length; j++)
                {
                    count[j] = count[j] + count[j - 1];
                }
                // 重排
                for (int j = data.Length - 1; j >= 0; j--)
                {
                    int key = tmp[j] / divide % radix;
                    count[key]--;
                    data[count[key]] = tmp[j];
                }
                divide *= radix;
            }
        }

        public static void radixSort(int[] data)
        {
            int radix = 10;
            int max = data[0];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > max)
                    max = data[i];
            }
            int distince;
            for (distince = 0; max != 0; distince++)
            {
                max = max / radix;
            }
            radixSort(data, radix, distince);
        }
        
        public static void print(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
        }
    }

}
