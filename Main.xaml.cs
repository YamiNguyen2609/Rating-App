using Rating_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Rating_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using var db = new ModelContext();
            string dbName = "cms.db";
            if (!File.Exists(dbName))
            {
                db.Database.EnsureCreated();
            }
            if (!db.ConfigModel.Any())
            {
                db.ConfigModel.AddRange(new ConfigModel[]
                {
                    new ConfigModel{Key = "username", Value = "admin"},
                    new ConfigModel{Key = "password", Value = "password"},
                });

                db.SaveChanges();
            }

            InitializeComponent();
        }

        private void Btn_home_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void Btn_zoom_Click(object sender, RoutedEventArgs e)
        {
            main_window.WindowState = main_window.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }
    }
}
