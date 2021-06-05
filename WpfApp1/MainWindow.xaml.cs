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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Global;
using Global.prop;
using Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object NavigationService { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // homeknop 
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // 
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




        private void toonAlles_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                var test = new DataBeheer();
                test.Inlezen();
                MessageBox.Show("a");
                string connectionString = @"Data Source =.\SQLEXPRESS;Initial Catalog = eindWerk; Integrated Security = True";
                conn = new(connectionString);

                SqlCommand com = new SqlCommand("SELECT * FROM adres, adreslocatie, gemeente, straat WHERE  adres.straatID = straat.id AND adres.adreslocatieID = adreslocatie.id AND straat.NIScode = gemeente.NIScode", conn);
                SqlDataAdapter d = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                d.Fill(dt);
                dataGrid.DataContext = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputgemeente = inputGemeente.Text;
                string inputHL = inputgemeente.Substring(0, 1).ToUpper() + inputgemeente.Substring(1);
                MessageBox.Show(inputHL);
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //List<Adres> adres = new List<Adres>();

            //var orderProvintienaam = adres.GroupBy(p => p.Id);

            //foreach (Adres naam in orderProvintienaam)
            //{
            //    Console.WriteLine($"{naam.Id} {naam.Huisnummer} {naam.Postcode} {naam.Huisnummerlabel} ");
            //}
        }
    }
}
