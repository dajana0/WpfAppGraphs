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
            // a1();
            // a2();
            //  a3();

            //a4();
            //public void test()
            //{
            TNode root = new TNode(1);
            root.AddChild(2);
            root.Children[0].AddChild(3);
            root.Children[0].AddChild(5);
            root.Children[0].Children[1].AddChild(4);
            root.Children[0].Children[1].AddChild(6);
            //}
           
            List<int> sequence = new List<int>() {5,3,5,3,5};
                Prufer pruf = new Prufer();
              //  TNode result = pruf.decode(sequence);
           // graph.Items.Add(result);
        }
        // TNode tree;


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string[] arr = (sender as TextBox).Text.Split(',').ToArray();
            if (arr.Length < 2) return;
            List<int> sequence = new List<int>() ;
            foreach (string item in arr)
            {
                if(!String.IsNullOrEmpty(item))
                    sequence.Add(int.Parse(item));
            }
            Prufer pruf = new Prufer();
            TNode result = pruf.decode(sequence);
            graph.Items.Clear();
            graph.Items.Add(result);

        }

        private void TextBlock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
    }
}



//public void test()
//{
//    TNode root = new TNode(1);
//    root.AddChild(2);
//    root.children[0].AddChild(3);
//    root.children[0].AddChild(5);
//    root.children[0].children[1].AddChild(4);
//    root.children[0].children[1].AddChild(6);
//    int count = TNode.CountVertices(root);

//    Prufer pruf = new Prufer();
//    int[] result = pruf.encode(root);
//    var ad = 1;
//}


//public void test2()
//{
//    TNode root = new TNode(1);
//    root.AddChild(2);
//    root.children[0].AddChild(9);
//    root.AddChild(3);
//    root.AddChild(4);
//    root.AddChild(5);
//    root.AddChild(6);
//    root.AddChild(7);
//    root.AddChild(8);
//    int count = TNode.CountVertices(root);
//    TNode lowestNode = root.FindLowestLeaf();
//    var a = 0;

//    Prufer pruf = new Prufer();
//    int[] result = pruf.encode(root);
//}

//public void test3()
//{
//    TNode root = new TNode(6);
//    root.AddChild(1);
//    root.children[0].AddChild(4);
//    root.children[0].children[0].AddChild(5);
//    root.children[0].children[0].AddChild(2);
//    root.children[0].children[0].AddChild(3);

//    var a = 0;

//    Prufer pruf = new Prufer();
//    int[] result = pruf.encode(root);
//}

//public void test4()
//{
//    TNode root = new TNode(2);
//    root.AddChild(3);
//    root.children[0].AddChild(1);
//    root.children[0].AddChild(7);
//    root.children[0].AddChild(6);
//    root.children[0].AddChild(5);
//    root.children[0].AddChild(4);

//    Prufer pruf = new Prufer();
//    int[] result = pruf.encode(root);
//}

//public void test5()
//{
//    TNode root = new TNode(5);
//    root.AddChild(1);
//    root.AddChild(4);
//    root.children[0].AddChild(2);
//    root.children[0].AddChild(3);

//    Prufer pruf = new Prufer();
//    int[] result = pruf.encode(root);
//}

//public void test6()
//{
//    TNode root = new TNode(5);
//    root.AddChild(2);
//    root.children[0].AddChild(3);
//    root.children[0].AddChild(4);
//    root.children[0].children[1].AddChild(1);
//    root.children[0].children[1].AddChild(6);

//    Prufer pruf = new Prufer();
//    int[] result = pruf.encode(root);
//}
//public void test7()
//{
//    TNode root = new TNode(1);
//    root.AddChild(4);
//    root.children[0].AddChild(2);
//    root.children[0].AddChild(3);
//    root.children[0].AddChild(5);
//    root.children[0].children[2].AddChild(6);

//    Prufer pruf = new Prufer();
//    int[] result = pruf.encode(root);
//}
//public void a1()
//{
//    List<int> sequence = new List<int>() { 1, 2, 3, 4 };
//    Prufer pruf = new Prufer();
//    TNode result = pruf.decode(sequence);
//}

//public void a2()
//{
//    List<int> sequence = new List<int>() { 2, 2, 5, 5 };
//    Prufer pruf = new Prufer();
//    TNode result = pruf.decode(sequence);
//}

//public void a3()
//{
//    List<int> sequence = new List<int>() { 3, 3, 3, 3, 3 };
//    Prufer pruf = new Prufer();
//    TNode result = pruf.decode(sequence);
//}
//public void a4()
//{
//    List<int> sequence = new List<int>() { 3, 3, 3 };
//    Prufer pruf = new Prufer();
//    TNode result = pruf.decode(sequence);
//}