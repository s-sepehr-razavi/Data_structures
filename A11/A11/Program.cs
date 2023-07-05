//// See https://aka.ms/new-console-template for more information
using A11;


////Q1BinaryTreeTraversals q1 = new Q1BinaryTreeTraversals("ss");

////long n = Convert.ToInt64(Console.ReadLine());
////long[][] arr = new long[n][];

////for (int i = 0; i < n; i++)
////{
////    arr[i] = Array.ConvertAll(Console.ReadLine().Split(), s => long.Parse(s));
////}

//////var x = q1.Solve(arr);

//////for (int i = 0; i < 3; i++)
//////{
//////	for (int j = 0; j < x[i].Length; j++)
//////	{
//////		Console.Write($"{x[i][j]} ");
//////	}
//////	Console.WriteLine();
//////}
////int[][] x = new int[2][];
////x[0] = new int[] { 1, 2, 3 };
////x[1] = new int[] { 1, 2, 3 };
////Console.WriteLine(x.Length);
////SplayTree splay = new SplayTree();
////Node node= new Node();
////node.key= 0;
////splay.root= node;

////node.left = new Node();
////node.left.parent = node;
////node.left.key = -1;

////node.right = new Node();
////node.right.parent = node;
////node.right.key = 1;

////node.left.left = new Node();
////node.left.left.key = -2;
////node.left.left.parent = node.left;

//////splay.traverse(node);
//////Node y = splay.rotate(node, false);
//////splay.bfs(splay.root);
//////Console.WriteLine("================================================================");
////splay.Splay(node.left.left);
//////Console.WriteLine();
//////splay.traverse(splay.root);
//////Console.WriteLine();
//////Console.WriteLine(splay.root.right.right.key);
//////splay.bfs(splay.root);
////Console.WriteLine("================================================================");
//////Console.WriteLine(splay.root.right.right.right.parent.key);
////splay.Splay(splay.root.right.right.right);
////splay.insert(8);
////splay.bfs(splay.root);

//SplayTree splay = new SplayTree();
////splay.insert(4);
////splay.insert(6);
////splay.insert(0);
////splay.insert(2);
////splay.insert(1);
////splay.insert(3);
//Random rand = new Random();
//List<int> ints= new List<int>();
//for (int i = 0; i < 6; i++)
//{
//    int x = rand.Next(-10, 10);
//    Console.WriteLine($"added node: {x}");
//    splay.insert(x);
//    ints.Add(x);
//}
////Console.WriteLine(splay.root.right.right.key);
//Console.WriteLine("===============================================================");
//splay.bfs(splay.root);

////Node n = splay.find(3, splay.root);
////Console.WriteLine($"n: {n.key}");
////Console.WriteLine($"suc: {splay.successor(n).key}");
////Console.WriteLine($"pre: {splay.predecessor(n).key}");
//Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
//for (int i = 0; i < ints.Count; i++)
//{
//    Console.WriteLine($"to delete {ints[i]}");
//    Console.WriteLine("before deletion:\n");
//    splay.bfs(splay.root);
//    splay.delete(ints[i]);
//    Console.WriteLine("after deletion:\n");
//    splay.bfs(splay.root);

//}

//Q4SetWithRangeSums q4 = new Q4SetWithRangeSums("ss");
//string input;
//List<string> inputs = new List<string>();

//while(true)
//{
//    input = Console.ReadLine();
//	if (input == "end")
//	{
//		break;
//	}
//	else
//	{
//		inputs.Add(input);
//	}
//}

//string[] strings = q4.Solve(inputs.ToArray());

//foreach (var item in strings)
//{
//	long.TryParse(item, out long value);
//	if (value < 0)
//	{
//		Console.WriteLine(item);
//		break;
//	}
//	Console.WriteLine(item);

//}

Q5Rope q5 = new Q5Rope("ss");
//string s = "fdxsdsc";
//_SplayTree _SplayTree = new _SplayTree();
//_SplayTree.array_to_tree(s, 0, s.Length - 1);
////_SplayTree.traverse(_SplayTree.root);
////Console.WriteLine();
////_SplayTree.bfs(_SplayTree.root);
////Console.WriteLine();
////Console.WriteLine(_SplayTree.find(6, _SplayTree.root).key);
//_SplayTree.bfs(_SplayTree.root);
//Console.WriteLine();
//Tuple<_SplayTree, _SplayTree> tuple = q5.split(3, _SplayTree);
//_SplayTree.traverse(tuple.Item1.root);
//Console.WriteLine();
//_SplayTree.traverse(tuple.Item2.root);
//Console.WriteLine();
//_SplayTree sp = q5.merge(tuple.Item2,tuple.Item1);
//sp.traverse(sp.root);
//_Node node= _SplayTree.find(3, _SplayTree.root);
//_SplayTree.bfs(_SplayTree.root);
//Console.WriteLine();
////Console.WriteLine(node.key);
//_SplayTree.Splay(node);
////Console.WriteLine();
//_SplayTree.bfs(_SplayTree.root);
string str = Console.ReadLine();
string input;
List<long[]> list = new List<long[]>();
while (true)
{
	input = Console.ReadLine();
	if (input == "end")
	{
		break;
	}

	list.Add(Array.ConvertAll(input.Split(), s => long.Parse(s)));
}

q5.Solve(str, list.ToArray());

//_SplayTree sp = new _SplayTree();
//string str = "yqhuvyarn";
//sp.array_to_tree(str, 0, str.Length - 1);
//sp = q5.do_the_thing(new long[] { 5, 7, 0 }, sp);
//sp.traverse(sp.root);
//Console.WriteLine();
//Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
//sp = q5.do_the_thing(new long[] { 1, 4, 1 }, sp);
//sp.traverse(sp.root);
//Console.WriteLine();
//Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
//sp = q5.do_the_thing(new long[] { 7, 8, 6 }, sp);
//sp.traverse(sp.root);
//Console.WriteLine();
//Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
//sp = q5.do_the_thing(new long[] { 0, 3, 2 }, sp);
//sp.traverse(sp.root);
//Console.WriteLine();
//Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");