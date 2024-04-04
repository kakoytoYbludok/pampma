using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;
using System.Security.Cryptography;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
    
            
            if (tbLogin.Text != "" && GetPassword(tb_Pass) != ""  && tbMail.Text != "" && tbPhone.Text != "")
            {

                DataBaseClass dataBaseClass = new DataBaseClass();
                string query = $"insert into dbo.[Buyer]([Login_Buyer], [Password_Buyer], [Mail_Buyer]," +
                    $" [Phone_Buyer]) values ('{this.tbLogin.Text}', '{HashPassword(GetPassword(tb_Pass))}', '{this.tbMail.Text}', '{this.tbPhone.Text}')";


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

                tbLogin.Clear(); tb_Pass.Clear();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
