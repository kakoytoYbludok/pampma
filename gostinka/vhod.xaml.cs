using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security;
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
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private string GetPassword(PasswordBox passwordBox)
        {
            // Получение содержимого PasswordBox с использованием SecureString
            SecureString securePassword = passwordBox.SecurePassword;

            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
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
            if (tbLoginvhod.Text != "" && GetPassword(tb_Pass) != "")
            {
              DataBaseClass dataBaseClass = new DataBaseClass();



                if (dataBaseClass.loginuser(tbLoginvhod.Text, HashPassword(GetPassword(tb_Pass)))) 
                {
                    MessageBox.Show("Удачный вход!");
                    glavnaya glavnaya = new glavnaya();
                    //vhod.ShowDialog();
                    User.Instance.InitUser(tbLoginvhod.Text);
                    glavnaya.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось войти!");
                }

                tbLoginvhod.Clear(); tb_Pass.Clear();
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
