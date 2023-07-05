using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);


        /*static long is_it_better(long test, long max)
        {
            long a = Math.Max(test, max);
            long aa = a;
            long b = Math.Min(test, max);
            long bb = b;

            List<long> list_a = new List<long>();
            List<long> list_b = new List<long>();

            while (aa != 0)
	        {
             list_a.Add(aa % 10);
             aa /= 10;
	        }
            list_a.Reverse();

            while (bb != 0)
	        {
             list_b.Add(bb % 10);
             bb /= 10;
	        }
            list_b.Reverse();

            if (list_a.Count != list_b.Count)
	        {
                for (int i = 0; i < list_a.Count - list_b.Count; i++)
			    {
                    list_b.Add(list_a[i]);
			    }
        	}

            for (int i = 0; i < list_b.Count; i++)
			{
                if (list_b[i] > list_a[i])
                {
                    return b;
	            }
                else if (list_b[i] < list_a[i])
	            {
                    return a;
	            }

			}
            return a;
        }*/

        static long is_it_better(long test, long max)
        {
            string a = test.ToString() + max.ToString();
            string b = max.ToString() + test.ToString();

            long la = Convert.ToInt64(a);
            long lb = Convert.ToInt64(b);

            if (la > lb)
	        {
                 return test;
	        }
            else return max;
        }
        

        public virtual string Solve(long n, long[] numbers)
        {
            string answer = "";
            List<long> nums = new List<long>();
            for (int i = 0; i < numbers.Length; i++)
			{
                nums.Add(numbers[i]);
			}
            /*for (int i = 0; i < numbers.Length; i++)
			{
                Console.WriteLine(numbers[i]);
			}*/
            while (nums.Count != 0)
            {
            //Console.WriteLine("here");
                long best_choice = nums[0];
                int best_index = 0;
                for (int i = 0; i < nums.Count; i++)
			    {
                    best_choice = is_it_better(nums[i], best_choice);
                    if(nums[i] == best_choice) 
                    {
                        best_index = i;
                    }
			    }
                answer += best_choice;
                nums.RemoveAt(best_index);
              //  Console.WriteLine(nums.Count);
            }
            
           return answer;
        }

    }
}

