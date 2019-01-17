using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ClassLibrary;
using System.Threading;

namespace lesMotsTordus
{
    public partial class frmGestionAuteur : MetroForm
    {

        //propriété.s
        private auteur unAuteur;
        private AuteurProc _auteur;
        private Label _txtMouseHover;
        private Boolean onOff;
        private int autId;
        private string _niveau;
        private Thread th;

        public frmGestionAuteur(string wNiveau)
        {
            InitializeComponent();

            //permet de vider la mémoire RAM non utilisé
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _niveau = wNiveau; //récupére le niveau de l'utilisateur

            if (_niveau == "persResp")
            {
                pctBoxEmprunteur.Enabled = false;
                pctBoxEmprunteur.Cursor = Cursors.Default;
                pctBoxEmprunteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_off") as Image;
            }

            newDataGrid();
            pnlGestionAuteur.Visible = true;
            //pnlRechercheAuteur.Visible = false;

            //initialise le label au survol des images des autres fenêtres
            _txtMouseHover = new Label(); //initialise un nouveau label
            _txtMouseHover.BackColor = Color.Orange; //change le fond du label en orange
            _txtMouseHover.AutoSize = true; //la taille du label s'adapte au text
            _txtMouseHover.Font = new Font("Bahnschrift Condensed", 11, FontStyle.Bold); //change la police du label
        }

        private void addTextOnHover(string text) //au survol des images à gauche
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

        private void btnGestionAuteur_Click(object sender, EventArgs e)
        {
            pnlGestionAuteur.Location = new Point(178, 100);
            pnlGestionAuteur.Visible = true;
            //pnlRechercheAuteur.Visible = false;
            pnlGestionAuteur.Show();

        }

        //private void btnRechercheAUteur_Click(object sender, EventArgs e)
        //{
        //    pnlRechercheAuteur.Location = new Point(178, 100);
        //    pnlRechercheAuteur.Visible = true;
        //    pnlGestionAuteur.Visible = false;
        //    pnlRechercheAuteur.Show();
        //}

        private void btnAjoutAuteur_Click(object sender, EventArgs e)
        {
            if (datePickerDeces.Enabled == false)
            {
                _auteur = new AuteurProc();
                unAuteur = new auteur(0, txtBoxNom.Text, txtBoxPrenom.Text, txtBoxPseudo.Text, datePickerNaiss.Value, txtBoxPays.Text, txtBoxBio.Text);
                _auteur.insertionAuteur(unAuteur);
            }
            else
            {
                _auteur = new AuteurProc();
                unAuteur = new auteur(0, txtBoxNom.Text, txtBoxPrenom.Text, txtBoxPseudo.Text, datePickerNaiss.Value, datePickerDeces.Value, txtBoxPays.Text, txtBoxBio.Text);
                _auteur.insertionAuteur(unAuteur);
            }

            //Réinitialise les champs après la validation.
            txtBoxNom.Text = "";
            txtBoxPrenom.Text = "";
            txtBoxBio.Text = "";
            txtBoxPays.Text = "";
            txtBoxPseudo.Text = "";

            newDataGrid();
        }

        private void btnModifierAuteur_Click(object sender, EventArgs e)
        {
            if (datePickerDeces.Enabled == false)
            {
                _auteur = new AuteurProc();
                unAuteur = new auteur(autId, txtBoxNom.Text, txtBoxPrenom.Text, txtBoxPseudo.Text, datePickerNaiss.Value, txtBoxPays.Text, txtBoxBio.Text);
                _auteur.modificationAuteur(unAuteur);
            }
            else
            {
                _auteur = new AuteurProc();
                unAuteur = new auteur(autId, txtBoxNom.Text, txtBoxPrenom.Text, txtBoxPseudo.Text, datePickerNaiss.Value, datePickerDeces.Value, txtBoxPays.Text, txtBoxBio.Text);
                _auteur.modificationAuteur(unAuteur);
            }

            //Réinitialise les champs après la validation.
            txtBoxNom.Text = "";
            txtBoxPrenom.Text = "";
            txtBoxBio.Text = "";
            txtBoxPays.Text = "";
            txtBoxPseudo.Text = "";

            newDataGrid();
        }

        private void checkboxNaiss_OnChange(object sender, EventArgs e)
        {
            if (onOff == true)
            {
                onOff = false;
                datePickerNaiss.Enabled = true;
                datePickerNaiss.Visible = true;
                checkboxNaiss.Checked = true;
            }
            else
            {
                onOff = true;
                datePickerNaiss.Enabled = false;
                datePickerNaiss.Visible = false;
                checkboxNaiss.Checked = false;
            }
        }

        //Cette méthode permet de cocher si l'auteur est décédé ou non, il affichera le controle de décès en fonction.
        private void checkboxDeces_OnChange(object sender, EventArgs e)
        {
            if (onOff == true)
            {
                onOff = false;
                datePickerDeces.Enabled = true;
                datePickerDeces.Visible = true;
                checkboxDeces.Checked = true;
            }
            else
            {
                onOff = true;
                datePickerDeces.Enabled = false;
                datePickerDeces.Visible = false;
                checkboxDeces.Checked = false;
            }
        }

        private void newDataGrid()
        {
            _auteur = new AuteurProc();
            dataGridViewAuteur.DataSource = _auteur.listAuteur();

            dataGridViewAuteur.Columns[3].HeaderText = "IdAuteur";
            dataGridViewAuteur.Columns[4].HeaderText = "NomAuteur";
            dataGridViewAuteur.Columns[5].HeaderText = "PrenomAuteur";
            dataGridViewAuteur.Columns[6].HeaderText = "PseudoAuteur";
            dataGridViewAuteur.Columns[7].HeaderText = "DateNaissAuteur";
            dataGridViewAuteur.Columns[8].HeaderText = "DateDecesAuteur";
            dataGridViewAuteur.Columns[9].HeaderText = "PaysAuteurs";
            dataGridViewAuteur.Columns[10].Visible = false;
            dataGridViewAuteur.Columns[1].Visible = false;
            dataGridViewAuteur.Columns[2].Visible = false;
            dataGridViewAuteur.Columns[0].Visible = false;

            /*dataGridViewAuteur.Columns["Id"].DisplayIndex = 0;
            dataGridViewAuteur.Columns["nom"].DisplayIndex = 1;
            dataGridViewAuteur.Columns["prenom"].DisplayIndex = 2;
            dataGridViewAuteur.Columns["pseudo"].DisplayIndex = 3;
            dataGridViewAuteur.Columns["naissance"].DisplayIndex = 4;
            dataGridViewAuteur.Columns["deces"].DisplayIndex = 5;
            dataGridViewAuteur.Columns["pays"].DisplayIndex = 6;
            dataGridViewAuteur.Columns["bio"].DisplayIndex = 7;*/
        }

        //méthode qui permet de remplir les champs grâce au clique sur un datagridView
        private void dataGridViewAuteur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBoxNom.Text = dataGridViewAuteur.SelectedCells[4].Value.ToString();
            txtBoxPrenom.Text = dataGridViewAuteur.SelectedCells[5].Value.ToString();
            txtBoxPseudo.Text = dataGridViewAuteur.SelectedCells[6].Value.ToString();

            if(dataGridViewAuteur.SelectedCells[7].Value.ToString() == "01/01/0001 00:00:00")
            {
                datePickerNaiss.Enabled = false;
                datePickerNaiss.Visible = false;
                onOff = false;
                checkboxNaiss.Checked = false;
                checkboxNaiss.Visible = true;
                checkboxNaiss.Enabled = true;
            }
            else
            {
                datePickerNaiss.Enabled = true;
                datePickerNaiss.Visible = true;
                onOff = true;
                checkboxNaiss.Checked = true;
                checkboxNaiss.Visible = true;
                checkboxNaiss.Enabled = false;
                datePickerNaiss.Value = DateTime.Parse(dataGridViewAuteur.SelectedCells[7].Value.ToString());
            }

            //Vérifie si la date de décès est valide ou non, si elle ne l'est pas on affiche pas le controle, si elle est valide on l'affiche.
            if(dataGridViewAuteur.SelectedCells[8].Value.ToString() == "01/01/0001 00:00:00")
            {
                datePickerDeces.Enabled = false;
                datePickerDeces.Visible = false;
                onOff = false;
                checkboxDeces.Checked = false;
                checkboxDeces.Visible = true;
                checkboxDeces.Enabled = true;
            }
            else
            {
                datePickerDeces.Enabled = true;
                datePickerDeces.Visible = true;
                onOff = true;
                checkboxDeces.Checked = true;
                checkboxDeces.Visible = true;
                checkboxDeces.Enabled = false;
                datePickerDeces.Value = DateTime.Parse(dataGridViewAuteur.SelectedCells[8].Value.ToString());
            }

            txtBoxPays.Text = dataGridViewAuteur.SelectedCells[9].Value.ToString();
            txtBoxBio.Text = dataGridViewAuteur.SelectedCells[10].Value.ToString();
            autId = int.Parse(dataGridViewAuteur.SelectedCells[3].Value.ToString());
        }

        //private void SearchDataGrid()
        //{
        //    _auteur = new AuteurProc();
        //    dataGridViewAuteur.DataSource = _auteur.uneListeAuteur(txtBoxNom.Text, txtBoxPseudo.Text);

        //    dataGridViewAuteur.Columns[3].HeaderText = "IdAuteur";
        //    dataGridViewAuteur.Columns[4].HeaderText = "NomAuteur";
        //    dataGridViewAuteur.Columns[5].HeaderText = "PrenomAuteur";
        //    dataGridViewAuteur.Columns[6].HeaderText = "PseudoAuteur";
        //    dataGridViewAuteur.Columns[7].HeaderText = "DateNaissAuteur";
        //    dataGridViewAuteur.Columns[8].HeaderText = "DateDecesAuteur";
        //    dataGridViewAuteur.Columns[9].HeaderText = "PaysAuteurs";
        //    dataGridViewAuteur.Columns[10].HeaderText = "BioAuteur";
        //    dataGridViewAuteur.Columns[1].Visible = false;
        //    dataGridViewAuteur.Columns[2].Visible = false;
        //    dataGridViewAuteur.Columns[0].Visible = false;

        //    dataGridViewAuteur.Columns["IdAuteur"].DisplayIndex = 1;
        //    dataGridViewAuteur.Columns["NomAuteur"].DisplayIndex = 2;
        //    dataGridViewAuteur.Columns["PrenomAuteur"].DisplayIndex = 3;
        //    dataGridViewAuteur.Columns["PseudoAuteur"].DisplayIndex = 4;
        //    dataGridViewAuteur.Columns["DateNaissAuteur"].DisplayIndex = 5;
        //    dataGridViewAuteur.Columns["DateDecesAuteur"].DisplayIndex = 6;
        //    dataGridViewAuteur.Columns["PaysAuteurs"].DisplayIndex = 7;
        //    dataGridViewAuteur.Columns["BioAuteur"].DisplayIndex = 8;
        //}

        //private void txtBoxNom_TextChanged(object sender, EventArgs e)
        //{
        //    SearchDataGrid();
        //}
        //private void txtBoxPseudo_TextChanged(object sender, EventArgs e)
        //{
        //    SearchDataGrid();
        //}

        //Cette méthode permet d'afficher le formulaire de gestion des livres

        #region Livre
        //méthodes liées au bouton livre
        private void pctBoxLivre_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBoxLivre.BackgroundImage = Properties.Resources.ResourceManager.GetObject("livre_hover") as Image; //change l'image
            addTextOnHover("Gestion des livres"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBoxLivre_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBoxLivre.BackgroundImage = Properties.Resources.ResourceManager.GetObject("livre") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBoxLivre_Click(object sender, EventArgs e) //au clique sur l'image
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
        private void pctBoxEmprunteur_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBoxEmprunteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_hover") as Image; //change l'image
            addTextOnHover("Gestion des emprunts"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBoxEmprunteur_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBoxEmprunteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBoxEmprunteur_Click(object sender, EventArgs e)
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
        private void pctBoxEditeur_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBoxEditeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur_hover") as Image; //change l'image
            addTextOnHover("Gestion des éditeurs"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBoxEditeur_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBoxEditeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBoxEditeur_Click(object sender, EventArgs e)
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
        private void pctBoxCouverture_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pctBoxCouverture.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couv_hover") as Image; //change l'image
            addTextOnHover("Gestion des couvertures de livre"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pctBoxCouverture_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pctBoxCouverture.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couverture") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pctBoxCouverture_Click(object sender, EventArgs e)
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
    }
}
