using System;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {
        long[] parent;
        long[] rank;
        long[] table;

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        

        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
            parent = new long[tableSizes.Length];
            rank = new long[tableSizes.Length];
            table = tableSizes;
            long max_val = long.MinValue;
            long[] answer = new long[sourceTables.Length];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
                rank[i] = 0;
                max_val = Math.Max(max_val, table[i]);
            }

            for (int i = 0; i < targetTables.Length; i++)
            {
                max_val = Math.Max(union(targetTables[i] - 1, sourceTables[i] - 1), max_val);
                answer[i] = max_val;
            }


            return answer;
        }

        public long find_address(long i)
        {
            if (parent[i] != i)
            {
                parent[i] = find_address(parent[i]);
                table[parent[i]] += table[i];
                table[i] = 0;
            }
            return parent[i];
        }

        public long union(long i, long j)
        {
            long address_i = find_address(i);
            long address_j = find_address(j);

            if (address_i == address_j)
            {
                return table[address_i];
            }

            if (rank[address_i] > rank[address_j])
            {
                parent[address_j] = address_i;
                table[address_i] += table[address_j];
                table[address_j] = 0;
            }
            else
            {
                parent[address_i] = address_j;
                table[address_j] += table[address_i];
                table[address_i] = 0;
            }

            if (rank[address_i] == rank[address_j])
            {
                rank[address_j]++;
            }

            return table[address_i] + table[address_j];
        }
        
    }
}
