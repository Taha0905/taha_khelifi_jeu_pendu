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
    /// 
    public partial class MainWindow : Window
    {
        private JeuPendu pendu;

        public MainWindow()
        {
            InitializeComponent();
            pendu = new JeuPendu(TB_Vie_Restant, TB_Mot);
        }

        private void BTN_Commencer_Click_1(object sender, RoutedEventArgs e)
        {
            pendu.InitialiserJeu();
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

            pendu.JouerTour(lettre);

            if (pendu.EstPartiePerdue())
            {
                MessageBox.Show("Vous avez perdu !");
                DesactiverTouchesClavier();
            }
            else if (pendu.EstPartieGagnee())
            {
                MessageBox.Show("Vous avez gagné !");
                DesactiverTouchesClavier();
            }
        }

        private void DesactiverTouchesClavier()
        {
            foreach (var child in ClavierGrid.Children.OfType<Button>())
            {
                if (child.Name != "BTN_Commencer")
                {
                    child.IsEnabled = false;
                }
            }
        }
    }

    public class JeuPendu
    {
        private string motAdeviner;
        private int viesRestantes = 4;
        private TextBox TB_Vie_Restant;
        private TextBox TB_Mot;

        public JeuPendu(TextBox tbVieRestant, TextBox tbMot)
        {
            TB_Vie_Restant = tbVieRestant;
            TB_Mot = tbMot;
        }

        public void InitialiserJeu()
        {
            viesRestantes = 4;
            TB_Vie_Restant.Text = viesRestantes.ToString();

            List<string> mots = new List<string> { "RARE", "JEUX", "BALLE" /* Ajoutez plus de mots ici */ };
            Random random = new Random();
            motAdeviner = mots[random.Next(mots.Count)];

            TB_Mot.Text = new string('*', motAdeviner.Length);
        }

        public void JouerTour(string lettre)
        {
            if (motAdeviner.Contains(lettre))
            {
                char[] motActuel = TB_Mot.Text.ToCharArray();
                for (int i = 0; i < motAdeviner.Length; i++)
                {
                    if (motAdeviner[i] == lettre[0])
                    {
                        motActuel[i] = lettre[0];
                    }
                }
                TB_Mot.Text = new string(motActuel);
            }
            else
            {
                viesRestantes--;
                TB_Vie_Restant.Text = viesRestantes.ToString();
            }
        }

        public bool EstPartiePerdue()
        {
            return viesRestantes == 0;
        }

        public bool EstPartieGagnee()
        {
            return !TB_Mot.Text.Contains("*");
        }
    }
}