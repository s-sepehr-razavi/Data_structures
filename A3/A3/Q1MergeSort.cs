using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] arr)
        {
           sort(arr);
            return arr;
        }

         static void sort(long[] arr)
         {
            if (arr.Length == 1)
            {
                return;
            }
            
            int mid_index = arr.Length / 2;
            long[] left = new long[mid_index];
            for (int i = 0; i < mid_index; i++)
            {
                left[i] = arr[i];
            }
            long[] right = new long[arr.Length - mid_index];
            for (int i = mid_index; i < arr.Length; i++)
            {
                right[i - mid_index] = arr[i];
            };

            sort(left);
            sort(right);

            merge_non_rec(left, right, arr);
         }


        static void merge(long[] arr1, long[] arr2, int i, int j,int k, long[] merged)
        {

            for (int v = 0; v < k; v++)
            {
            }
            if (k == merged.Length)
            {
                return;
            }
            try
            {
                if (arr1[i] > arr2[j])
                {
                    merged[k] = arr2[j];
                    merge(arr1, arr2, i, j + 1, k + 1, merged);
                }
                else
                {
                    merged[k] = arr1[i];
                    merge(arr1, arr2, i + 1, j, k + 1, merged);
                }
            }
            catch (Exception)
            {
                if (j >= arr2.Length)
                {
                    merged[k] = arr1[i];
                    merge(arr1, arr2, i + 1, j, k + 1, merged);
                }
                else if (i >= arr1.Length)
                {
                    merged[k] = arr2[j];
                    merge(arr1, arr2, i, j + 1, k + 1, merged);
                }

                
                
            }

            return;
        }

        static void merge_non_rec(long[] arr1, long[] arr2, long[] merged)
        {
            int i = 0;
            int j = 0;

            for (int k = 0; k < merged.Length; k++)
			{   
                if (j < arr2.Length && i < arr1.Length)
                {
                    if (arr2[j] < arr1[i])
	                {
                        merged[k] = arr2[j];
                        j++;
                    }
                    else
                    {
                        merged[k] = arr1[i];
                        i++;
                    }
                }
                else
                {
                    if (i >= arr1.Length)
                    {
                        merged[k] = arr2[j];
                        j++;
                    }
                    
                    else if (j >= arr2.Length)
                    {
                        merged[k] = arr1[i];
                        i++;
                    }

                }
                
			}
        }
    }
}
