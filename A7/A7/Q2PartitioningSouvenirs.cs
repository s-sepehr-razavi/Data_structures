using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            long sum = 0;
            if (souvenirsCount == 0)
            {
                return 0;
            }
            for (int i = 0; i < souvenirs.Length; i++)
            {
                sum+= souvenirs[i];
            }

            if (sum % 3 != 0)
            {
                return 0;
            }
            
            List<int> first_partition = selecting_one_third(sum / 3, souvenirs);
            if (first_partition == null)
            {
                return 0;
            }

            for (int i = 0; i < first_partition.Count; i++)
            {
                souvenirs[i] = -1;
            }

            List<long> remained_ = new List<long>();
            for (int i = 0; i < souvenirs.Length; i++)
            {
                if (souvenirs[i] != -1)
                {
                    remained_.Add(souvenirs[i]);
                }
            }

            List<int> second_partition = selecting_one_third(sum / 3, remained_.ToArray());

            if (second_partition == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public List<int> selecting_one_third(long W, long[] goldBars)
        {
            long[,] dp = new long[W + 1, goldBars.Length + 1];

            for (int i = 0; i <= W; i++)
            {
                dp[i, 0] = 0;
            }

            for (int i = 0; i <= goldBars.Length; i++)
            {
                dp[0, i] = 0;
            }

            for (int i = 1; i <= W; i++)
            {
                for (int j = 1; j <= goldBars.Length; j++)
                {
                    dp[i, j] = dp[i, j - 1];

                    if (goldBars[j - 1] <= i)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - goldBars[j - 1], j - 1] + goldBars[j - 1]);
                    }
                }
            }
            if (dp[W, goldBars.Length] == W)
            {
                return backtrack(dp, W, goldBars.Length, goldBars);
            }
            else
            {
                return null;
            }

            //for (int i = 0; i <= W; i++)
            //{
            //    for (int j = 0; j <= goldBars.Length; j++)
            //    {
            //        Console.Write(dp[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("selected bars:");
            //List<int> list = backtrack(dp, W, goldBars.Length, goldBars);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.Write(list[i] + " ");
            //}
            //return dp[W, goldBars.Length];
        }

        public List<int> backtrack(long[,] dp,long w, int bar_index, long[] gold_bars)
        {
            if (w == 0 || bar_index == 0)
            {
                return new List<int>();
            }
            //Console.WriteLine(bar_index);
            if (dp[w, bar_index - 1] == dp[w, bar_index])
            {
                return backtrack(dp, w, bar_index - 1, gold_bars);
            }
            else
            {
                List<int> list = backtrack(dp, w - gold_bars[bar_index - 1], bar_index - 1, gold_bars);
                list.Add(bar_index- 1);
                return list;
            }
        }

    }
}
