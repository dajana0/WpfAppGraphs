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
            test();
        }

        public void test()
        {
            TNode<int> root = new TNode<int>(1);
            root.AddChild(2);
            root.children[0].AddChild(3);
            root.children[0].AddChild(4);
            root.children[0].children[1].AddChild(5);
            root.children[0].children[1].AddChild(6);
            int count = TNode<int>.CountVertices(root);
            var a = 0;
        }
    }
}
