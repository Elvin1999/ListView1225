using System;
using System.Collections.Generic;
using System.IO;
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
using WpfApp3.Models;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public void DirSearch(string path)
        {
            try
            {
                foreach (var directory in Directory.GetDirectories(path))
                {
                    var treeViewItem = new TreeViewItem();
                    treeViewItem.Header=Directory.GetParent(directory).Name;
                    foreach (var filename in Directory.GetFiles(directory))
                    {
                        treeViewItem.Items.Add(new TreeViewItem
                        {
                            Header=filename,
                        });
                    }
                    DirSearch(directory);
                    myTree.Items.Add(treeViewItem);

                }
            }
            catch (Exception)
            {
            }
        }
        public List<Book> Books { get; set; } = new List<Book>
        {
            new Book
            {
                Id=1,
                Author="Fyodor Dostoyevski",
                Genre="Criminal",
                Pages=755,
                Publisher="Baku INC",
                Title="Crime and Punishment",
                ImagePath="images/image1.jpg"
            },
            new Book
            {
                Id=2,
                Author="Napolion Hill",
                Genre="Self Improvement",
                Pages=755,
                Publisher="Baku INC",
                Title="Think and Grow Rich",
                ImagePath="images/image2.png"
            },
            new Book
            {
                Id=3,
                Author="Robert Kiyosoki",
                Genre="Self Improvement",
                Pages=550,
                Publisher="Baku INC",
                Title="Rich Dad , Poor Dad",
                ImagePath="images/image3.png"
            }
        };
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = this;
            DirSearch(@"C:\Users\camalzadeelvin");
            //listView.ItemsSource = Books;
        }
    }
}
