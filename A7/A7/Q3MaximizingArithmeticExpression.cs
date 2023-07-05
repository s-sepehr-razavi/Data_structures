using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        long[,] min_sub;
        long[,] max_sub;
        string ops;

        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            long[] nums = Array.ConvertAll(expression.Split(new char[] { '+', '-', '*' }), s => long.Parse(s));

            char c;
            ops = "";
            for (int i = 0; i < expression.Length; i++)
            {
                c = expression[i];
                if (c == '+' || c == '-' || c == '*')
                {
                    ops += c;
                }
            }

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    Console.WriteLine(nums[i]);
            //}

            //Console.WriteLine(ops);

            min_sub = new long[nums.Length, nums.Length];
            max_sub = new long[nums.Length, nums.Length];
            
            for (int i = 0; i < nums.Length; i++)
            {
                max_sub[i, i] = nums[i];
                min_sub[i, i] = nums[i];
            }

            int row;
            int coloumn;
            long[] min_max;
            for (int a = 1; a < nums.Length; a++)
            {
                for (int b = a; b < nums.Length; b++)
                {
                    coloumn = b;
                    row = b - a;

                    min_max = find_min_max(row, coloumn);
                    //Console.WriteLine(min_max[0] + ", " + min_max[1] + "\n");
                    min_sub[row, coloumn] = min_max[0];
                    max_sub[row, coloumn] = min_max[1]; 
                }
            }
            //Console.WriteLine("max_vals:");
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = 0; j < nums.Length; j++)
            //    {
            //        Console.Write(max_sub[i, j] + " ");
            //    }

            //    Console.WriteLine();    
            //}

            //Console.WriteLine("\nmin_vals:");
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = 0; j < nums.Length; j++)
            //    {
            //        Console.Write(min_sub[i, j] + " ");
            //    }

            //    Console.WriteLine();
            //}
            Console.WriteLine(ops);
            Console.WriteLine(max_sub[0, nums.Length - 1]);
            return max_sub[0, nums.Length - 1];

        }

        long[] find_min_max(int i, int j)
        {
            long[] answer = new long[] {long.MaxValue, long.MinValue};
            
            for (int k = i; k < j; k++) // k is the index seperates the expression  (i, k) \ (k + 1, j)
            {
                switch (ops[k])
                {
                    case '+':
                        answer[0] = Math.Min(answer[0], max_sub[i, k] + max_sub[k + 1, j]);
                        answer[0] = Math.Min(answer[0], min_sub[i, k] + max_sub[k + 1, j]);
                        answer[0] = Math.Min(answer[0], max_sub[i, k] + min_sub[k + 1, j]);
                        answer[0] = Math.Min(answer[0], min_sub[i, k] + min_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], max_sub[i, k] + max_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], min_sub[i, k] + max_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], max_sub[i, k] + min_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], min_sub[i, k] + min_sub[k + 1, j]);
                        break;

                    case '-':
                        answer[0] = Math.Min(answer[0], max_sub[i, k] - max_sub[k + 1, j]);
                        answer[0] = Math.Min(answer[0], min_sub[i, k] - max_sub[k + 1, j]);
                        answer[0] = Math.Min(answer[0], max_sub[i, k] - min_sub[k + 1, j]);
                        answer[0] = Math.Min(answer[0], min_sub[i, k] - min_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], max_sub[i, k] - max_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], min_sub[i, k] - max_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], max_sub[i, k] - min_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], min_sub[i, k] - min_sub[k + 1, j]);
                        break;

                    case '*':
                        answer[0] = Math.Min(answer[0], max_sub[i, k] * max_sub[k + 1, j]);
                        answer[0] = Math.Min(answer[0], min_sub[i, k] * max_sub[k + 1, j]);
                        answer[0] = Math.Min(answer[0], max_sub[i, k] * min_sub[k + 1, j]);
                        answer[0] = Math.Min(answer[0], min_sub[i, k] * min_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], max_sub[i, k] * max_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], min_sub[i, k] * max_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], max_sub[i, k] * min_sub[k + 1, j]);
                        answer[1] = Math.Max(answer[1], min_sub[i, k] * min_sub[k + 1, j]);
                        break;
                }
            }

            return answer;
        }
    }
}
