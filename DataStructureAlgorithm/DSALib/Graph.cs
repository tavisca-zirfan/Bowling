using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DSALib
{
    public class Graph<T>
    {
        public NodeList<T> NodeSet { get; set; }
        public Graph():this(null){}

        public Graph(NodeList<T> nodeSet)
        {
            if (nodeSet != null)
                this.NodeSet = nodeSet;
            else
            {
                this.NodeSet = new NodeList<T>();
            }
        }

        public void AddNode(GraphNode<T> node)
        {
            this.NodeSet.Add(node);
        }

        public void AddNode(T value)
        {
            this.NodeSet.Add(new GraphNode<T>(value));
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, double cost)
        {
            from.Neighbours.Add(to);
            from.Cost.Add(cost);

            to.Neighbours.Add(from);
            to.Cost.Add(cost);
        }

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, double cost)
        {
            from.Neighbours.Add(to);
            from.Cost.Add(cost);
        }

        public GraphNode<T> FindByValue(T value)
        {
            return (GraphNode<T>) this.NodeSet.FindByValue(value);
        }

        public bool Contains(T value)
        {
            return FindByValue(value) != null;
        }

        public int Count
        {
            get { return NodeSet.Count; }
        }
    }

    public class GraphNode<T> : Node<T>
    {
        private List<double> _cost; 
        public List<double> Cost
        {
            get { return this._cost ?? (this._cost = new List<double>()); }
        }

        public GraphNode():base(){}

        public GraphNode(T value):base(value){}

        public GraphNode(T value, NodeList<T> neighbours) : base(value, neighbours)
        {
            
        }

        public new NodeList<T> Neighbours
        {
            get { return base.Neighbours ?? (base.Neighbours = new NodeList<T>()); }
        }


    }

    
}
