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
    /// Логика взаимодействия для glavnaya.xaml
    /// </summary>
    public partial class glavnaya : Window
    {
        public glavnaya()
        {
            InitializeComponent();
        }

        private void Button_luxe(object sender, RoutedEventArgs e)
        {
            luxe luxe = new luxe();
            //vhod.ShowDialog();
            luxe.Show();
            this.Close();
        }

        private void Button_4x(object sender, RoutedEventArgs e)
        {
            chetirmest chetirmest = new chetirmest();
            //vhod.ShowDialog();
            chetirmest.Show();
            this.Close();
        }

        private void Button_koika(object sender, RoutedEventArgs e)
        {
            koika koika = new koika();
            //vhod.ShowDialog();
            koika.Show();
            this.Close();
        }

        private void Button_usluga(object sender, RoutedEventArgs e)
        {
            usluga usluga = new usluga();
            //vhod.ShowDialog();
            usluga.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            profile profile = new profile();
            //vhod.ShowDialog();
            profile.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vhod vhod = new vhod();
            //vhod.ShowDialog();
            vhod.Show();
            this.Close();
        }
    }
}
