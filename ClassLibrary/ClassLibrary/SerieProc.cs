using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SerieProc
    {
        #region propriétés
        private connexionBdd _connexion;
        private MySqlCommand CmdSql;

        #endregion
        #region constructeur

        public SerieProc()
        {
            _connexion = new connexionBdd();

        }
        #endregion
        #region méthodes
        public void exec()//execute la procédure stockée
        {
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            //execution de la requête
            CmdSql.ExecuteNonQuery();
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
        }
        public void initProc(String nomProc)//initialise la procédure stockée
        {
            //création objet Command et association à la Ps
            CmdSql = new MySqlCommand();
            CmdSql.CommandText = nomProc;
            CmdSql.CommandType = CommandType.StoredProcedure;
            CmdSql.Connection = _connexion.laConnection;
        }
        public void AjouterSerie(serie wserie)//ajoute la série
        {

          //  _editeur.Add(wserie);
            initProc("Ajouter_Serie");
            //foreach (Editeur unEditeur in _editeur)
            //{

                //mise en place des paramètres
                CmdSql.Parameters.Add(new MySqlParameter("wnom", MySqlDbType.String));
            CmdSql.Parameters["wnom"].Value = wserie.GetNom;
            CmdSql.Parameters.Add(new MySqlParameter("wnb", MySqlDbType.Int32));
            CmdSql.Parameters["wnb"].Value = wserie.GetNb;
            exec();
        }
    }
}
#endregion