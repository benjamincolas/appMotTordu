using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ClassLibrary;
using System.Threading;

namespace lesMotsTordus
{
    public partial class frmGestionCompteUtilisateur : MetroForm
    {
       //propriétés
        private utilisateursProc _utilisateurs;
        private utilisateurs unUtilisateur;
        private int utilId;
        private Label _txtMouseHover;
        private string _niveau;
        private Thread th;

        public frmGestionCompteUtilisateur(string wNiveau) //contructeur
        {
            InitializeComponent();

            //permet de vider la mémoire RAM non utilisé
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _niveau = wNiveau; //récupére le niveau de l'utilisateur

            newDataGrid(); //iitialise un nouveau dataGrid

            //ajoute des objets à la comboBox
            cbBoxNiveauCompte.Items.Add("admin");
            cbBoxNiveauCompte.Items.Add("accueil");
            cbBoxNiveauCompte.Items.Add("respSecteur");
            cbBoxNiveauCompte.Items.Add("persResp");

            //initialise le label au survol des images des autres fenêtres
            _txtMouseHover = new Label(); //initialise un nouveau label
            _txtMouseHover.BackColor = Color.Orange; //change le fond du label en orange
            _txtMouseHover.AutoSize = true; //la taille du label s'adapte au text
            _txtMouseHover.Font = new Font("Bahnschrift Condensed", 11,FontStyle.Bold); //change la police du label
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

        private void initUtilisateur() //cette méthode permet d'initialiser deux nouveaux objets utilisateurs et utilisateursProc
        {
            _utilisateurs = new utilisateursProc();
            unUtilisateur = new utilisateurs(utilId, txtBxPrenomCompte.Text, txtBxNomCompte.Text, txtBxPseudoCompte.Text, txtBxPassCompte.Text, cbBoxNiveauCompte.Text);
        }

        private void newDataGrid() //cette méthode permet d'initialiser un nouveau dataGridView
        {
            _utilisateurs = new utilisateursProc();
            dataGridCompte.DataSource = _utilisateurs.listUtilisateur();

            //nommer les colonnes
            dataGridCompte.Columns[0].HeaderText = "prenom";
            dataGridCompte.Columns[1].HeaderText = "nom";
            dataGridCompte.Columns[2].HeaderText = "pseudo";
            dataGridCompte.Columns[3].Visible = false;
            dataGridCompte.Columns[4].HeaderText = "niveau";
            dataGridCompte.Columns[5].Visible = false;
        }

        private void resetBox() //cette méthode permet de mettre à zero le contenu des textsBox
        {
            txtBxNomCompte.Clear();
            txtBxPassCompte.Clear();
            txtBxPrenomCompte.Clear();
            txtBxPseudoCompte.Clear();
        }

        private void pctBxDeconnexion_Click(object sender, EventArgs e) //au clique sur le bouton de déconnexion
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

        private void btnAjoutCompte_Click(object sender, EventArgs e) //au clique sur le bouton d'ajout de compte utilisateur
        {
            if(txtBxNomCompte.Text == "" || txtBxPassCompte.Text == "" || txtBxPrenomCompte.Text == "" || txtBxPseudoCompte.Text == "" || cbBoxNiveauCompte.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
            else
            {
                initUtilisateur(); //appel la méthode initUtilisateur
                _utilisateurs.ajoutUtilisateur(unUtilisateur); //appel la méthode ajoutUtilisateur de utilisateurProc avec comme paramètre un objet de type utilisateur
                resetBox(); //appel la méthode resetBox
                newDataGrid(); //appel la méthode newDataGrid
            }
        }

        private void btnModifCompte_Click(object sender, EventArgs e) //au clique sur le bouton de modification de compte utilisateur
        {
            initUtilisateur(); //appel la méthode initUtilisateur
            _utilisateurs.modifUtilisateur(unUtilisateur); //appel la méthode modifUtilisateur de utilisateurProc avec comme paramètre un objet de type utilisateur
            resetBox(); //appel la méthode resetBox
            newDataGrid(); //appel la méthode newDataGrid
        }

        private void btnSupprCompte_Click(object sender, EventArgs e) //au clique sur le bouton de suppression de compte utilisateur
        {
            initUtilisateur(); //appel la méthode initUtilisateur
            _utilisateurs.supprUtilisateur(unUtilisateur); //appel la méthode supprUtilisateur de utilisateurProc avec comme paramètre un objet de type utilisateur
            resetBox(); //appel la méthode resetBox
            newDataGrid(); //appel la méthode newDataGrid
        }

        private void dataGridCompte_CellClick(object sender, DataGridViewCellEventArgs e) //au clique sur une cellule du dataGridView
        {
            txtBxPrenomCompte.Text = dataGridCompte.SelectedCells[0].Value.ToString(); //affecte au textBox du prénom, le prénom de la ligne selectionnée
            txtBxNomCompte.Text = dataGridCompte.SelectedCells[1].Value.ToString(); //affecte au textBox du du nom de famille, le nom de famille de la ligne selectionnée
            txtBxPseudoCompte.Text = dataGridCompte.SelectedCells[2].Value.ToString(); //affecte au textBox du pseudo, le pseudo de la ligne selectionnée
            cbBoxNiveauCompte.SelectedItem = dataGridCompte.SelectedCells[4].Value.ToString(); //affecte à la comboBox du niveau, le niveau de la ligne selectionnée
            utilId = int.Parse(dataGridCompte.SelectedCells[5].Value.ToString()); //affecte à la variable de l'ID, l'ID de la ligne selectionnée
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
        private void pctBxEmprunt_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBxEmprunt.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_hover") as Image; //change l'image
            addTextOnHover("Gestion des emprunts"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBxEmprunt_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBxEmprunt.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBxEmprunt_Click(object sender, EventArgs e)
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
            //initialise une nouvelle fenêtre de Gestion des editeurs
            void opennewform(object obj)
            {
                Application.Run(new frmGestionEditeur(_niveau));
            }
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        #endregion

        #region Couverture
        //méthodes liées au bouton Couverture
        private void pctBxLivreCouv_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBxLivreCouv.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couv_hover") as Image; //change l'image
            addTextOnHover("Gestion des couvertures de livre"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBxLivreCouv_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBxLivreCouv.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couverture") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBxLivreCouv_Click(object sender, EventArgs e)
        {
            //initialise une nouvelle fenêtre de Gestion des couvertures
            void opennewform(object obj)
            {
                Application.Run(new frmModifierCouv(_niveau));
            }
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
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