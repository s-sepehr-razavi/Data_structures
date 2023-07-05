using System;
using TestCommon;

namespace E1
{
    public class Q1 : Processor
    {
        public Q1(string testDataName) : base(testDataName)
        {
        }

        
        public override string Process(string inStr) => E1Processors.ProcessQ1(inStr, Solve);

        public long Solve(long n, long[] Tasks)
        {
            long time = 0;
            Array.Sort(Tasks);
            long x = 0;
            for (int i = 0; i < Tasks.Length; i++)
			{
                if(time < Tasks[i])
                {
                    x++;
                    time++;
                }
			}
            return x;
        }

    }
}
