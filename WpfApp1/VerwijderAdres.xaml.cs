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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for VerwijderAdres.xaml
    /// </summary>
    public partial class VerwijderAdres : Page
    {
        public VerwijderAdres()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            this.Content = home;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdresUpdaten update = new AdresUpdaten();
            this.Content = update;
        }

        private void verwijderen_Click(object sender, RoutedEventArgs e)
        {
            VerwijderAdres verwijder = new VerwijderAdres();
            this.Content = verwijder;
        }

        private void toevoegen_Click(object sender, RoutedEventArgs e)
        {
            ToevoegenAdres toevoegen = new ToevoegenAdres();
            this.Content = toevoegen;
        }




        private void AdresVerwijderen_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GemeenteVerwijderen_Click(object sender, RoutedEventArgs e)
        {

        }   
        private void StraatVerwijderen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
