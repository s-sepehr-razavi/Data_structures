using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{

    public class Node
    {
        public Node parent;
        public Node left; public Node right;
        public long key;
        public long sum;

    }

    public class SplayTree
    {

        public Node root;

        public void update_sum(Node node)
        {
            if (node == null)
            {
                return;
            }

            node.sum = ((node.left == null) ? 0 : node.left.sum) + ((node.right == null) ? 0 : node.right.sum) + node.key;
        }

        public Node rotate(Node x, bool to_left)
        {
            if (x == null)
            {
                return null;
            }

            Node parent = x.parent;
            Node y = to_left ?
                x.right : x.left;
            Node b = to_left ?
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
            if(b != null)
                b.parent = x;
            update_sum(x);
            update_sum(y);
            return y;
        }



        public void _Splay(Node x)
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

            Node parent = x.parent;
            Node grand_parent = parent.parent;

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

            if (x.parent == null) root = x;
            _Splay(x);

        }

        public void zigging(Node x)
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

            Node parent = x.parent;
            Node grand_parent = parent.parent;

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

        public void Splay(Node x)
        {
            if (x == null) return;
            while (x.parent != null)
            {
                zigging(x);
            }

            root = x;
        }


        public void bfs(Node x)
        {
            if (x == null)
            {
                Console.WriteLine("the tree is empty");
                return;
            }
            Queue<Tuple<Node, int>> queue = new Queue<Tuple<Node, int>>();
            queue.Enqueue(new Tuple<Node, int>(x, 1));
            int level = 1;
            while(queue.Count > 0)
            {
                Node node = queue.Peek().Item1;
                if (node.left != null)
                {
                    queue.Enqueue(new Tuple<Node, int>(node.left, queue.Peek().Item2 + 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new Tuple<Node, int>(node.right, queue.Peek().Item2 + 1));
                }
                Tuple<Node, int> pair = queue.Dequeue();

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

        public Node rec_find(long k, Node x)
        {
            if (x == null)
            {
                return null;
            }

            if (x.key == k)
            {
                return x;
            }

            if (k < x.key)
            {
                if (x.left != null)
                    return rec_find(k, x.left);
                else return x;
            }

            if (x.key < k)
            {
                if (x.right != null)
                    return rec_find(k, x.right);
                else return x;
            }
            return null;
        }

        public Node find(long k, Node x)
        {
            if (x == null)
            {
                //Console.WriteLine("here");
                return null;
            }

            while (true)
            {
                //if (k == 829547299)
                //{
                //    Console.WriteLine($"x.key = {x.key}");
                //}
                if (x.key == k)
                {
                    return x;
                }

                if (k < x.key)
                {
                    if (x.left != null)
                        x = x.left;
                    else return x;
                }

                if (x.key < k)
                {
                    if (x.right != null)
                        x = x.right;
                    else return x;
                }

            }

            return null;
        }

        public void insert(long x)
        {
            Node inserted_node = new Node();
            inserted_node.key = x;
            inserted_node.sum = x;
            if (root == null)
            {
                root = inserted_node;
                return;
            }

            Node node = find(x, root);
            //Console.WriteLine($"founded node {node.key}");
            if (x == node.key)
            {
                Splay(node);
                return;
            }
            else if (x < node.key)
            {
                node.left = inserted_node;
                inserted_node.parent = node;
            }
            else
            {
                node.right = inserted_node;
                inserted_node.parent = node;
            }
            update_sum(node);
            //Console.WriteLine("================================================================================");
            //Console.WriteLine($"before: {x}\n");
            //bfs(root);
            Splay(inserted_node);
            //Console.WriteLine($"\nafter: {x}\n");
            //bfs(root);
        }

        public Node successor(Node node)
        {
            if (node.right != null)
            {
                node = node.right;
                while (node.left != null)
                {
                    node= node.left;
                }
                return node;
            }

            while (true)
            {
                if (node.parent != null)
                {
                    if (node.parent.left == node)
                    {
                        return node.parent;
                    }
                    node= node.parent;
                }
                else
                {
                    return null;
                }
            }
        }

        public Node predecessor(Node node)
        {
            if (node.left != null)
            {
                node = node.left;
                while (node.right != null)
                {
                    node = node.right;
                }
                return node;
            }

            while (true)
            {
                if (node.parent != null)
                {
                    if (node.parent.right == node)
                    {
                        return node.parent;
                    }
                    node = node.parent;
                }
                else
                {
                    return null;
                }
            }
        }

        public void traverse(Node x)
        {
            if (x == null)
            {
                return;
            }

            traverse(x.left);
            Console.Write(x.key + " ");
            traverse(x.right);
            
        }

        public long delete(long key)
        {
            Node node = find(key, root);
            if (node == null)
                return long.MinValue;
            if (node.key != key)
            {
                return long.MinValue;
            }
            Node next = successor(node);
            if (next != null)
            {
                Splay(next);
                Splay(node);
                next.left = node.left;
                if(next.left!= null)
                next.left.parent = next;
                next.parent = null;
                root = next;
                update_sum(next);
                return node.key;
            }

            Splay(node);
            root = node.left;
            if(node.left != null)
            node.left.parent = null;
            return node.key;
        }



    }

    

        public class Q4SetWithRangeSums : Processor
    {
        public Q4SetWithRangeSums(string testDataName) : base(testDataName)
        {
            CommandDict =
                        new Dictionary<char, Func<string, string>>()
                        {
                            ['+'] = Add,
                            ['-'] = Del,
                            ['?'] = Find,
                            ['s'] = Sum
                        };
            //this.ExcludeTestCaseRangeInclusive(20, 69);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        public readonly Dictionary<char, Func<string, string>> CommandDict;

        public const long M = 1_000_000_001;

        public long X = 0;

        //protected List<long> Data;
        protected SplayTree Data;

        public string[] Solve(string[] lines)
        {
            //return null;
            X = 0;
            Data = new SplayTree();
            List<string> result = new List<string>();
            foreach (var line in lines)
            {
                char cmd = line[0];
                string args = line.Substring(1).Trim();
                var output = CommandDict[cmd](args);
                if (null != output)
                    result.Add(output);
            }
            return result.ToArray();
        }

        private long Convert(long i)
            => i = (i + X) % M;

        private string Add(string arg)
        {
            long i = Convert(long.Parse(arg));
            //int idx = Data.BinarySearch(i);
            //if (idx < 0)
            //    Data.Insert(~idx, i);
            Data.insert(i);

            return null;
        }

        private string Del(string arg)
        {
            
            long i = Convert(long.Parse(arg));
            //int idx = Data.BinarySearch(i);
            //if (idx >= 0)
            //    Data.RemoveAt(idx);
            Data.delete(i);

            return null;
        }

        private string Find(string arg)
        {
            long i = Convert(int.Parse(arg));
            //int idx = Data.BinarySearch(i);
            //return idx < 0 ?
            //    "Not found" : "Found";
            Node node = Data.find(i, Data.root);
            Data.Splay(node);
            if (node == null)
            {
                return "Not found";
            }

            if (node.key != i)
            {
                return "Not found";
            }

            return "Found";
        }

        private string Sum(string arg)
        {
            var toks = arg.Split();
            long l = Convert(long.Parse(toks[0]));
            long r = Convert(long.Parse(toks[1]));
            //Console.WriteLine($"actual r: {r}\nactual l: {l}");
            if (l > r)
            {
                X = 0;
                return "0";
            }

            //l = Data.BinarySearch(l);
            //if (l < 0)
            //    l = ~l;

            //r = Data.BinarySearch(r);
            //if (r < 0)
            //    r = (~r - 1);
            // If not ~r will point to a position with
            // a larger number. So we should not include 
            // that position in our search.

            long sum = 0;
            //for (int i = (int)l; i <= r && i < Data.Count; i++)
            //    sum += Data[i];

            //Console.WriteLine("========================================================");
            //Console.WriteLine(arg + ": ");
            Node r_node = new Node();
            //Console.WriteLine("bfs before finding right");
            //Data.bfs(Data.root);
            r_node = Data.find(r, Data.root);
            
            Data.Splay(r_node);
            if (r_node == null)
            {
                //Console.WriteLine("r_node is null");
                return X + "";
            }
            //Console.WriteLine($"r_node.key: {r_node.key}");
            long r_sum = 0;

            if (r_node.key <= r)
            {
                r_sum = (r_node.left == null) ? r_node.key : (r_node.key + r_node.left.sum);
            }
            else
            {
                r_sum = (r_node.left == null) ? 0 : (r_node.left.sum);
            }


            Node l_node = new Node();
            //Console.WriteLine("bfs before finding left");
            //Data.bfs(Data.root);
            l_node = Data.find(l, Data.root);
            Data.Splay(l_node);
            if (l_node == null)
            {
                //Console.WriteLine("l_node is null");
                return X + "";
            }
            //Console.WriteLine($"l_node.key: {l_node.key}");
            long l_sum = 0;

            if (l_node.key < l)
            {
                l_sum = (l_node.left == null) ? l_node.key : (l_node.key + l_node.left.sum);
            }
            else
            {
                l_sum = (l_node.left == null) ? 0 : (l_node.left.sum);
            }

            //Console.WriteLine($"r_sum: {r_sum}    l_sum: {l_sum}");
            //Data.bfs(Data.root);
            //Console.WriteLine();
            //Data.traverse(Data.root);
            //Console.WriteLine();
            //Console.WriteLine("========================================================");

            sum = r_sum - l_sum;

            //if (sum < 0)
            //{
            //    sum *= -1; 
            //}

            X = sum;

            return sum.ToString();
        }
    }
}
