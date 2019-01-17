using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ClassLibrary;
using System.Threading;

namespace lesMotsTordus
{
    public partial class frmConnexion : MetroForm
    {
        //propriétés
        private utilisateursProc _utilisateurs;
        private utilisateurs unUtilisateur;
        private string _niveau;
        private bool etatActivPass = true;
        private Thread th;

        public frmConnexion() //constructeur
        {
            InitializeComponent();

            //permet de vider la mémoire RAM non utilisé
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void pctBxQuit_Click(object sender, EventArgs e) //au clique sur le bouton de fermeture de l'application
        {
            Application.Exit(); //ferme l'application
        }

        private void connect() //cette méthode permet de connecter l'utilisateur à l'application
        {
            //initialise la procéure et un nouvelle utilisateur
            _utilisateurs = new utilisateursProc();
            unUtilisateur = new utilisateurs(txtBxIdentifiant.Text, txtBxPassword.Text);
            _utilisateurs.connectApp(unUtilisateur);

            //récupère le niveau de l'utilisateur
            _niveau = _utilisateurs.niveau;

            //si l'utilisateur est connecté alors on initialise la form GestionGeneral
            if (_niveau != "")
            {
                progressBar.Visible = true; //rend la barre de progression visible
                timer.Start(); //démarre le timer de la barre de progression
                lblErreurAuth.Visible = false; //cache le label du message d'erreur

                th = new Thread(opennewform);
                th.SetApartmentState(ApartmentState.STA);
            }
            else //si le compte n'éxiste pas, renvoie un message d'erreur
            {
                lblErreurAuth.Visible = true; //rend le message d'erreur visible
            }
        }

        private void opennewform(object obj)
        {
            Application.Run(new frmGestionGeneral(_niveau));
        }

        private void timer_Tick(object sender, EventArgs e) //timer tick de 1 milliseconde
        {
            if (progressBar.Value < 100) //si la barre de progression est inférieur à 100% alors
            {
                progressBar.Value += 2; //ajoute 2%
            }
            else if (progressBar.Value == 100) //sinon si la barre de progression est égale à 100% alors
            {
                this.Dispose(); //ferme la fenêtre courante
                th.Start(); //démarre le thread de la nouvelle fenêtre
                timer.Stop(); //arrête le timer
            }
        }

        private void txtBxIdentifiant_Click(object sender, EventArgs e) //au clique sur la zone de saisie de l'identifiant
        {
            if (txtBxIdentifiant.Text == "Identifiant") //si dans la zone de saisie le text est égale à "Identifiant"
            {
                txtBxIdentifiant.Clear(); //vide la zone de saisie
            }
            if (txtBxPassword.Text == "") //si la zone de saisie du mot de passe est vide
            {
                txtBxPassword.Text = "Mot de passe"; //remplace le vide par "Mot de passe"
                txtBxPassword.PasswordChar = '\0'; //rend le text lisible
            }
        }

        private void txtBxIdentifiant_KeyPress(object sender, KeyPressEventArgs e) //à l'appuie sur une touche dans la zone de l'identifiant
        {
            if (e.KeyChar == (char)Keys.Enter) //si la touche est entrée alors
            {
                connect(); //appel la méthode de connexion
            }
        }

        private void txtBxPassword_Click(object sender, EventArgs e) //au clique sur la zone de saisie du mot de passe
        {
            if (txtBxPassword.Text == "Mot de passe") //si la zone de saisie du mot de passe est égale à "Mot de passe"
            {
                txtBxPassword.Clear(); //vide la zone de saisie
            }

            if (txtBxIdentifiant.Text == "") //si la zone de saisie de l'identifiant est vide
            {
                txtBxIdentifiant.Text = "Identifiant"; //remplace le vide par "Mot de passe"
            }
        }

        private void txtBxPassword_KeyDown(object sender, KeyEventArgs e) //quand on commence à écrire dans la zone de saisie du mot de passe
        {
            txtBxPassword.PasswordChar = '*'; //remplace le text de la zone de saisie par des étoiles
            pctBxPassword.Visible = true; //rend l'oeil à droite visible
        }

        private void txtBxPassword_KeyPress(object sender, KeyPressEventArgs e) //à l'appuie sur une touche dans la zone de saisie du mot de passe
        {
            if (e.KeyChar == (char)Keys.Enter) //si la touche est entrée alors
            {
                connect(); //appel la méthode de connexion
            }
        }

        private void pctBxPassword_Click(object sender, EventArgs e) //au clique sur l'oeil à droite du mot de passe
        {
            if (etatActivPass == true) //si etatActivPass est vrai alors
            {
                pctBxPassword.BackgroundImage = Properties.Resources.ResourceManager.GetObject("visible") as Image; //change l'image de l'oeil
                txtBxPassword.PasswordChar = '\0'; //rend le mot de passe lisible
                etatActivPass = false; //etatActivPass prend la valeur faux
            }
            else if(etatActivPass == false)//sinon si etatActivPass est faux alors
            {
                pctBxPassword.BackgroundImage = Properties.Resources.ResourceManager.GetObject("invisible") as Image; //change l'image de l'oeil
                txtBxPassword.PasswordChar = '*'; //remplace les caractères du mot de passe par des étoiles
                etatActivPass = true; //etatActivPass prend la valeur vrai
            }
        }

        private void btnConnexion_Click(object sender, EventArgs e) //au clique sur le bouton de connexion
        {
            connect(); //appel la méthode connect
        }
    }
}
