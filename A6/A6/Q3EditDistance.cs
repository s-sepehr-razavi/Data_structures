using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            
            int[,] distances = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                distances[i, 0] = i;
            }

            for (int i = 0; i <= str2.Length; i++)
            {
                distances[0, i] = i;
            }

            int del;
            int ins;
            int mat_mis;
            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    del = distances[i - 1, j] + 1;
                    ins = distances[i, j - 1] + 1;
                    if (str1[i - 1] == str2[j - 1])
                    {
                        mat_mis = distances[i - 1, j - 1];
                    }
                    else
                    {
                        mat_mis = distances[i - 1, j - 1] + 1;
                    }

                    distances[i, j] = Math.Min(Math.Min(del, ins), mat_mis);
                }
            }
            //for (int i = 0; i < str1.Length; i++)
            //{
            //    for (int j = 0; j < str2.Length; j++)
            //    {
            //        Console.Write(distances[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            return (long)distances[str1.Length, str2.Length];
        }
    }
}
