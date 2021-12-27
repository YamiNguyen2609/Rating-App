using Rating_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Rating_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        private SlideModel CurrentItem;
        private int CurrentIndex = -1;
        private System.Timers.Timer interval;
        private DateTime Expried;
        public Main()
        {
            using var db = new ModelContext();
            string dbName = "cms.db";
            if (!File.Exists(dbName))
            {
                db.Database.EnsureCreated();
            }
            if (!db.ConfigModel.Any())
            {
                Expried = DateTime.Parse(DateTime.Now.AddYears(2).ToString("yyyy-MM-dd 23:59:59"));

                db.ConfigModel.AddRange(new ConfigModel[]
                {
                    new ConfigModel{Key = "username", Value = "admin"},
                    new ConfigModel{Key = "password", Value = "password"},
                    new ConfigModel{Key = "expried", Value = Expried.ToString("yyyy-MM-dd HH:mm:ss")},
                });

                db.SaveChanges();
            }
            else
            {
                Expried = DateTime.Parse(db.ConfigModel.Find(new string[] { "expried" }).Value);
            }


            InitializeComponent();

            btn.Width = SystemParameters.PrimaryScreenWidth;
            btn.Height = SystemParameters.PrimaryScreenHeight;

            OnMove();

            interval = new System.Timers.Timer()
            {
                Interval = TimeSpan.FromSeconds(10).TotalSeconds * 1000,
                Enabled = true
            };

            interval.Elapsed += this.Execute;
        }

        private void Btn_home_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void OnMove()
        {
            Dispatcher.Invoke(() =>
            {
                using var db = new ModelContext();

                IQueryable<SlideModel> data = db.SlideModel;

                panel.Children.Clear();

                if (data.ToList().Count > 0)
                {
                    CurrentIndex = data.ToList().Count > CurrentIndex + 1 ? CurrentIndex + 1 : 0;

                    CurrentItem = data.ToList()[CurrentIndex];

                    if (CurrentItem.Type == 1)
                    {
                        try
                        {
                            Image image = new Image()
                            {
                                Width = SystemParameters.PrimaryScreenWidth,
                                Height = SystemParameters.PrimaryScreenHeight,
                                Source = new BitmapImage(new Uri(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/Slide/" + CurrentItem.Path))
                            };
                            panel.Children.Add(image);
                        }
                        catch { }
                        Thread thread = new Thread(() =>
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(3));
                            OnMove();
                        });

                        thread.IsBackground = true;
                        thread.Start();
                    }
                    else
                    {
                        MediaElement media = new MediaElement()
                        {
                            Width = SystemParameters.PrimaryScreenWidth,
                            Height = SystemParameters.PrimaryScreenHeight,
                            Source = new Uri(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/Slide/" + CurrentItem.Path)
                        };

                        media.MediaEnded += MediaElement_MediaEnded;

                        panel.Children.Add(media);
                    }
                }
                else
                {
                    Thread thread = new Thread(() =>
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(3));
                        OnMove();
                    });

                    thread.IsBackground = true;
                    thread.Start();
                }
            });
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            OnMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            panel_rating.Visibility = Visibility.Visible;
            StartCloseTimer();
        }

        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            panel_rating.Visibility = Visibility.Hidden;
        }

        private void btn_rating_Click(object sender, RoutedEventArgs e)
        {
            using var db = new ModelContext();

            string Id = "1";

            IQueryable<RatingModel> data = db.RatingModel;
            var item = data.OrderByDescending(x => x.Id).FirstOrDefault();

            if (item != null) Id = item.Id;

            string param = ((Button)sender).Tag.ToString();

            int[] spl = param.Split("-").Select(x => int.Parse(x)).ToArray();

            RatingModel model = new RatingModel()
            {
                Id = Id,
                Type = spl[0],
                State = spl[1] == 1,
                CreateAt = DateTime.Now
            };

            db.RatingModel.Add(model);

            db.SaveChanges();

            panel_rating.Visibility = Visibility.Hidden;
        }

        private void Execute(Object source, System.Timers.ElapsedEventArgs e)
        {
            if(DateTime.Now >= Expried)
            {
                string x = "";
            }
        }

        private void btn_browser_Click(object sender, RoutedEventArgs e)
        {
            string link = ((Button)sender).Tag.ToString();
            Browser browser = new Browser(link);
            browser.ShowDialog();
        }

    }
}
