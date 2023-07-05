using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        static long[] arr;

        public virtual long[] Solve(long n, long[] a)
        {
            arr = a;
            merge_sort(0,n-1);
            return a;
        }

        static void swap(long i, long j)
        {
            long tmp;
            tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        static void merge_sort(long left, long right)
        {
            if (left == right)
                return;
            long pivot = arr[right];
            long x = left - 1, y = right + 1;
            for (long i = left; i < y; i++)
            {
                if (arr[i] > pivot)
                {
                    while (arr[i] > pivot && y != i)
                    {
                        y--;
                        swap(y, i);
                    }
                    if (arr[i] < pivot)
                    {
                        x++;
                        swap(i, x);
                    }
                }
                else if (arr[i] < pivot)
                {
                    x++;
                    swap(i,x);
                }
            }
            if (x > left - 1)
                merge_sort(left, x);
            if (y < right + 1)
                merge_sort(y, right);
            return;
        }
        
    }
}
