using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
     class Point : IComparable<Point>
    {
        public long value;
        public int order;
        public int index;

        public Point(long value, int order, int index)
        {
            this.value = value;
            this.order = order;
            this.index = index;
        }

        public int CompareTo(Point other)
        {
            if (this.value > other.value)
            {
                return 1;
            }
            else if(this.value < other.value)
            {
                return -1;
            }
            else
            {
                if (this.order > other.order)
                {
                    return 1;
                }
                else if (this.order < other.order)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    public class Q5OrganizingLottery:Processor
    {
        static long[] startSeg;
        static long[] endSeg;
        static long[] points;
        static long[] result;
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        {
        }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);
        
        public virtual long[] Solve(long[] points_set, long[] startSegments, long[] endSegment)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < points_set.Length; i++)
            {
                points.Add(new Point(points_set[i], 2, i));
            }

            for (int i = 0; i < startSegments.Length; i++)
            {
                points.Add(new Point(startSegments[i], 1, -1));
                points.Add(new Point(endSegment[i], 3, -1));
            }

            points.Sort();
            long[] longs = new long[points_set.Count()];

            long number_of_segs = 0;
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].order == 1)
                {
                    number_of_segs++;
                }
                else if (points[i].order == 2)
                {
                    longs[points[i].index] = number_of_segs; 
                }
                else
                {
                    number_of_segs--;
                }
            }
            return longs;
        }

       /* public virtual long[] Solve(long[] points_set, long[] startSegments, long[] endSegment)
        {
            startSeg = startSegments;
            /* for (int i = 0; i < startSeg.Length; i++)
			{
             Console.WriteLine(startSeg[i]);
			} 
            endSeg = endSegment;
            points = points_set;
            result = new long[points.Length];
            long[] refrence_to_the_original_array = new long[points.Length];
            for (int i = 0; i < points.Length; i++)
			{
             refrence_to_the_original_array[i] = i;
			}
            Array.Sort(points, refrence_to_the_original_array);
            Array.Sort(startSeg);
            Array.Sort(endSeg);
            /*for (int i = 0; i < points_set.Length; i++)
			{
                Console.WriteLine(points_set[i]);
			}
            //do_the_job(0, endSegment.Length - 1, 0, points_set.Length - 1);
            another_doer();
            long[] real_result = new long[result.Length];
            for (int i = 0; i < result.Length; i++)
			{
                real_result[i] = result[refrence_to_the_original_array[i]];
			}
            return real_result;
        }

        static void another_doer()
        {
            int pointer_to_starts = 0;
            int pointer_to_ends = 0;
            int pointer_to_points = 0;
            long last_point_to_visit = Math.Max(endSeg.Max(), points[points.Length - 1]);
            long counter = Math.Min(points[0], startSeg[0]);
            int number_of_segments = 0;
            while (counter <= last_point_to_visit)
            {   
                if(pointer_to_starts < startSeg.Length)
                if(counter == startSeg[pointer_to_starts])
                {
                    number_of_segments++;
                    pointer_to_starts++;
                }

                if(pointer_to_points < points.Length)
                if(counter == points[pointer_to_points])
                {
                    result[pointer_to_points] = number_of_segments;
                    pointer_to_points++;
                }

                if(pointer_to_ends < endSeg.Length)
                if(counter == endSeg[pointer_to_ends])
                {
                    number_of_segments--;
                    pointer_to_ends++;
                }

                
                counter++;
            }

        } */

         /*void do_the_job(int start_seg, int end_seg, int start_points, int end_points)
        {
            int mid_index = (end_points + start_points) / 2;
            int last_seg_index = -1; // TODO: what if the element wasn't in the segments
            int included_seg_count = 0;


            for (int i = 0; i < end_seg - start_seg + 1; i++)
			{   
                if (startSeg[i] <= points[mid_index] && endSeg[i] >= points[mid_index])
                {
                    last_seg_index = Math.Max(i, last_seg_index);
                    included_seg_count++;
                }
			}

        int l = start_seg, r = end_seg;
        while (l <= r) {
            int m = l + (r - l) / 2;
 
            // Check if x is present at mid
            if (startSeg[m] == points[mid_index])
                break;
 
            // If x greater, ignore left half
            if (startSeg[m] < points[mid_index])
                l = m + 1;
 
            // If x is smaller, ignore right half
            else
                r = m - 1;
        }

        last_seg_index = l;

            result[mid_index] = included_seg_count; // TODO: set the element to it's original place

            if(end_points == start_points) // when the "points" contains only one element
            {
                return;
            }
            do_the_job(start_seg, last_seg_index, start_points, mid_index - 1);
            do_the_job(last_seg_index, end_seg, mid_index + 1, end_points);
        }*/

    }
}
