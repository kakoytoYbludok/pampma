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
    /// Логика взаимодействия для profile.xaml
    /// </summary>
    public partial class profile : Window
    {
        DataTable datatable = new DataTable();
        DataBaseClass database = new DataBaseClass();
        public profile()
        {
            InitializeComponent();
            dg_History.CanUserAddRows = false;
            dg_History.IsReadOnly = true;
            datatable = database.GetUsersZakaz(User.Instance.Login);
            dg_History.ItemsSource = datatable.DefaultView;
            dg_HisUsl.ItemsSource = database.GetUsersZakazUslug(User.Instance.Login).DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            glavnaya glavnaya = new glavnaya();
            //vhod.ShowDialog();
            glavnaya.Show();
            this.Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            vhod vhod = new vhod();
            //vhod.ShowDialog();
            vhod.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lb_Login.Content = User.Instance.Login;
            lb_Mail.Content = User.Instance.Mail;
            lb_Phone.Content = User.Instance.Phone;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tb_Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {

            string searchText = tb_Poisk.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dataView = datatable.DefaultView;
                dataView.RowFilter = GetFilterExpression(searchText);
               
            }
            else
            {
                datatable.DefaultView.RowFilter = String.Empty;
            }
        }
        private string GetFilterExpression(string searchText)
        {
            string FilterExpression = string.Empty;
            foreach (DataColumn column in datatable.Columns)
            {
                if (!string.IsNullOrEmpty(FilterExpression))
                {
                    FilterExpression += " OR ";
                }
                FilterExpression += GetFilterExpressionForColumn(column, searchText);
            }
            return FilterExpression;
        }

        private string GetFilterExpressionForColumn(DataColumn column, string searchText)
        {
            switch (Type.GetTypeCode(column.DataType))
            {
                case TypeCode.String:
                case TypeCode.Char:
                    return $"CONVERT({column.ColumnName}, 'System.String') LIKE '%{searchText}%'";

                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Double:
                case TypeCode.Single:
                case TypeCode.Decimal:
                    return $"CONVERT({column.ColumnName}, 'System.String') LIKE '%{searchText}%'";

                case TypeCode.Boolean:
                    return $"CONVERT({column.ColumnName}, 'System.String') LIKE '%{searchText}%'";


                default:
                    return string.Empty;
            }
        }

        
    }
}
