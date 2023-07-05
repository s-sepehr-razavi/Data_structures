using A9;

Q2MergingTables q2 = new Q2MergingTables("ss");
long[] x = q2.Solve(new long[] { 40, 48, 31, 98, 72, 18, 7, 56, 34 }, new long[] { 4,1,6,2,8,2,7,5}, new long[] { 2,1,4,5,3,6,8,5});
//long[] y = q2.Solve(new long[] { 10, 0, 5, 0, 3, 3 }, new long[] { 6, 6, 5, 4 }, new long[] { 6, 5, 4, 3 });

for (int i = 0; i < x.Length; i++)
{
    Console.WriteLine(x[i]);
}