using System;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long n, long m)
        {
                         
        long[] arr = new long[1000000];
        int i = 2;
        arr[0] = 0;
        arr[1] = 1;
        arr[2] = 1;
        //cout << "0 1 1 ";
        while (arr[i] != 1 || arr[i - 1] != 0) {
            arr[i + 1] = (arr[i] + arr[i - 1]) % m;

            i++;
            //cout << arr[i] << " ";
        }
        i--;
        /*cout << "\n" << "====================================================================================";
        cout << "\n" << "i = " << i;*/
        return arr[n % i];
        }
    }
}
