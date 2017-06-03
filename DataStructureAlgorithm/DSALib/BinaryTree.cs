using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALib
{
    public class BinaryTree<T>:Tree<T> where T:IComparable
    {
        public BinaryTree()
        {
            
        }

        private List<T> _inorder = new List<T>();
        public BinaryTree(BinaryNode<T> root ):base(root){}

        public void AddNode(BinaryNode<T> node)
        {
            if (Root == null)
                Root = node;
            else
            {
                var nodeToBeInsertedValue = node.Value;
                var current = (BinaryNode<T>)Root;
                while (true)
                {
                    if (nodeToBeInsertedValue.CompareTo(current.Value) < 0)
                    {
                        if (current.LeftNode != null)
                        {
                            current = current.LeftNode;
                        }
                        else
                        {
                            current.LeftNode = node;
                            break;
                        }
                    }
                    else
                    {
                        if (current.RightNode != null)
                        {
                            current = current.RightNode;
                        }
                        else
                        {
                            current.RightNode = node;
                            break;
                        }
                    }
                }
            }
        }

        private void CreateDisplay(BinaryNode<T> node )
        {
            if(node==null)
                return;
            CreateDisplay(node.LeftNode);
            _inorder.Add(node.Value);
            CreateDisplay(node.RightNode);
            
        }

        public string Display()
        {
            CreateDisplay((BinaryNode<T>)Root);
            var response = "";
            _inorder.ForEach(m=>response+=","+m.ToString());
            return response;
        }
    }

    public class BinaryNode<T> : Node<T>
    {
        public BinaryNode(T value) : base(value)
        {
            this.Neighbours = new NodeList<T>(2);
        }

        public BinaryNode(T value,BinaryNode<T> leftNode,BinaryNode<T> rightNode)
            : base(value)
        {
            this.Neighbours = new NodeList<T>(2);
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public BinaryNode<T> LeftNode
        {
            get { return this.Neighbours[0] as BinaryNode<T>; }
            set { Neighbours[0] = value; }
        }

        public BinaryNode<T> RightNode
        {
            get { return this.Neighbours[1] as BinaryNode<T>; }
            set { Neighbours[1] = value; }
        }
    }
}
