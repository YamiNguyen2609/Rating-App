
using Microsoft.Web.WebView2.Core;
using System;
using System.IO;
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                web_browser.Source = new Uri(Link);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Browser - " + ex.Message.ToString());
            }
            StartCloseTimer();
        }
    }
}
