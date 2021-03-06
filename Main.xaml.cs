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
        private System.Timers.Timer interval1;
        private DateTime Expried;
        private int time_counter = 2;
        private int time = 30;
        private DispatcherTimer timer;
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
                Expried = DateTime.Parse("2022-12-31 23:59:59");

                db.ConfigModel.AddRange(new ConfigModel[]
                {
                    new ConfigModel{Key = "username", Value = "admin"},
                    new ConfigModel{Key = "password", Value = "password"},
                    new ConfigModel{Key = "username_admin", Value = "admin"},
                    new ConfigModel{Key = "password_admin", Value = "password"},
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
                Interval = TimeSpan.FromSeconds(60).TotalSeconds * 1000,
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
                                Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Slide/" + CurrentItem.Path))
                            };
                            panel.Children.Add(image);
                        }
                        catch { }
                        Thread thread = new Thread(() =>
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(time));
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
                            Source = new Uri(Directory.GetCurrentDirectory() + "/Slide/" + CurrentItem.Path)
                        };

                        media.MediaEnded += MediaElement_MediaEnded;

                        panel.Children.Add(media);
                    }
                }
                else
                {
                    Thread thread = new Thread(() =>
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(time));
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
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(2);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Tick -= TimerTick;
            panel_rating.Visibility = Visibility.Hidden;
        }

        private void btn_rating_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                timer.Stop();
                timer.Tick -= TimerTick;

                using var db = new ModelContext();

                int Id = 1;

                IQueryable<RatingModel> data = db.RatingModel;
                if (data.Count() > 0)
                {
                    var item = data.ToArray()[data.Count() - 1];

                    if (item != null) Id = int.Parse(item.Id) + 1;
                }

                string param = ((Button)sender).Tag.ToString();

                int[] spl = param.Split("-").Select(x => int.Parse(x)).ToArray();

                RatingModel model = new RatingModel()
                {
                    Id = Id.ToString(),
                    Type = spl[0],
                    State = spl[1] == 1,
                    CreateAt = DateTime.Now
                };

                db.RatingModel.Add(model);

                db.SaveChanges();

                txt.Text = "Cảm ơn bạn đã đánh giá (Đóng sau " + time_counter + "s...)";
                panel_thanks.Visibility = Visibility.Visible;

                interval1 = new System.Timers.Timer()
                {
                    Interval = TimeSpan.FromSeconds(time_counter).TotalSeconds * 1000,
                    Enabled = true
                };

                interval1.Elapsed += this.Execute1;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Rating - " + ex.Message.ToString());
            }
        }

        private void Execute(Object source, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (DateTime.Now >= Expried)
                {
                    MessageBoxResult result = MessageBox.Show("Phiên bản hiện tại đã hết hạn sử dụng", "Cảnh báo", MessageBoxButton.OK);

                    if (MessageBoxResult.OK == result)
                        Application.Current.Shutdown();
                }
            });
        }

        private void Execute1(Object source, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (time_counter > 1)
                {
                    time_counter -= 1;
                    txt.Text = "Cảm ơn bạn đã đánh giá (Đóng sau " + time_counter + "s...)";
                    panel_thanks.Visibility = Visibility.Visible;
                }
                else
                {
                    interval1.Close();
                    panel_thanks.Visibility = Visibility.Hidden;
                    time_counter = 2;
                    StartCloseTimer();
                }
            });
        }

        private void btn_browser_Click(object sender, RoutedEventArgs e)
        {
            string link = ((Button)sender).Tag.ToString();
            string[] spl = link.Split("|");
            Browser browser = new Browser(spl[1], spl[0] == "1");
            browser.ShowDialog();
        }

        private void main_window_Loaded(object sender, RoutedEventArgs e)
        {
            //panel_rating.Visibility = Visibility.Hidden;
            StartCloseTimer();
        }
    }
}
