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
        }
    
    }