using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
       static public long[] H; 
       static List<Tuple<long, long>> List = new List<Tuple<long, long>>();

        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public int left_child(int i)
        {
            return 2 * i + 1;
        }

        public int right_child(int i)
        {
            return 2 * i + 2;
        }

        public void swap(int i, int j)
        {
            long c = H[i];
            H[i] = H[j];
            H[j] = c;
            List.Add(new Tuple<long, long>((long)i, (long)j));
        }

        public void sift_down(int i)
        {
            int min_index = i;

            int l = left_child(i);
            if (l < H.Length) 
            {
                if (H[l] < H[min_index])
                {
                    min_index= l;
                }
            }

            int r = right_child(i);
            if (r < H.Length)
            {
                if (H[r] < H[min_index])
                {
                    min_index = r;
                }
            }

            if (i != min_index)
            {
                swap(i, min_index);
                sift_down(min_index);
            }

            return;
        }

        public Tuple<long, long>[] Solve(long[] array)
        {
            H = array;
            List = new List<Tuple<long, long>>();
            for (int i = H.Length/2; i > -1; i--)
            {
                sift_down(i);
                //for (int j = 0; j < H.Length; j++)
                //{
                //    Console.Write(H[j] + " ");
                //}
                //Console.WriteLine();
                //Console.WriteLine("===============================");
            }
            return List.ToArray();
        }
    }
}
