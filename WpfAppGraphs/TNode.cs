using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppGraphs
{
    public class TNode
    {
        public string Label
        {
            get
            {
                return label.ToString();
            }
        }
        public int? label;
        public List<TNode> Children { get; set; }
        public TNode Parent { get; set; }
        public TNode(int label)
        {
            Children = new List<TNode>();
            this.label = label;
        }

        public TNode GetChild(int label)
        {
            return Children.Where(x => x.label == label).FirstOrDefault();
        }
        public TNode FindChild(int label)
        {
            if(this.label == label)
            {
                return this;
            }
            foreach (TNode child in Children)
            {
                var res = child.FindChild(label);
                if (res !=null)
                    return res;
            }
            return null;
        }
        public TNode AddChild(int label)
        {
            var node = new TNode(label) { Parent = this };
            Children.Add(node);
            return node;
        }
        public void AddChild(TNode child)
        {
            child.Parent = this ;
            //var node = new TNode(label) { Parent = this };
            //Children.Add(node);
            Children.Add(child);
            //return node;
        }
        public void RemoveChild(TNode node)
        {

            Children.RemoveAll(x => x.label == node.label);
        }

        public static int CountVertices(TNode node)
        {
            int counter = 1;
            foreach (var child in node.Children)
            {
                counter += CountVertices(child) ;
            }
            return counter;
        }

        public  TNode FindLowestLeaf()
        {
            
            if (Children.Count == 0) return this;

            TNode currentNode = GetLowestNode(this, null);
            //sprawdzenie dla dzieci
            for (var x = 0; x< Children.Count; x++)
            {
                TNode childLowestNode = GetLowestNode(Children[x], currentNode);
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
        private  TNode GetLowestNode(TNode node , TNode currentLowest)
        {
            if (currentLowest == null || (node.label < currentLowest.label)) {
                if (((node.Parent == null && node.Children.Count == 1) || (node.Parent != null && node.Children.Count == 0)))
                    return node;
            }
            TNode res = null;
            foreach (var child in node.Children)
            {

                res = GetLowestNode(child, currentLowest);

                if (currentLowest == null || (res != null && currentLowest.label > res.label))
                {
                    currentLowest = res;
                }
            }
            return currentLowest;
        }

        public TNode RemoveNodeFormTree(TNode node)
        {
            TNode current = node;
            foreach (var child in current.Children)
            {
                if (child.label == node.label)
                {
                    current.Children.RemoveAll(x => x.label == node.label);
                }
                RemoveNodeFormTree(child);

            }
            return current;
        }


    }
}
