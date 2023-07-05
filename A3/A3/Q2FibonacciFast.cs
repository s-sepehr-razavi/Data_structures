using System;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            
            long a = 0;
            long b = 1;

            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }
            long c;
            for (int i = 1; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return b;
        }
    }
}
