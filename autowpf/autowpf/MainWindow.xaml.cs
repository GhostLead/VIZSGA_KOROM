using autoapp;
using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace autowpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //3-4. feladat: Betöltés gomb eseménykezelője
        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                List<Auto> autok = Auto.Beolvas(filePath);
                dgTablazat.ItemsSource = autok;
            }
        }

        //6. feladat: Keresés gomb eseménykezelője
        private void btnBezar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan ki szeretne lépni?", "Kilépés", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
            else
            {
                return;
            }
        }

        //5. feladat: Szűrés eseménykezelője
        private void txtEv_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbSpecko.Items.Clear();

            int szurtEv = int.Parse(txtEv.Text);

            List<Auto> autok = (List<Auto>)dgTablazat.ItemsSource;

            if (autok != null)
            {
                lbSpecko.Items.Clear();
                var szurtAutok = autok.Where(a => a.GyartasiEv == szurtEv).ToList();
                foreach (var auto in szurtAutok)
                {
                    lbSpecko.Items.Add($"{auto.Marka} {auto.Modell}");
                }
            }
            


        }
    }
}