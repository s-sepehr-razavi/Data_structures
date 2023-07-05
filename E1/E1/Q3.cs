using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace E1
{
    public class Q3 : Processor
    {
        public Q3(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) => E1Processors.ProcessQ3(inStr, Solve);

        public static long Solve(long n, long[] A)
        {
            throw new NotImplementedException();
        }
    }
}
