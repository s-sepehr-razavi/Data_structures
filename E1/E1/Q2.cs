using System;
using TestCommon;

namespace E1
{
    public class Q2 : Processor
    {
        public Q2(string testDataName) : base(testDataName)
        {
        }

        
        public override string Process(string inStr) => E1Processors.ProcessQ2(inStr, Solve);

        public long Solve(long n, long k)
        {
           /* Console.WriteLine("n = " + n);
            Console.WriteLine("k = " + k);*/
            
            long two_pow_n_minus_1 = (long)Math.Pow(2, n - 1);

            if(k == two_pow_n_minus_1)
            {
                return n;
            }
            else
	        {
                return Solve(n - 1, k % (two_pow_n_minus_1));
	        }
        }
    }
}
