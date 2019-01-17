using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ClassLibrary;
using System.Threading;

namespace lesMotsTordus
{
    public partial class frmGestionEditeur : MetroForm
    {

        //déclaratio des propriétés
        private Editeurproc _editeur;
        private Editeur unEditeur;
        private Label _txtMouseHover;
        private Thread th;
        private String _niveau;

        public frmGestionEditeur(String wNiveau)
        {
            InitializeComponent();

            //permet de vider la mémoire RAM non utilisé
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _niveau = wNiveau; //récupére le niveau de l'utilisateur

            if (_niveau == "persResp")
            {
                pctBxEmprunteurs.Enabled = false;
                pctBxEmprunteurs.Cursor = Cursors.Default;
                pctBxEmprunteurs.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_off") as Image;

                btnSupprimer.Enabled = false;
                btnSupprimer.Cursor = Cursors.Default;
            }

            //appel de la méthode newDataGrid qui crée un dataGrid
            newDataGrid();

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

        //crée un nouveau dataGrid
        private void newDataGrid()
        {

            _editeur = new Editeurproc();
            dataGridViewEditeur.DataSource = _editeur.listEditeur(); //permet de transmettre les données des éditeurs dans le dataGrid


            dataGridViewEditeur.Columns[0].Visible = false;
            dataGridViewEditeur.Columns[1].HeaderText = "Nom";
            dataGridViewEditeur.Columns[2].HeaderText = "Année de Création";
            dataGridViewEditeur.Columns[3].HeaderText = "Adresse";
            dataGridViewEditeur.Columns[4].HeaderText = "CP";
            dataGridViewEditeur.Columns[5].HeaderText = "Ville";
            dataGridViewEditeur.Columns[6].HeaderText = "Tel";
            dataGridViewEditeur.Columns[7].HeaderText = "Fax";
            dataGridViewEditeur.Columns[8].HeaderText = "Mail";
            dataGridViewEditeur.Columns[9].HeaderText = "Nom du Contact";
            dataGridViewEditeur.Columns[10].HeaderText = "Prenom du Contact";
            dataGridViewEditeur.Columns[11].Visible = false;



            dataGridViewEditeur.Columns["wnom"].DisplayIndex = 1;
            dataGridViewEditeur.Columns["wcreation"].DisplayIndex = 2;
            dataGridViewEditeur.Columns["wadresse"].DisplayIndex = 3;
            dataGridViewEditeur.Columns["wcp"].DisplayIndex = 4;
            dataGridViewEditeur.Columns["wville"].DisplayIndex = 5;
            dataGridViewEditeur.Columns["wtel"].DisplayIndex = 6;
            dataGridViewEditeur.Columns["wfax"].DisplayIndex = 7;
            dataGridViewEditeur.Columns["wmail"].DisplayIndex = 8;
            dataGridViewEditeur.Columns["wnom_contact"].DisplayIndex = 9;
            dataGridViewEditeur.Columns["wprenom_contact"].DisplayIndex = 10;
        }

        //crée un nouveau dataGrid pour la recherche
        private void newDataGridRecherche()
        {

            _editeur = new Editeurproc();
            unEditeur = new Editeur(txtBxNom.Text);
            dataGridViewEditeur.DataSource = _editeur.rechercheEditeur(unEditeur);


            dataGridViewEditeur.Columns[0].Visible = false;
            dataGridViewEditeur.Columns[1].HeaderText = "Nom";
            dataGridViewEditeur.Columns[2].HeaderText = "Année de Création";
            dataGridViewEditeur.Columns[3].HeaderText = "Adresse";
            dataGridViewEditeur.Columns[4].HeaderText = "CP";
            dataGridViewEditeur.Columns[5].HeaderText = "Ville";
            dataGridViewEditeur.Columns[6].HeaderText = "Tel";
            dataGridViewEditeur.Columns[7].HeaderText = "Fax";
            dataGridViewEditeur.Columns[8].HeaderText = "Mail";
            dataGridViewEditeur.Columns[9].HeaderText = "Nom du Contact";
            dataGridViewEditeur.Columns[10].HeaderText = "Prenom du Contact";
            dataGridViewEditeur.Columns[11].Visible = false;



            dataGridViewEditeur.Columns["wnom"].DisplayIndex = 1;
            dataGridViewEditeur.Columns["wcreation"].DisplayIndex = 2;
            dataGridViewEditeur.Columns["wadresse"].DisplayIndex = 3;
            dataGridViewEditeur.Columns["wcp"].DisplayIndex = 4;
            dataGridViewEditeur.Columns["wville"].DisplayIndex = 5;
            dataGridViewEditeur.Columns["wtel"].DisplayIndex = 6;
            dataGridViewEditeur.Columns["wfax"].DisplayIndex = 7;
            dataGridViewEditeur.Columns["wmail"].DisplayIndex = 8;
            dataGridViewEditeur.Columns["wnom_contact"].DisplayIndex = 9;
            dataGridViewEditeur.Columns["wprenom_contact"].DisplayIndex = 10;
        }

        //cette méthode permet de remplir les textsBox grace au click sur un compte dans le dataGrid
        private void dataGridViewEditeur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBxNumero.Text = dataGridViewEditeur.SelectedCells[0].Value.ToString();
            txtBxNom.Text = dataGridViewEditeur.SelectedCells[1].Value.ToString();
            txtBxCreation.Text = dataGridViewEditeur.SelectedCells[2].Value.ToString();
            txtBxAdresse.Text = dataGridViewEditeur.SelectedCells[3].Value.ToString();
            txtBxCP.Text = dataGridViewEditeur.SelectedCells[4].Value.ToString();
            txtBxVille.Text = dataGridViewEditeur.SelectedCells[5].Value.ToString();
            txtBxTel.Text = dataGridViewEditeur.SelectedCells[6].Value.ToString();
            txtBxFax.Text = dataGridViewEditeur.SelectedCells[7].Value.ToString();
            txtBxMail.Text = dataGridViewEditeur.SelectedCells[8].Value.ToString();
            txtBxPrenom.Text = dataGridViewEditeur.SelectedCells[10].Value.ToString();
            txtBxNom_Contact.Text = dataGridViewEditeur.SelectedCells[9].Value.ToString();
            newDataGrid();

        }

        //permet d'ajouter un éditeur
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            _editeur = new Editeurproc();
            unEditeur = new Editeur(txtBxNom.Text, int.Parse(txtBxCreation.Text), txtBxAdresse.Text, txtBxCP.Text, txtBxVille.Text, txtBxTel.Text, txtBxFax.Text, txtBxMail.Text, txtBxNom_Contact.Text, txtBxPrenom.Text);
            _editeur.AjouterEditeur(unEditeur);
            txtBxNom.Text = "";
            txtBxAdresse.Text = "";
            txtBxCP.Text = "";
            txtBxCreation.Text = "";
            txtBxFax.Text = "";
            txtBxMail.Text = "";
            txtBxTel.Text = "";
            txtBxVille.Text = "";
            txtBxNom_Contact.Text = "";
            txtBxPrenom.Text = "";
            newDataGrid();

        }

        //permet de modifier un éditeur
        private void btnModifier_Click(object sender, EventArgs e)
        {
            _editeur = new Editeurproc();
            unEditeur = new Editeur(int.Parse(txtBxNumero.Text), txtBxNom.Text, int.Parse(txtBxCreation.Text), txtBxAdresse.Text, txtBxCP.Text, txtBxVille.Text, txtBxTel.Text, txtBxFax.Text, txtBxMail.Text, txtBxNom_Contact.Text, txtBxPrenom.Text);
            _editeur.ModifierEditeur(unEditeur);
            txtBxNom.Text = "";
            txtBxAdresse.Text = "";
            txtBxCP.Text = "";
            txtBxCreation.Text = "";
            txtBxFax.Text = "";
            txtBxMail.Text = "";
            txtBxTel.Text = "";
            txtBxVille.Text = "";
            txtBxNumero.Text = "";
            txtBxNom_Contact.Text = "";
            txtBxPrenom.Text = "";
            newDataGrid();
        }

        //ouvre le panel de motif
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            pnlMotif.Location = new Point(400, 300);
            pnlMotif.Visible = true;
        }

        //Permet de rechercher un nom en temps réel avec la saisie du nom
        private void txtBxNom_TextChanged(object sender, EventArgs e)
        {
            newDataGridRecherche();
        }

        //ne rend plus visible le panel de motif
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            pnlMotif.Visible = false;
        }

        //valide la suppression d'un editeur
        private void btnValider_Click(object sender, EventArgs e)
        {
            _editeur = new Editeurproc();
            unEditeur = new Editeur(int.Parse(txtBxNumero.Text), txtBxMotif.Text);

            _editeur.SupprimerEditeur(unEditeur);
            txtBxNumero.Text = "";
            txtBxMotif.Text = "";
            txtBxNom.Text = "";
            txtBxAdresse.Text = "";
            txtBxCP.Text = "";
            txtBxCreation.Text = "";
            txtBxFax.Text = "";
            txtBxMail.Text = "";
            txtBxTel.Text = "";
            txtBxVille.Text = "";
            txtBxNom_Contact.Text = "";
            txtBxPrenom.Text = "";
            newDataGrid();
            pnlMotif.Visible = false;
        }

        #region Livre
        //méthodes liées au bouton livre
        private void pctBxLivres_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBxLivres.BackgroundImage = Properties.Resources.ResourceManager.GetObject("livre_hover") as Image; //change l'image
            addTextOnHover("Gestion des livres"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBxLivres_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBxLivres.BackgroundImage = Properties.Resources.ResourceManager.GetObject("livre") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBxLivres_Click(object sender, EventArgs e) //au clique sur l'image
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
        private void pctBxEmprunteurs_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBxEmprunteurs.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_hover") as Image; //change l'image
            addTextOnHover("Gestion des emprunts"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBxEmprunteurs_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBxEmprunteurs.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBxEmprunteurs_Click(object sender, EventArgs e)
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

        #region Couverture
        //méthodes liées au bouton Couverture
        private void pctBxCouvertures_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBxCouvertures.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couv_hover") as Image; //change l'image
            addTextOnHover("Gestion des couvertures de livre"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBxCouvertures_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBxCouvertures.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couverture") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBxCouvertures_Click(object sender, EventArgs e)
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
        private void pctBxAuteurs_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBxAuteurs.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur_hover") as Image; //change l'image
            addTextOnHover("Gestion des auteurs"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBxAuteurs_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBxAuteurs.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBxAuteurs_Click(object sender, EventArgs e)
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
