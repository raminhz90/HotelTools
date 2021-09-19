using System;
using System.Windows.Controls;

namespace HotelTools.Interfaces
{
    public interface IPageService
    {
        Type GetPageType(string key);

        Page GetPage(string key);
    }
}