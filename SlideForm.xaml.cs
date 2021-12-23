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
    /// Interaction logic for SlideForm.xaml
    /// </summary>
    public partial class SlideForm : Window
    {
        public SlideForm()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            rbn_video.IsChecked = false;
            rbn_image.IsChecked = false;
            RadioButton rbn = sender as RadioButton;
            rbn.IsChecked = true;
        }
    }
}
