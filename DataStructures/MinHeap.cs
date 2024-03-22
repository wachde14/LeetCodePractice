using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }

    public class MinHeap
    {
        public Node root;
        private int count;

        public MinHeap()
        {
            root = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Insert(int value)
        {
            root = InsertHelper(root, value);
            count++;
        }

        private Node InsertHelper(Node node, int value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.value)
            {
                int temp = node.value;
                node.value = value;
                value = temp;
            }

            if (node.left == null)
                node.left = new Node(value);
            else if (node.right == null)
                node.right = new Node(value);
            else if (node.left != null && node.right != null)
            {
                if (node.left.value < node.right.value)
                    node.left = InsertHelper(node.left, value);
                else
                    node.right = InsertHelper(node.right, value);
            }

            return node;
        }

        public int ExtractMin()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            int min = root.value;
            root.value = int.MaxValue;
            BubbleDown(root);
            count--;

            return min;
        }

        private void BubbleDown(Node node)
        {
            if (node == null)
            {
                return;
            }

            Node minChild = node.left;
            if (node.right != null && node.right.value < minChild.value)
            {
                minChild = node.right;
            }

            if (minChild != null && minChild.value < node.value)
            {
                int temp = node.value;
                node.value = minChild.value;
                minChild.value = temp;
                BubbleDown(minChild);
            }
        }
    }
}
