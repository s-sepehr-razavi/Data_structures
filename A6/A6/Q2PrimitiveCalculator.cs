using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        public long[] Solve(long n)
        {
            long[] longs = new long[n + 1];

            for (int i = 1; i < longs.Length; i++)
			{

                longs[i] = longs[i - 1] + 1;
                if(i % 2 == 0)
                {
                    longs[i] = Math.Min(longs[i / 2] + 1, longs[i]);
                }
                if(i % 3 == 0)
                {
                    longs[i] = Math.Min(longs[i / 3] + 1, longs[i]);
                }
                

			}
            List<long> result = new List<long>();
            long a, m;
            result.Add(n);
            while(n != 1)
            {
                a = Int64.MaxValue;
                m = n;
                if(n % 3 == 0)
                {
                    
                       a = longs[n / 3];
                       m = n / 3;
                    
                }
                if(n % 2 == 0)
                {
                    if (longs[n / 2] < a)
                    {
                        a = longs[n / 2];
                        m = n / 2;
                    
                    }  
                    
                }
                if (longs[n - 1] < a)
                {
                    if (longs[n - 1] < a)
                    {
                        a = longs[n - 1];
                        m = n - 1;
                    }
                    
                }

                n = m;
                result.Add(n);
            }
            result.Reverse();
            return result.ToArray();
        }
    }
}
