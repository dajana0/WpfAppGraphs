using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppGraphs
{
    public class TNode<T>
    {
        public T label;
        public List<TNode<T>> children = new List<TNode<T>>();
        public TNode<T> Parent { get; set; }
        public TNode(T label)
        {
            this.label = label;
        }

        public TNode<T> GetChild(T label)
        {
            return children.Where(x => x.label.ToString() == label.ToString()).FirstOrDefault();
        }
        public TNode<T> AddChild(T label)
        {
            var node = new TNode<T>(label) { Parent = this };
            children.Add(node);
            return node;
        }
        public bool RemoveChild(TNode<T> node)
        {
            return children.Remove(node);
        }
        public static int CountVertices(TNode<T> node)
        {
            foreach (var child in node.children)
            {
                return  node.children.Count + CountVertices(child) + 1;
            }
            return 1;
        }

    }
}
