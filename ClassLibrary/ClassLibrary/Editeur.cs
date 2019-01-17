using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Editeur
    {
        //propriétés
        private int editeur_numero;
        private string editeur_nom;
        private int editeur_creation;
        private string editeur_adresse;
        private string editeur_cp;
        private string editeur_ville;
        private string editeur_tel;
        private string editeur_fax;
        private string editeur_mail;
        private string editeur_prenom_contact;
        private string editeur_nom_contact;
        private string editeur_motif;

        //tous les constructeurs
        #region constructeur.s
        public Editeur(int wediteur_numero, string wediteur_nom, int wediteur_creation, string wediteur_adresse, string wediteur_cp, string wediteur_ville, string wediteur_tel, string wediteur_fax, string wediteur_mail, string wediteur_nom_contact, string wediteur_prenom_contact)
        {
            editeur_numero = wediteur_numero;
            editeur_nom = wediteur_nom;
            editeur_creation = wediteur_creation;
            editeur_adresse = wediteur_adresse;
            editeur_cp = wediteur_cp;
            editeur_ville = wediteur_ville;
            editeur_tel = wediteur_tel;
            editeur_fax = wediteur_fax;
            editeur_mail = wediteur_mail;
            editeur_prenom_contact = wediteur_prenom_contact;
            editeur_nom_contact = wediteur_nom_contact;
        }

        public Editeur(string wediteur_nom, int wediteur_creation, string wediteur_adresse, string wediteur_cp, string wediteur_ville, string wediteur_tel, string wediteur_fax, string wediteur_mail, string wediteur_nom_contact, string wediteur_prenom_contact)
        {
            editeur_nom = wediteur_nom;
            editeur_creation = wediteur_creation;
            editeur_adresse = wediteur_adresse;
            editeur_cp = wediteur_cp;
            editeur_ville = wediteur_ville;
            editeur_tel = wediteur_tel;
            editeur_fax = wediteur_fax;
            editeur_mail = wediteur_mail;
            editeur_prenom_contact = wediteur_prenom_contact;
            editeur_nom_contact = wediteur_nom_contact;
        }

        public Editeur(int wediteur_numero, string wediteur_motif)
        {
            editeur_numero = wediteur_numero;
            editeur_motif = wediteur_motif;
        }
        public Editeur(string wediteur_nom)
        {
            editeur_nom = wediteur_nom;
        }
        #endregion

        //tous les accesseurs 
        #region méthode.s 
        public int wnumero
        {
            get { return editeur_numero; }
            set { editeur_numero = value; }
        }

        public string wnom
        {
            get { return editeur_nom; }
            set { editeur_nom = value; }
        }

        public int wcreation
        {
            get { return editeur_creation; }
            set { editeur_creation = value; }
        }

        public string wadresse
        {
            get { return editeur_adresse; }
            set { editeur_adresse = value; }
        }

        public string wcp
        {
            get { return editeur_cp; }
            set { editeur_cp = value; }
        }

        public string wville
        {
            get { return editeur_ville; }
            set { editeur_ville = value; }
        }

        public string wtel
        {
            get { return editeur_tel; }
            set { editeur_tel = value; }
        }

        public string wfax
        {
            get { return editeur_fax; }
            set { editeur_fax = value; }
        }

        public string wmail
        {
            get { return editeur_mail; }
            set { editeur_mail = value; }
        }

        public string wnom_contact
        {
            get { return editeur_nom_contact; }
            set { editeur_nom_contact = value; }
        }

        public string wprenom_contact
        {
            get { return editeur_prenom_contact; }
            set { editeur_prenom_contact = value; }
        }

        public string wmotif
        {
            get { return editeur_motif; }
            set { editeur_motif = value; }
        }
        #endregion
    }
}
