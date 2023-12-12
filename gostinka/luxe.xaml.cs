using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gostinka
{
    /// <summary>
    /// Логика взаимодействия для luxe.xaml
    /// </summary>
    public partial class luxe : Window
    {
        int i = 1;
        DataBaseClass dataBase = new DataBaseClass();
        public luxe()
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

            picHolder.Source = new BitmapImage(new Uri(@"imageluxe/" + i + ".jpg", UriKind.Relative));
        }
        private void goBack(object sender, RoutedEventArgs e)
        {
            i++;


            if (i > 4)
            {
                i = 1;
            }

            picHolder.Source = new BitmapImage(new Uri(@"imageluxe/" + i + ".jpg", UriKind.Relative));
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

        private void luxe_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBoxVidNomer();
            

        }

        private void FillComboBoxVidNomer()
        {
            string tablename = "[dbo].[Infonomer]";
            string columnname = "VidNomera";
            DataBaseClass dataBase = new DataBaseClass();
            cb_VidNomera.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_VidNomera.DisplayMemberPath = "VidNomera";
        }

        private void FillComBoxTypeBed()
        {
            string Vid = cb_VidNomera.Text;
            cb_TypeBed.ItemsSource = dataBase.GetTypeBed(Vid).DefaultView;
            cb_TypeBed.DisplayMemberPath = "Bed";
        }

        private void FillComBoxNomer()
        {
            string Bed = cb_TypeBed.Text;
            string Vid = cb_VidNomera.Text;
            cb_Nomer.ItemsSource = dataBase.GetNomer(Vid, Bed).DefaultView;
            cb_Nomer.DisplayMemberPath = "NumberNomer";
        }


       

        private void cb_VidNomera_DropDownClosed(object sender, EventArgs e)
        {
            FillComBoxTypeBed();
            lab_itogluxe.Content = CalculateCost();

        }

        

            private void cb_TypeBed_DropDownClosed(object sender, EventArgs e)
        { 
            FillComBoxNomer();
            lab_itogluxe.Content = CalculateCost();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lab_itogluxe.Content = CalculateCost();
        }

        private void data_luxeviezd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lab_itogluxe.Content = CalculateCost();
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

            int countdays = CountDays(data_luxezaezd.SelectedDate, data_luxeviezd.SelectedDate);          
            int cost = dataBase.GetCost(cb_TypeBed.Text);
            if (countdays == -1 || cost == -1)
            {
                return "Выберите остальные данные";
            }
            int result = countdays * cost;
            return result.ToString(); 
        }
    }
}
    

