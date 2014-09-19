using System.Windows;
using CefSharp;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            Cef.Initialize();
            Exit += (s, e) => Cef.Shutdown();
        }
    }
}
