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
        private string motAdeviner;
        private int viesRestantes = 4;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_Commencer_Click_1(object sender, RoutedEventArgs e)
        {
            // Réinitialisez le jeu.
            viesRestantes = 4;
            TB_Vie_Restant.Text = viesRestantes.ToString();

            // Générez un nouveau mot aléatoire.
            List<string> mots = new List<string> { "MOT1", "MOT2", "MOT3" /* Ajoutez plus de mots ici */ };
            Random random = new Random();
            motAdeviner = mots[random.Next(mots.Count)];

            // Initialisez TB_Mot avec des astérisques.
            TB_Mot.Text = new string('*', motAdeviner.Length);

            // Réactivez les touches du clavier.
            foreach (var child in ClavierGrid.Children.OfType<Button>())
            {
                if (child.Name != "BTN_Commencer")
                {
                    child.IsEnabled = true;
                }
            }
        }

        private void Clavier_Click(object sender, RoutedEventArgs e)
        {
            Button bouton = (Button)sender;
            string lettre = bouton.Content.ToString();

            if (motAdeviner.Contains(lettre))
            {
                // La lettre fait partie du mot à deviner.
                char[] motActuel = TB_Mot.Text.ToCharArray();
                for (int i = 0; i < motAdeviner.Length; i++)
                {
                    if (motAdeviner[i] == lettre[0])
                    {
                        motActuel[i] = lettre[0];
                    }
                }
                TB_Mot.Text = new string(motActuel);
                bouton.IsEnabled = false;
            }
            else
            {
                // La lettre ne fait pas partie du mot, réduisez les vies.
                viesRestantes--;
                TB_Vie_Restant.Text = viesRestantes.ToString();
                bouton.IsEnabled = false;
            }

            if (viesRestantes == 0)
            {
                MessageBox.Show("Vous avez perdu !");
                DesactiverTouchesClavier();
            }
            else if (!TB_Mot.Text.Contains("*"))
            {
                MessageBox.Show("Vous avez gagné !");
                DesactiverTouchesClavier();
            }
        }

        private void DesactiverTouchesClavier()
        {
            // Désactivez toutes les touches du clavier.
            foreach (var child in ClavierGrid.Children.OfType<Button>())
            {
                if (child.Name != "BTN_Commencer")
                {
                    child.IsEnabled = false;
                }
            }
        }
    }
}