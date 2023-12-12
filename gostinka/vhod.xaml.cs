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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gostinka
{
    /// <summary>
    /// Логика взаимодействия для vhod.xaml
    /// </summary>
    public partial class vhod : Window
    {
        public vhod()
        {
            InitializeComponent();
            
        }


        private void Button_noacc(object sender, RoutedEventArgs e)
        {
            registr registr = new registr();
            //vhod.ShowDialog();
            registr.Show();
            this.Close();
        }

        private void Button_vhod(object sender, RoutedEventArgs e)
        {
            if (tbLoginvhod.Text != "" && tbPassvhod.Text != "")
            {
              DataBaseClass dataBaseClass = new DataBaseClass();
                
                
                
                if (dataBaseClass.loginuser(tbLoginvhod.Text, tbPassvhod.Text))
                {
                    MessageBox.Show("Удачный вход!");
                    glavnaya glavnaya = new glavnaya();
                    //vhod.ShowDialog();
                    glavnaya.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось войти!");
                }

                tbLoginvhod.Clear(); tbPassvhod.Clear();
            }
            else
            {
                MessageBox.Show("Не все поля заполены!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vhodAdmin vhodAdmin = new vhodAdmin();
            //vhod.ShowDialog();
            vhodAdmin.Show();
            this.Close();
        }


        

    }
    }
