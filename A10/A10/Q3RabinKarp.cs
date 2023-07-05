using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            List<long> result = new List<long>();
            long x = 243;
            long p = 1113491139767;
            p = 1000000007;

            long pattern_hash = PolyHash(pattern, 0, (int)p, (int)p, x);
            //Console.WriteLine($"hash {pattern_hash}");
            long[] H = PreComputeHashes(text, pattern.Length, p, x);

            for (int i = 0; i < H.Length; i++)
            {
               // Console.WriteLine(H[i]);
            }

            for (int i = 0; i < H.Length; i++)
            {
                if (H[i] == pattern_hash)
                {   
                    if (pattern == text.Substring(i, pattern.Length))
                    {
                        result.Add((long)i);
                    }
                }
            }

            return result.ToArray();
        }

        //public static long PolyHash(
        //string str, int start, long count,
        //long p, long x)
        //{
        //    long hash = 0;
        //    for (int i = str.Length - 1; i > -1; i--)
        //    {
        //        hash = (hash * x + str[i]) % p;
        //    }
        //    return (hash % p) % count;
        //}

        public static long PolyHash(
            string str, int start, int count,
            long p, long x)
        {
            long hash = 0;
            for (int i = str.Length - 1; i > -1; i--)
            {
                hash = (hash * x + str[i]) % p;
                // Console.WriteLine($"hash = {hash}");
            }

            //Console.WriteLine((hash % p) % count);
            return (hash % p) % count;
        }



        public static long[] PreComputeHashes(
            string T, 
            int P, 
            long p, 
            long x)
        {
            long[] hash = new long[T.Length - P + 1];
            //Console.WriteLine(T.Substring(T.Length - P, P));
            hash[T.Length - P] = PolyHash(T.Substring(T.Length - P, P), 0, (int)p, (int)p, x);

            long y = 1;
            for (int i = 0; i < P; i++)
            {
                y *= x;
                y %= p;
            }

            for (int i = hash.Length - 2; i > -1; i--)
            {

                hash[i] = (T[i] + x * hash[i + 1] - T[i + P] * y + p) % p;
                while (hash[i] < 0)
                {
                    hash[i] = (hash[i] + p) % p;
                }
            }

            return hash;
        }
    }
}
