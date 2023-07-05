using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long []a, long[] b) 
        {
            long[] ans = new long[b.Length];
            for (int i = 0; i < b.Length; i++)
			{
                ans[i] = bs(a, b[i], 0, a.Length - 1);
			}
            return ans;
        }

        long bs(long[] a, long p, int l, int r)
        {
            int m = (r - l) / 2;
            if (l > r)
            {
                return -1;
            }

            if (a[m + l] == p)
            {
                return (long)(m + l);
            }

            if (a[m + l] < p)
            {
                return bs(a, p, m + l + 1, r);
            }

            if (a[m + l] > p)
            {
                return bs(a, p, l, m + l - 1);
            }
            return -1;
        }
    }
}
