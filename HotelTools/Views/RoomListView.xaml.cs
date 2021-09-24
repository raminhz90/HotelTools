using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelTools.Views
{
    /// <summary>
    /// Interaction logic for RoomListView.xaml
    /// </summary>
    public partial class RoomListView : Page
    {
        public RoomListView(ViewModels.RoomListViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
