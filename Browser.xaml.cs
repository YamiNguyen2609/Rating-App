using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
            timer.Interval = TimeSpan.FromSeconds(30);
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
            web_browser.Source = new Uri(Link);

            StartCloseTimer();
        }

        private void web_browser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("click ne");
        }
    }
}
