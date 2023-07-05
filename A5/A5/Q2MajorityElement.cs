using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            long[] x = find_the_most_repeated_number(a, 0, a.Length - 1);
            
            return (x[1] > n / 2) ? 1: 0;
        }

        long[] find_the_most_repeated_number(long[] array, int l, int r)
        {


            if (r == l)
            {
                long[] ret = new long[2];
                ret[0] = array[l];
                ret[1] = 1;
                return ret;
            }

            int m = (r - l) / 2 + l;

            long[] l_result = find_the_most_repeated_number(array, l, m);
            long[] r_result = find_the_most_repeated_number(array, m + 1, r);
            

            for (int i = l; i <= m; i++)
            {
                if (r_result[0] == array[i])
                {
                    r_result[1]++;
                }
            }

            for (int i = m + 1; i <= r; i++)
            {
                if (l_result[0] == array[i])
                {
                    l_result[1]++;
                }
            }

            return (r_result[1] > l_result[1]) ? r_result : l_result;
        }

    }
}
