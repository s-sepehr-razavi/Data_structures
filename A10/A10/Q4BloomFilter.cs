// Bloom filter: https://www.jasondavies.com/bloomfilter/
using System;
using System.Collections;
using System.Linq;
using TestCommon;


namespace A10
{
    public class Q4BloomFilter
    {
        BitArray Filter;
        Func<string, int>[] HashFunctions;

        public Q4BloomFilter(int filterSize, int hashFnCount)
        {
            this.Filter = new BitArray(filterSize, false);
            this.HashFunctions = new Func<string, int>[hashFnCount];

            HashFunctions[0] = str =>
            {

                long hash = 0;
                long p = 1000000007;
                Random random = new Random();
                long x = random.NextInt64(p - 3);
                for (int i = str.Length - 1; i > -1; i--)
                {
                    hash = (hash * 123 + str[i]) % p;
                    // Console.WriteLine($"hash = {hash}");
                }

                //Console.WriteLine((hash % p) % count);
                return (int)(hash % filterSize);
            };

            HashFunctions[1] = str =>
            {

                long hash = 0;
                long p = 1000000007;
                Random random = new Random();
                long x = random.NextInt64(p - 3);
                for (int i = str.Length - 1; i > -1; i--)
                {
                    hash = (hash * 64 + str[i]) % p;
                    // Console.WriteLine($"hash = {hash}");
                }

                //Console.WriteLine((hash % p) % count);
                return (int)(hash % filterSize);
            };

            HashFunctions[2] = str =>
            {

                long hash = 0;
                long p = 1000000007;
                Random random = new Random();
                long x = random.NextInt64(p - 3);
                for (int i = str.Length - 1; i > -1; i--)
                {
                    hash = (hash * 923 + str[i]) % p;
                    // Console.WriteLine($"hash = {hash}");
                }

                //Console.WriteLine((hash % p) % count);
                return (int)(hash % filterSize);
            };

            HashFunctions[3] = str =>
            {

                long hash = 0;
                long p = 1000000007;
                Random random = new Random();
                long x = random.NextInt64(p - 3);
                for (int i = str.Length - 1; i > -1; i--)
                {
                    hash = (hash * 23 + str[i]) % p;
                    // Console.WriteLine($"hash = {hash}");
                }

                //Console.WriteLine((hash % p) % count);
                return (int)(hash % filterSize);
            };

        }

        
        public void Add(string str)
        {
            for (int i=0; i< HashFunctions.Length; i++)
            {
                Filter[HashFunctions[i](str)] = true;
            }
        }

        public bool Test(string str)
        {
            for (int i=0; i<HashFunctions.Length; i++)
            {
                if (Filter[HashFunctions[i](str)] == true)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    }
}