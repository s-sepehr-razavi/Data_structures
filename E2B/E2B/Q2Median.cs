using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PriorityQueues;
using TestCommon;

namespace E2
{
    public class Q2Median : Processor
    {
        public Q2Median(string testDataName) : base(testDataName)
        { }

        PriorityQueue<long> bellow_median;
        PriorityQueue<long> over_median;
        double median;
        public override string Process(string inStr) => E2Processors.ProcessQ2Median(inStr, Solve);

        public void update()
        {
            if (bellow_median.Count() == over_median.Count())
            {
                median = over_median.Peek() - bellow_median.Peek();
                median /= 2;
                return;
            }

            if (bellow_median.Count() == over_median.Count() + 1)
            {
                median = (-1)*bellow_median.Peek();
                return;
            }

            if (over_median.Count() == bellow_median.Count() + 1)
            {
                median = over_median.Peek();
                return;
            }

            if (bellow_median.Count() == over_median.Count() + 2)
            {
                over_median.Enqueue(bellow_median.Dequeue() * (-1));
                median = over_median.Peek() - bellow_median.Peek();
                median /= 2;
                return;
            }

            if (over_median.Count() == bellow_median.Count() + 2)
            {
                bellow_median.Enqueue(over_median.Dequeue() * (-1));
                median = over_median.Peek() - bellow_median.Peek();
                median /= 2;
                return;
            }
        }

        public String Solve(long n,long[] arr)
        {
            bellow_median = new PriorityQueue<long>();
            over_median = new PriorityQueue<long>();
            List<double> list = new List<double>();
            StringBuilder stringBuilder= new StringBuilder();

            over_median.Enqueue(arr[0]);
            median = arr[0];
            //list.Add(median);
            stringBuilder.Append(median.ToString("0.0"));
            stringBuilder.Append('\n');

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] >= median)
                {
                    over_median.Enqueue(arr[i]);
                }
                else
                {
                    bellow_median.Enqueue((-1)*arr[i]);
                }

                update();
                //list.Add(median);
                stringBuilder.Append(median.ToString("0.0"));
                if(i != arr.Length - 1)
                stringBuilder.Append('\n');
            }
            return stringBuilder.ToString();
        }
    }
}