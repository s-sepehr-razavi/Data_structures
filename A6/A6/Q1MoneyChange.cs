using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            long[] changes = new long[n + 1];
            changes[0] = 0;

            for (int i = 1; i < changes.Length; i++)
			{
                changes[i] = Int64.MaxValue;
                for (int j = 0; j < COINS.Length; j++)
			    {

                    if(COINS[j] <= i)
                    {
                        changes[i] = Math.Min(changes[i - COINS[j]] + 1, changes[i]);
                    }
			    }
			}
            return changes[n];
        }
    }
}
