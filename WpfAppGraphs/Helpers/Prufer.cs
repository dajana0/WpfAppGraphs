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
            TNode treeToDecode = tree;
            TNode lowestNode = tree.FindLowestLeaf();
            int[] result = new int[n - 2];

            return result;
        }

        public void decode(int[] sequence)
        {
            
        }
    }
}
