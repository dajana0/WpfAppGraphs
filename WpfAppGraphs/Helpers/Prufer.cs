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

            
            List<int> b = new List<int>();
            for(int x =1; x <= sequence.Count + 2; x++)
            {
                b.Add(x);
            }
            List<int> copySequence = sequence.ToList();
            List<TNode> allNodes = new List<TNode>();
            TNode root = new TNode(sequence.First());

            allNodes.Add(root);
          
            while(sequence.Count !=0)
            {
                int minNodeInb = b.Where(y => !sequence.Any(y2 => y2 == y)).Min();
                int firstInSequence = sequence.First();

                TNode nodeToLink = FindNodeInList(allNodes, firstInSequence);
                TNode x2 = FindNodeInList(allNodes, minNodeInb);
                if (nodeToLink == null)
                {
                    nodeToLink = new TNode(firstInSequence);
                    if (x2 == null) {
                        nodeToLink.AddChild(minNodeInb);
                        allNodes.Add(nodeToLink);
                    }
                    else
                    {
                        x2.AddChild(nodeToLink);
                    }
                }
                else
                {
                    if(x2 == null)
                    {
                        nodeToLink.AddChild(minNodeInb);
                    }
                    else
                    {
                        nodeToLink.AddChild(x2);
                    }
                }

                sequence.Remove(sequence.First());
                b.Remove(minNodeInb);
            }

            TNode lastChild = root.FindChild(b.First());
            if(lastChild != null)
            {
                lastChild.AddChild(b[1]);
            }
            else
            {
                root.FindChild(b[1]).AddChild(b.First());
            }
                    
            return FindRootInList(allNodes);
        }
        private TNode FindRootInList(List<TNode> list)
        {

            foreach (TNode node in list)
            {
                if(node.Parent == null) return node;

            }
            return null;
        }


        public TNode decode2(List<int> sequence)
        {


            List<TNode> allNodes = new List<TNode>();
            List<int> b = new List<int>();
            for (int x = 1; x <= sequence.Count + 2; x++)
            {
                b.Add(x);
                allNodes.Add(new TNode(x));
            }
            // List<int> copySequence = sequence.ToList();

            //allNodes.Add(root);

            while (sequence.Count != 0)
            {
                int minNodeInb = b.Where(y => !sequence.Any(y2 => y2 == y)).Min();
                int firstInSequence = sequence.First();

                TNode nodeToLink = FindNodeInList(allNodes, firstInSequence);
                TNode x2 = FindNodeInList(allNodes, minNodeInb);

                nodeToLink.AddChild(x2);

                sequence.Remove(sequence.First());
                b.Remove(minNodeInb);
            }

            TNode lastChild = FindNodeInList(allNodes, b.First());
            TNode lastLink = FindNodeInList(allNodes, b[1]);
            lastChild.AddChild(lastLink);

            return allNodes.First();
        }



        private TNode FindNodeInList(List<TNode> list, int label)
        {
            TNode result;
            foreach (TNode node in list)
            {
                result = node.FindChild(label);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
//5,3,5,3,5ed