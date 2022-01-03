using Microsoft.Win32;
using Rating_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Rating_App
{
    /// <summary>
    /// Interaction logic for SlideForm.xaml
    /// </summary>
    public partial class SlideForm : Window
    {
        private string FileName;
        private int Type;

        private Config ConfigPage;

        private SlideModel model;

        private List<string> arr_video;

        public SlideForm(Config config, int Id)
        {
            InitializeComponent();

            window.Width = SystemParameters.PrimaryScreenWidth / 2;
            window.Height = SystemParameters.PrimaryScreenHeight / 2;

            FileName = "";

            Type = 1;

            ConfigPage = config;

            arr_video = new List<string>() { ".wav", ".aac", ".wma", ".wmv", ".avi", ".mpg", ".mpeg", ".m1v", ".mp2", ".mp3", ".mpa", ".mpe", ".m3u", ".mp4", ".mov", ".3g2", ".3gp2", ".3gp", ".3gpp", ".m4a", ".cda", ".aif", ".aifc", ".aiff", ".mid", ".midi", ".rmi", ".mkv", ".WAV", ".AAC", ".WMA", ".WMV", ".AVI", ".MPG", ".MPEG", ".M1V", ".MP2", ".MP3", ".MPA", ".MPE", ".M3U", ".MP4", ".MOV", ".3G2", ".3GP2", ".3GP", ".3GPP", ".M4A", ".CDA", ".AIF", ".AIFC", ".AIFF", ".MID", ".MIDI", ".RMI", ".MKV" };

            if (Id > 0)
            {
                using var db = new ModelContext();

                var item = db.SlideModel.Find(Id);

                model = item;

                txt_path.Text = item.Path;
                btn_submit.Content = "Cập nhật";
                Type = item.Type;
                //if(item.Type == 1) rbn_image.IsChecked = true;
                //else rbn_video.IsChecked = true;
            }
        }
        private void btn_path_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Images files (*.BMP;*.JPG;*.GIF)|*.BMP;*.PNG;*.JPG;*.GIF|All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                string nameFile = "";
                foreach (string filename in openFileDialog.FileNames)
                {
                    FileName = System.IO.Path.GetFullPath(filename);
                    nameFile = System.IO.Path.GetFileName(filename);

                    string extenionName = System.IO.Path.GetExtension(filename);

                    if (arr_video.IndexOf(extenionName) > -1) Type = 2;
                }
                txt_path.Text = nameFile;
            }
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            using var db = new ModelContext();
            string name = txt_path.Text;
            bool isCreateFile = true;

            try
            {
                if (!File.Exists(name))
                {
                    string folder = Directory.GetCurrentDirectory() + "/Slide/";

                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    File.Copy(FileName, folder + name, true);
                }
            }
            catch (Exception ex)
            {
                isCreateFile = false;
                MessageBox.Show("Tao File - " + ex.Message.ToString());
            }
            if (isCreateFile)
            {
                try
                {
                    if (model == null)
                    {
                        IQueryable<SlideModel> data = db.SlideModel;
                        var item = data.OrderByDescending(x => x.Index).FirstOrDefault();
                        int Index = 1;
                        int id = 1;
                        if (item != null)
                        {
                            id = item.Id + 1;
                            Index = item.Index + 1;
                        }
                        db.SlideModel.Add(new SlideModel()
                        {
                            Id = id,
                            Path = name,
                            Type = Type,
                            Index = Index
                        });

                        db.SaveChanges();

                        MessageBox.Show("Thêm File thành công");
                    }
                    else
                    {
                        db.SlideModel.Update(new SlideModel()
                        {
                            Id = model.Id,
                            Path = name,
                            Type = Type,
                            Index = model.Index
                        });

                        db.SaveChanges();

                        MessageBox.Show("Cập nhật File thành công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insert db - " + ex.Message.ToString());
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ConfigPage.Refresh();
        }
    }
}
