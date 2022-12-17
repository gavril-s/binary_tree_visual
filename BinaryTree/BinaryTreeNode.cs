using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class BinaryTreeNode
    {
        /*
         * Класс, описывающий вершину
         * двоичного дерева поиска
        */

        // значение, которое хранится в вершине
        public int value;

        // вершина-родитель
        public BinaryTreeNode parent;

        // дочерняя левая вершина 
        public BinaryTreeNode left;

        // дочерняя правая вершина
        public BinaryTreeNode right;

        public BinaryTreeNode()
        {
            /*
             * Конструктор по умолчанию,
             * устанавливает всё в "ноль"
            */

            value = 0;
            parent = null;
            left = null;
            right = null;
        }

        public BinaryTreeNode(int val)
        {
            /*
             * Конструктор, устанавливающий
             * только хранимое значение
            */

            value = val;
            parent = null;
            left = null;
            right = null;
        }

        public BinaryTreeNode(
            int val, 
            BinaryTreeNode p, 
            BinaryTreeNode l, 
            BinaryTreeNode r)
        {
            /*
             * Конструктор, устанавливающий
             * все параметры класса
            */

            value = val;
            parent = p;
            left = l;
            right = r;
        }
    }
}
