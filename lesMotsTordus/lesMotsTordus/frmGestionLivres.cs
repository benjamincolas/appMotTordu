using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ClassLibrary;

namespace lesMotsTordus
{
    public partial class frmGestionLivres : MetroFramework.Forms.MetroForm
    {
        #region propriétés
        private LivreProc unLivreProc;
        private Livre unLivre;
        private LivreSuppr leLivre;
        private Thread th;
        private LivreSupprProccs LivreSupprProc;
        private ExemplaireProc _exemplaire;
        private SerieProc serieProc;
        private auteur auteurDessin;
        private auteur auteurScenario;
        private Exemplaire unExemplaire;
        private List<int> NumEmprunteur;
        private int numID;
        private string _niveau;
        #endregion


        public frmGestionLivres(string wNiveau)
        {
            //unLivre = new LivreProc();
            InitializeComponent();

            //permet de vider la mémoire RAM non utilisé
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _niveau = wNiveau; //récupére le niveau de l'utilisateur

            if (_niveau == "accueil")
            {
                pct_auteur.Enabled = false;
                pct_auteur.Cursor = Cursors.Default;
                pct_auteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur_off") as Image;

                pct_editeur.Enabled = false;
                pct_editeur.Cursor = Cursors.Default;
                pct_editeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur_off") as Image;

                pct_couverture.Enabled = false;
                pct_couverture.Cursor = Cursors.Default;
                pct_couverture.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couv_off") as Image;

                pct_emprunteur.Enabled = false;
                pct_emprunteur.Cursor = Cursors.Default;
                pct_emprunteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_off") as Image;

                btnAjoutExemplaire.Enabled = false;
                btnAjoutExemplaire.Cursor = Cursors.Default;
                btnModifExemplaire.Enabled = false;
                btnModifExemplaire.Cursor = Cursors.Default;
                btnSupprExemplaire.Enabled = false;
                btnSupprExemplaire.Cursor = Cursors.Default;
                btn_Emprunter.Enabled = false;
                btn_Emprunter.Cursor = Cursors.Default;
                btn_RendreExemplaire.Enabled = false;
                btn_RendreExemplaire.Cursor = Cursors.Default;
                btn_GestionLivre.Enabled = false;
                btn_GestionLivre.Cursor = Cursors.Default;
            }
            else if (_niveau == "respSecteur")
            {
                pct_auteur.Enabled = false;
                pct_auteur.Cursor = Cursors.Default;
                pct_auteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur_off") as Image;

                pct_editeur.Enabled = false;
                pct_editeur.Cursor = Cursors.Default;
                pct_editeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur_off") as Image;

                pct_couverture.Enabled = false;
                pct_couverture.Cursor = Cursors.Default;
                pct_couverture.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couv_off") as Image;

                btnAjoutExemplaire.Enabled = false;
                btnAjoutExemplaire.Cursor = Cursors.Default;
                btnSupprExemplaire.Enabled = false;
                btnSupprExemplaire.Cursor = Cursors.Default;
                btn_RendreExemplaire.Enabled = false;
                btn_RendreExemplaire.Cursor = Cursors.Default;
                btn_GestionLivre.Enabled = false;
                btn_GestionLivre.Cursor = Cursors.Default;
            }
            else if (_niveau == "persResp")
            {
                pct_emprunteur.Enabled = false;
                pct_emprunteur.Cursor = Cursors.Default;
                pct_emprunteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_off") as Image;

                btn_GestionExemp.Enabled = false;
                btn_GestionExemp.Cursor = Cursors.Default;
                btn_supprimer.Enabled = false;
                btn_supprimer.Cursor = Cursors.Default;
            }

            newDataGrid();

            //initialise le label au survol des images des autres fenêtres
            _txtMouseHover = new Label(); //initialise un nouveau label
            _txtMouseHover.BackColor = Color.Orange; //change le fond du label en orange
            _txtMouseHover.AutoSize = true; //la taille du label s'adapte au text
            _txtMouseHover.Font = new Font("Bahnschrift Condensed", 11, FontStyle.Bold); //change la police du label

            NumEmprunteur = new List<int>();

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

        #region Emprunt
        //méthodes liées au bouton Emprunt
        private void pct_emprunteur_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pct_editeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur_hover") as Image; //change l'image
            addTextOnHover("Gestion des emprunts"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pct_emprunteur_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pct_editeur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("emprunteur") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pct_emprunteur_Click(object sender, EventArgs e)
        {
            void opennewform(object obj)
            {
                Application.Run(new frmGestionEmprunteur(_niveau));
            }
            this.Dispose();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        #endregion

        #region Editeur
        //méthodes liées au bouton Editeur
        private void pct_editeur_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pct_couverture.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur_hover") as Image; //change l'image
            addTextOnHover("Gestion des éditeurs de livre"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        
    

    private void pct_editeur_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
    {
        pct_couverture.BackgroundImage = Properties.Resources.ResourceManager.GetObject("editeur") as Image; //change l'image
        this.Controls.Remove(_txtMouseHover); //supprime le text du survol
    }
    

        private void pct_editeur_Click(object sender, EventArgs e)
        {
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
        private void pct_couverture_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pct_couverture.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couv_hover") as Image; //change l'image
            addTextOnHover("Gestion des couvertures de livre"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pct_couverture_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pct_couverture.BackgroundImage = Properties.Resources.ResourceManager.GetObject("couverture") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pct_couverture_Click(object sender, EventArgs e)
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
        private void pct_auteur_MouseEnter(object sender, EventArgs e) //au survol de l'image
        {
            pct_auteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur_hover") as Image; //change l'image
            addTextOnHover("Gestion des auteurs"); //appel la méthode addTextOnHover avec en paramètre un text indicatif
        }

        private void pct_auteur_MouseLeave(object sender, EventArgs e) //quitte le survol de l'image
        {
            pct_auteur.BackgroundImage = Properties.Resources.ResourceManager.GetObject("auteur") as Image; //change l'image
            this.Controls.Remove(_txtMouseHover); //supprime le text du survol
        }

        private void pct_auteur_Click(object sender, EventArgs e)
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

        //Appui sur le bouton Gestion des Livres
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
    
        {
            panel_gestionLivre.Location = new Point(178, 34);
           
            panel_gestionLivre.Visible = true;
            panel_recherche.Visible = false;
            _exemplaire = new ExemplaireProc();

        //initialisation des listes
            foreach (auteur unAuteur in _exemplaire.ListNomAuteur())
            {
                cbbxScenario.Items.Add(unAuteur.nom);
                cbbxDessin.Items.Add(unAuteur.nom);
            }
            foreach (Editeur unEditeur in _exemplaire.ListNomEditeur())
            {
                cbbx_editeur.Items.Add(unEditeur.wnom);
            }
            foreach (serie uneSerie in _exemplaire.ListNomSerie())
            {
                cbbx_serie.Items.Add(uneSerie.GetNom);
            }
        }
        // Évènement clic sur le bouton recherche 
        private void btn_RechercherLivre_Click(object sender, EventArgs e)
        {
            panel_recherche.Location = new Point(178, 34);
            panel_gestionLivre.Visible = false;
            panel_recherche.Visible = true;
            newDataGridRecherche();
        }
        //Appui sur le bouton ajouter livre
        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            string resu; AuteurProc auteurProc; AuteurProc auteurProc2;
            LivreProc livreProc;
            LivreProc unLivreProc2;
            resu = "Couleur";
            if (txtbox_titre.Text != "" && txtbox_codeISBn.Text != "" && txtbox_tome.Text != "" && datepick_annee.Value.ToString("MM/yyyy") != "" && txtbox_nbPg.Text != "" &&  txtbox_format.Text != "" && cbbx_serie.Text != "" && cbbx_editeur.Text != "")// si tout les champs sont remplis
            {
                if (rbtnNoir.Checked == true)//radio bouton pour choisir la colorimétrie
                {
                    resu = "Noir et Blanc";
                }

                livreProc = new LivreProc(); auteurProc = new AuteurProc(); auteurProc2 = new AuteurProc();
                unLivreProc2 = new LivreProc(); unLivreProc2 = new LivreProc(); unLivreProc2 = new LivreProc();
                unLivre = new Livre(txtbox_titre.Text, txtbox_codeISBn.Text, txtbox_tome.Text, datepick_annee.Value.ToString("MM/yyyy"), int.Parse(txtbox_nbPg.Text), "", resu, txtbox_commentaire.Text, txtbox_format.Text, unLivreProc.GetNumSerier(cbbx_serie.Text), unLivreProc.GetNumEditeur(cbbx_editeur.Text));//instancie un nouveeau livre
                unLivreProc.AjouterLivre(unLivre);// ajoute le livre à la base
                auteurDessin = new auteur(livreProc.GetId(txtbox_codeISBn.Text), auteurProc.GetNumAuteur(cbbxDessin.Text), 1); //instancie l'auteur du dessin
                auteurScenario = new auteur(unLivreProc2.GetId(txtbox_codeISBn.Text), auteurProc.GetNumAuteur(cbbxScenario.Text), 0);//instancie k'auteur du scénario
                //ajoute les auteurs
                auteurProc2.AjouterAuteurLivre(auteurDessin);

                auteurProc.AjouterAuteurLivre(auteurScenario);
                //vide les champs
                txtbox_codeISBn.Text = "";
                txtbox_titre.Text = "";
                txtbox_nbPg.Text = "";

                cbbx_editeur.Text = "";
                cbbx_serie.Text = "";
                txtbox_format.Text = "";
                txtbox_commentaire.Text = "";
                txtbox_tome.Text = "";
                newDataGrid(); //actualise le datagrid
            }
            else { pnl_MsgErreurGestionLivre.Visible = true; }// sinon affiche le message d'erreur

        }
        
        
        private void btn_nonRendus_Click(object sender, EventArgs e)
        {
            DataGridNonRendus();//aficche dans le datagridview tout les livres non rendus malgrès la date limite dépassée 
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (txtbox_titre.Text != "" && txtbox_codeISBn.Text != "" && txtbox_tome.Text != "" && datepick_annee.Value.ToString("MM/yyyy") != "" && txtbox_nbPg.Text != ""  && txtbox_format.Text != "" && cbbx_serie.Text != "" && cbbx_editeur.Text != "")//vérifie si tout les champs sont remplis
            {
                string resu;
                resu = "Couleur";
                if (rbtnNoir.Checked == true)
                {
                    resu = "Noir et Blanc";
                }


                unLivreProc = new LivreProc();
                unLivre = new Livre(txtbox_titre.Text, txtbox_codeISBn.Text, txtbox_tome.Text, datepick_annee.Value.ToString("MM/yyyy"), int.Parse(txtbox_nbPg.Text), "", resu, txtbox_commentaire.Text, txtbox_format.Text, unLivreProc.GetNumSerier(cbbx_serie.Text), unLivreProc.GetNumEditeur(cbbx_editeur.Text), int.Parse(dgv_livre.SelectedCells[0].Value.ToString()));//instancie un nouvelle objet
                unLivreProc.ModifierLivre(unLivre);


                //vide els champs
                txtbox_codeISBn.Text = "";
                txtbox_titre.Text = "";
                txtbox_nbPg.Text = "";
                txtbox_nbPg.Text = "";

                cbbx_editeur.Text = "";
                cbbx_serie.Text = "";
                txtbox_format.Text = "";
                txtbox_commentaire.Text = "";
                txtbox_tome.Text = "";
                newDataGrid(); //Affiche un nouveau datagrid pour actualiser les champs
            }
            else { pnl_MsgErreurGestionLivre.Visible = true; }//sinon affiche un message d'erreur
        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            if (txtbox_titre.Text != "" && txtbox_codeISBn.Text != "" && txtbox_tome.Text != ""  && txtbox_nbPg.Text != "" &&  txtbox_format.Text != "" && cbbx_serie.Text != "" && cbbx_editeur.Text != "")//vérifie que tout les champs sont remplis
            {
                pnlMotif.Visible = true; //affiche le pannel pour saisir un motif
            }
            else { pnl_MsgErreurGestionLivre.Visible = true; }//sinon affiche un mesage d'erreur

        }
        private void newDataGridRecherche()
        {
            unLivreProc = new LivreProc();
            dgv_RechercheLivre.DataSource = unLivreProc.listLivre(); //le datagridview 

            //gère les colonnes du dgv
            dgv_RechercheLivre.Columns[1].HeaderText = "Titre";
            dgv_RechercheLivre.Columns[2].HeaderText = "ISBN";
            dgv_RechercheLivre.Columns[3].HeaderText = "Tome";
            dgv_RechercheLivre.Columns[4].HeaderText = "Date publication";
            dgv_RechercheLivre.Columns[5].HeaderText = "Nombre de pages";
            dgv_RechercheLivre.Columns[6].HeaderText = "Nom de l'image";
            dgv_RechercheLivre.Columns[7].HeaderText = "Colorimétrie";
            dgv_RechercheLivre.Columns[8].HeaderText = "Commentaire";
            dgv_RechercheLivre.Columns[9].HeaderText = "Format";
            dgv_RechercheLivre.Columns[10].HeaderText = "Numéro Série";
            dgv_RechercheLivre.Columns[11].HeaderText = "Numéro Éditeur";
            dgv_RechercheLivre.Columns[12].Visible = false;
            dgv_RechercheLivre.Columns[0].Visible = false;


           


            // affiche les différents valeurs dans le dgv
            dgv_RechercheLivre.Columns["wBdTitre"].DisplayIndex = 0;
            dgv_RechercheLivre.Columns["wBdIsbn"].DisplayIndex = 1;
            dgv_RechercheLivre.Columns["wBdTome"].DisplayIndex = 2;
            dgv_RechercheLivre.Columns["wBdParution"].DisplayIndex = 3;
            dgv_RechercheLivre.Columns["wBdPages"].DisplayIndex = 4;
            dgv_RechercheLivre.Columns["wBdImage"].DisplayIndex = 5;
            dgv_RechercheLivre.Columns["wBdCouleur"].DisplayIndex = 6;
            dgv_RechercheLivre.Columns["wBdCommentaires"].DisplayIndex = 7;
            dgv_RechercheLivre.Columns["wBdFormat"].DisplayIndex = 8;

            dgv_RechercheLivre.Columns["wBdNumSerie"].DisplayIndex = 9;
            dgv_RechercheLivre.Columns["wBdNumEditeur"].DisplayIndex = 10;


        }
        private void newDataGrid()
        {
            unLivreProc = new LivreProc();
            dgv_livre.DataSource = unLivreProc.listLivre();

       //nomme les colonnes
            dgv_livre.Columns[1].HeaderText = "Titre";
            dgv_livre.Columns[2].HeaderText = "ISBN";
            dgv_livre.Columns[3].HeaderText = "Tome";
            dgv_livre.Columns[4].HeaderText = "Date publication";
            dgv_livre.Columns[5].HeaderText = "Nombre de pages";
            dgv_livre.Columns[6].HeaderText = "Nom de l'image";
            dgv_livre.Columns[7].HeaderText = "Colorimétrie";
            dgv_livre.Columns[8].HeaderText = "Commentaire";
            dgv_livre.Columns[9].HeaderText = "Format";
            dgv_livre.Columns[10].HeaderText = "Numéro Série";
            dgv_livre.Columns[11].HeaderText = "Numéro Éditeur";
            dgv_livre.Columns[12].Visible = false;
            dgv_livre.Columns[0].Visible = false;






            // affiche les différents valeurs dans le dgv
            dgv_livre.Columns["wBdTitre"].DisplayIndex = 0;
            dgv_livre.Columns["wBdIsbn"].DisplayIndex =1;
            dgv_livre.Columns["wBdTome"].DisplayIndex = 2;
            dgv_livre.Columns["wBdParution"].DisplayIndex = 3;
            dgv_livre.Columns["wBdPages"].DisplayIndex = 4;
            dgv_livre.Columns["wBdImage"].DisplayIndex = 5;
            dgv_livre.Columns["wBdCouleur"].DisplayIndex = 6;
            dgv_livre.Columns["wBdCommentaires"].DisplayIndex = 7;
            dgv_livre.Columns["wBdFormat"].DisplayIndex = 8;
          
            dgv_livre.Columns["wBdNumSerie"].DisplayIndex = 9;
            dgv_livre.Columns["wBdNumEditeur"].DisplayIndex = 10;
          
        }
        private void DataGridExemplaire()
        {
            ExemplaireProc unExemplaireProcdgv;
            unExemplaireProcdgv = new ExemplaireProc();
            dgv_GestionExemplaire.DataSource = unExemplaireProcdgv.ListExemplaire();
            //Affiche ou non les colonnes (des colonnes se sont pas utile pour l'utilisateur)
            dgv_GestionExemplaire.Columns[0].Visible = true; 
            dgv_GestionExemplaire.Columns[1].Visible = false;
            dgv_GestionExemplaire.Columns[2].Visible = true;
            dgv_GestionExemplaire.Columns[3].Visible = false;
            dgv_GestionExemplaire.Columns[4].Visible = false;
            dgv_GestionExemplaire.Columns[5].Visible = true;
            dgv_GestionExemplaire.Columns[6].Visible = false;
            dgv_GestionExemplaire.Columns[7].Visible = false;

            dgv_GestionExemplaire.Columns[0].HeaderText = "Titre";
            dgv_GestionExemplaire.Columns[5].HeaderText = "État";
        
            dgv_GestionExemplaire.Columns[2].HeaderText = "Référence";
            
           
            dgv_GestionExemplaire.Columns["wBdEmpRef"].DisplayIndex = 0;
            dgv_GestionExemplaire.Columns["wBdEtatRef"].DisplayIndex = 1;
            dgv_GestionExemplaire.Columns["wBdTitre"].DisplayIndex = 2;
         
            
        }
        private void DataGridExemplaireNonEmprunter()
        {
            ExemplaireProc unExemplaireProcdgv;
            unExemplaireProcdgv = new ExemplaireProc();
            dgv_GestionExemplaire.DataSource = unExemplaireProcdgv.Afficher_LivreNonEmprunter();

            dgv_GestionExemplaire.Columns[0].Visible = false;
            dgv_GestionExemplaire.Columns[1].Visible = false;
            dgv_GestionExemplaire.Columns[2].Visible = true;
            dgv_GestionExemplaire.Columns[3].Visible = false;
            dgv_GestionExemplaire.Columns[4].Visible = false;
            dgv_GestionExemplaire.Columns[5].Visible = false;
            dgv_GestionExemplaire.Columns[6].Visible = true;
            dgv_GestionExemplaire.Columns[7].Visible = false;


            dgv_GestionExemplaire.Columns[6].HeaderText = "État";

            dgv_GestionExemplaire.Columns[0].HeaderText = "Référence";





            // dgv_livre.Columns[11].HeaderText = "id";


            dgv_GestionExemplaire.Columns["wBdEmpRef"].DisplayIndex = 0;
            dgv_GestionExemplaire.Columns["wBdEtatRef"].DisplayIndex = 1;
            


            // dgv_livre.Columns["wBdId"].DisplayIndex = 11;
        }
        private void DataGridExemplaireEmprunter()
        {
            ExemplaireProc unExemplaireProcdgv;
            unExemplaireProcdgv = new ExemplaireProc();
            dgv_GestionExemplaire.DataSource = unExemplaireProcdgv.Afficher_LivreEmprunter();


            dgv_GestionExemplaire.Columns[0].Visible = false;
            dgv_GestionExemplaire.Columns[1].Visible = false;
            dgv_GestionExemplaire.Columns[2].Visible = true;
            dgv_GestionExemplaire.Columns[3].Visible = false;
            dgv_GestionExemplaire.Columns[4].Visible = false;
            dgv_GestionExemplaire.Columns[5].Visible = false;
            dgv_GestionExemplaire.Columns[6].Visible = true;
            dgv_GestionExemplaire.Columns[7].Visible = false;



            dgv_GestionExemplaire.Columns[0].HeaderText = "Référence";
            dgv_GestionExemplaire.Columns[6].HeaderText = "Date d'emprunt";





            // dgv_livre.Columns[11].HeaderText = "id";


            dgv_GestionExemplaire.Columns["wBdEmpRef"].DisplayIndex = 0;
          


            // dgv_livre.Columns["wBdId"].DisplayIndex = 11;
        }

        //cette méthode permet de remplir les textsBox grace au click sur un compte dans le dataGrid
        private void dataGridCompte_CellClick(object sender, DataGridViewCellEventArgs e) //quand l'utilisateur clic sur une celulle du dgv de gestion livre
        {
            //remplis les différents champs dans les textboxs
            LivreProc unLivreProc; unLivreProc = new LivreProc();
            txtbox_titre.Text = dgv_livre.SelectedCells[1].Value.ToString();
            txtbox_codeISBn.Text = dgv_livre.SelectedCells[2].Value.ToString();
          txtbox_tome.Text = dgv_livre.SelectedCells[3].Value.ToString();
            string date = dgv_livre.SelectedCells[4].Value.ToString();
            DateTime wdate = Convert.ToDateTime(date);
            datepick_annee.Value = wdate;
            int.Parse(txtbox_nbPg.Text= dgv_livre.SelectedCells[5].Value.ToString());
            if (dgv_livre.SelectedCells[7].Value.ToString()=="Couleur")
            {
                rbtnCouleur.Checked = true;
            }
            else { rbtnNoir.Checked= true; }
            txtbox_commentaire.Text = dgv_livre.SelectedCells[8].Value.ToString();
            txtbox_format.Text = dgv_livre.SelectedCells[9].Value.ToString();
           numID = int.Parse(dgv_livre.SelectedCells[0].Value.ToString());
            
           cbbx_serie.Text =unLivreProc.Afficher_SerieISBN(dgv_livre.SelectedCells[2].Value.ToString());
            cbbx_editeur.Text = unLivreProc.Afficher_EditeurISBN(dgv_livre.SelectedCells[2].Value.ToString());
            cbbxDessin.Text = unLivreProc.Afficher_auteursDessins(dgv_livre.SelectedCells[2].Value.ToString());
            cbbxScenario.Text = unLivreProc.Afficher_auteurScenario(dgv_livre.SelectedCells[2].Value.ToString());
           
        }

        private void btnValider_Click(object sender, EventArgs e)//valide une supression
        {

            LivreSupprProc = new LivreSupprProccs();
    
            
            leLivre = new LivreSuppr(unLivreProc.GetId(txtbox_codeISBn.Text),txtBxMotif.Text);//instncie un livresuppr
      
            LivreSupprProc.SupprimerLivre(leLivre);//supprime le livre
            txtBxMotif.Text = "";
            pnlMotif.Visible = false;

            txtbox_codeISBn.Text = "";
            txtbox_titre.Text = "";
            txtbox_nbPg.Text = "";
      
            cbbx_editeur.Text = "";
            cbbx_serie.Text = "";
            txtbox_format.Text = "";
            txtbox_commentaire.Text = "";
            txtbox_tome.Text = "";
            newDataGrid();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)//quand l'utilisateur clic sur le bouton annuler du panel de validation de supression
        {
            txtBxMotif.Text = "";
            pnlMotif.Visible = false;
        }

        private void btn_abimes_Click(object sender, EventArgs e)
        {
            DataGridAbime();
        }//Affiche les livres très abimés
        private void DataGridAbime()
        {
        
            _exemplaire = new ExemplaireProc();
            dgv_GestionExemplaire.DataSource = _exemplaire.listExemplaireAbime();

            //nommer les colonnes
            //dgv_livre.Columns[2].HeaderText = "Reférence";
            //dgv_livre.Columns[1].Visible = false;
            //dgv_livre.Columns[3].HeaderText = "État";
            //dgv_livre.Columns[5].Visible = false;
            //dgv_livre.Columns[6].Visible = false;
            //dgv_livre.Columns[4].Visible = false;
            //dgv_livre.Columns[6].Visible = false;
            //dgv_livre.Columns[7].Visible = false;

            dgv_GestionExemplaire.Columns[0].Visible = false;
            dgv_GestionExemplaire.Columns[1].Visible = false;
            //REF QUI PART  dgv_livre.Columns[2].Visible = false;
            dgv_GestionExemplaire.Columns[2].HeaderText = "Référence";
            dgv_GestionExemplaire.Columns[2].Visible = true;
            dgv_GestionExemplaire.Columns[3].Visible = false;
            dgv_GestionExemplaire.Columns[4].Visible = false;
            //ETAT QUI PART dgv_livre.Columns[5].Visible = false;
            dgv_GestionExemplaire.Columns[6].HeaderText = "État";
            dgv_GestionExemplaire.Columns[5].Visible = false;
            dgv_GestionExemplaire.Columns[6].Visible = true;
            dgv_GestionExemplaire.Columns[7].Visible = false;


            //organiser les colonnes
            dgv_GestionExemplaire.Columns["wBdEmpRef"].DisplayIndex = 0;
            dgv_GestionExemplaire.Columns["wBdEtatRef"].DisplayIndex =1;
           
        }//Remplis le datagrid par une liste de livres très abimé
        private void DataGridNonRendus()
        {

            _exemplaire = new ExemplaireProc();
            dgv_GestionExemplaire.DataSource = _exemplaire.listExempNonrendus();

            //nommer les colonnes

            dgv_GestionExemplaire.Columns[0].Visible = false;
            dgv_GestionExemplaire.Columns[1].Visible = false;
            dgv_GestionExemplaire.Columns[2].Visible = true;
            dgv_GestionExemplaire.Columns[3].Visible = true;
            dgv_GestionExemplaire.Columns[4].Visible = false;
            dgv_GestionExemplaire.Columns[5].Visible = false;
            dgv_GestionExemplaire.Columns[6].Visible = false;
            dgv_GestionExemplaire.Columns[7].Visible = false;
          
            dgv_GestionExemplaire.Columns[2].HeaderText = "Reférence";
            dgv_GestionExemplaire.Columns[3].HeaderText = "Date";

            //organiser les colonnes
            dgv_GestionExemplaire.Columns["wBdEmpRef"].DisplayIndex = 0;
            dgv_GestionExemplaire.Columns["wBdDate"].DisplayIndex = 1;

        }//remplis le datagrid par une liste de livre non rendus
        private void DataGridNbLivres()
        {
            _exemplaire = new ExemplaireProc();
            dgv_GestionExemplaire.DataSource = _exemplaire.listExempNbLivre();

            //nommer les colonnes
            dgv_GestionExemplaire.Columns[0].Visible = true;
            dgv_GestionExemplaire.Columns[1].Visible = true;
            dgv_GestionExemplaire.Columns[2].Visible = false;
            dgv_GestionExemplaire.Columns[3].Visible = false;
            dgv_GestionExemplaire.Columns[4].Visible = false;
            dgv_GestionExemplaire.Columns[5].Visible = false;
            dgv_GestionExemplaire.Columns[6].Visible = false;
            dgv_GestionExemplaire.Columns[7].Visible = false;
            dgv_GestionExemplaire.Columns[0].HeaderText = "Titre";
            dgv_GestionExemplaire.Columns[1].HeaderText = "Nombre";

            //organiser les colonnes
            dgv_GestionExemplaire.Columns["wBdTitre"].DisplayIndex = 0;
            dgv_GestionExemplaire.Columns["wBdnbExemp"].DisplayIndex = 1;

        }//remplis le datagrid pas une liste de livre avec le nombre d'exemplaire de clui ci

        private void btn_NombreEtEtat_Click(object sender, EventArgs e)
        {
            DataGridNbLivres();
        }//affiche dans le datagrid le nombre d'exemplaire d'un livre aninsi que leur etat

        private void btn_ajouterSerie_Click(object sender, EventArgs e)
        {
            pnlSerie.Visible = true;
            pnlSerie.Location = new Point(215, 220);
        }

        private void btn_valider_Serie_Click(object sender, EventArgs e)//ajoute une série
        {
            serie serie; AuteurProc auteurProc;auteurProc = new AuteurProc();
            serieProc = new SerieProc();
            serie = new serie(txtbx_NomSerie.Text, int.Parse(txtbx_Nombre.Text));//insatncie une série
            serieProc.AjouterSerie(serie);//l'ajoute dans la bdd
            txtbx_NomSerie.Text = "";
            txtbx_Nombre.Text = "";
            pnlSerie.Visible = false;
            cbbx_serie.SelectedText = txtbx_NomSerie.Text;
            cbbx_serie.Items.Clear();
            foreach (serie uneSerie in _exemplaire.ListNomSerie())
            {
                cbbx_serie.Items.Add(uneSerie.GetNom);//remplis un combobox de nom de série
            }
         
        }

        private void btn_annuler_serie_Click(object sender, EventArgs e)
        {
            pnlSerie.Visible = false;
        }

        private void btn_valider_auteur_livre_Click(object sender, EventArgs e)
        {

            pnlAuteurLivre.Visible = false;
        }

        private void btn_annuler_auteur_livre_Click(object sender, EventArgs e)
        {
            cbbxDessin.Text = "";
            cbbxScenario.Text = "";
            pnlAuteurLivre.Visible = false;
        }

        private void btn_ajoutAuteur_Click(object sender, EventArgs e)
        {
            pnlAuteurLivre.Visible = true;


        }

       

        private void btnAjoutExemplaire_Click(object sender, EventArgs e)
        {
            if (txtBox_RefExemp.Text != "" && cbbxEtatExmp.Text != "" && cbbxBdExemp.Text != "")
            {//vérifie que tout les champs sont remplis
                LivreProc wlivreproc; wlivreproc = new LivreProc(); ExemplaireProc exemplaireproc; exemplaireproc = new ExemplaireProc();
                Exemplaire unExemplaire; int a; a = wlivreproc.Afficher_idBd_enFctionNom(cbbxBdExemp.Text); Boolean o; o = false;
                foreach (Exemplaire wExemplaire in exemplaireproc.ListExemplaire()) 
                {
                    if (wExemplaire.wBdEmpRef == txtBox_RefExemp.Text) //vérifie que la référence n'est pas déja définie dans la base de donnée
                    {
                        o = true;
                    }
                }
                if (o== false)// si non alors on instancie un nouvel objet puis on l'ajoute 
                {
                    unExemplaire = new Exemplaire(txtBox_RefExemp.Text, cbbxEtatExmp.Text, a);//instancie un nouveau exemplaire
                    ExemplaireProc exemp;
                    exemp = new ExemplaireProc();
                    exemp.AjouterExemplaire(unExemplaire);//l'ajoute a la base
                    txtBox_RefExemp.Text = "";
                    cbbxBdExemp.Text = "";
                    cbbxEtatExmp.Text = "";
                }
                else
                {
                    pnlRefFaux.Visible = true;

                }
            }

            else { pnl_MsgErreurExemplaire.Visible = true; } 
           //
           
        }//ajoute un exemplaire a la base

        private void btnModifExemplaire_Click(object sender, EventArgs e)//modifie un exemplaire
        {
            if (txtBox_RefExemp.Text != "" && cbbxEtatExmp.Text != "" && cbbxBdExemp.Text != "")//vérification que tout les champs sont remplis
            {
                Exemplaire unExemplaire; ExemplaireProc exemplaireProc; exemplaireProc = new ExemplaireProc();
                unExemplaire = new Exemplaire(txtBox_RefExemp.Text, cbbxEtatExmp.Text);//instancie un objet
                exemplaireProc.ModifierEtatExemplaire(unExemplaire);//Modifie l'objet dans la base de donnée
            }
            else { pnl_MsgErreurExemplaire.Visible = true; }

        }

        private void btnSupprExemplaire_Click(object sender, EventArgs e)//Supprime un exemplaire
        {
            if (txtBox_RefExemp.Text != "")//vérification que le champs est remplis
            {
                pnl_MotifEmp.Visible = true;
                txtbox_motifEmp.Text = "";
            }

            else { pnl_MsgErreurExemplaire.Visible = true; } }

        private void btn_GestionExemp_Click(object sender, EventArgs e)//affiche le panel de gestion d'exemplaire
        {
            panel_Exemplaire.Visible = true;
            panel_Exemplaire.Location = new Point(178, 34);
            DataGridExemplaire();
            EmprunteurProc emprunteurProc; emprunteurProc = new EmprunteurProc();

            foreach (Livre unLivre in unLivreProc.listBdTitre())
            {
                cbbxBdExemp.Items.Add(unLivre.wBdTitre);//remplis ue combobox de titre de livre  
            }
            foreach (Emprunteur unEmprunteur in emprunteurProc.listEmprunteur())
            {
                cbbx_Emprunteur.Items.Add(unEmprunteur.nomEmp + " " + unEmprunteur.prenomEmp);//remplis un combobox des nom et prenoms des emprunteurs présent dans la base
                NumEmprunteur.Add(unEmprunteur.numEmp);
                cbbx_Emprunteur.ValueMember = unEmprunteur.numEmp.ToString();
            }
            cbbxEtatExmp.Items.Add("très bon"); cbbxEtatExmp.Items.Add("bon"); cbbxEtatExmp.Items.Add("abimé"); cbbxEtatExmp.Items.Add("très abimé");//ajoute les états des exemplaires dans un combobox

        }

        private void btn_Exemplaire_Click(object sender, EventArgs e)//évènement clic sur le bouton "Exemplaire"
        {
            DataGridExemplaire(); //affiche les exemplaires de livres
          
        }

        private void btn_AnnulerMotifEmp_Click(object sender, EventArgs e)//appui sur le bouton annuler d'un des panels  
        {
            pnl_MotifEmp.Visible = false;
            
        }

        private void btn_ValiderMotifEmp_Click(object sender, EventArgs e)
        {
         
                        Exemplaire ExemplaireSuppr;ExemplaireProc ExemplaireProcSuppr;ExemplaireProcSuppr = new ExemplaireProc();
            ExemplaireSuppr = new Exemplaire(txtBox_RefExemp.Text,txtbox_motifEmp.Text);
            ExemplaireProcSuppr.SupprimerExemplaire(ExemplaireSuppr);
            
            txtbox_motifEmp.Text = "";
            pnl_MotifEmp.Visible = false;
            txtBox_RefExemp.Text = "";
            
        }//supprime l'exemplaire

        private void btn_Emprunter_Click(object sender, EventArgs e)
        {
            pnl_emprunter.Visible = true;
            
        }//affiche le panel emprunter

        private void btn_AnnulerEmprunter_Click(object sender, EventArgs e)
        {
            cbbx_Emprunteur.Text = "";
            pnl_emprunter.Visible = false;
        }

        private void btn_validerEmprunter_Click(object sender, EventArgs e)//ajoute un emprunt 
        {
            Emprunter unEmprunt;
            Emprunter unEmpruntProc;
            unEmpruntProc = new Emprunter();
            DateTime thisDate = DateTime.Today;//prend la date d'aujourd'hui
      
            Emprunteur unEmp =(Emprunteur)cbbx_Emprunteur.SelectedValue;
   
            unEmprunt = new Emprunter (txtBox_RefExemp.Text, thisDate ,NumEmprunteur[cbbx_Emprunteur.SelectedIndex]);//Prend le numero emprunteur de la liste NumEmprunteur d'index l'emprunteur sélectionné 
            unEmpruntProc.Ajouter_DateEmprunt(unEmprunt);
            pnl_emprunter.Visible = false;
        }

        private void btn_ExemplaireEmpruntés_Click(object sender, EventArgs e)
        {
            DataGridExemplaireEmprunter();        }//affiche les exemplaires empruntés

        private void btn_ExemplaireNonEmpruntés_Click(object sender, EventArgs e)
        {
            DataGridExemplaireNonEmprunter();
        }//affiche les exemplaires non empruntés

        private void txtBox_titreRecherche_TextChanged(object sender, EventArgs e)
        {

            unLivre = new Livre(txtBox_titreRecherche.Text);
            unLivreProc = new LivreProc();
            unLivreProc.listRechercheLivre(unLivre);

         
            dgv_RechercheLivre.DataSource = unLivreProc.listRechercheNomLivre(unLivre);

            dgv_RechercheLivre.Columns[1].HeaderText = "Titre";
            dgv_RechercheLivre.Columns[2].HeaderText = "ISBN";
            dgv_RechercheLivre.Columns[3].HeaderText = "Tome";
            dgv_RechercheLivre.Columns[4].HeaderText = "Date publication";
            dgv_RechercheLivre.Columns[5].HeaderText = "Nombre de pages";
            dgv_RechercheLivre.Columns[6].HeaderText = "Nom de l'image";
            dgv_RechercheLivre.Columns[7].HeaderText = "Colorimétrie";
            dgv_RechercheLivre.Columns[8].HeaderText = "Commentaire";
            dgv_RechercheLivre.Columns[9].HeaderText = "Format";
            dgv_RechercheLivre.Columns[10].HeaderText = "Numéro Série";
            dgv_RechercheLivre.Columns[11].HeaderText = "Numéro Éditeur";
            dgv_RechercheLivre.Columns[12].Visible = false;



            // dgv_livre.Columns[11].HeaderText = "id";



            dgv_RechercheLivre.Columns["wBdTitre"].DisplayIndex = 0;
            dgv_RechercheLivre.Columns["wBdIsbn"].DisplayIndex = 1;
            dgv_RechercheLivre.Columns["wBdTome"].DisplayIndex = 2;
            dgv_RechercheLivre.Columns["wBdParution"].DisplayIndex = 3;
            dgv_RechercheLivre.Columns["wBdPages"].DisplayIndex = 4;
            dgv_RechercheLivre.Columns["wBdImage"].DisplayIndex = 5;
            dgv_RechercheLivre.Columns["wBdCouleur"].DisplayIndex = 6;
            dgv_RechercheLivre.Columns["wBdCommentaires"].DisplayIndex = 7;
            dgv_RechercheLivre.Columns["wBdFormat"].DisplayIndex = 8;

            dgv_RechercheLivre.Columns["wBdNumSerie"].DisplayIndex = 9;
            dgv_RechercheLivre.Columns["wBdNumEditeur"].DisplayIndex = 10;


        }//A chaque lettre ajoutée dans le txtbox

        //private void datePicker_Recherche_onValueChanged(object sender, EventArgs e)
        //{
        //    unLivre = new Livre(datePicker_Recherche.Value.ToString("MM/yyyy"));
        //    unLivreProc = new LivreProc();
        //    unLivreProc.listRechercheLivre(unLivre);
        //    lbltest.Text = datePicker_Recherche.Value.ToString("MM/yyyy");

        //    dgv_RechercheLivre.DataSource = unLivreProc.Recherche_Date_Livre(unLivre);
        //    dgv_RechercheLivre.Columns[1].HeaderText = "Titre";
        //    dgv_RechercheLivre.Columns[2].HeaderText = "ISBN";
        //    dgv_RechercheLivre.Columns[3].HeaderText = "Tome";
        //    dgv_RechercheLivre.Columns[4].HeaderText = "Date publication";
        //    dgv_RechercheLivre.Columns[5].HeaderText = "Nombre de pages";
        //    dgv_RechercheLivre.Columns[6].HeaderText = "Nom de l'image";
        //    dgv_RechercheLivre.Columns[7].HeaderText = "Colorimétrie";
        //    dgv_RechercheLivre.Columns[8].HeaderText = "Commentaire";
        //    dgv_RechercheLivre.Columns[9].HeaderText = "Format";
        //    dgv_RechercheLivre.Columns[10].HeaderText = "Numéro Série";
        //    dgv_RechercheLivre.Columns[11].HeaderText = "Numéro Éditeur";
        //    dgv_RechercheLivre.Columns[12].Visible = false;



          



        //    dgv_RechercheLivre.Columns["wBdTitre"].DisplayIndex = 0;
        //    dgv_RechercheLivre.Columns["wBdIsbn"].DisplayIndex = 1;
        //    dgv_RechercheLivre.Columns["wBdTome"].DisplayIndex = 2;
        //    dgv_RechercheLivre.Columns["wBdParution"].DisplayIndex = 3;
        //    dgv_RechercheLivre.Columns["wBdPages"].DisplayIndex = 4;
        //    dgv_RechercheLivre.Columns["wBdImage"].DisplayIndex = 5;
        //    dgv_RechercheLivre.Columns["wBdCouleur"].DisplayIndex = 6;
        //    dgv_RechercheLivre.Columns["wBdCommentaires"].DisplayIndex = 7;
        //    dgv_RechercheLivre.Columns["wBdFormat"].DisplayIndex = 8;

        //    dgv_RechercheLivre.Columns["wBdNumSerie"].DisplayIndex = 9;
        //    dgv_RechercheLivre.Columns["wBdNumEditeur"].DisplayIndex = 10;


        //}//A chaque date ajoutée 

        private void btn_RendreExemplaire_Click(object sender, EventArgs e)
        {
            Exemplaire unExemplaire;
            unExemplaire = new Exemplaire(txtBox_RefExemp.Text);
            ExemplaireProc unExemplaireProc;
            unExemplaireProc = new ExemplaireProc();
            unExemplaireProc.Supprimer_ExemplaireEmprunté(unExemplaire);
            txtBox_RefExemp.Text = "";
        }//supprime l'eexemplaire de la table emprunter

        private void btn_MSGErreurLivre_Click(object sender, EventArgs e)
        {
            pnl_MsgErreurGestionLivre.Visible = false;
        }//message d'erreur

        private void btn_MSGExemp_Click(object sender, EventArgs e)
        {
            pnl_MsgErreurExemplaire.Visible = false;
        }//message d'erreur

        private void btn_rechercheLivre_Click(object sender, EventArgs e)
        {
            unLivre = new Livre(datePicker_Recherche.Value.ToString("MM/yyyy"));
            unLivreProc = new LivreProc();
            unLivreProc.listRechercheLivre(unLivre);
           

            dgv_RechercheLivre.DataSource = unLivreProc.Recherche_Date_Livre(unLivre);
            dgv_RechercheLivre.Columns[1].HeaderText = "Titre";
            dgv_RechercheLivre.Columns[2].HeaderText = "ISBN";
            dgv_RechercheLivre.Columns[3].HeaderText = "Tome";
            dgv_RechercheLivre.Columns[4].HeaderText = "Date publication";
            dgv_RechercheLivre.Columns[5].HeaderText = "Nombre de pages";
            dgv_RechercheLivre.Columns[6].HeaderText = "Nom de l'image";
            dgv_RechercheLivre.Columns[7].HeaderText = "Colorimétrie";
            dgv_RechercheLivre.Columns[8].HeaderText = "Commentaire";
            dgv_RechercheLivre.Columns[9].HeaderText = "Format";
            dgv_RechercheLivre.Columns[10].HeaderText = "Numéro Série";
            dgv_RechercheLivre.Columns[11].HeaderText = "Numéro Éditeur";
            dgv_RechercheLivre.Columns[12].Visible = false;







            dgv_RechercheLivre.Columns["wBdTitre"].DisplayIndex = 0;
            dgv_RechercheLivre.Columns["wBdIsbn"].DisplayIndex = 1;
            dgv_RechercheLivre.Columns["wBdTome"].DisplayIndex = 2;
            dgv_RechercheLivre.Columns["wBdParution"].DisplayIndex = 3;
            dgv_RechercheLivre.Columns["wBdPages"].DisplayIndex = 4;
            dgv_RechercheLivre.Columns["wBdImage"].DisplayIndex = 5;
            dgv_RechercheLivre.Columns["wBdCouleur"].DisplayIndex = 6;
            dgv_RechercheLivre.Columns["wBdCommentaires"].DisplayIndex = 7;
            dgv_RechercheLivre.Columns["wBdFormat"].DisplayIndex = 8;

            dgv_RechercheLivre.Columns["wBdNumSerie"].DisplayIndex = 9;
            dgv_RechercheLivre.Columns["wBdNumEditeur"].DisplayIndex = 10;

        }

        private void btn_ErreurRef_Click(object sender, EventArgs e)
        {
            pnlRefFaux.Visible = false;
        }
    }
}