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
        public usluga()
        {
            InitializeComponent();
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
            string columnname = "VidEda";
            DataBaseClass dataBase = new DataBaseClass();
            cb_Eda.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_Eda.DisplayMemberPath = "VidEda";
        }


        private void FillComboBoxMassage()
        {
            string tablename = "[dbo].[Uslugi]";
            string columnname = "VidMassage";
            DataBaseClass dataBase = new DataBaseClass();
            cb_Massage.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_Massage.DisplayMemberPath = "VidMassage";

        }

        private void FillComboBoxSPA()
        {
            string tablename = "[dbo].[Uslugi]";
            string columnname = "VidSPA";
            DataBaseClass dataBase = new DataBaseClass();
            cb_SPA.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_SPA.DisplayMemberPath = "VidSPA";
        }

        private void FillComboBoxUborka()
        {
            string tablename = "[dbo].[Uslugi]";
            string columnname = "VidUborka";
            DataBaseClass dataBase = new DataBaseClass();
            cb_Uborka.ItemsSource = dataBase.Getcolumndata(tablename, columnname).DefaultView;
            cb_Uborka.DisplayMemberPath = "VidUborka";
        }
    }
}
