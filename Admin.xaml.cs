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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            Press_Control("btn_config");
        }

        private void Press_Control(string Name)
        {
            btn_config.Background = Brushes.Navy;
            btn_config_slide.Background = Brushes.Navy;
            //foreground
            btn_config.Foreground = Brushes.White;
            btn_config_slide.Foreground = Brushes.White;

            switch (Name)
            {
                case "btn_config":
                    btn_config.Background = Brushes.White;
                    btn_config.Foreground = Brushes.Navy;
                    return;
                case "btn_config_slide":
                    btn_config_slide.Background = Brushes.White;
                    btn_config_slide.Foreground = Brushes.Navy;
                    return;
            }
        }

        private void Btn_tab_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Press_Control(btn.Name);
        }
    }
}
