using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppGraphs
{
    public class TNode
    {
        public int label;
        public List<TNode> children = new List<TNode>();
        public TNode Parent { get; set; }
        public TNode(int label)
        {
            this.label = label;
        }

        public TNode GetChild(int label)
        {
            return children.Where(x => x.label == label).FirstOrDefault();
        }
        public TNode AddChild(int label)
        {
            var node = new TNode(label) { Parent = this };
            children.Add(node);
            return node;
        }
        public bool RemoveChild(TNode node)
        {
            return children.Remove(node);
        }
        public static int CountVertices(TNode node)
        {
            foreach (var child in node.children)
            {
                return  node.children.Count + CountVertices(child) + 1;
            }
            return 1;
        }
        public override bool Equals(object obj)
        {
            return (label > ((TNode)obj).label);
        }

        public  TNode FindLowestLeaf()
        {
            
            if (children.Count == 0) return this;

            TNode currentNode = GetLowestNode(children[0]);

            for (var x = 1; x< children.Count; x++)
            {
                TNode childLowestNode = GetLowestNode(children[x]);
                if (childLowestNode != null)
                {
                    if(childLowestNode.label < currentNode.label)
                    {
                        currentNode = childLowestNode;
                    }
                }
            }
            return currentNode;

           
        }
        private  TNode GetLowestNode(TNode node)
        {
            if ((node.Parent == null && node.children.Count == 1) || (node.Parent != null && node.children.Count == 0))
                return node;
            foreach (var child in node.children)
            {
                return GetLowestNode(child);
            }
            return null;
        }

    }
}
