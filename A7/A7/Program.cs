using A7;
Q3MaximizingArithmeticExpression q3 = new Q3MaximizingArithmeticExpression("ss");

long xxxxx = q3.Solve("7+6+3-2-7-4*2+4+2-9*6*8");

//int[,] xx = new int[6, 6];

//for (int i = 0; i < 6; i++)
//{
//	for (int j = i; j < 6; j++)
//	{
//		xx[j - i, j] = i;
//	}
//}

//for (int i = 0; i < 6; i++)
//{
//	for (int j = 0; j < 6; j++)
//	{
//		Console.Write(xx[i, j] + " ");
//	}
//	Console.WriteLine();
//}

Console.WriteLine(xxxxx);

//Q2PartitioningSouvenirs q2 = new Q2PartitioningSouvenirs("ss");

//long x = q2.Solve(1, new long[] { 3, 6, 12, 9, 6, 3 });
//Console.WriteLine(x);

//static List<int> func(int x)
//{
//	if (x == 0)
//	{
//		return new List<int>();
//	}
//	else
//	{
//		List<int > list = func(x - 1);
//		list.Add(x);
//		return list;
//	}
//}

//List<int> xx = func(100);

//for (int i = 0; i < xx.Count; i++)
//{
//	Console.WriteLine(xx[i]);
//}