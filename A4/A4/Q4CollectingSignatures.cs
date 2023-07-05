using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            
            Array.Sort(endTimes, startTimes);
            List<long> times = new List<long>();
            times.Add(endTimes[0]);
            long the_last_time_visited = endTimes[0];
            for (int i = 0; i < endTimes.Length; i++)
			{
                if (the_last_time_visited < startTimes[i])
	            {
                    the_last_time_visited = endTimes[i];
                    times.Add(the_last_time_visited);
	            }
			}

            return times.Count;
        }
    }
}
