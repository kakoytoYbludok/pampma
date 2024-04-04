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
        bool correctcost = false;
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
            btn_perehodkoi.IsEnabled = correctcost;

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
            lab_itogkoi.Content = CalculateCost(out correctcost);
            btn_perehodkoi.IsEnabled = correctcost;
        }


        private void cb_VidNomerachet_DropDownClosed(object sender, EventArgs e)
        {
            FillComBoxTypeBed();
            lab_itogkoi.Content = CalculateCost(out correctcost);
            btn_perehodkoi.IsEnabled = correctcost;
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
            lab_itogkoi.Content = CalculateCost(out correctcost);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lab_itogkoi.Content = CalculateCost(out correctcost);
            btn_perehodkoi.IsEnabled = correctcost;
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

        private string CalculateCost(out bool correctcost)
        {
            correctcost = false;
            int countdays = CountDays(data_koizaezd.SelectedDate, data_koiviezd.SelectedDate);
            int cost = dataBase.GetCost(cb_TypeBedkoi.Text);
            if (countdays == -1 || cost == -1)
            {
                return "Выберите остальные данные";
            }
            int result = countdays * cost;
            if (result < 0)
            {
                return "Выберите корректные даты";
            }

            correctcost = true;;
            return result.ToString();
        }       

        private void data_koiviezd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lab_itogkoi.Content = CalculateCost(out correctcost);
            btn_perehodkoi.IsEnabled = correctcost;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            oplatanom oplatanom = new oplatanom();
            //vhod.ShowDialog();
            oplatanom.Show();
            this.Close();
        }
    }



}
