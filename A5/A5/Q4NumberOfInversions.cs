using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions:Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] a)
        {
            //write your code here
            return sort(a);
        }

         static long sort(long[] arr)
         {
            if (arr.Length == 1)
            {
                return 0;
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

            long left_invs = sort(left);
            long right_invs =sort(right);

            return merge_non_rec(left, right, arr, left_invs, right_invs);
         }

        static long merge_non_rec(long[] arr1, long[] arr2, long[] merged, long arr1_inv, long arr2_inv)
        {
            int i = 0;
            int j = 0;
            long inv_count = arr1_inv + arr2_inv;

            for (int k = 0; k < merged.Length; k++)
			{   
                if (j < arr2.Length && i < arr1.Length)
                {
                    if (arr2[j] < arr1[i])
	                {
                        merged[k] = arr2[j];
                        inv_count += (arr1.Length - i);
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
                        if (arr1[arr1.Length - 1] > arr2[j])
                        {
                            inv_count++;
                        }
                        j++;
                    }
                    
                    else if (j >= arr2.Length)
                    {
                        merged[k] = arr1[i];
                        i++;
                    }

                }
                
			}
            return inv_count;
        }

    }
}
