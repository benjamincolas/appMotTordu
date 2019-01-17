using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Threading;

namespace lesMotsTordus
{
    public partial class frmModifierCouv : MetroForm
    {
        private Label _txtMouseHover;
        private string _niveau;
        private Thread th;

        public frmModifierCouv(string wNiveau)
        {
            InitializeComponent();

            //permet de vider la mémoire RAM non utilisé
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _niveau = wNiveau; //récupére le niveau de l'utilisateur

            if (_niveau == "persResp")
            {
                pctBxEmprunteur.Enabled = false;
                pctBxEmprunteur.Cursor = Cursors.Default;
                pctBxEmprunteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_off") as Image;
            }

            //initialise le label au survol des images des autres fenêtres
            _txtMouseHover = new Label(); //initialise un nouveau label
            _txtMouseHover.BackColor = Color.Orange; //change le fond du label en orange
            _txtMouseHover.AutoSize = true; //la taille du label s'adapte au text
            _txtMouseHover.Font = new Font("Bahnschrift Condensed", 11, FontStyle.Bold); //change la police du label
        }

        private void addTextOnHover(string text) //au survol des image à gauche
        {
            Point monPoint = Cursor.Position; //monPoint de type point prend la position du curseur
            monPoint.Y -= Cursor.Size.Height - 13; //enleve 13 sur l'axe de y de monPoint par rapport au curseur
            monPoint.X -= this.Location.X; //garde la position de x
            monPoint.Y -= this.Location.Y; //garde la position de y
            _txtMouseHover.Location = monPoint; //affecte monPoint à la localisation du label au survol
            _txtMouseHover.Text = text; //affecte la veleur text au label
            this.Controls.Add(_txtMouseHover); //ajoute le label à la fenêtre
            _txtMouseHover.BringToFront(); //met le label au dessus de tous les autres contrôles
        }

        private void pctBxDeconnexion_Click(object sender, EventArgs e) //au clique sur le bouton dee déconnexion
        {
            //initialise une nouvelle fenêtre de connexion
            void opennewform(object obj)
            {
                Application.Run(new frmConnexion());
            }
            this.Dispose();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void pctBxQuitApp_Click(object sender, EventArgs e) //cette méthode permet de quitter l'application
        {
            Application.Exit(); //ferme l'application
        }

        private void pctBxHome_Click(object sender, EventArgs e) //au clique sur le logo
        {
            //initialise une nouvelle fenêtre de gestion général
            void opennewform(object obj)
            {
                Application.Run(new frmGestionGeneral(_niveau));
            }
            this.Dispose();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        #region Livre
        //méthodes liées au bouton livre
        private void pctBxLivre_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBxLivre.BackgroundImage = Properties.Resources.ResourceManager.GetObject("livre_hover") as Image; //change l'image
            addTextOnHover("Gestion des livres"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBxLivre_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBxLivre.BackgroundImage = Properties.Resources.ResourceManager.GetObject("livre") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBxLivre_Click(object sender, EventArgs e) //au clique sur l'image
        {
            //initialise une nouvelle form de Gestion des livres
            void opennewform(object obj)
            {
                Application.Run(new frmGestionLivres(_niveau));
            }
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        #endregion

        #region Emprunt
        //méthodes liées au bouton Emprunt
        private void pctBxEmprunteur_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBxEmprunteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_hover") as Image; //change l'image
            addTextOnHover("Gestion des emprunts"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBxEmprunteur_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBxEmprunteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBxEmprunteur_Click(object sender, EventArgs e)
        {
            //initialise une nouvelle fenêtre de Gestion des emprunts
            void opennewform(object obj)
            {
                Application.Run(new frmGestionEmprunteur(_niveau));
            }
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        #endregion

        #region Editeur
        //méthodes liées au bouton Editeur
        private void pctBxEditeur_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBxEditeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur_hover") as Image; //change l'image
            addTextOnHover("Gestion des éditeurs"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBxEditeur_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBxEditeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBxEditeur_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Auteur
        //méthodes liées au bouton Auteur
        private void pctBxAuteur_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBxAuteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur_hover") as Image; //change l'image
            addTextOnHover("Gestion des auteurs"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBxAuteur_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBxAuteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBxAuteur_Click(object sender, EventArgs e)
        {
            //initialise une nouvelle fenêtre de Gestion des auteurs
            void opennewform(object obj)
            {
                Application.Run(new frmGestionAuteur(_niveau));
            }
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        #endregion
    }
}
