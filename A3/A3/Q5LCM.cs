using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            long d = gcd(a, b);
	        a = a / d;
	        b = b / d;
	        return a * b * d;
        }

        
        public long gcd(long a, long b)
        {
            if (b > a) 
			{
				long h = a;
				a = b;
				b = h;
			}

			long d = b;
			long x = a;
			long y = b;

			while (a % d != 0 || b % d != 0)
			{
				d = x % d;
				x = y;
				y = d;
			}

			return d;
        }

    }
}
