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

namespace taha_khelifi_jeu_pendu
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> motsEn4Lettres = new List<string> { "chat", "rare", "vent", "rond" };
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_Commencer_Click_1(object sender, RoutedEventArgs e)
        {
            {
                // Sélectionnez un mot aléatoire dans la liste
                int indexMotAleatoire = random.Next(motsEn4Lettres.Count);
                string motAleatoire = motsEn4Lettres[indexMotAleatoire];

                // Affichez le mot dans TextBlock TB_Mot
                TB_Mot.Text = motAleatoire;
            }
        }
    }
}