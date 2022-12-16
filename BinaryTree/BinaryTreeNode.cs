using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class BinaryTreeNode
    {
        public int value;
        public BinaryTreeNode parent;
        public BinaryTreeNode left;
        public BinaryTreeNode right;

        public BinaryTreeNode()
        {
            value = 0;
            parent = null;
            left = null;
            right = null;
        }

        public BinaryTreeNode(int val)
        {
            value = val;
            parent = null;
            left = null;
            right = null;
        }

        public BinaryTreeNode(int val, BinaryTreeNode p, BinaryTreeNode l, BinaryTreeNode r)
        {
            value = val;
            parent = p;
            left = l;
            right = r;
        }
    }
}
