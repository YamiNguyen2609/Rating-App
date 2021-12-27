using Rating_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class Rating : Page
    {
        public Rating()
        {
            InitializeComponent();

            Refresh();
        }

        public void Refresh()
        {
            using var db = new ModelContext();

            IQueryable<RatingModel> data = db.RatingModel;

            list_item.ItemsSource = data.Select(x => new RatingViewModel() { Type = x.Type == 1 ? "Phòng đào tạo đại học" :  x.Type == 2 ? "Phòng đào tạo sau đại học": x.Type == 3 ? "Phòng công tác sinh viên" : "Trung tâm dịch vụ", State = x.State ? "Thích" : "Không thích", CreateAt = x.CreateAt.ToString("dd-MM-yyyy HH:mm:ss")}).ToList();

        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            double size = panel.RowDefinitions[1].ActualHeight / 2;
            list_item.FontSize = size / 3;
        }
    }
}
