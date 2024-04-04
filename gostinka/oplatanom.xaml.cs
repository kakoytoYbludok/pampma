using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для oplatanom.xaml
    /// </summary>
    public partial class oplatanom : Window
    {
       
        public oplatanom()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lb_Login.Content = User.Instance.Login;
            lb_Mail.Content = User.Instance.Mail;
            lb_Phone.Content = User.Instance.Phone;

            FillInfoNomer();
            FillComboBoxTypeOplata();
        }

        private void FillInfoNomer()
        {
            lb_VidNomera.Content = InfoNomer.Instance.Vidnomera;
            lb_Price.Content = InfoNomer.Instance.PriceNomer;
            lb_Bed.Content = InfoNomer.Instance.Bed;
            lb_Nomer.Content = InfoNomer.Instance.NumberNomer;
            lb_Zaselen.Content = InfoNomer.Instance.Zaselen.Value.ToString("dd MMMM yyyy");
            Console.WriteLine(  );
        }


        private void FillComboBoxTypeOplata()
        {
            string tablename = "[dbo].[Zakaz]";
            string columnname = "SposobOplati";
            DataBaseClass dataBase = new DataBaseClass();
            cb_sposoboplat.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_sposoboplat.DisplayMemberPath = "SposobOplati";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            glavnaya glavnaya = new glavnaya();
            //vhod.ShowDialog();
            glavnaya.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataBaseClass dataBase = new DataBaseClass();
            profile profile = new profile();
            //vhod.ShowDialog();
            profile.Show();
            this.Close();
        }
    }
    }

