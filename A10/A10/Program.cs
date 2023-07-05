using A10;
using Microsoft.VisualBasic;//string[] s = new string[2];
//Console.Write(s[0]);
//Q2HashingWithChain q2 = new Q2HashingWithChain("ss");
//int m = Convert.ToInt32(Console.ReadLine());
//int n = Convert.ToInt32(Console.ReadLine());
//string[] s2 = new string[n];
//for (int i = 0; i < n; i++)
//{
//    s2[i] = Console.ReadLine();
//}

//var x = q2.Solve(m, s2);

//foreach (var item in x)
//{
//    Console.WriteLine(item);
//}
//Q2HashingWithChain q2 = new Q2HashingWithChain("ss");
//long x = q2.q2_hash("luck", 5);
//long y = q2.q2_hash("GooD", 5);
//Console.WriteLine($"{x}, {y}");
////LinkedList<long> list = new LinkedList<long>();
////list.AddFirst(0);
////LinkedListNode<long> node = list.First;
////if (node == null)
////{
////    Console.WriteLine("null");
////}
////Console.WriteLine(node.Value);

//string xx = "abcdef";
//Console.WriteLine(xx.Substring(xx.Length - 3, 3));
//Q3RabinKarp q3 = new Q3RabinKarp("ss");
//long[] x = q3.Solve("ab\n", "");
//Console.WriteLine(x.Length);
//for (int i = 0; i < x.Length; i++)
//{
//    Console.WriteLine(x[i]);
//}
//int[] xx = new int[] { 1, 2, 3, 4, 5, 6, 7, 7 };
//xx.ToList(xx.ToList().ForEach(x => Console.Write($"{x} ssss {x*x}")));
//LinkedList<int> list = new LinkedList<int>();
//Q2HashingWithChain q2 = new Q2HashingWithChain("ss");
//long hash = q2.PolyHash("12", 0, 2, 10000000, 1);
//Console.WriteLine(hash);
//string[] x = q2.Solve();
int x = 2;

Func<int, int> f = y => { return x; };
Console.WriteLine(f(5));