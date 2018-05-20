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
            for (int x = 0; x < n - 2; x++)
            {
                TNode lowestNode = treeToDecode.FindLowestLeaf();
                TNode nearestNeighbor = lowestNode.Parent == null ? lowestNode.Children[0] : lowestNode.Parent;
                result[x] = (int)nearestNeighbor.label;

                if (nearestNeighbor.Parent == lowestNode)
                {
                    nearestNeighbor.Parent = null;
                }
                else
                {
                    nearestNeighbor.RemoveChild(lowestNode);
                }
                if (lowestNode.Parent != null)
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
            for (int x = 1; x <= sequence.Count + 2; x++)
            {
                b.Add(x);
            }
            List<int> copySequence = sequence.ToList();
            List<TNode> allNodes = new List<TNode>();
            TNode root = new TNode(sequence.First());

            allNodes.Add(root);

            while (sequence.Count != 0)
            {
                int minNodeInb = b.Where(y => !sequence.Any(y2 => y2 == y)).Min();
                int firstInSequence = sequence.First();

                TNode nodeToLink = FindNodeInList(allNodes, firstInSequence);
                TNode x2 = FindNodeInList(allNodes, minNodeInb);
                if (nodeToLink == null)
                {
                    nodeToLink = new TNode(firstInSequence);
                    if (x2 == null)
                    {
                        nodeToLink.AddChild(minNodeInb);
                        allNodes.Add(nodeToLink);
                    }
                    else
                    {
                        nodeToLink.AddChild(x2);
                    }
                }
                else
                {
                    if (x2 == null)
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

            TNode lastChild = FindNodeInList(allNodes, b.First());
            TNode lastlink = FindNodeInList(allNodes, b[1]);
            if (lastChild == null)
            {
                lastChild = new TNode(b.First());
            }
            if (lastlink == null)
            {
                lastlink = new TNode(b[1]);
            }
            lastlink.AddChild(lastChild);
            // if (lastChild != null)
            // {

            //     lastChild.AddChild(lastlink);
            // }
            // else
            // {
            //     root.FindChild(b[1]).AddChild(b.First());
            //}

            return recursiveFindRoot(root);//FindRootInList(allNodes);
        }

        public TNode decode5(List<int> a)
        {
            List<int> b = new List<int>();
            for (int x = 1; x <= a.Count + 2; x++)
            {
                b.Add(x);
            }

            TNode root = new TNode(1);
            List<TNode> reminidingNodes = new List<TNode>();
            while (b.Count != 2)
            {
                int smallestInb = b.Where(y => !a.Any(y2 => y2 == y)).Min();
                int firstInA = a.First();
                bool isInA = true;
                bool isInB = true;
                TNode node = root.FindChild(firstInA);
                TNode parent = null;
                TNode child = null;
                if (node == null)
                {
                    isInA = false;
                    node = root.FindChild(smallestInb);
                }
                else
                {
                    parent = node;
                }

                if (node == null)
                {
                    isInB = false;
                    if (firstInA < smallestInb)
                    {
                        parent = new TNode(firstInA);
                    }
                    else
                    {
                        parent = new TNode(smallestInb);
                    }
                }
                else
                {
                    if (parent == null)
                        parent = node;
                }
                bool IsnodeAinList = false;
                bool IsnodeBinList = false;
                bool childInList = false;
                if (isInA == false && isInB == false)
                {
                    if (node == null)
                    {
                        node = FindNodeInList(reminidingNodes, smallestInb);

                    }
                    if (node == null)
                    {
                        IsnodeBinList = false;
                        node = FindNodeInList(reminidingNodes, firstInA);
                    }
                    else
                    {
                        parent = node;
                        IsnodeBinList = true;
                    }
                    if (node == null)
                    {
                        IsnodeAinList = false;
                        if (firstInA < smallestInb)
                        {
                            parent = new TNode(firstInA);
                        }
                        else
                        {
                            parent = new TNode(smallestInb);
                        }
                    }
                    else
                    {
                        IsnodeAinList = true;
                        parent = node;
                    }
                }
                if( isInA && isInB)
                {
                    child = FindNodeInList(reminidingNodes, smallestInb);
                    if(child == null)
                    {
                        child = new TNode(smallestInb);
                    }
                }

                if ((isInA && isInB == false) || (isInB && isInA == false))
                {
                    if (isInA)
                    {
                        child = FindNodeInList(reminidingNodes, smallestInb);
                        if (child == null)
                        {
                            child = new TNode(smallestInb);
                        }
                    }
                    if (isInB)
                    {
                        child = FindNodeInList(reminidingNodes, firstInA);
                        if (child == null)
                        {
                            child = new TNode(firstInA);
                        }
                    }
                    childInList = true;
                }


                if (!isInA && !isInB && !IsnodeAinList && !IsnodeBinList)
                {
                    if (firstInA < smallestInb)
                        parent.AddChild(smallestInb);
                    else
                        parent.AddChild(firstInA);
                    reminidingNodes.Add(parent);
                }
                
                else if ((isInA && isInB )||childInList)
                {
                    parent.AddChild(child);
                }
                else if (isInA || IsnodeAinList)
                {
                    parent.AddChild(smallestInb);
                }
                else if (isInB || IsnodeBinList)
                {
                    parent.AddChild(firstInA);
                }
                a.Remove(a.First());
                b.Remove(smallestInb);
            }
            TNode last = root.FindChild(b[0]);
            if (last == null)
            {
                root.FindChild(b[1]).AddChild(b[0]);
            }
            else
            {
                last.AddChild(b[1]);
            }


            return root;
        }
        private TNode FindRootInList(List<TNode> list)
        {
            TNode result;
            foreach (TNode node in list)
            {
                result = recursiveFindRoot(node);
                if (result != null) return result;
            }
            return null;
        }

        private TNode recursiveFindRoot(TNode node)
        {
            if (node.Parent == null)
                return node;
            var result = recursiveFindRoot(node.Parent);
            return result;
        }



        private TNode FindNodeInList(List<TNode> list, int label)
        {
            TNode result;
            foreach (TNode node in list)
            {
                if (node.label == label)
                    return node;
                result = node.FindChild(label);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
//5,3,5,3,5ed