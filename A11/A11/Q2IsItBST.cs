using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q2IsItBST : Processor
    {
        public Q2IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            Q1BinaryTreeTraversals q1Binary = new Q1BinaryTreeTraversals("ss");
            long[] in_order = q1Binary.Solve(nodes)[0];

            for (int i = 0; i < in_order.Length - 1; i++)
            {
                if (in_order[i] > in_order[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
