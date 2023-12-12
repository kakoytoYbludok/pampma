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
    /// Логика взаимодействия для vhodAdmin.xaml
    /// </summary>
    public partial class vhodAdmin : Window
    {
        public vhodAdmin()
        {
            InitializeComponent();
        }



        private void Button_VhodAdm(object sender, RoutedEventArgs e)
        {
            if (tbLoginAdm.Text != "" && tbPassAdm.Text != "")
            {
                DataBaseClass dataBaseClass = new DataBaseClass();



                if (dataBaseClass.loginAdmin(tbLoginAdm.Text, tbPassAdm.Text))
                {
                    MessageBox.Show("Удачный вход!");
                    AdminPanel AdminPanel = new AdminPanel();
                    //vhod.ShowDialog();
                    AdminPanel.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось войти!");
                }

                tbLoginAdm.Clear(); tbPassAdm.Clear();
            }
            else
            {
                MessageBox.Show("Не все поля заполены!");
            }
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
