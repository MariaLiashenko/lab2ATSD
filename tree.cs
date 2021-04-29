using System;
using System.Collections.Generic;

namespace ATSD2lab
{
    class Program
    { 
      static void Main(string[] args)
        {

        }  
    }
}
class Node<T>
    {
        public T data;
        public Node<T> left;
        public Node<T> right;
        public Node(T data)
        {
            this.data = data;
        }
        class AVL<T> where T : IComparable
        {                 
            Node<T> root;        
            public AVL()
            {
            }                
            public AVL(T data)
            {
                root = new Node<T>(data);
            }
                
            public AVL(Node<T> node)
            {
                root = node;
            }
            public void Add(T data)
            {
                Node<T> newItem = new Node<T>(data);
                if (root == null)
                {
                    root = newItem;
                    //Console.WriteLine(newItem.data);
                }
                else
                {
                    root = RecursiveInsert(root, newItem);
                }
            }
            private Node<T> RecursiveInsert(Node<T> current, Node<T> n)
            {
                if (current == null)
                {
                    current = n;
                    return current;
                }
                //<
                else if (Comparer<T>.Default.Compare(current.data,n.data) == 1  )
                {
                    current.left = RecursiveInsert(current.left, n);
                    current = balance_tree(current);
                }
                //>
                else if (Comparer<T>.Default.Compare(n.data,current.data) == 1  )
                {
                    current.right = RecursiveInsert(current.right, n);
                    current = balance_tree(current);
                }
                return current;
            }
            private Node<T> balance_tree(Node<T> current)
            {
                int b_factor = balance_factor(current);
                if (b_factor > 1)
                {
                    if (balance_factor(current.left) > 0)
                    {
                        current = RotateLL(current);
                    }
                    else
                    {
                        current = RotateLR(current);
                    }
                }
                else if (b_factor < -1)
                {
                    if (balance_factor(current.right) > 0)
                    {
                        current = RotateRL(current);
                    }
                    else
                    {
                        current = RotateRR(current);
                    }
                }
                return current;
            }
            private int balance_factor(Node<T> current)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int b_factor = l - r;
                return b_factor;
            }
        }
    
    }