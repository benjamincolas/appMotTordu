using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ClassLibrary
{
    public class connexionBdd
    {
        #region constructeur.s
        //constructeur de la classe connexionBdd sans paramètre
        public connexionBdd()
        {
            laConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectBdd"].ConnectionString);
        }
        #endregion

        #region méthode.s
        //propriété.s auto property
        public MySqlConnection laConnection { get; set; }

        //cette méthode permet de véifier si la connexion à la base de données est établie (s'y connecte) ou non
        public bool OuvrirConnexion()
        {
            try 
            {
          
                laConnection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        //cette méthode permet de fermer la connection à la base de données
        public void fermerConnexion()
        {
            laConnection.Close();
        }
        #endregion
    }
}
