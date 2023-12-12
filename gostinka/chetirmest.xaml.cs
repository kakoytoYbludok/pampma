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
    /// Логика взаимодействия для chetirmest.xaml
    /// </summary>
    public partial class chetirmest : Window
    {
        int i = 1;
        DataBaseClass dataBase = new DataBaseClass();
        public chetirmest()
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

            picHolder.Source = new BitmapImage(new Uri(@"image4x/" + i + ".jpg", UriKind.Relative));
        }
        private void goBack(object sender, RoutedEventArgs e)
        {
            i++;


            if (i > 4)
            {
                i = 1;
            }

            picHolder.Source = new BitmapImage(new Uri(@"image4x/" + i + ".jpg", UriKind.Relative));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            glavnaya glavnaya = new glavnaya();
            //vhod.ShowDialog();
            glavnaya.Show();
            this.Close();
        }

        private void chetirmest_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBoxVidNomer();


        }

        private void FillComboBoxVidNomer()
        {
            string tablename = "[dbo].[Infonomer]";
            string columnname = "VidNomera";
            DataBaseClass dataBase = new DataBaseClass();
            cb_VidNomerachet.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_VidNomerachet.DisplayMemberPath = "VidNomera";
        }

        private void FillComBoxTypeBed()
        {
            string Vid = cb_VidNomerachet.Text;
            cb_TypeBedchet.ItemsSource = dataBase.GetTypeBed(Vid).DefaultView;
            cb_TypeBedchet.DisplayMemberPath = "Bed";
        }


   
        private void cb_VidNomerachet_DropDownClosed(object sender, EventArgs e)
        {
            FillComBoxTypeBed();
        }

        private void FillComBoxNomerchet()
        {
            string Bed = cb_TypeBedchet.Text;
            string Vid = cb_VidNomerachet.Text;
            cb_Nomerchet.ItemsSource = dataBase.GetNomer(Vid, Bed).DefaultView;
            cb_Nomerchet.DisplayMemberPath = "NumberNomer";
        }



       


        private void cb_TypeBedchet_DropDownClosed(object sender, EventArgs e)
        {

            FillComBoxNomerchet();
        }


        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lab_itogchet.Content = CalculateCost();
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

            int countdays = CountDays(data_chetzaezd.SelectedDate, data_chetviezd.SelectedDate);
            int cost = dataBase.GetCost(cb_TypeBedchet.Text);
            if (countdays == -1 || cost == -1)
            {
                return "Выберите остальные данные";
            }
            int result = countdays * cost;
            return result.ToString();
        }

        private void data_chetviezd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lab_itogchet.Content = CalculateCost();
        }
    }
}
