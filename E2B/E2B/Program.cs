﻿// See https://aka.ms/new-console-template for more information
using E2;

//Console.WriteLine("Hello, World!");

//Q3ExtractCode q3 = new Q3ExtractCode("ss");

//string s = q3.Solve("9[6[3[a]2[b3[dwd]c]4[wd]7[gfg]9[gg]]7[j]4[h]]9[6[3[a]2[b3[dwd]c]4[wd]7[gfg]9[gg]]7[j]4[h]]9[6[3[a]2[b3[dwd]c]4[wd]7[gfg]9[gg]]7[j]4[h]]9[6[3[a]2[b3[dwd]c]4[wd]7[gfg]9[gg]]7[j]4[h]]9[6[3[a]2[b3[dwd]c]4[wd]7[gfg]9[gg]]7[j]4[h]]9[6[3[a]2[b3[dwd]c]4[wd]7[gfg]9[gg]]7[j]4[h]]9[6[3[a]2[b3[dwd]c]4[wd]7[gfg]9[gg]]7[j]4[h]]9[6[3[a]2[b3[dwd]c]4[wd]7[gfg]9[gg]]7[j]4[h]]9[6[3[a]2[b3[dwd]c]4[wd]7[gfg]9[gg]]7[j]4[h]]");
////Console.WriteLine(s);
//string ss = "aaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhhaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggaaabdwddwddwdcbdwddwddwdcwdwdwdwdgfggfggfggfggfggfggfgggggggggggggggggggjjjjjjjhhhh";
//if (ss != s)
//{
//	Console.WriteLine("here");
//	//Console.WriteLine(s);
//}
//for (int i = 0; i < s.Length; i++)
//{
//	try
//	{

//		if (s[i] != ss[i])
//		{
//			Console.WriteLine(i);

//		}
//	}
//	catch (Exception)
//	{
//		Console.WriteLine($"exception: " + i);
//		Console.WriteLine($"size s {s.Length}");
//		Console.WriteLine($"size ss {ss.Length}");

//		throw;
//	}
//}

//Q1Tickets q1 = new Q1Tickets("ss");

//Q3ExtractCode q3 = new Q3ExtractCode("ss");
Q2Median q2 = new Q2Median("ss");

int n = int.Parse(Console.ReadLine());
List<long> list = new List<long>();

for (int i = 0; i < n; i++)
{
    list.Add(long.Parse(Console.ReadLine()));
}

string s = q2.Solve(n, list.ToArray());

Console.WriteLine("===============================");
Console.WriteLine(s);