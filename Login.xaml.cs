using Microsoft.EntityFrameworkCore;
using Rating_App.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            window.Width = SystemParameters.PrimaryScreenWidth /2;
            window.Height = SystemParameters.PrimaryScreenHeight / 2;
        }

        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            using var db = new ModelContext();

            var username = db.ConfigModel.Find(new string[] { "username" });
            var password = db.ConfigModel.Find(new string[] { "password" });
            if (txt_username.Text == username.Value && txt_password.Password == password.Value)
            {
                this.Close();
                Admin admin = new Admin();
                admin.ShowDialog();
            }
        }

        private void panel_Loaded(object sender, RoutedEventArgs e)
        {
            txt_username.FontSize = panel.RowDefinitions[3].ActualHeight / 2;
            txt_password.FontSize = panel.RowDefinitions[5].ActualHeight / 2;
            btn_login.FontSize = panel.RowDefinitions[7].ActualHeight / 2;
        }
    }
}
