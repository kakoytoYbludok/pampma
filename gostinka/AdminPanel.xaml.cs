using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using OxyPlot;
using OxyPlot.Series;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OxyPlot.Axes;

namespace gostinka
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public PlotModel PlotModel { get; set; }
        public AdminPanel()
        {
            InitializeComponent();
            PlotModel = new PlotModel();

            // Add series to the plot model
            var series = new LineSeries();
            series.MarkerType = MarkerType.Circle;
            series.MarkerSize = 6;
            series.MarkerStroke = OxyColors.Black;
            series.MarkerFill = OxyColors.Red;
            series.Points.Add(new DataPoint(1, 87926));

            // Add more data points as needed

            PlotModel.Series.Add(series);

            DataContext = this;
        }

        private void TableUserFill()
        {
            try
            {

                Action action = () =>
                {
                    DataBaseClass dataBaseClass = new DataBaseClass();

                    dataBaseClass.sqlExecute("select [ID_Buyer], [Login_Buyer], [Password_Buyer], [Mail_Buyer], [Phone_Buyer] from [dbo].[Buyer]", DataBaseClass.act.select);

                    dataBaseClass.dependency.OnChange += DependancyOnChange_User;

                    dgUser.ItemsSource = dataBaseClass.resultTable.DefaultView;
                    dgUser.Columns[0].Visibility = Visibility.Hidden;
                    dgUser.Columns[1].Header = "Логин";
                    dgUser.Columns[2].Header = "Пароль";
                    dgUser.Columns[3].Header = "Почта";
                    dgUser.Columns[4].Header = "Телефон";
                };
                Dispatcher.Invoke(action);
            }
            catch { };
        }

        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = dgUser.SelectedItems[0] as DataRowView;
                tbLoginUser.Text = dataRowView[1].ToString();
                tbPassUser.Text = dataRowView[2].ToString();
                tbMailUser.Text = dataRowView[3].ToString();
                tbPhoneUser.Text = dataRowView[4].ToString();

            }
            catch { }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass dataBaseClass = new DataBaseClass();
            dataBaseClass.sqlExecute(string.Format("insert into [dbo].[Buyer] ([Login_Buyer], [Password_Buyer], [Mail_Buyer], [Phone_Buyer])" +
                "values ('{0}', '{1}', '{2}', '{3}')", tbLoginUser.Text, tbPassUser.Text, tbMailUser.Text, tbPhoneUser.Text), DataBaseClass.act.manipulation);

        }
        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass dataBaseClass = new DataBaseClass();
            DataRowView dataRowView = dgUser.SelectedItems[0] as DataRowView;
            dataBaseClass.sqlExecute(String.Format("update [dbo].[Buyer] set " +
                "[Login_Buyer] = '{0}'," +
                "[Password_Buyer] = '{1}'," +
                "[Mail_Buyer] = '{2}'," +
                "[Phone_Buyer] = '{3}'" +
                "where [ID_Buyer] = {4}",
                  tbLoginUser.Text, tbPassUser.Text, tbMailUser.Text, tbPhoneUser.Text, dataRowView[0]), DataBaseClass.act.manipulation);
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (dgUser.Items.Count != 0 & dgUser.SelectedItems.Count != 0)
            {
                DataRowView dataRowView = (DataRowView)dgUser.SelectedItems[0];
                DataBaseClass dataBaseClass = new DataBaseClass();
                dataBaseClass.sqlExecute(string.Format("delete from [dbo].[Buyer] where [ID_Buyer] = {0}", dataRowView[0]), DataBaseClass.act.manipulation);
            }
        }

        /////////////////////////////SOTRUDNIK///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        private void TableWorkerFill()
        {
            try
            {

                Action action = () =>
                {
                    DataBaseClass dataBaseClass = new DataBaseClass();

                    dataBaseClass.sqlExecute("select [ID_Sotrudnik], [Login_Sotrudnik], [Password_Sotrudnik], [Passport_Sotrudnik], [Phone_Sotrudnik], [DataNaima] from [dbo].[Sotrudnik]", DataBaseClass.act.select);

                    dataBaseClass.dependency.OnChange += DependancyOnChange_Worker;

                    dgWorker.ItemsSource = dataBaseClass.resultTable.DefaultView;
                    dgWorker.Columns[0].Visibility = Visibility.Hidden;
                    dgWorker.Columns[1].Header = "Логин";
                    dgWorker.Columns[2].Header = "Пароль";
                    dgWorker.Columns[3].Header = "Паспорт";
                    dgWorker.Columns[4].Header = "Телефон";
                    dgWorker.Columns[5].Header = "Дата найма";
                };
                Dispatcher.Invoke(action);
            }
            catch { };
        }

        private void dgWorker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = dgWorker.SelectedItems[0] as DataRowView;
                tbLoginWorker.Text = dataRowView[1].ToString();
                tbPassWorker.Text = dataRowView[2].ToString();
                tbpassportWorker.Text = dataRowView[3].ToString();
                tbPhoneWorker.Text = dataRowView[4].ToString();
                tbDatanaim.Text = dataRowView[5].ToString();

            }
            catch { }
        }

        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass dataBaseClass = new DataBaseClass();
            dataBaseClass.sqlExecute(string.Format("insert into [dbo].[Sotrudnik] ([Login_Sotrudnik], [Password_Sotrudnik], [Passport_Sotrudnik], [Phone_Sotrudnik], [DataNaima])" +
                "values ('{0}', '{1}', '{2}', '{3}', '{4}')", tbLoginWorker.Text, tbPassWorker.Text, tbpassportWorker.Text, tbPhoneWorker.Text, tbDatanaim.Text), DataBaseClass.act.manipulation);

        }
        private void btnUpdateWorker_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass dataBaseClass = new DataBaseClass();
            DataRowView dataRowView = dgWorker.SelectedItems[0] as DataRowView;
            dataBaseClass.sqlExecute(String.Format("update [dbo].[Sotrudnik] set " +
                "[Login_Sotrudnik] = '{0}'," +
                "[Password_Sotrudnik] = '{1}'," +
                "[Passport_Sotrudnik] = '{2}'," +
                "[Phone_Sotrudnik] = '{3}'," +
                "[DataNaima] = '{4}'" +
                "where [ID_Sotrudnik] = {5}",
                  tbLoginWorker.Text, tbPassWorker.Text, tbpassportWorker.Text, tbPhoneWorker.Text, tbDatanaim.Text, dataRowView[0]), DataBaseClass.act.manipulation);
        }

        private void btnDeleteWorker_Click(object sender, RoutedEventArgs e)
        {
            if (dgWorker.Items.Count != 0 & dgWorker.SelectedItems.Count != 0)
            {
                DataRowView dataRowView = (DataRowView)dgWorker.SelectedItems[0];
                DataBaseClass dataBaseClass = new DataBaseClass();
                dataBaseClass.sqlExecute(string.Format("delete from [dbo].[Sotrudnik] where [ID_Sotrudnik] = {0}", dataRowView[0]), DataBaseClass.act.manipulation);
            }
        }

        /////////////////////////////NOMER///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void TableNomerFill()
        {
            try
            {

                Action action = () =>
                {
                    DataBaseClass dataBaseClass = new DataBaseClass();

                    dataBaseClass.sqlExecute("select [ID_Infonomer], [NumberNomer], [Vidnomera], [Bed], [PriceNomer] from [dbo].[Infonomer]", DataBaseClass.act.select);

                    dataBaseClass.dependency.OnChange += DependancyOnChange_Nomer;

                    dgNomer.ItemsSource = dataBaseClass.resultTable.DefaultView;
                    dgNomer.Columns[0].Visibility = Visibility.Hidden;
                    dgNomer.Columns[1].Header = "Номер";
                    dgNomer.Columns[2].Header = "Вид номера";
                    dgNomer.Columns[3].Header = "Тип кровати";
                    dgNomer.Columns[4].Header = "Цена";
                };
                Dispatcher.Invoke(action);
            }
            catch { };
        }

        private void dgNomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = dgNomer.SelectedItems[0] as DataRowView;
                tbNumber.Text = dataRowView[1].ToString();
                tbVidNomera.Text = dataRowView[2].ToString();
                tbTypeBed.Text = dataRowView[3].ToString();
                tbPriceNomer.Text = dataRowView[4].ToString();

            }
            catch { }
        }

        private void btnAddNomer_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass dataBaseClass = new DataBaseClass();
            dataBaseClass.sqlExecute(string.Format("insert into [dbo].[Infonomer] ([NumberNomer], [Vidnomera], [Bed], [PriceNomer])" +
                "values ('{0}', '{1}', '{2}', '{3}')", tbNumber.Text, tbVidNomera.Text, tbTypeBed.Text, tbPriceNomer.Text), DataBaseClass.act.manipulation);

        }
        private void btnUpdateNomer_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass dataBaseClass = new DataBaseClass();
            DataRowView dataRowView = dgNomer.SelectedItems[0] as DataRowView;
            dataBaseClass.sqlExecute(String.Format("update [dbo].[Infonomer] set " +
                "[NumberNomer] = '{0}'," +
                "[Vidnomera] = '{1}'," +
                "[Bed] = '{2}'," +
                "[PriceNomer] = '{3}'" +
                "where [ID_Infonomer] = {4}",
                  tbNumber.Text, tbVidNomera.Text, tbTypeBed.Text, tbPriceNomer.Text, dataRowView[0]), DataBaseClass.act.manipulation);
        }

        private void btnDeleteNomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgNomer.Items.Count != 0 & dgNomer.SelectedItems.Count != 0)
            {
                DataRowView dataRowView = (DataRowView)dgNomer.SelectedItems[0];
                DataBaseClass dataBaseClass = new DataBaseClass();
                dataBaseClass.sqlExecute(string.Format("delete from [dbo].[Infonomer] where [ID_Infonomer] = {0}", dataRowView[0]), DataBaseClass.act.manipulation);
            }
        }



















        private void DependancyOnChange_Nomer(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
            {
                TableNomerFill();
            }
        }



        private void DependancyOnChange_Worker(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
            {
                TableWorkerFill();
            }
        }



        private void DependancyOnChange_User(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
            {
                TableUserFill();
            }
        }

        private void dgUser_Loaded(object sender, RoutedEventArgs e)
        {
            TableUserFill();
        }

        private void dgWorker_Loaded(object sender, RoutedEventArgs e)
        {
            TableWorkerFill();
        }

        private void dgNomer_Loaded(object sender, RoutedEventArgs e)
        {
            TableNomerFill();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vhod vhod = new vhod();
            //vhod.ShowDialog();
            vhod.Show();
            this.Close();
        }
    }


}

