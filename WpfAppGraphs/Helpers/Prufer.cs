using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppGraphs.Helpers
{
    public class Prufer
    {
        public int[] encode(TNode tree)
        {
            int n = TNode.CountVertices(tree);
            if (n <= 2)
            {
                return null;
            }

            TNode treeToDecode = tree;
           
            int[] result = new int[n - 2];
            for(int x = 0; x < n - 2; x++)
            {
                TNode lowestNode = treeToDecode.FindLowestLeaf();
                TNode nearestNeighbor = lowestNode.Parent == null ? lowestNode.Children[0] : lowestNode.Parent;
                result[x] = (int)nearestNeighbor.label;
     
                if(nearestNeighbor.Parent == lowestNode)
                {
                    nearestNeighbor.Parent = null;
                }
                else
                {
                    nearestNeighbor.RemoveChild(lowestNode);
                }
                if(lowestNode.Parent != null)
                    lowestNode.Parent.RemoveChild(lowestNode);
                else if (lowestNode == treeToDecode)
                {
                    treeToDecode = treeToDecode.Children[0];
                }

            }
            return result;
        }

        public TNode decode(List<int> sequence)
        {
            TNode root = new TNode(sequence.FirstOrDefault());
            List<int> b = new List<int>();
            for(int x = 1; x <= sequence.Count + 2; x++)
            {
                b.Add(x);
            }
            List<int> copySequence = sequence.ToList();

          //  for(int x = 0; x <= sequence.Count + 3; x++)
            while(b.Count>2)
            {
                int node = b.Where(y => !sequence.Any(y2 => y2 == y)).Min();
                TNode nodeToLink = root.FindChild(sequence.First());
                if(nodeToLink == null)
                {
                    nodeToLink = root.FindChild(b.First());
                    nodeToLink.AddChild(sequence.First());
                }
                else
                {
                    nodeToLink.AddChild(node);
                }
                sequence.Remove(sequence.First());
                b.Remove(node);
            }

            TNode lastChild = root.FindChild(b.First());
            if(lastChild != null)
            {
                lastChild.AddChild(b[1]);
            }
            else
            {
                root.FindChild(b[1]).AddChild(b[1]);
            }
                
                
                
            return root;
        }
    }
}
