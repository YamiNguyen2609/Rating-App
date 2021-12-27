using Rating_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Config.xaml
    /// </summary>
    public partial class Config : Page
    {
        public Config()
        {
            InitializeComponent();

            Refresh();
        }

        public void Refresh()
        {
            using var db = new ModelContext();

            IQueryable<SlideModel> data = db.SlideModel;

            list_item.ItemsSource = data.Select(x => new SlideViewModel() { Id = x.Id, Path = x.Path, Type = x.Type == 1 ? "Hình ảnh" : "Video" }).ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SlideForm form = new SlideForm(this, 0);
            form.ShowDialog();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            SlideForm form = new SlideForm(this, id);
            form.ShowDialog();
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;

            using var db = new ModelContext();

            var item = db.SlideModel.Find(id);

            string name = item.Path;
            //if (!File.Exists(name))
            //{
            //    File.Delete(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/Slide/" + name);
            //}

            db.SlideModel.Remove(item);

            db.SaveChanges();

            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            double size = panel.RowDefinitions[1].ActualHeight / 2;
            btn.FontSize = size;
            list_item.FontSize = size / 2;
        }
    }
}
