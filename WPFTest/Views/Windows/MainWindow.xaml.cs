using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPFTest.Models;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Group group)) return;
            if (group.Name is null) return;

            var filterStr = GroupNameFilterText.Text;
            if (filterStr.Length == 0) return;
            if (group.Name.IndexOf(filterStr, StringComparison.OrdinalIgnoreCase) >= 0) return;

            e.Accepted = false;
        }

        private void GroupNameFilterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text_box = (TextBox)sender;
            var collection = (CollectionViewSource)text_box.FindResource("GroupsCollection");
            collection.View.Refresh();
        }
    }
}
