
using System;
using System.Windows;
using System.Windows.Threading;

namespace Rating_App
{
    /// <summary>
    /// Interaction logic for Browser.xaml
    /// </summary>
    public partial class Browser : Window
    {
        private DispatcherTimer timer;

        private string Link;

        public Browser(string _link)
        {
            Link = _link;

            InitializeComponent();    
        }

        private void StartCloseTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(60);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // var env = await CoreWebView2Environment.CreateAsync(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/Webview.Support");
            //await web_browser.EnsureCoreWebView2Async(env);
                web_browser.Source = new Uri(Link);

            StartCloseTimer();
        }
    }
}
