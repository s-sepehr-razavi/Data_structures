// See https://aka.ms/new-console-template for more information
using A6;

Q5LCSOfThree q4 = new Q5LCSOfThree("ss");
string str1 = "7 1";
string str2 = "10 15 16 17 14 2 3 8 9 4 5 7 1";
string str3 = "1 17 10 4 0";
long[] arr1 = Array.ConvertAll(str1.Split(), s => long.Parse(s));
long[] arr2 = Array.ConvertAll(str2.Split(), s => long.Parse(s));
long[] arr3 = Array.ConvertAll(str3.Split(), s => long.Parse(s));


long x = q4.Solve(arr1, arr2, arr3);
Console.WriteLine(x);