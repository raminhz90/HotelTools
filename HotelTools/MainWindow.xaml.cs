using HandyControl.Themes;
using HandyControl.Tools;
using HotelTools.Interfaces;
using HotelTools.ViewModels;
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

namespace HotelTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window, IMainWindow
    {
        public MainWindow(Core.Interfaces.IDataBaseService dataBaseService, MainWindowViewModel viewModel)
        {
            ConfigHelper.Instance.SetWindowDefaultStyle();

            InitializeComponent();
            ThemeManager.Current.UsingSystemTheme = true;
            DataContext = viewModel;

        }



        public Frame GetMainFrame() => _frame;


    }
}
