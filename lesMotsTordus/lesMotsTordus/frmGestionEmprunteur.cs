using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ClassLibrary;
using System.Threading;

namespace lesMotsTordus
{
    public partial class frmGestionEmprunteur : MetroForm
    {
        private Label _txtMouseHover;
        private EmprunteurProc _emprunteurs;
        private Emprunteur unEmprunteur;
        private int num;
        private Thread th;
        private string _niveau;

        public frmGestionEmprunteur(string wNiveau)
        {
            InitializeComponent();

            //permet de vider la mémoire RAM non utilisé
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _niveau = wNiveau; //récupére le niveau de l'utilisateur

            if (_niveau == "respSecteur")
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

                btnSupprimer.Enabled = false;
                btnSupprimer.Cursor = Cursors.Default;
            }

            // Appel la methode pour initialiser un nouveau dataGrid
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

        // Vide le contenu des textbox
        private void resetBox()
        {
            txtBxNumEmp.Text = "";
            txtBxNomEmp.Text = "";
            txtBxPrenomEmp.Text = "";
            txtBxRueEmp.Text = "";
            txtBxCPEmp.Text = "";
            txtBxVilleEmp.Text = "";
            txtBxMailEmp.Text = "";
            txtBxResp.Text = "";
            txtBxMembre.Text = "";
        }

        // Instanciation et constructeur de l'objet unEmprunteur
        private void initEmprunteur()
        {
            _emprunteurs = new EmprunteurProc();
            unEmprunteur = new Emprunteur(num, txtBxNomEmp.Text.ToUpper(), txtBxPrenomEmp.Text, txtBxRueEmp.Text, txtBxCPEmp.Text, txtBxVilleEmp.Text, DatePickerEmp.Value, txtBxMailEmp.Text, DatePikerAdhesion.Value, DatePikerFinAdhesion.Value);
        }

        // Ajout d'un emprunteur
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            initEmprunteur();
            _emprunteurs.AjouterEmprunteur(unEmprunteur);
            resetBox();
            newDataGrid();
        }

        // Modification d'un emprunteur
        private void btnModifier_Click(object sender, EventArgs e)
        {
            _emprunteurs = new EmprunteurProc();
            unEmprunteur = new Emprunteur(int.Parse(txtBxNumEmp.Text), txtBxNomEmp.Text.ToUpper(), txtBxPrenomEmp.Text, txtBxRueEmp.Text, txtBxCPEmp.Text, txtBxVilleEmp.Text, DatePickerEmp.Value, txtBxMailEmp.Text, DatePikerAdhesion.Value, DatePikerFinAdhesion.Value);
            _emprunteurs.ModifierEmprunteur(unEmprunteur);
            newDataGrid();
            resetBox();
        }

        // Envoi du motif de licenciement dans la base de données + supression de l'emprunteur
        private void btnValider_Click(object sender, EventArgs e)
        {
            _emprunteurs = new EmprunteurProc();
            unEmprunteur = new Emprunteur(int.Parse(txtBxNumEmp.Text), txtBxMotif.Text);
            _emprunteurs.SupprimerEmprunteur(unEmprunteur);
            newDataGrid();
            resetBox();
            pnlMotif.Visible = false;
        }

        // Affiche le panel du motif et recharge le DataGrid
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            pnlMotif.Visible = Enabled;
            newDataGrid();
        }

        private void newDataGrid()
        {
            _emprunteurs = new EmprunteurProc();
            DgvEmp.DataSource = _emprunteurs.listEmprunteur();

            DgvEmp.Columns[0].HeaderText = "N°";
            DgvEmp.Columns[1].HeaderText = "Nom";
            DgvEmp.Columns[2].HeaderText = "Prenom";
            DgvEmp.Columns[3].HeaderText = "Rue";
            DgvEmp.Columns[4].HeaderText = "CP";
            DgvEmp.Columns[5].HeaderText = "Ville";
            DgvEmp.Columns[6].HeaderText = "Date de naissance";
            DgvEmp.Columns[7].HeaderText = "Mail";
            DgvEmp.Columns[8].HeaderText = "Date inscription";
            DgvEmp.Columns[9].HeaderText = "Date renouvellement";
            DgvEmp.Columns[10].Visible = false;

            DgvEmp.Columns[0].Width = 40;
            DgvEmp.Columns[4].Width = 40;
            DgvEmp.Columns[6].Width = 80;
            DgvEmp.Columns[8].Width = 80;
            DgvEmp.Columns[9].Width = 80;
            DgvEmp.Columns[7].Width = 140;
            DgvEmp.Columns[3].Width = 140;
        }

        // Cette méthode permet de remplir les textBox grâce au clic sur une cellule dans le dataGrid
        private void DgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBxNumEmp.Text = DgvEmp.SelectedCells[0].Value.ToString();
            txtBxNomEmp.Text = DgvEmp.SelectedCells[1].Value.ToString();
            txtBxPrenomEmp.Text = DgvEmp.SelectedCells[2].Value.ToString();
            txtBxRueEmp.Text = DgvEmp.SelectedCells[3].Value.ToString();
            txtBxCPEmp.Text = DgvEmp.SelectedCells[4].Value.ToString();
            txtBxVilleEmp.Text = DgvEmp.SelectedCells[5].Value.ToString();
            DatePickerEmp.Value = DateTime.Parse(DgvEmp.SelectedCells[6].Value.ToString());
            txtBxMailEmp.Text = DgvEmp.SelectedCells[7].Value.ToString();
            DatePikerAdhesion.Value = DateTime.Parse(DgvEmp.SelectedCells[8].Value.ToString());
            DatePikerFinAdhesion.Value = DateTime.Parse(DgvEmp.SelectedCells[9].Value.ToString());
            newDataGrid();
        }

        private void SearchDataGrid()
        {
            _emprunteurs = new EmprunteurProc();
            DgvEmp.DataSource = _emprunteurs.unelistEmprunteur(txtBxNumEmp.Text, txtBxNomEmp.Text.ToUpper());

            // Titres des colonnes
            DgvEmp.Columns[0].HeaderText = "N°";
            DgvEmp.Columns[1].HeaderText = "Nom";
            DgvEmp.Columns[2].HeaderText = "Prenom";
            DgvEmp.Columns[3].HeaderText = "Rue";
            DgvEmp.Columns[4].HeaderText = "CP";
            DgvEmp.Columns[5].HeaderText = "Ville";
            DgvEmp.Columns[6].HeaderText = "Date de naissance";
            DgvEmp.Columns[7].HeaderText = "Mail";
            DgvEmp.Columns[8].HeaderText = "Date inscription";
            DgvEmp.Columns[9].HeaderText = "Date renouvellement";
            DgvEmp.Columns[10].Visible = false;

            // Largeur des colonnes
            DgvEmp.Columns[0].Width = 40;
            DgvEmp.Columns[4].Width = 40;
            DgvEmp.Columns[6].Width = 80;
            DgvEmp.Columns[8].Width = 80;
            DgvEmp.Columns[9].Width = 80;
            DgvEmp.Columns[7].Width = 140;
            DgvEmp.Columns[3].Width = 140;
        }

        private void txtBxNomEmp_TextChanged_1(object sender, EventArgs e)
        {
            // Le DataGrid se met à jour en fonction de la saisie du texte (pour le nom)
            SearchDataGrid();
        }

        // Le DataGrid se met à jour en fonction de la saisie du texte (pour le numéro)
        private void txtBxNumEmp_TextChanged(object sender, EventArgs e)
        {
            SearchDataGrid();
        }

        // Le DataGrid se met à jour en fonction de la saisie du texte (pour le nom)


        // Cache le panel du motif lors du click sur "annuler"
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            pnlMotif.Visible = false;
        }

        // Vide les textbox lors de l'appui sur la touche Retour en Arrière
        private void txtBxNomEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                txtBxNumEmp.Text = "";
                txtBxPrenomEmp.Text = "";
                txtBxRueEmp.Text = "";
                txtBxCPEmp.Text = "";
                txtBxVilleEmp.Text = "";
                txtBxMailEmp.Text = "";
                txtBxResp.Text = "";
                DatePickerEmp.Value = DateTime.Today;
                DatePikerAdhesion.Value = DateTime.Today;
                DatePikerFinAdhesion.Value = DateTime.Today;
            }
        }

        // Ajout d'un emprunteur
        private void btnAjouterFamille(object sender, EventArgs e)
        {
            _emprunteurs = new EmprunteurProc();
            unEmprunteur = new Emprunteur(int.Parse(txtBxMembre.Text), int.Parse(txtBxResp.Text));
            _emprunteurs.AjouterFamilleEmprunteur(unEmprunteur);
            resetBox();
            newDataGrid();
        }

        private void btnFamille_Click(object sender, EventArgs e)
        {
            if(txtBxResp.Text != "" && txtBxMembre.Text != "")
            {
                _emprunteurs = new EmprunteurProc();
                unEmprunteur = new Emprunteur(int.Parse(txtBxResp.Text), int.Parse(txtBxMembre.Text));
                _emprunteurs.AjouterFamilleEmprunteur(unEmprunteur);
                resetBox();
                newDataGrid();
            }
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