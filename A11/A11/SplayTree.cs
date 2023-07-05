//using System;

//namespace A11
//{

//	public class SplayTree
//	{
//		public class Node
//		{
//			public Node parent;
//			public Node left; public Node right;
//			public var key;

//		}

//		Node root;

//		public void rotate(Node x, bool is_it_left)
//		{
//			if (x == null)
//			{
//				return;
//			}

//			Node parent = x.parent;
//			Node y = is_it_left ?
//				x.right : x.left;
//			Node b = is_it_left ?
//				y.left : y.right;

//			if (is_it_left)
//				y.left = x;
//			else
//				y.right = x;
//			y.parent = parent;
//			if (parent.left == x)
//			{
//				parent.left = y;
//			}
//			else
//			{
//				parent.right = y;
//			}

//			x.parent = y;
//			if (is_it_left)
//				x.right = b;
//			else
//				x.left = b;
//			b.parent = x;
//		}



//	}
//}