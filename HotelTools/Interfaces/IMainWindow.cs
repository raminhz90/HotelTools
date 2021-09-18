using System.Windows.Controls;

namespace HotelTools.Interfaces
{
    internal interface IMainWindow
    {
        void Show();
        void Close();
        Frame GetMainFrame();
    }
}
