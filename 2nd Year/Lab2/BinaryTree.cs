using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using System;

namespace Lab3._2
{

    public class BinaryNode<T> where T : IComparable<T> 
    {
        public T data { get; set; }
        public BinaryNode<T> left { get; set; }
        public BinaryNode<T> right { get; set; }

        public BinaryNode(T _data) 
        {
            data = _data;
            left = null;
            right = null;
        }
    }
    
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T> 
    {
        public BinaryNode<T> root { get; private set; }

        public IEnumerator<T> GetEnumerator() 
        {
            return preorderIterator(root).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> preorderIterator(BinaryNode<T> node)
        {
            if (node != null)
            {
                // Return the Root
                yield return node.data;

                // Traverse Left
                foreach (var leftData in preorderIterator(node.left))
                {
                    yield return leftData;
                }

                // Traverse Right
                foreach (var rightData in preorderIterator(node.right))
                {
                    yield return rightData;
                }
            }
        }


        public void Insert(T data) 
        {
            root = InsertRecursive(root, data);
        }

        private BinaryNode<T> InsertRecursive(BinaryNode<T> node, T data) 
        {
            if(node == null) return new BinaryNode<T>(data);

            if (data.CompareTo(node.data) < 0) node.left = InsertRecursive(node.left, data);
            else if(data.CompareTo(node.data) > 0) node.right = InsertRecursive(node.right, data);

            return node;
        }

        public void preorderTrav() 
        {
            preorderRecursive(root);
            Console.WriteLine();
        }

        private void preorderRecursive(BinaryNode<T> node) 
        {
            if (node != null) 
            {
                Console.WriteLine(node.data.ToString());

                preorderRecursive(node.left);
                preorderRecursive(node.right);
            }
        }
    }
}
