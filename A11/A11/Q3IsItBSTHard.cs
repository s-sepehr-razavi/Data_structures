using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{

    
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) {
            this.ExcludeTestCases(new int[] { 7, 10, 11, 14, 16 });
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        //public static Stack<Pair<long[], bool>> my_stack = new Stack<Pair<long[], bool>>();
        //public static long[][] nodes;

        //public static void add_to_stack(long index)
        //{
        //    while (index != -1)
        //    {
        //        my_stack.Push(new Pair<long[], bool>(nodes[index], false));
        //        index = nodes[index][1];
        //    }
        //}
        //public bool Solve(long[][] nodes_inp)
        //{

        //    nodes = nodes_inp;

        //    add_to_stack(0);
        //    while (my_stack.Count != 0)
        //    {
        //        if (!my_stack.Peek().Item2)
        //        {
        //            if (my_stack.Peek().Item1[1] != -1)
        //            {
        //                if (nodes[my_stack.Peek().Item1[1]][0] >= my_stack.Peek().Item1[0])
        //                {
        //                    return false;
        //                }
        //            }

        //            if (my_stack.Peek().Item1[2] != -1)
        //            {
        //                if (nodes[my_stack.Peek().Item1[2]][0] < my_stack.Peek().Item1[0])
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //        if ((my_stack.Peek().Item2) || (my_stack.Peek().Item1)[2] == -1)
        //        {
        //           long x = my_stack.Pop().Item1[0];
        //        }
        //        else
        //        {
        //            my_stack.Peek().Item2 = true;
        //            add_to_stack((my_stack.Peek().Item1)[2]);
        //        }
        //    }
        //    return true;
        //}

        public bool Solve(long[][] nodes_inp)
        {
            
            for (int i = 0; i < nodes_inp.Length; i++)
            {
                if (nodes_inp[i][1] != -1)
                {
                    if (nodes_inp[nodes_inp[i][1]][0] >= nodes_inp[i][0])
                    {
                        return false;
                    }
                }

                if (nodes_inp[i][2] != -1)
                {
                    if (nodes_inp[nodes_inp[i][2]][0] < nodes_inp[i][0])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
