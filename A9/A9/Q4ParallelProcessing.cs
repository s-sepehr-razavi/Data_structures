using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q3ParallelProcessing : Processor
    {
        processor[] H;
        long size;
        public Q3ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public int left_child(int i)
        {
            return 2 * i + 1;
        }

        public int right_child(int i)
        {
            return 2 * i + 2;
        }

        //public int parent(int i)
        //{
        //    return i - 1 / 2;
        //}

        public void swap(int i, int j)
        {
            long tmp_index = H[i].index;
            long tmp_time = H[i].time;
            H[i].time = H[j].time;
            H[i].index = H[j].index;
            H[j].index = tmp_index;
            H[j].time = tmp_time;
           // List.Add(new Tuple<long, long>((long)i, (long)j));
        }

        public void sift_down(int i)
        {
            int min_index = i;

            int l = left_child(i);
            if (l < H.Length)
            {
                if (H[min_index].CompareTo(H[l]) > 0)
                {
                    min_index = l;
                }
            }

            int r = right_child(i);
            if (r < H.Length)
            {
                if (H[min_index].CompareTo(H[r]) > 0)
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

        //public void sift_up(int i)
        //{
        //    while (i > 0)
        //    {
        //        if (H[parent(i)] < H[i])
        //        {
        //            swap(i, parent(i));
        //            i = parent(i);
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //}

        //public void enque(processor processor)
        //{
        //    if (size == H.Length)
        //    {
        //        Console.WriteLine("size == H.Length");
        //    }
        //    else
        //    {
        //        size++;
        //        H[size] = processor;
        //        sift_up(size);
        //    }
        //}

        //public processor deque()
        //{
        //    if (size < 0)
        //    {
        //        Console.WriteLine("size < 0");
        //        return null;
        //    }
        //    processor ret = new processor(H[0].index, H[0].time);
        //    swap(0, size);
        //    size--;
        //    sift_down(0);
        //    return ret;
        //}

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            H = new processor[threadCount];
            //size = threadCount - 1;
            Tuple<long, long>[] answer = new Tuple<long, long>[jobDuration.Length];
            for (int i = 0; i < threadCount; i++)
            {
                H[i] = new processor(i,0);
            }

            for (int i = 0; i < jobDuration.Length; i++)
            {
                answer[i] = new Tuple<long, long>(H[0].index, H[0].time);
                H[0].time += jobDuration[i];
                sift_down(0);
            }
            return answer;
        }

        
    }

    class processor : IComparable<processor>
    {
       public long index;
       public long time;
        public processor(long index, long time)
        {
            this.index = index;
            this.time = time;
        }

        public int CompareTo(processor other)
        {
            if (this.time > other.time)
            {
                return 1;
            }

            if (this.time < other.time)
            {
                return -1;
            }

            if (this.index > other.index)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }


}
