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
            var username_admin = db.ConfigModel.Find(new string[] { "username_admin" });
            var password_admin = db.ConfigModel.Find(new string[] { "password_admin" });
            if ((txt_username.Text == username.Value && txt_password.Password == password.Value) || (txt_username.Text == username_admin.Value && txt_password.Password == password_admin.Value))
            {
                this.Close();
                Admin admin = new Admin();
                admin.ShowDialog();
            }
            else
            {
                txt_error.Text = "Tên đăng nhập hoặc mật khẩu không chính xác";
            }
        }

        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_error.Text = "";
        }
    }
}
