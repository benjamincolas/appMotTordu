using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Drawing;
using System.Threading;

namespace lesMotsTordus
{
    public partial class frmGestionGeneral : MetroForm
    {
        //propriétée.s
        private string _niveau;
        private Thread th;

        //constructeur de la form
        public frmGestionGeneral(string wNiveau)
        {
            InitializeComponent();

            _niveau = wNiveau;

            //permet de vider la mémoire RAM non utiliser
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _niveau = wNiveau;
            //si l'utilisateur est un administrateur alors on active le bouton gestion des comptes utilisateur
            if (_niveau == "admin")
            {
                pctBxCompte.Enabled = true;
                pctBxCompte.Cursor = Cursors.Hand;
                pctBxCompte.BackgroundImage = Properties.Resources.ResourceManager.GetObject("utilisateur") as Image;
            }
            else if(_niveau == "accueil")
            {
                pctBxAuteur.Enabled = false;
                pctBxAuteur.Cursor = Cursors.Default;
                pctBxAuteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur_off") as Image;

                pctBxEditeur.Enabled = false;
                pctBxEditeur.Cursor = Cursors.Default;
                pctBxEditeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur_off") as Image;

                pctBxLivreCouv.Enabled = false;
                pctBxLivreCouv.Cursor = Cursors.Default;
                pctBxLivreCouv.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couv_off") as Image;

                pctBxEmprunt.Enabled = false;
                pctBxEmprunt.Cursor = Cursors.Default;
                pctBxEmprunt.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_off") as Image;
            }
            else if (_niveau == "respSecteur")
            {
                pctBxAuteur.Enabled = false;
                pctBxAuteur.Cursor = Cursors.Default;
                pctBxAuteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur_off") as Image;

                pctBxEditeur.Enabled = false;
                pctBxEditeur.Cursor = Cursors.Default;
                pctBxEditeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur_off") as Image;

                pctBxLivreCouv.Enabled = false;
                pctBxLivreCouv.Cursor = Cursors.Default;
                pctBxLivreCouv.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couv_off") as Image;
            }
            else if (_niveau == "persResp")
            {
                pctBxEmprunt.Enabled = false;
                pctBxEmprunt.Cursor = Cursors.Default;
                pctBxEmprunt.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_off") as Image;
            }

        }

        #region méthode.s
        //cette méthode permet de quitter l'application
        private void pctBxQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //cette méthode permet de ce déconnecter de l'application
        private void pctBxDeconnect_Click(object sender, EventArgs e)
        {
            void opennewform(object obj)
            {
                Application.Run(new frmConnexion());
            }
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        //méthodes liées au bouton livre
        #region Livre
        //change l'image quand la souris passe sur le bouton
        private void pctBxLivre_MouseEnter(object sender, EventArgs e)
        {
            pctBxLivre.BackgroundImage = Properties.Resources.ResourceManager.GetObject("livre_hover") as Image;
        }

        //change l'image quand la souris quitte le bouton
        private void pctBxLivre_MouseLeave(object sender, EventArgs e)
        {
            pctBxLivre.BackgroundImage = Properties.Resources.ResourceManager.GetObject("livre") as Image;
        }

        //quand on click sur l'image, ouvre la form
        private void pctBxLivre_Click(object sender, EventArgs e)
        {
            //initialise une nouvelle form de Gestion des livres
            void opennewform(object obj)
            {
                Application.Run(new frmGestionLivres(_niveau));
            }
            this.Close(); //ferme la form courante
            th = new Thread(opennewform); //affecte un objet de type thread à th
            th.SetApartmentState(ApartmentState.STA);
            th.Start(); //lance le nouveau thread
        }
        #endregion

        //méthodes liées au bouton Emprunt
        #region Emprunt
        //change l'image quand la souris passe sur le bouton
        private void pctBxEmprunt_MouseEnter(object sender, EventArgs e)
        {
            pctBxEmprunt.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_hover") as Image;
        }

        //change l'image quand la souris quitte le bouton
        private void pctBxEmprunt_MouseLeave(object sender, EventArgs e)
        {
            pctBxEmprunt.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur") as Image;
        }

        //quand on click sur l'image, ouvre la form
        private void pctBxEmprunt_Click(object sender, EventArgs e)
        {
            //initialise une nouvelle form de Gestion des emprunts
            void opennewform(object obj)
            {
                Application.Run(new frmGestionEmprunteur(_niveau));
            }
            this.Close(); //ferme la form courante
            th = new Thread(opennewform); //affecte un objet de type thread à th
            th.SetApartmentState(ApartmentState.STA);
            th.Start(); //lance le nouveau thread
        }
        #endregion

        //méthodes liées au bouton Editeur
        #region Editeur
        //change l'image quand la souris passe sur le bouton
        private void pctBxEditeur_MouseEnter(object sender, EventArgs e)
        {
            pctBxEditeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur_hover") as Image;
        }

        //change l'image quand la souris quitte le bouton
        private void pctBxEditeur_MouseLeave(object sender, EventArgs e)
        {
            pctBxEditeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur") as Image;
        }

        //quand on click sur l'image, ouvre la form
        private void pctBxEditeur_Click(object sender, EventArgs e)
        {
            //initialise une nouvelle form de Gestion des editeurs
            void opennewform(object obj)
            {
                Application.Run(new frmGestionEditeur(_niveau));
            }
            this.Close(); //ferme la form courante
            th = new Thread(opennewform); //affecte un objet de type thread à th
            th.SetApartmentState(ApartmentState.STA);
            th.Start(); //lance le nouveau thread
        }
        #endregion

        //méthodes liées au bouton Couverture
        #region Couverture
        //change l'image quand la souris passe sur le bouton
        private void pctBxLivreCouv_MouseEnter(object sender, EventArgs e)
        {
            pctBxLivreCouv.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couv_hover") as Image;
        }

        //change l'image quand la souris quitte le bouton
        private void pctBxLivreCouv_MouseLeave(object sender, EventArgs e)
        {
            pctBxLivreCouv.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couverture") as Image;
        }

        //quand on click sur l'image, ouvre la form
        private void pctBxLivreCouv_Click(object sender, EventArgs e)
        {
            //initialise une nouvelle form de Gestion des couvertures
            void opennewform(object obj)
            {
                Application.Run(new frmModifierCouv(_niveau));
            }
            this.Close(); //ferme la form courante
            th = new Thread(opennewform); //affecte un objet de type thread à th
            th.SetApartmentState(ApartmentState.STA);
            th.Start(); //lance le nouveau thread
        }
        #endregion

        //méthodes liées au bouton Auteur
        #region Auteur
        //change l'image quand la souris passe sur le bouton
        private void pctBxAuteur_MouseEnter(object sender, EventArgs e)
        {
            pctBxAuteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur_hover") as Image;
        }

        //change l'image quand la souris quitte le bouton
        private void pctBxAuteur_MouseLeave(object sender, EventArgs e)
        {
            pctBxAuteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur") as Image;
        }

        //quand on click sur l'image, ouvre la form
        private void pctBxAuteur_Click(object sender, EventArgs e)
        {
            //initialise une nouvelle form de Gestion des auteurs
            void opennewform(object obj)
            {
                Application.Run(new frmGestionAuteur(_niveau));
            }
            this.Close(); //ferme la form courante
            th = new Thread(opennewform); //affecte un objet de type thread à th
            th.SetApartmentState(ApartmentState.STA);
            th.Start(); //lance le nouveau thread
        }
        #endregion

        //méthodes liées au bouton ComptesUtilisateur
        #region ComptesUtilisateur
        //change l'image quand la souris passe sur le bouton
        private void pctBxCompte_MouseEnter(object sender, EventArgs e)
        {
            pctBxCompte.BackgroundImage = Properties.Resources.ResourceManager.GetObject("utilisateur_hover") as Image;
        }

        //change l'image quand la souris quitte le bouton
        private void pctBxCompte_MouseLeave(object sender, EventArgs e)
        {
            pctBxCompte.BackgroundImage = Properties.Resources.ResourceManager.GetObject("utilisateur") as Image;
        }

        //quand on click sur l'image, ouvre la form
        private void pctBxCompte_Click(object sender, EventArgs e)
        {
            //initialise une nouvelle form de Gestion des comptesUtilisateur
            void opennewform(object obj)
            {
                Application.Run(new frmGestionCompteUtilisateur(_niveau));
            }
            this.Dispose();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        #endregion
        #endregion
    }
}
