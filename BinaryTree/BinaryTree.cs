using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree
    {
        private BinaryTreeNode root;

        public BinaryTree()
        {
            root = null;
        }

        private BinaryTreeNode firstMatchingInOrder
            (BinaryTreeNode node, Func<BinaryTreeNode, bool> f)
        {
            if (node == null)
            {
                return null;
            }

            BinaryTreeNode left = firstMatchingInOrder(node.left, f);
            if (left != null)
            {
                return left;
            }

            if (f(node))
            {
                return node;
            }

            BinaryTreeNode right = firstMatchingInOrder(node.left, f);
            if (right != null)
            {
                return right;
            }

            return null;
        }

        private BinaryTreeNode firstMatchingInOrder
            (Func<BinaryTreeNode, bool> f)
        {
            return firstMatchingInOrder(root, f);
        }

        private int depth(BinaryTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(depth(node.left), depth(node.right));
        }

        public List<int?> HeapStyle()
        {
            List<int?> res = new List<int?>();

            if (root == null)
            {
                return res;
            }

            List<BinaryTreeNode> layer = new List<BinaryTreeNode> { root };
            bool notNullLayer = true;
            while (notNullLayer)
            {
                for (int i = 0; i < layer.Count; i++)
                {
                    if (layer[i] != null)
                    {
                        res.Add(layer[i].value);
                    }
                    else
                    {
                        res.Add(null);
                    }
                }
                
                List<BinaryTreeNode> nextLayer = new List<BinaryTreeNode>();
                notNullLayer = false;
                for (int i = 0; i < layer.Count; i++)
                {
                    if (layer[i] == null)
                    {
                        nextLayer.Add(null);
                        nextLayer.Add(null);
                        continue;
                    }

                    if (layer[i].left != null || layer[i].right != null)
                    {
                        notNullLayer = true;
                    }
                    nextLayer.Add(layer[i].left);
                    nextLayer.Add(layer[i].right);
                }
                layer = nextLayer;
            }

            return res;
        }

        public int Depth()
        {
            return depth(root);
        }

        public bool Contains(int val)
        {
            if (root == null)
            {
                return false;
            }
            else
            {
                BinaryTreeNode curr = root;
                while (curr != null)
                {
                    if (val > curr.value)
                    {
                        curr = curr.right;
                    }
                    else if (val < curr.value)
                    {
                        curr = curr.left;
                    }
                    else
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public void Insert(int val)
        {
            if (root == null)
            {
                root = new BinaryTreeNode(val);
            }
            else
            {
                BinaryTreeNode curr = root;
                while (curr != null)
                {
                    if (val > curr.value)
                    {
                        if (curr.right == null)
                        {
                            curr.right = new BinaryTreeNode(val);
                            curr.right.parent = curr;
                            break;
                        }
                        else
                        {
                            curr = curr.right;
                        }
                    }
                    else if (val < curr.value)
                    {
                        if (curr.left == null)
                        {
                            curr.left = new BinaryTreeNode(val);
                            curr.left.parent = curr;
                            break;
                        }
                        else
                        {
                            curr = curr.left;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public void Remove(int val)
        {
            if (root == null)
            {
                return;
            }

            BinaryTreeNode curr = root;
            while (curr != null)
            {
                if (val > curr.value)
                {
                    if (curr.right == null)
                    {
                        return;
                    }
                    else
                    {
                        curr = curr.right;
                    }
                }
                else if (val < curr.value)
                {
                    if (curr.left == null)
                    {
                        return;
                    }
                    else
                    {
                        curr = curr.left;
                    }
                }
                else
                {
                    if (curr.left == null && curr.right == null)
                    {
                        if (curr == root)
                        {
                            root = null;
                        }

                        if (curr.parent != null)
                        {
                            if (curr.parent.left == curr)
                            {
                                curr.parent.left = null;
                            }
                            else if (curr.parent.right == curr)
                            {
                                curr.parent.right = null;
                            }
                        }
                    }
                    else if (curr.left == null && curr.right != null)
                    {
                        if (curr == root)
                        {
                            root = curr.right;
                        }

                        if (curr.parent != null)
                        {
                            if (curr.parent.left == curr)
                            {
                                curr.parent.left = curr.right;
                                curr.right.parent = curr.parent;
                            }
                            else if (curr.parent.right == curr)
                            {
                                curr.parent.right = curr.right;
                                curr.right.parent = curr.parent;
                            }
                        }
                    }
                    else if (curr.left != null && curr.right == null)
                    {
                        if (curr == root)
                        {
                            root = curr.left;
                        }

                        if (curr.parent != null)
                        {
                            if (curr.parent.left == curr)
                            {
                                curr.parent.left = curr.left;
                                curr.left.parent = curr.parent;
                            }
                            else if (curr.parent.right == curr)
                            {
                                curr.parent.right = curr.left;
                                curr.left.parent = curr.parent;
                            }
                        }
                    }
                    else if (curr.left != null && curr.right != null)
                    {
                        BinaryTreeNode replace = firstMatchingInOrder(
                            (BinaryTreeNode n) => 
                                {
                                    if (curr.parent != null)
                                    {
                                        if ((curr.parent.left == curr  && n.value > curr.parent.value) ||
                                            (curr.parent.right == curr && n.value < curr.parent.value))
                                        {
                                            return false;
                                        }
                                        if ((curr.left != null && curr.left.value > n.value) || 
                                            (curr.right != null && curr.right.value < n.value))
                                        {
                                            return false;
                                        }
                                    }
                                    return true;
                                });

                        if (replace == null)
                        {
                            /* пиздец */
                        }
                        else
                        {
                            int newCurrValue = replace.value;
                            Remove(replace.value);
                            curr.value = newCurrValue;
                        }
                    }

                    break;
                }
            }
        }
    }
}
