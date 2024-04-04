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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace gostinka
{
    /// <summary>
    /// Логика взаимодействия для luxe.xaml
    /// </summary>
    public partial class luxe : Window
    {
        int i = 1;
        bool correctcost = false;
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

       

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uslugi.Instance.InitUsluga3(cb_VidNomera.Text, Convert.ToInt32(lab_itogluxe.Content), data_luxezaezd.SelectedDate, cb_Time.Text);
            oplatanom oplatanom = new oplatanom();
            //vhod.ShowDialog();
            oplatanom.Show();
            this.Close();
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
            btn_perehodluxe.IsEnabled = correctcost;

        }

        private void FillComboBoxVidNomer()
        {
            string tablename = "[dbo].[Uslugi]";
            string columnname = "ManStr";
            DataBaseClass dataBase = new DataBaseClass();
            cb_VidNomera.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_VidNomera.DisplayMemberPath = "ManStr";
        }

        private void FillComBoxTypeBed()
        {
            string Vid = cb_VidNomera.Text;
        }

        private void FillComBoxNomer()
        {
            string Vid = cb_VidNomera.Text;
        }

        private void FillComboBoxTime()
        {
            string tablename = "[dbo].[Zakaz]";
            string columnname = "Time";
            cb_Time.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_VidNomera.DisplayMemberPath = "Time";

        }



        private void cb_VidNomera_DropDownClosed(object sender, EventArgs e)
        {
            FillComBoxTypeBed();
            btn_perehodluxe.IsEnabled = correctcost;
        }

        

            private void cb_TypeBed_DropDownClosed(object sender, EventArgs e)
        { 
            FillComBoxNomer();
            btn_perehodluxe.IsEnabled = correctcost;
        }

        private void cb_Nomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_perehodluxe.IsEnabled = correctcost;
        }


        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           
            btn_perehodluxe.IsEnabled = correctcost;
        }

        private void data_luxeviezd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_perehodluxe.IsEnabled = correctcost;

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

       

        private void cb_Time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cb_Time_DropDownClosed(object sender, EventArgs e)
        {
            DataBaseClass dataBase = new DataBaseClass();
        }
    }
}
    

