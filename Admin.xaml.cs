using Rating_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rating_App
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            using var db = new ModelContext();
            string dbName = "cms.db";
            if (!File.Exists(dbName))
            {
                db.Database.EnsureCreated();
            }

            InitializeComponent();
            Press_Control("btn_config");
        }

        private void Press_Control(string Name)
        {
            btn_config.Background = Brushes.LightGray;
            btn_config_slide.Background = Brushes.LightGray;

            switch (Name)
            {
                case "btn_config":
                    btn_config.Background = Brushes.White;
                    return;
                case "btn_config_slide":
                    btn_config_slide.Background = Brushes.White;
                    return;
            }
        }

        private void Btn_tab_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            panel.Source = new Uri(btn.Tag.ToString(), UriKind.Relative);
            Press_Control(btn.Name);
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
