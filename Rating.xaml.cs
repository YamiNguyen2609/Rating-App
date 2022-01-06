using Microsoft.Win32;
using Rating_App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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
            List<RatingViewModel> temp = new List<RatingViewModel>();
            for (int i = 0; i < 4; i++)
            {
                float total = data.Where(x => x.Type == i).Count();
                if (total == 0) total = 1;
                float like = data.Where(x => x.Type == i && x.State == true).Count();
                float dislike = data.Where(x => x.Type == i && x.State == false).Count();
                string type = i == 0 ? "Phòng đào tạo đại học" : i == 1 ? "Phòng đào tạo sau đại học" : i == 2 ? "Phòng công tác sinh viên" : "Trung tâm dịch vụ";

                temp.Add(new RatingViewModel() { Type = type, Like = String.Format("{0}%",(like / total) * 100), DisLike = String.Format("{0}%", (dislike / total) * 100)});
            }

            list_item.ItemsSource = temp;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            using var db = new ModelContext();

            IQueryable<RatingModel> data = db.RatingModel;

            DateTime dateFrom = DateTime.Now;
            DateTime dateTo = DateTime.Now;

            try
            {
                dateFrom = DateTime.Parse(date_from.Text + " 00:00:00");
                dateTo = DateTime.Parse(date_end.Text + " 23:59:59");
                DataTable table = new DataTable();
                List<RatingViewModel> items = data.Where(x => x.CreateAt >= dateFrom && x.CreateAt <= dateTo).Select(x => new RatingViewModel { Type = x.Type == 0 ? "Phòng đào tạo đại học" : x.Type == 1 ? "Phòng đào tạo sau đại học" : x.Type == 2 ? "Phòng công tác sinh viên" : "Trung tâm dịch vụ", Like = x.State ? "Thích" : "Không thích", DisLike = x.CreateAt.ToString("dd-MM-yyyy HH:mm:ss") }).ToList();


                string name = "Rating" + DateTime.Now.ToUniversalTime();
                name = name.Replace(":", "_").Replace("/", "_").Replace(" ", "_");

                SaveFileDialog exportDialog = new SaveFileDialog();

                // Settings.
                exportDialog.Filter = "Comma Separated Values (*.csv)|*.csv";

                exportDialog.FileName = name + ".csv";

                // Verification.
                if (exportDialog.ShowDialog() == true)
                {
                    string title = "Bộ Phận,Trạng thái,Thời gian\r\n";

                    Encoding encoding = Encoding.GetEncoding("UTF-8");
                    FileStream fParameter = new FileStream(exportDialog.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter m_WriterParameter = new StreamWriter(fParameter, encoding);
                    m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
                    m_WriterParameter.Write(title + String.Join("\r\n", items.Select(x => String.Format("{0},{1},{2}", x.Type, x.Like, x.DisLike))));
                    m_WriterParameter.Flush();
                    m_WriterParameter.Close();

                    //CSVLibraryAK.Core.CSVLibraryAK.

                    //// Export to CSV file.
                    //CSVLibraryAK.Core.CSVLibraryAK.Export(exportDialog.FileName, table);

                    //// Info.
                    MessageBox.Show("Xuất file thành công", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Thời gian sai định dạng");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            date_from.SelectedDate = DateTime.Now;
            date_end.SelectedDate = DateTime.Now;
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            using var db = new ModelContext();

            IQueryable<RatingModel> data = db.RatingModel;

            DateTime dateFrom = DateTime.Parse(date_from.Text + " 00:00:00");
            DateTime dateTo = DateTime.Parse(date_end.Text + " 23:59:59");

            List<RatingModel> dataTemp = data.Where(x => x.CreateAt >= dateFrom && x.CreateAt <= dateTo).ToList();

            List<RatingViewModel> temp = new List<RatingViewModel>();
            for (int i = 0; i < 4; i++)
            {
                float total = dataTemp.Where(x => x.Type == i).Count();
                if (total == 0) total = 1;
                float like = dataTemp.Where(x => x.Type == i && x.State == true).Count();
                float dislike = dataTemp.Where(x => x.Type == i && x.State == false).Count();
                string type = i == 0 ? "Phòng đào tạo đại học" : i == 1 ? "Phòng đào tạo sau đại học" : i == 2 ? "Phòng công tác sinh viên" : "Trung tâm dịch vụ";

                temp.Add(new RatingViewModel() { Type = type, Like = String.Format("{0}%", ((like / total) * 100)), DisLike = String.Format("{0}%", ((dislike / total) * 100)) });
            }

            list_item.ItemsSource = temp;
        }
    }
}
