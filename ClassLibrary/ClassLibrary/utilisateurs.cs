using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class utilisateurs
    {
        //propriétée.s
        private String util_prenom;
        private String util_nom;
        private String util_pseudo;
        private String util_password;
        private String util_niveau;
        private int util_id;

        #region constructeur.s
        //constructeur.s de base la classe utilisateurs 
        public utilisateurs(int wUtil_id, String wUtil_prenom, String wUtil_nom, String wUtil_pseudo, String wUtil_password, String wUtil_niveau)
        {
            util_id = wUtil_id;
            util_prenom = wUtil_prenom;
            util_nom = wUtil_nom;
            util_pseudo = wUtil_pseudo;
            util_password = wUtil_password;
            util_niveau = wUtil_niveau;
        }

        //deuxième constructeur de la classe utilisateurs pour la connexion
        public utilisateurs(String wUtil_pseudo, String wUtil_password)
        {
            util_pseudo = wUtil_pseudo;
            util_password = wUtil_password;
        }
        #endregion

        #region méthode.s
        //gettter.s setter.s
        public String prenom
        {
            get { return util_prenom; }
            set { util_prenom = value; }
        }

        public String nom
        {
            get { return util_nom; }
            set { util_nom = value; }
        }

        public String pseudo
        {
            get { return util_pseudo; }
            set { util_pseudo = value; }
        }

        public String password
        {
            get { return util_password; }
            set { util_password = value; }
        }

        public String niveau
        {
            get { return util_niveau; }
            set { util_niveau = value; }
        }

        public int id
        {
            get { return util_id; }
            set { util_id = value; }
        }
        #endregion
    }
}
