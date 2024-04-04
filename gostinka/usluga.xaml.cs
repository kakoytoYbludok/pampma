using Org.BouncyCastle.Pqc.Crypto.Lms;
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
    /// Логика взаимодействия для usluga.xaml
    /// </summary>
    public partial class usluga : Window
    {
        oplatausluga oplatausluga = null;
        public usluga()
        {
            InitializeComponent();
            oplatausluga = new oplatausluga(this);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            glavnaya glavnaya = new glavnaya();
            //vhod.ShowDialog();
            glavnaya.Show();
            this.Close();
        }

        private void Usluga_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBoxEdA();
            FillComboBoxMassage();
            FillComboBoxSPA();
            FillComboBoxUborka();

        }



        private void FillComboBoxEdA()
        {
            string tablename = "[dbo].[Uslugi]";
            string columnname = "Pokraska";
            DataBaseClass dataBase = new DataBaseClass();
            cb_Eda.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_Eda.DisplayMemberPath = "Pokraska";
        }


        private void FillComboBoxMassage()
        {
            string tablename = "[dbo].[Uslugi]";
            string columnname = "GirlStr";
            DataBaseClass dataBase = new DataBaseClass();
            cb_Massage.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_Massage.DisplayMemberPath = "GirlStr";

        }

        private void FillComboBoxSPA()
        {
            string tablename = "[dbo].[Uslugi]";
            string columnname = "ManStr";
            DataBaseClass dataBase = new DataBaseClass();
            cb_SPA.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_SPA.DisplayMemberPath = "ManStr";
        }

        private void FillComboBoxUborka()
        {
            string tablename = "[dbo].[Uslugi]";
            string columnname = "Manik";
            DataBaseClass dataBase = new DataBaseClass();
            cb_Uborka.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_Uborka.DisplayMemberPath = "Manik";
        }

        private void cb_Eda_DropDownClosed(object sender, EventArgs e)
        {
            DataBaseClass dataBase = new DataBaseClass();
            lb_PricePokraska.Content = dataBase.GetCostUsluga(cb_Eda.Text);
        }
        private void cb_Massage_DropDownClosed(object sender, EventArgs e)
        {
            DataBaseClass dataBase = new DataBaseClass();
            lb_pricemas.Content = dataBase.GetCostUsluga2(cb_Massage.Text);
        }
        private void cb_SPA_DropDownClosed(object sender, EventArgs e)
        {
            DataBaseClass dataBase = new DataBaseClass();
            lb_PriceMan.Content = dataBase.GetCostUsluga3(cb_SPA.Text);
        }
        private void cb_Uborka_DropDownClosed(object sender, EventArgs e)
        {
            DataBaseClass dataBase = new DataBaseClass();
            lb_priceubor.Content = dataBase.GetCostUsluga4(cb_Uborka.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uslugi.Instance.InitUsluga(cb_Eda.Text, Convert.ToInt32(lb_PricePokraska.Content));
            //vhod.ShowDialog();
            oplatausluga.increase_itogprice(Convert.ToInt32(lb_PricePokraska.Content));
            this.Hide();
            oplatausluga.ShowDialog();
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Uslugi.Instance.InitUsluga2(cb_Massage.Text, Convert.ToInt32(lb_pricemas.Content));
            //vhod.ShowDialog();
            oplatausluga.increase_itogprice(Convert.ToInt32(lb_pricemas.Content));
            this.Hide();
            oplatausluga.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Uslugi.Instance.InitUsluga2(cb_SPA.Text, Convert.ToInt32(lb_PriceMan.Content));
            //vhod.ShowDialog();
            oplatausluga.increase_itogprice(Convert.ToInt32(lb_PriceMan.Content));
            this.Hide();
            oplatausluga.ShowDialog();
           
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Uslugi.Instance.InitUsluga4(cb_Uborka.Text, Convert.ToInt32(lb_priceubor.Content));
            //vhod.ShowDialog();
            oplatausluga.increase_itogprice(Convert.ToInt32(lb_priceubor.Content));
            this.Hide();
            oplatausluga.ShowDialog();
          
        }

        private void cb_Eda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
