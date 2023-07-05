using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);

        public LinkedList<string>[] hash_table;
        public string[] Solve(long bucketCount, string[] commands)
        {
            List<string> result = new List<string>();
            hash_table = new LinkedList<string>[bucketCount];
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {

            str = str.Substring(start, count);
            long hash = 0;
            for (int i = str.Length - 1; i > -1; i--)
            {
                hash = (hash * x + str[i]) % p;
               // Console.WriteLine($"hash = {hash}");
            }
            
            //Console.WriteLine((hash % p) % count);
            return hash % p;
        }

        public long q2_hash(string str, long m)
        {
            return PolyHash(str, 0, str.Length) % m;
        }

        public void Add(string str)
        {
            long hash = q2_hash(str, hash_table.Length);
            try
            {
                LinkedListNode<string> pointer = hash_table[hash].First;
            }
            catch (Exception)
            {
                hash_table[hash] = new LinkedList<string>();
                hash_table[hash].AddFirst(str);
                return;
            }

            LinkedListNode<string> node = hash_table[hash].Find(str);
            if (node != null)
            {
                return;
            }
            hash_table[hash].AddFirst(str);
        }

        public string Find(string str)
        {
            long hash = q2_hash(str, hash_table.Length);
            LinkedListNode<string> node;
            try
            {
                node = hash_table[hash].Find(str);
            }
            catch (Exception)
            {
                return "no";
            }
            if (node == null)
            {
                return "no";
            }
            return "yes";
        }

        public void Delete(string str)
        {
            long hash = q2_hash(str, hash_table.Length);
            LinkedListNode<string> node;
            try
            {
                node = hash_table[hash].Find(str);
            }
            catch (Exception)
            {
                return;
            }

            if (node == null)
            {
                return;
            }

            hash_table[hash].Remove(node);
        }

        public string Check(int i)
        {
            string str = "";
            if (hash_table[i] == null)
            {
                return "-";
            }

            if (hash_table[i].First == null)
            {
                return "-";
            }

            int limit = hash_table[i].Count;
            int counter = 1;
            foreach (var item in hash_table[i])
            {
                if (counter == limit)
                {
                    str += (item);
                    break;
                }
                str += (item + " ");
                counter++;
            }
            return str;
        }
    }
}
