using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            long[,,] dp_cube = new long[seq1.Length, seq2.Length, seq3.Length];
            long[,] seq2_3 = find_bases(seq2, seq3, seq1[0]);
            long[,] seq1_2 = find_bases(seq1, seq2, seq3[0]);
            long[,] seq1_3 = find_bases(seq1, seq3, seq2[0]);
         /*   Console.WriteLine("seq2_3");
            for (int i = 0; i < seq2.Length; i++)
            {
                for (int j = 0; j < seq3.Length; j++)
			    {
                    Console.Write(seq2_3[i, j] + " ");
			    }
                Console.WriteLine();
            }
            Console.WriteLine("===========================================================================");
            Console.WriteLine("seq1_2");
            for (int i = 0; i < seq1.Length; i++)
            {
                for (int j = 0; j < seq2.Length; j++)
			    {
                    Console.Write(seq1_2[i, j] + " ");
			    }
                Console.WriteLine();
            }
            Console.WriteLine("===========================================================================");
            Console.WriteLine("seq1_3");
            for (int i = 0; i < seq1.Length; i++)
            {
                for (int j = 0; j < seq3.Length; j++)
			    {
                    Console.Write(seq1_3[i, j] + " ");
			    }
                Console.WriteLine();
            }
         */

            for (int i = 0; i < seq2.Length; i++)
			{
                for (int j = 0; j < seq3.Length; j++)
			    {
                    dp_cube[0, i, j] = seq2_3[i, j];
			    }
			}


            for (int i = 0; i < seq1.Length; i++)
			{
                for (int j = 0; j < seq2.Length; j++)
			    {
                    dp_cube[i, j, 0] = seq1_2[i, j];
			    }
			}

            for (int i = 0; i < seq1.Length; i++)
			{
                for (int j = 0; j < seq3.Length; j++)
			    {
                    dp_cube[i, 0, j] = seq1_3[i, j];
			    }
			}

            for (int i = 1; i < seq1.Length; i++)
			{
                for (int j = 1; j < seq2.Length; j++)
			    {
                    for (int k = 1; k < seq3.Length; k++)
			        {
                        if (seq1[i] == seq2[j] && seq1[i] == seq3[k])
                        {
                            dp_cube[i,j,k] = dp_cube[i-1,j - 1,k - 1] + 1;
                        }
                        else
                        {
                            dp_cube[i,j,k] = Math.Max(dp_cube[i,j,k - 1], dp_cube[i,j-1,k]);
                            dp_cube[i,j,k] = Math.Max(dp_cube[i - 1,j,k], dp_cube[i,j,k]);
                            dp_cube[i,j,k] = Math.Max(dp_cube[i - 1,j - 1,k], dp_cube[i,j,k]);
                            dp_cube[i,j,k] = Math.Max(dp_cube[i - 1,j,k - 1], dp_cube[i,j,k]);
                            dp_cube[i,j,k] = Math.Max(dp_cube[i,j - 1,k - 1], dp_cube[i,j,k]);

                        }
			        }
    			}
			}

            return dp_cube[seq1.Length - 1, seq2.Length - 1, seq3.Length - 1];
        }

        public long[,] find_bases(long[] seq1, long[] seq2, long i_0_seq)
        {
            long[,] dp = new long[seq1.Length, seq2.Length];
            int x = Int32.MaxValue, y = Int32.MaxValue;
            for (int i = 0; i < seq1.Length; i++)
			{
                for (int j = 0; j < seq2.Length; j++)
			    {
                    if(seq1[i] == seq2[j] && seq1[i] == i_0_seq)
                    {
//                        Console.WriteLine("here");
  //                      Console.WriteLine(i + " " + j) ;
                        x = i;
                        y = j;
                    }

                    if (i >= x && j >= y)
                    {
                        dp[i,j] = 1;
                    }
                    else
	                {
                        dp[i,j] = 0;
	                }
			    }
			}
            
            return dp;
        }

    }
}
