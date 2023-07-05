using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    class node
    {
        public int value;
        public string direction;
        public node(int value, string direction)
        {
            this.value = value;
            this.direction = direction;
        }
    }

    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            long[,] dp = new long[seq1.Length, seq2.Length];
            bool flag = false;

            for (int i = 0; i < seq2.Length; i++)
			{
                if (seq1[0] == seq2[i])
                {
                    flag = true;
                }

                if (flag)
                {
                    dp[0, i] = 1;
                }
                else
                {
                    dp[0, i] = 0;
                }
			}
            flag = false;
            for (int i = 0; i < seq1.Length; i++)
			{
                if (seq1[i] == seq2[0])
                {
                    flag = true;
                }

                if (flag)
                {
                    dp[i, 0] = 1;
                }
                else
                {
                    dp[i, 0] = 0;
                }
			}

            for (int i = 1; i < seq1.Length; i++)
			{
                for (int j = 1; j < seq2.Length; j++)
			    {
                    if (seq1[i] == seq2[j])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
	                {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
	                }
			    }
			}
            return dp[seq1.Length - 1, seq2.Length - 1];
        }



       /* static node[,] make_array(long[] str1, long[] str2)
        {
            node[,] distances = new node[str1.Length + 1, str2.Length + 1];

            distances[0, 0] = new node(0, "-");
            for (int i = 1; i <= str1.Length; i++)
            {
                distances[i, 0] = new node(i, "l");
            }

            for (int i = 1; i <= str2.Length; i++)
            {
                distances[0, i] = new node(i, "u");
            }

            int del;
            int ins;
            int mat_mis;
            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    del = distances[i - 1, j].value + 1;
                    ins = distances[i, j - 1].value + 1;
                    if (str1[i - 1] == str2[j - 1])
                    {
                        mat_mis = distances[i - 1, j - 1].value;
                    }
                    else
                    {
                        mat_mis = distances[i - 1, j - 1].value + 1;
                    }
                    distances[i, j] = new node(-1, "");
                    distances[i, j].value = Math.Min(Math.Min(del, ins), mat_mis);

                    if (distances[i, j].value == del)
                    {
                        distances[i, j].direction = "l";
                    }
                    else if (distances[i, j].value == ins)
                    {
                        distances[i, j].direction = "u";
                    }
                    else
                    {
                        distances[i, j].direction = "d";
                    }
                }
            }

            return distances;
        }

        static List<long?>[] backtrack(node[,] distances, int i, int j, long[] str1, long[] str2)
        {
            List<long?> str1_list = new List<long?>();
            List<long?> str2_list = new List<long?>();
            List<long?>[] strings = {str1_list, str2_list};
            int counter = 1;
            while (true)
            {
                if (i == 0 && j == 0)
                {
                        return strings;
                }

                if (distances[i, j].direction == "l")
                {
                    strings[0].Add(str1[i - 1]);
                    strings[1].Add(null);
                    i--;
                }

                if (distances[i, j].direction == "u")
                {
                    strings[0].Add(null);
                    strings[1].Add(str2[j - 1]);
                    j--;
                }

                if (distances[i, j].direction == "d")
                {
                    strings[0].Add(str1[i - 1]);
                    strings[1].Add(str2[j - 1]);
                    i--;
                    j--;
                }
            }
        }

        static long count_matches(List<long?> str1, List<long?> str2)
        {
            for (int i = 0; i < str1.Count; i++)
			{
                if (str1[i] == null)
                {
                    Console.Write("--- ");
                }
                else
                {
                    Console.Write(str1[i] + " ");
                }
			}
            Console.WriteLine();
            Console.WriteLine("==================================================================================================================================================================================================================");
            for (int i = 0; i < str2.Count; i++)
			{
                if (str2[i] == null)
                {
                    Console.Write("--- ");
                }
                else
                {
                    Console.Write(str2[i] + " ");
                }
			}


            int counter = 0;
            for (int i = 0; i < str1.Count; i++)
            {
                if (str1[i] == str2[i])
                {
                    counter++;
                }
            }
            return counter;
        }*/
        

    }
}
