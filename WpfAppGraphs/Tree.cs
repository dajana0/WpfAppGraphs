using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppGraphs
{
    public class TNode
    {
        public int? label;
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
        public TNode FindChild(int label)
        {
            if(this.label == label)
            {
                return this;
            }
            foreach (TNode child in children)
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
            children.Add(node);
            return node;
        }
        public void RemoveChild(TNode node)
        {

            children.RemoveAll(x => x.label == node.label);
        }

        public static int CountVertices(TNode node)
        {
            int counter = 1;
            foreach (var child in node.children)
            {
                counter += CountVertices(child) ;
            }
            return counter;
        }

        public  TNode FindLowestLeaf()
        {
            
            if (children.Count == 0) return this;

            TNode currentNode = GetLowestNode(this, null);
            //sprawdzenie dla dzieci
            for (var x = 0; x< children.Count; x++)
            {
                TNode childLowestNode = GetLowestNode(children[x], currentNode);
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
                if (((node.Parent == null && node.children.Count == 1) || (node.Parent != null && node.children.Count == 0)))
                    return node;
            }
            TNode res = null;
            foreach (var child in node.children)
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
            foreach (var child in current.children)
            {
                if (child.label == node.label)
                {
                    current.children.RemoveAll(x => x.label == node.label);
                }
                RemoveNodeFormTree(child);

            }
            return current;
        }


    }
}
