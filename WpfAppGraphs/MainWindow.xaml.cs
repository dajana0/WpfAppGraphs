using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppGraphs.Helpers;

namespace WpfAppGraphs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // test();
            // test2();
            // test3();
            //test4();
            //test5();
            //test6();
            //test7();
            a3();
        }

        public void test()
        {
            TNode root = new TNode(1);
            root.AddChild(2);
            root.children[0].AddChild(3);
            root.children[0].AddChild(5);
            root.children[0].children[1].AddChild(4);
            root.children[0].children[1].AddChild(6);
            int count = TNode.CountVertices(root);

            Prufer pruf = new Prufer();
            int[] result = pruf.encode(root);
            var ad = 1;
        }


        public void test2()
        {
            TNode root = new TNode(1);
            root.AddChild(2);
            root.children[0].AddChild(9);
            root.AddChild(3);
            root.AddChild(4);
            root.AddChild(5);
            root.AddChild(6);
            root.AddChild(7);
            root.AddChild(8);
            int count = TNode.CountVertices(root);
            TNode lowestNode = root.FindLowestLeaf();
            var a = 0;

            Prufer pruf = new Prufer();
            int[] result = pruf.encode(root);
        }

        public void test3()
        {
            TNode root = new TNode(6);
            root.AddChild(1);
            root.children[0].AddChild(4);
            root.children[0].children[0].AddChild(5);
            root.children[0].children[0].AddChild(2);
            root.children[0].children[0].AddChild(3);

            var a = 0;

            Prufer pruf = new Prufer();
            int[] result = pruf.encode(root);
        }

        public void test4()
        {
            TNode root = new TNode(2);
            root.AddChild(3);
            root.children[0].AddChild(1);
            root.children[0].AddChild(7);
            root.children[0].AddChild(6);
            root.children[0].AddChild(5);
            root.children[0].AddChild(4);

            Prufer pruf = new Prufer();
            int[] result = pruf.encode(root);
        }

        public void test5()
        {
            TNode root = new TNode(5);
            root.AddChild(1);
            root.AddChild(4);
            root.children[0].AddChild(2);
            root.children[0].AddChild(3);

            Prufer pruf = new Prufer();
            int[] result = pruf.encode(root);
        }

        public void test6()
        {
            TNode root = new TNode(5);
            root.AddChild(2);
            root.children[0].AddChild(3);
            root.children[0].AddChild(4);
            root.children[0].children[1].AddChild(1);
            root.children[0].children[1].AddChild(6);

            Prufer pruf = new Prufer();
            int[] result = pruf.encode(root);
        }
        public void test7()
        {
            TNode root = new TNode(1);
            root.AddChild(4);
            root.children[0].AddChild(2);
            root.children[0].AddChild(3);
            root.children[0].AddChild(5);
            root.children[0].children[2].AddChild(6);

            Prufer pruf = new Prufer();
            int[] result = pruf.encode(root);
        }
        public void a1()
        {
            List<int> sequence = new List<int>() { 1, 2, 3, 4 };
            Prufer pruf = new Prufer();
            TNode result = pruf.decode(sequence);
        }

        public void a2()
        {
            List<int> sequence = new List<int>() { 1, 2, 3, 4 };
            Prufer pruf = new Prufer();
            TNode result = pruf.decode(sequence);
        }

        public void a3()
        {
            List<int> sequence = new List<int>() { 3, 3, 3, 3,3 };
            Prufer pruf = new Prufer();
            TNode result = pruf.decode(sequence);
        }
    }
}
