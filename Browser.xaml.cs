
using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Windows.Devices.Input;

namespace Rating_App
{
    /// <summary>
    /// Interaction logic for Browser.xaml
    /// </summary>
    public partial class Browser : Window
    {
        private DispatcherTimer timer;

        private string Link;

        private bool IskeyBoard;

        private Process process;

        public Browser(string _link, bool _isKeyboard = false)
        {
            Link = _link;

            IskeyBoard = _isKeyboard;

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
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (process.ProcessName == "TabTip")
                {
                    process.Kill();
                    break;
                }
            }
            Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                web_browser.Source = new Uri(Link);
                //Directory.GetParent(workingDirectory).Parent.Parent.FullName
                if(IskeyBoard)
                    process = Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Browser - " + ex.Message.ToString());
            }
            StartCloseTimer();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (process.ProcessName == "TabTip" || process.ProcessName == "TextInputHost")
                {
                    process.Kill();
                }
            }
        }
    }
}
