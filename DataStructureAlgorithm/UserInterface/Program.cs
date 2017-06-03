using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSALib;

namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();
            tree.AddNode(new BinaryNode<int>(5));
            tree.AddNode(new BinaryNode<int>(9));
            tree.AddNode(new BinaryNode<int>(34));
            tree.AddNode(new BinaryNode<int>(2));
            tree.AddNode(new BinaryNode<int>(45));
            tree.AddNode(new BinaryNode<int>(14));
            tree.AddNode(new BinaryNode<int>(7)); tree.AddNode(new BinaryNode<int>(19));
            tree.AddNode(new BinaryNode<int>(3));
            Console.WriteLine(tree.Display());
            Console.Read();
        }
    }
}
