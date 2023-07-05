using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {   
            long number_to_subtract = 1;
            int counter = 0;
            List<long> answer = new List<long>();
            while (true)
            {
                if (n - number_to_subtract > 0)
                {
                    n -= number_to_subtract;
                    answer.Add(number_to_subtract);
                    counter++;
                    number_to_subtract++;
                }
                else if (n - number_to_subtract == 0)
                {
                    answer.Add(number_to_subtract);
                    counter++;
                    break;
                }
                else
                {
                    answer[counter - 1] += n;
                    break;
                }
            }
            long[] real_answer = new long[counter];
                for (int i = 0; i < counter; i++)
			    {
                    real_answer[i] = answer[i];
			    }
                return real_answer;
        }
    }
}

