using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALib
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        public Tree():this(null){}

        public Tree(Node<T> rootNode)
        {
            this.Root = rootNode;
        }
    }

    public class Node<T>
    {
        public NodeList<T> Neighbours { get; set; }
        public T Value { get; set; }

        public Node():this(default(T),null){}
        public Node(T value) : this(value, null){}
        public Node(T value,NodeList<T> neighbours )
        {
            this.Value = value;
            this.Neighbours = neighbours;
        }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList():base(){}

        public NodeList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                base.Items.Add(default(Node<T>));
            }
        }

        public Node<T> FindByValue(T value)
        {
            return this.FirstOrDefault(node => node.Value.Equals(value));
        }
    }
}
