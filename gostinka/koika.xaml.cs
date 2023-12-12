using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace gostinka
{
    /// <summary>
    /// Логика взаимодействия для koika.xaml
    /// </summary>
    public partial class koika : Window
    {
        DataBaseClass dataBase = new DataBaseClass();
        int i = 1;
        public koika()
        {
            InitializeComponent();
        }

        private void goNext(object sender, RoutedEventArgs e)
        {
            i++;


            if (i > 4)
            {
                i = 1;
            }

            picHolder.Source = new BitmapImage(new Uri(@"imagekoi/" + i + ".jpg", UriKind.Relative));
        }
        private void goBack(object sender, RoutedEventArgs e)
        {
            i++;


            if (i > 4)
            {
                i = 1;
            }

            picHolder.Source = new BitmapImage(new Uri(@"imagekoi/" + i + ".jpg", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            glavnaya glavnaya = new glavnaya();
            //vhod.ShowDialog();
            glavnaya.Show();
            this.Close();
        }
        private void koika_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBoxVidNomer();


        }

        private void FillComboBoxVidNomer()
        {
            string tablename = "[dbo].[Infonomer]";
            string columnname = "VidNomera";
            DataBaseClass dataBase = new DataBaseClass();
            cb_VidNomerakoi.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_VidNomerakoi.DisplayMemberPath = "VidNomera";
        }

        private void FillComBoxTypeBed()
        {
            string Vid = cb_VidNomerakoi.Text;
            cb_TypeBedkoi.ItemsSource = dataBase.GetTypeBed(Vid).DefaultView;
            cb_TypeBedkoi.DisplayMemberPath = "Bed";
        }



        private void cb_VidNomerakoi_DropDownClosed(object sender, EventArgs e)
        {
            FillComBoxTypeBed();
        }


        private void cb_VidNomerachet_DropDownClosed(object sender, EventArgs e)
        {
            FillComBoxTypeBed();
        }

        private void FillComBoxNomerkoi()
        {
            string Bed = cb_TypeBedkoi.Text;
            string Vid = cb_VidNomerakoi.Text;
            cb_Nomerkoi.ItemsSource = dataBase.GetNomer(Vid, Bed).DefaultView;
            cb_Nomerkoi.DisplayMemberPath = "NumberNomer";
        }



        private void cb_VidNomera_DropDownClosed(object sender, EventArgs e)
        {
            FillComBoxTypeBed();

        }



        private void cb_TypeBedkoi_DropDownClosed(object sender, EventArgs e)
        {

            FillComBoxNomerkoi();
            lab_itogkoi.Content = CalculateCost();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lab_itogkoi.Content = CalculateCost();
        }



        private int CountDays(DateTime? date1, DateTime? date2)
        {
            if (date1.HasValue && date2.HasValue)
            {
                TimeSpan diff = date2.Value - date1.Value;
                return diff.Days;
            }
            return -1;
        }

        private string CalculateCost()
        {

            int countdays = CountDays(data_koizaezd.SelectedDate, data_koiviezd.SelectedDate);
            int cost = dataBase.GetCost(cb_TypeBedkoi.Text);
            if (countdays == -1 || cost == -1)
            {
                return "Выберите остальные данные";
            }
            int result = countdays * cost;
            return result.ToString();
        }       

        private void data_koiviezd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lab_itogkoi.Content = CalculateCost();
        }
    }



}
