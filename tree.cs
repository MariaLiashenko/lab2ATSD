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
             public void Delete(T target)
            {//and here
                root = Delete(root, target);
            }
                private Node<T> Delete(Node<T> current, T target)
            {
                Node<T> parent;
                if (current == null)
                { return null; }
                else
                {
                    //left subtree<
                    if (Comparer<T>.Default.Compare(current.data,target) == 1  )
                    {
                        current.left = Delete(current.left, target);
                        if (balance_factor(current) == -2)//here
                        {
                            if (balance_factor(current.right) <= 0)
                            {
                                current = RotateRR(current);
                            }
                            else
                            {
                                current = RotateRL(current);
                            }
                        }
                    }
                    //right subtree>
                    else if (Comparer<T>.Default.Compare(target, current.data) == 1 )
                    {
                        current.right = Delete(current.right, target);
                        if (balance_factor(current) == 2)
                        {
                            if (balance_factor(current.left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else
                            {
                                current = RotateLR(current);
                            }
                        }
                    }
                    //if target is found
                    else
                    {
                        if (current.right != null)
                        {
                            //delete its inorder successor
                            parent = current.right;
                            while (parent.left != null)
                            {
                                parent = parent.left;
                            }
                            current.data = parent.data;
                            current.right = Delete(current.right, parent.data);
                            if (balance_factor(current) == 2)//rebalancing
                            {
                                if (balance_factor(current.left) >= 0)
                                {
                                    current = RotateLL(current);
                                }
                                else { current = RotateLR(current); }
                            }
                        }
                        else
                        {   //if current.left != null
                            return current.left;
                        }
                    }
            }
            return current;
        }
            public void Find(T key)
            {
                if (Find(key, root).data.CompareTo(key) == 0)
                {
                    Console.WriteLine("{0} was found!", key);
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
                private Node<T> Find(T target, Node<T> current)
            {
                //<
                if (Comparer<T>.Default.Compare(current.data,target) == 1 )
                {
                    if (target.CompareTo(current.data) == 0)
                    {
                        return current;
                    }
                    else
                        return Find(target, current.left);
                }
                else
                {
                    if (target.CompareTo(current.data) == 0)
                    {
                        return current;
                    }
                    else
                        return Find(target, current.right);
                }

            }
                private int max(int l, int r)
            {
                return l > r ? l : r;
            }
            private int getHeight(Node<T> current)
            {
                int height = 0;
                if (current != null)
                {
                    int l = getHeight(current.left);
                    //Console.WriteLine("l" +l);
                    int r = getHeight(current.right);
                    int m = max(l, r);
                    height = m + 1;
                }
                return height;
            }
            private int balance_factor(Node<T> current)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int b_factor = l - r;
                return b_factor;
            }
                private Node<T> RotateRR(Node<T> parent)
            {
                Node<T> pivot = parent.right;
                parent.right = pivot.left;
                pivot.left = parent;
                return pivot;
            }
            private Node<T> RotateLL(Node<T> parent)
            {
                Node<T> pivot = parent.left;
                parent.left = pivot.right;
                pivot.right = parent;
                return pivot;
            }
            private Node<T> RotateLR(Node<T> parent)
            {
                Node<T> pivot = parent.left;
                parent.left = RotateRR(pivot);
                return RotateLL(parent);
            }
            private Node<T> RotateRL(Node<T> parent)
            {
                Node<T> pivot = parent.right;
                parent.right = RotateLL(pivot);
                return RotateRR(parent);
            }
        }
    
    }