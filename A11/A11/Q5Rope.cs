using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A11
{

    public class _Node
    {
        public _Node parent;
        public _Node left; public _Node right;
        public char key;
        public long sum;

    }

    public class _SplayTree
    {

        public _Node root;

        public _Node array_to_tree(string str, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;

            _Node node = new _Node();
            if (root == null)
            {
                root = node;
            }
            node.key = str[mid];
            node.sum = end - start + 1;

            node.left = array_to_tree(str, start, mid - 1);
            if (node.left != null) node.left.parent = node;
            node.right = array_to_tree(str, mid + 1, end);
            if (node.right != null) node.right.parent = node;

            return node;
        }

        public void update_sum(_Node node)
        {
            if (node == null)
            {
                return;
            }

            node.sum = ((node.left == null) ? 0 : node.left.sum) + ((node.right == null) ? 0 : node.right.sum) + 1;
        }

        public _Node rotate(_Node x, bool to_left)
        {
            if (x == null)
            {
                return null;
            }

            _Node parent = x.parent;
            _Node y = to_left ?
                x.right : x.left;
            _Node b = to_left ?
                y.left : y.right;

            if (to_left)
                y.left = x;
            else
                y.right = x;
            y.parent = parent;

            if (parent != null)
            {
                if (parent.left == x)
                {
                    parent.left = y;
                }
                else
                {
                    parent.right = y;
                }
            }


            x.parent = y;
            if (to_left)
                x.right = b;
            else
                x.left = b;
            if (b != null)
                b.parent = x;
            update_sum(x);
            update_sum(y);
            return y;
        }


        public void zigging(_Node x)
        {
            //Console.WriteLine(x.key);
            if (x == root)
            {
                return;
            }

            if (x.parent == root)
            {
                if (root.right == x)
                {
                    rotate(x.parent, true);
                    root = x;
                }
                else
                {
                    rotate(x.parent, false);
                    root = x;
                }

                return;
            }

            _Node parent = x.parent;
            _Node grand_parent = parent.parent;

            if (grand_parent.right == parent)
            {
                if (parent.right == x)
                {
                    rotate(grand_parent, true);
                    rotate(parent, true);
                }
                else
                {
                    rotate(parent, false);
                    rotate(grand_parent, true);
                }
            }
            else
            {
                if (parent.left == x)
                {
                    rotate(grand_parent, false);
                    rotate(parent, false);
                }
                else
                {
                    rotate(parent, true);
                    rotate(grand_parent, false);
                }
            }

        }

        public void Splay(_Node x)
        {
            if (x == null) return;
            //Console.WriteLine("ss");
            while (x.parent != null)
            {
                zigging(x);
                //if(x.parent != null)
                //Console.WriteLine(x.parent.key);
                //bfs(root);
                //Console.WriteLine();
                
            }

            root = x;
        }


        public void bfs(_Node x)
        {
            if (x == null)
            {
                Console.WriteLine("the tree is empty");
                return;
            }
            Queue<Tuple<_Node, int>> queue = new Queue<Tuple<_Node, int>>();
            queue.Enqueue(new Tuple<_Node, int>(x, 1));
            int level = 1;
            while (queue.Count > 0)
            {
                _Node node = queue.Peek().Item1;
                if (node.left != null)
                {
                    queue.Enqueue(new Tuple<_Node, int>(node.left, queue.Peek().Item2 + 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new Tuple<_Node, int>(node.right, queue.Peek().Item2 + 1));
                }
                Tuple<_Node, int> pair = queue.Dequeue();

                if (pair.Item2 == level)
                {
                    Console.Write(pair.Item1.key + "/" + pair.Item1.sum + " ");
                }
                else
                {
                    level++;
                    Console.WriteLine();
                    Console.Write(pair.Item1.key + "/" + pair.Item1.sum + " ");
                }
            }
            Console.WriteLine();
        }       

        public _Node find(long k, _Node x) // 1-based indexing
        {
            if (x == null)
            {
                //Console.WriteLine("here");
                return null;
            }

            long s;

            while (true)
            {
                //if (k == 829547299)
                //{
                //    Console.WriteLine($"x.key = {x.key}");
                //}

                s = (x.left == null) ? 0 : x.left.sum;
                if (s + 1 == k)
                {
                    return x;
                }

                if (k < s + 1)
                {
                    if (x.left != null)
                        x = x.left;
                    else return x;
                }

                if (s + 1 < k)
                {
                    if (x.right != null)
                    {
                        x = x.right;
                        k = k - s - 1;
                    }                    
                    else return x;
                }

            }

            return null;
        }

        


        public void traverse(_Node x)
        {
            if (x == null)
            {
                return;
            }

            traverse(x.left);
            Console.Write(x.key + " ");
            traverse(x.right);

        }

        public string _traverse(_Node x)
        {
            string z = "";
            if (x == null)
            {
                return "";
            }

            z +=_traverse(x.left);
            z += x.key;
            z += _traverse(x.right);
            return z;
        }

    }


    public class Q5Rope : Processor
    {
        public Q5Rope(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long[][], string>)Solve);

        public string Solve(string text, long[][] queries)
        {
            _SplayTree sp = new _SplayTree();
            sp.array_to_tree(text, 0, text.Length - 1);

            //Console.WriteLine(queries.Length);
            foreach (var query in queries)
            {
                //Console.WriteLine($"{query[0]}, {query[1]}, {query[2]}");
                sp = do_the_thing(query, sp);
            }
                string ss = sp._traverse(sp.root);
            //Console.WriteLine(ss);

            return ss;
        }

        public Tuple<_SplayTree, _SplayTree> split(long index, _SplayTree sp_tree)
        {
            _Node node = sp_tree.find(index, sp_tree.root);
            //sp_tree.bfs(sp_tree.root);
            sp_tree.Splay(node);
            if (index < 1)
            {
                
                return new Tuple<_SplayTree, _SplayTree>(new _SplayTree(), sp_tree);
            }
            //sp_tree.bfs(sp_tree.root);
            _SplayTree ns = new _SplayTree();
            ns.root = node.right;
            if (ns.root != null) ns.root.parent = null;
            node.right = null;
            sp_tree.update_sum(sp_tree.root);
            //sp_tree.root.parent = null;
            //ns.root.parent = null;
            return new Tuple<_SplayTree, _SplayTree>(sp_tree, ns);
        }

        public _SplayTree merge(_SplayTree S1, _SplayTree S2)
        {
            //S1.root.parent = null;
            //S2.root.parent = null;
            if (S2 == null)
            {
                
                return S1;
            }

            if (S1 == null)
            {
                return S2;
            }
            if (S1.root == null) return S2;
            //Console.WriteLine("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
            _Node node = S1.find(long.MaxValue, S1.root);
            //Console.WriteLine($"\nnode: {node.key}");
            //S1.bfs(S1.root);
            //Console.WriteLine();
            S1.Splay(node);
            S1.root.right = S2.root;
            //Console.WriteLine(S2.root.key);
            if(S2.root != null)
            S2.root.parent = S1.root;
            S1.update_sum(S1.root);
            
            return S1;
        }


        public _SplayTree do_the_thing(long[] query, _SplayTree sp)
        {
            long left = query[0];
            long right = query[1];
            long put_it_after = query[2];

            //Console.WriteLine("first split: ");
            Tuple<_SplayTree, _SplayTree> split1 = split(right + 1, sp);
            _SplayTree sleft_main = split1.Item1;
            _SplayTree sright = split1.Item2;
            //sleft_main.traverse(sleft_main.root);
            //Console.WriteLine();
            //sright.traverse(sright.root);
            //Console.WriteLine();
            //Console.WriteLine("======================================================");

            //Console.WriteLine("second split: ");
            Tuple<_SplayTree, _SplayTree> split2 = split(left, sleft_main);
            _SplayTree sleft = split2.Item1;
            _SplayTree smain = split2.Item2;
            ////if (smain.root.parent != null)
            ////{
            ////    Console.WriteLine("uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu");
            ////}
            //sleft.traverse(sleft.root);
            //Console.WriteLine();
            //smain.traverse(smain.root);
            //Console.WriteLine();
            //Console.WriteLine("======================================================");

            //Console.WriteLine("merging left with right: ");
            _SplayTree merged_left_right = merge(sleft, sright);
            //merged_left_right.traverse(merged_left_right.root);
            //Console.WriteLine();
            //Console.WriteLine("======================================================");

            Tuple<_SplayTree, _SplayTree> split3 = split(put_it_after, merged_left_right);
            //Console.WriteLine(split3.Item2.root + " r");
            _SplayTree half = merge(split3.Item1, smain);
            //half.traverse(half.root);
            //Console.WriteLine();
            //split3.Item2.traverse(split3.Item2.root);
            //if (half.root.parent != null)
            //{

            //Console.WriteLine($"dddddddddddddddddd");
            //}

            _SplayTree done = merge(half, split3.Item2);
            //done.traverse(done.root);
            //Console.WriteLine();

            return done;
        }

    }
}
