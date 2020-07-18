
using System;
using System.Runtime.InteropServices.WindowsRuntime;

//Binary search tree -> All left nodes will be small and all right nodes will be large than the root.
// Binary tree -> only the immediate child node will be small(left) and large(right)
namespace Trees
{
	public class Node
	{
		public int Data { get; set; }
		public Node LeftChild { get; set; }
		public Node RightChild { get; set; }

		public Node(int data)
		{
			this.Data = data;
		}

		//public override string ToString()
		//{
		//	return this.LeftChild == null ? "null" : this.LeftChild.Data.ToString() + "<-" +
		//		this.Data.ToString() + "->" +
		//		this.RightChild == null ? "null" : this.RightChild.Data.ToString();
		//}
	}

	public class Tree
	{
		private Node _root;

		public Node Root { get { return _root; } }

		public Tree(int root)
		{
			this._root = new Node(root);
		}

		public void Insert(int value)
		{
			Node current = this._root;
			Node node = new Node(value);
			while (current != null) {
				if(value < current.Data)
				{
					if(current.LeftChild == null)
					{
						current.LeftChild = node;
						return;
					}
					current = current.LeftChild;
				}
				else if (value > current.Data)
				{
					if (current.RightChild == null)
					{
						current.RightChild = node;
						return;
					}
					current = current.RightChild;
				}
				else
				{
					return;
				}
			}
		}

		public bool Find(int value)
		{
			var current = this._root;
			while (current != null)
			{
				if (current.Data == value)
					return true;
				else if (value < current.Data)
					current = current.LeftChild;
				else if (value > current.Data)
					current = current.RightChild;
				
			}
			return false;
		}

		public void PrintPreorder() {
			PreOrder(this._root);
		}

		//Root left right
		private void PreOrder(Node root)
		{
			if(root == null)
				return;
			Console.Write(root.Data + "	");
			PreOrder(root.LeftChild);
			PreOrder(root.RightChild);
		}

		public void PrintInorder()
		{
			InOrder(this._root);
		}

		//Left Root Right
		private void InOrder(Node root)
		{
			if (root == null)
				return;
			InOrder(root.LeftChild);
			Console.Write(root.Data + "	");
			InOrder(root.RightChild);
		}

		public int Height()
		{
			return Height(this._root);
		}

		private int Height(Node root)
		{
			if (root.LeftChild == null && root.RightChild == null)
				return 0;

			int leftHeight = Height(root.LeftChild);
			int rightHeight = Height(root.RightChild);

			var max = Math.Max(leftHeight, rightHeight);

			return 1 + max;
		}

		public int Min()
		{
			return Min(this._root);
		}

		private int Min(Node root)
		{
			if (root.LeftChild == null && root.RightChild == null)
				return root.Data;
			int leftMin = Min(root.LeftChild);
			int rightMin = Min(root.RightChild);

			return Math.Min(leftMin, rightMin);
		}

		private bool IsLeafNode(Node node)
		{
			if (node.LeftChild == null && node.RightChild == null)
				return true;
			return false;
		}

		public bool IsEqual(Tree tree2)
		{
			return IsEqual(_root, tree2.Root);
		}

		private bool IsEqual(Node root1, Node root2) {
			if (root1 == null && root2 == null)
				return true;
			else if (root1 != null && root2 != null)
				return root1.Data == root2.Data
					&& IsEqual(root1.LeftChild, root2.LeftChild)
					&& IsEqual(root1.RightChild, root2.RightChild);
			else
				return false;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var tree1 = new Tree(7);
			tree1.Insert(4);
			tree1.Insert(9);
			tree1.Insert(1);
			tree1.Insert(6);
			tree1.Insert(8);
			tree1.Insert(10);

			var tree2 = new Tree(7);
			tree2.Insert(4);
			tree2.Insert(9);
			tree2.Insert(1);
			tree2.Insert(6);
			tree2.Insert(8);

			Console.WriteLine(tree1.IsEqual(tree2));
			
		}
	}
}
