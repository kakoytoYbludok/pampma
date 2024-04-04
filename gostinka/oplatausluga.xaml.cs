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
    /// Логика взаимодействия для oplatausluga.xaml
    /// </summary>
    public partial class oplatausluga : Window
    {
        DataBaseClass database = new DataBaseClass();
        int itogprice = 0;
        usluga formusluga = null;

        public void increase_itogprice(int n)
        {
            itogprice += n;
            lb_Itog.Content = itogprice;
            FillUslugi();
            FillUslugi2();
            FillUslugi3();
            FillUslugi4();
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            bool Visible = Uslugi.Instance.Pokraska != String.Empty;
            if (Visible)
            {
                btn_del1.Visibility = Visibility.Visible;
            }
            else btn_del1.Visibility = Visibility.Hidden;

            bool Visible2 = Uslugi.Instance.GirlStr != String.Empty;
            if (Visible2)
            {
                btn_del2.Visibility = Visibility.Visible;
            }
            else btn_del2.Visibility = Visibility.Hidden;

            bool Visible3 = Uslugi.Instance.ManStr != String.Empty;
            if (Visible3)
            {
                btn_del3.Visibility = Visibility.Visible;
            }
            else btn_del3.Visibility = Visibility.Hidden;

            bool Visible4 = Uslugi.Instance.Manik != String.Empty;
            if (Visible4)
            {
                btn_del4.Visibility = Visibility.Visible;
            }
            else btn_del4.Visibility = Visibility.Hidden;
        }


        public oplatausluga(usluga formusluga)
        {
            InitializeComponent();
            UpdateButtons();
            this.formusluga = formusluga;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lb_Login.Content = User.Instance.Login;
            lb_Mail.Content = User.Instance.Mail;
            lb_Phone.Content = User.Instance.Phone;

            
            FillComboBoxTypeOplata();
        

        }
        private void FillUslugi()
        {
            lb_Viduslugi.Content = Uslugi.Instance.Pokraska;
            lb_PriceUsluga.Content = Uslugi.Instance.PricePokraska;
            if (lb_Viduslugi.Content == null)
            {
                lb_PriceUsluga.Content = "";
            }

        }

        private void FillUslugi2()
        {
            lb_Viduslugi2.Content = Uslugi.Instance.GirlStr;
            lb_PriceUsluga2.Content = Uslugi.Instance.PriceGirl;
            if (lb_Viduslugi2.Content == null)
            {
                lb_PriceUsluga2.Content = "";
            }

        }

        private void FillUslugi3()
        {
            lb_Viduslugi3.Content = Uslugi.Instance.ManStr;
            lb_PriceUsluga3.Content = Uslugi.Instance.PriceMan;
            if (lb_Viduslugi3.Content == null)
            {
                lb_PriceUsluga3.Content = "";
            }

           
        }

        private void FillUslugi4()
        {
            lb_Viduslugi4.Content = Uslugi.Instance.Manik;
            lb_PriceUsluga4.Content = Uslugi.Instance.PriceManik;
            


        }

        private void FillComboBoxTypeOplata()
        {
            string tablename = "[dbo].[Uslugi]";
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

        private void Button_usl(object sender, RoutedEventArgs e)
        {

            //vhod.ShowDialog();
            this.Hide();
            formusluga.ShowDialog();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Uslugi.Instance.ManStr!= String.Empty) database.InsertUsluga(Uslugi.Instance.ManStr, Uslugi.Instance.PriceMan, User.Instance.Login);
            if (Uslugi.Instance.GirlStr != String.Empty) database.InsertUsluga(Uslugi.Instance.GirlStr, Uslugi.Instance.PriceGirl, User.Instance.Login);
            if (Uslugi.Instance.Manik != String.Empty) database.InsertUsluga(Uslugi.Instance.Manik, Uslugi.Instance.PriceManik, User.Instance.Login);
            if (Uslugi.Instance.Pokraska != String.Empty) database.InsertUsluga(Uslugi.Instance.Pokraska, Uslugi.Instance.PricePokraska, User.Instance.Login);
            profile profile = new profile();
            //vhod.ShowDialog();
            profile.Show();
            this.Close();

        }


        private void btn_del1_Click(object sender, RoutedEventArgs e)
        {
            itogprice -= Convert.ToInt32(Uslugi.Instance.PricePokraska);
            lb_Itog.Content = itogprice;
            Uslugi.Instance.Pokraska = String.Empty;
            Uslugi.Instance.PricePokraska = 0;
            lb_Viduslugi.Content = String.Empty;
            lb_PriceUsluga.Content = string.Empty;
            btn_del1.Visibility = Visibility.Hidden;
        }


        private void btn_del2_Click(object sender, RoutedEventArgs e)
        {

            itogprice -= Convert.ToInt32(Uslugi.Instance.PriceGirl);
            lb_Itog.Content = itogprice;
            Uslugi.Instance.GirlStr = String.Empty;
            Uslugi.Instance.PriceGirl = 0;
            lb_Viduslugi2.Content = String.Empty;
            lb_PriceUsluga2.Content = String.Empty;
            btn_del2.Visibility = Visibility.Hidden;
        }


        private void btn_del3_Click(object sender, RoutedEventArgs e)
        {
            itogprice -= Convert.ToInt32(Uslugi.Instance.PriceMan);
            lb_Itog.Content = itogprice;
            Uslugi.Instance.ManStr = String.Empty;
            Uslugi.Instance.PriceMan = 0;
            lb_Viduslugi3.Content = String.Empty;
            lb_PriceUsluga3.Content = String.Empty;
            btn_del3.Visibility = Visibility.Hidden;
        }

        private void btn_del4_Click(object sender, RoutedEventArgs e)
        {
            itogprice -= Convert.ToInt32(Uslugi.Instance.PriceManik);
            lb_Itog.Content = itogprice;
            Uslugi.Instance.Manik = String.Empty;
            Uslugi.Instance.PriceManik = 0;
            lb_Viduslugi4.Content = String.Empty;
            lb_PriceUsluga4.Content = String.Empty;
            btn_del4.Visibility = Visibility.Hidden;
        }
    }
}