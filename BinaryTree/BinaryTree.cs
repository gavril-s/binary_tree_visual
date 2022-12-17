using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree
    {
        /*
         * Класс, описывающий
         * двоичное дерево поиска
         * (BST)
        */

        // корень дерева
        private BinaryTreeNode root;

        public BinaryTree()
        {
            /*
             * Конструктор по умолчанию 
            */

            root = null;
        }

        private BinaryTreeNode firstMatchingInOrder
            (BinaryTreeNode node, Func<BinaryTreeNode, bool> f)
        {
            /*
             * Функция, которая обходит дерево
             * в inorder-порядке начиная с
             * вершины node и возвращает
             * первую вершину, удовлетворяющую
             * условию f (что значит, что f
             * вернула true)
            */

            if (node == null)
            {
                return null;
            }

            BinaryTreeNode left =
                firstMatchingInOrder(node.left, f);
            if (left != null)
            {
                return left;
            }

            if (f(node))
            {
                return node;
            }

            BinaryTreeNode right =
                firstMatchingInOrder(node.left, f);
            if (right != null)
            {
                return right;
            }

            return null;
        }

        private BinaryTreeNode firstMatchingInOrder
            (Func<BinaryTreeNode, bool> f)
        {
            /*
             * Функция, которая обходит дерево
             * в inorder-порядке и возвращает
             * первую вершину, удовлетворяющую
             * условию f (что значит, что f
             * вернула true)
            */

            return firstMatchingInOrder(root, f);
        }

        private int depth(BinaryTreeNode node)
        {
            /*
             * Возвращает глубину
             * дерева, корнем которого
             * является вершина node
            */

            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(
                depth(node.left),
                depth(node.right));
        }

        public List<int?> HeapStyle()
        {
            /*
             * Возвращает дерево,
             * записанное в массив
             * по слоям
             * 
             * Например,
             *    1
             *   / \
             *  0   3
             *     / \
             *    2   4
             * 
             * будет записано как
             * [1, 0, 3, null, null, 2, 4]
            */

            List<int?> res = new List<int?>();

            if (root == null)
            {
                return res;
            }

            List<BinaryTreeNode> layer =
                new List<BinaryTreeNode> { root };
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

                List<BinaryTreeNode> nextLayer =
                    new List<BinaryTreeNode>();
                notNullLayer = false;
                for (int i = 0; i < layer.Count; i++)
                {
                    if (layer[i] == null)
                    {
                        nextLayer.Add(null);
                        nextLayer.Add(null);
                        continue;
                    }

                    if (layer[i].left != null ||
                        layer[i].right != null)
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
            /*
             * Возвращает глубину
             * дерева
            */

            return depth(root);
        }

        public bool Contains(int val)
        {
            /*
             * Проверяет, содержится
             * ли val в дереве
            */

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
            /*
             * Вставляет в дерево
             * новую вершину со
             * значением val
            */

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
                        // Вставляем в правое поддерево

                        if (curr.right == null)
                        {
                            // В поддереве никого нет,
                            // добавляем новую вершину

                            curr.right = new BinaryTreeNode(val);
                            curr.right.parent = curr;
                            break;
                        }
                        else
                        {
                            // Продолжаем поиск 
                            // в правом поддереве

                            curr = curr.right;
                        }
                    }
                    else if (val < curr.value)
                    {
                        // Вставляем в левое поддерево

                        if (curr.left == null)
                        {
                            // В поддереве никого нет,
                            // добавляем новую вершину

                            curr.left = new BinaryTreeNode(val);
                            curr.left.parent = curr;
                            break;
                        }
                        else
                        {
                            // Продолжаем поиск 
                            // в левом поддереве

                            curr = curr.left;
                        }
                    }
                    else
                    {
                        // Нашли val в дереве.
                        // В BST не может быть одинаковых
                        // значений!
                        return;
                    }
                }
            }
        }

        public void Remove(int val)
        {
            /*
             * Удаляет вершину
             * из дерева
            */

            if (root == null)
            {
                return;
            }

            BinaryTreeNode curr = root;
            while (curr != null)
            {
                if (val > curr.value)
                {
                    // Ищем в правом
                    // поддереве

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
                    // Ищем в левом
                    // поддереве

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
                    // Нашли val в дереве.
                    // Удаляем

                    if (curr.left == null && curr.right == null)
                    {
                        // Потомков нет, удаляем просто так

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
                        // Есть правый потомок,
                        // заменяем им удаляемую вершину

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
                        // Есть левый потомок,
                        // заменяем им удаляемую вершину

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
                        // Ищем вершину, которую можно вставить
                        // на место удаляемой, потому что
                        // так просто как в предыдущих случаях
                        // тут не выйдет
                        
                        BinaryTreeNode replace = firstMatchingInOrder(
                            (BinaryTreeNode n) =>
                                {
                                    if (curr.parent != null)
                                    {
                                        if ((curr.parent.left == curr &&
                                             n.value > curr.parent.value) ||
                                            (curr.parent.right == curr &&
                                             n.value < curr.parent.value))
                                        {
                                            return false;
                                        }
                                        if ((curr.left != null &&
                                             curr.left.value > n.value) ||
                                            (curr.right != null &&
                                             curr.right.value < n.value))
                                        {
                                            return false;
                                        }
                                    }
                                    return true;
                                });

                        if (replace == null)
                        {
                            /*
                             * плохо (не можем найти замену, 
                             * а значит не можем удалить) 
                            */
                        }
                        else
                        {
                            /*
                             * Заменяем значение удаляемой вершины
                             * значением replace
                             * и удаляем replace
                            */

                            int newCurrValue = replace.value;
                            Remove(replace.value);
                            curr.value = newCurrValue;
                        }
                    }
                    break;
                }
            }
        }

        public void Replace(int oldVal, int newVal)
        {
            /*
             * У вершины со значением oldVal
             * устанавливает новое значение -
             * newVal
            */

            if (root == null)
            {
                return;
            }

            BinaryTreeNode curr = root;
            while (curr != null)
            {
                if (oldVal > curr.value)
                {
                    // Ищем в правом
                    // поддереве

                    if (curr.right == null)
                    {
                        return;
                    }
                    else
                    {
                        curr = curr.right;
                    }
                }
                else if (oldVal < curr.value)
                {
                    // Ищем в левом
                    // поддереве

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
                    // Нашли oldVal в дереве.
                    // Заменяем

                    if (curr.parent != null)
                    {
                        if (curr == curr.parent.left)
                        {
                            if (newVal > curr.parent.value)
                            {
                                return;
                            }
                        }
                        else if (curr == curr.parent.right)
                        {
                            if (newVal < curr.parent.value)
                            {
                                return;
                            }
                        }
                    }
                    
                    if (curr.left != null && newVal < curr.left.value)
                    {
                        return;
                    }
                    if (curr.right != null && newVal > curr.right.value)
                    {
                        return;
                    }

                    curr.value = newVal;
                }
            }
        }
    }
}
