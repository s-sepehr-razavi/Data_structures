using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{

    public class Pair<T1, T2>
    {
        public T1 Item1;
        public T2 Item2;

        public Pair(T1 t1, T2 t2)
        {
            this.Item1 = t1;
            this.Item2 = t2;
        }
    }

    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);


        public static Stack<Pair<long[], bool>> my_stack= new Stack<Pair<long[], bool>>();
        public static long[][] nodes;
        public static List<long> pre_order;
        public static List<long> post_order;
        public static List<long> in_order;

        public static void add_to_stack(long index)
        {
            while (index != -1)
            {
                my_stack.Push(new Pair<long[], bool>(nodes[index], false));
                pre_order.Add(nodes[index][0]);
                index = nodes[index][1];
            }
        }
        public long[][] Solve(long[][] nodes_inp)
        {
            nodes= nodes_inp;
            pre_order= new List<long>();
            post_order= new List<long>();
            in_order=new List<long>();

            add_to_stack(0);
            while (my_stack.Count != 0)
            {
                if (!my_stack.Peek().Item2)
                {
                    in_order.Add(my_stack.Peek().Item1[0]);
                }
                if ((my_stack.Peek().Item2) || (my_stack.Peek().Item1)[2] == -1)
                {
                    post_order.Add(my_stack.Pop().Item1[0]);
                }
                else
                {
                    my_stack.Peek().Item2 = true;
                    add_to_stack((my_stack.Peek().Item1)[2]);
                }
            }
            long[][] result = new long[3][];
            result[0] = in_order.ToArray();
            result[1] = pre_order.ToArray();
            result[2] = post_order.ToArray();
            return result;
        }
    }
}

