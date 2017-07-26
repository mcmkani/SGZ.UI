using Syncfusion.Windows.Shared;
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

namespace SGZ.AutoRefresh.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as TicketDetailsViewModel).StartTimer();
        }

        private void datagrid_Unloaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as TicketDetailsViewModel).StopTimer();
        }
    }
}
