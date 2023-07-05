using System;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            int[] arr = new int[100];
            int i = 2;
            arr[0] = 0;
            arr[1] = 1;
            arr[2] = 1;
            while (arr[i] != 1 || arr[i - 1] != 0) {
                arr[i + 1] = (arr[i] + arr[i - 1]) % 10;

                i++;
            }
            i--;
            return (arr[(n + 2) % i] + 9) % 10;
        }
    }
}
