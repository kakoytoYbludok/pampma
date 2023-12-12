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
using static System.Net.Mime.MediaTypeNames;

namespace gostinka
{
    /// <summary>
    /// Логика взаимодействия для registr.xaml
    /// </summary>
    public partial class registr : Window
    {
        public registr()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (tbLogin.Text != "" && tbPass.Text != "" && tbMail.Text != "" && tbPhone.Text != "")
            {

                DataBaseClass dataBaseClass = new DataBaseClass();
                string query = $"insert into dbo.[Buyer]([Login_Buyer], [Password_Buyer], [Mail_Buyer]," +
                    $" [Phone_Buyer]) values ('{this.tbLogin.Text}', '{this.tbPass.Text}', '{this.tbMail.Text}', '{this.tbPhone.Text}')";

               
                if (dataBaseClass.ExecuteQuery(query) != 0)
                {
                    MessageBox.Show("Вы успешно зарегестрировались !");
                    vhod vhod = new vhod();
                    //vhod.ShowDialog();
                    vhod.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось зарегестрироваться!");
                }

                tbLogin.Clear(); tbPass.Clear();
            }
            else
            {
                MessageBox.Show("Не все поля заполены!");
            }
        }

        private void Button_Clicktovhod(object sender, RoutedEventArgs e)
        {
            vhod vhod = new vhod();
            //vhod.ShowDialog();
            vhod.Show();
            this.Close();
        }
    }
}
