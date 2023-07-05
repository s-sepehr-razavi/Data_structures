using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long m, long n)
        {
            /*  int[] arr = new int[100];
              long i = 2;
              arr[0] = 0;
              arr[1] = 1;
              arr[2] = 1;
              while (arr[i] != 1 || arr[i - 1] != 0) {
                  arr[i + 1] = (arr[i] + arr[i - 1]) % 10;
                  i++;
              }
              i--;
              int a = arr[(n + 2) % i];
              int b = arr[(m + 1) % i];
              int c = a - b;
              if (c < 0)
              {
                  c += 10;
              }

              return c;
            */
            long x;
            if (n < m)
            {
                x = m;
                m = n;
                n = x;
            }
          return (sum(n) - sum(m - 1) + 10) % 10;
        }
        public long sum(long n)
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
