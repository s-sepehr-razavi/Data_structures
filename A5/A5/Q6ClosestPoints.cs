using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
        TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        static double distance(long x1, long y1, long x2, long y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
       public virtual double Solve(long n, long[] X, long[] Y)
        {
            Array.Sort(X, Y);
            double closest = find_closest_pair(X, Y);
            closest = ((long)(closest * 10000 + 0.5) / 10000.0);
            return closest;
        }

        static double find_closest_pair(long[] X, long[] Y)
        {
            if (X.Length == 1)
            {
                return Double.MaxValue;
            }
            long line = X[X.Length / 2];

            long[] left_X = new long[X.Length / 2];
            long[] left_Y = new long[X.Length / 2];
            for (int i = 0; i < left_X.Length; i++)
            {
                left_X[i] = X[i];
                left_Y[i] = Y[i];
            }

            long[] right_X = new long[X.Length - X.Length / 2];
            long[] right_Y = new long[X.Length - X.Length / 2];
            for (int i = X.Length / 2; i < X.Length; i++)
            {
                right_X[i - X.Length / 2] = X[i];
                right_Y[i - X.Length / 2] = Y[i];
            }

            double d_l = find_closest_pair(left_X, left_Y);
            double d_r = find_closest_pair(right_X, right_Y);
            double d = Math.Min(d_l, d_r);

            List<long> within_d_range_X = new List<long>();
            List<long> within_d_range_Y = new List<long>();
            for (int i = 0; i < X.Length; i++)
            {
                if (Math.Abs(X[i] - line) < d)
                {
                    within_d_range_X.Add(X[i]);
                    within_d_range_Y.Add(Y[i]);
                }
            }

            long[] within_d_range_X_arr = within_d_range_X.ToArray();
            long[] within_d_range_Y_arr = within_d_range_Y.ToArray();
            Array.Sort(within_d_range_Y_arr, within_d_range_X_arr);

            double min = d;
            for (int i = 0; i < within_d_range_X_arr.Length; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    if (i + j < within_d_range_X_arr.Length)
                    {
                        min = Math.Min(min, distance(within_d_range_X_arr[i], within_d_range_Y_arr[i], within_d_range_X_arr[i + j], within_d_range_Y_arr[i + j]));
                    }
                }
            }
            return min;
        }


    }
}