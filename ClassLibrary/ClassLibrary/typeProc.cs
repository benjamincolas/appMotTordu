using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class typeProc
    {
        //propriétée.s
        private connexionBdd _connexion;
        private MySqlCommand CmdSql;


        #region constructeur
        //constructeur de la classe livre 
        public typeProc()
        {
            _connexion = new connexionBdd();
         
        }
        #endregion
        public void exec() //execute la procédure stockée
        {
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            //execution de la requête
            CmdSql.ExecuteNonQuery();
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
        }

        public void AjouterTypeBD_Auteur(type unType)//ajoute un type 
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Ajouter_typeBD_Auteur";
            CmdSql.CommandType = CommandType.StoredProcedure;
          
            CmdSql.Parameters.Add(new MySqlParameter("_numbd", MySqlDbType.Int32));
            CmdSql.Parameters["_numbd"].Value = unType.UnNum;
            CmdSql.Parameters.Add(new MySqlParameter("_numparticipant", MySqlDbType.Int32));
            CmdSql.Parameters["_numparticipant"].Value = unType.UnNumParticipant;
            CmdSql.Parameters.Add(new MySqlParameter("_numtype", MySqlDbType.Int32));
            CmdSql.Parameters["_numtype"].Value = unType.UnNumType;
            exec();
        }
        public void AjouterTypeLivre(type unType) //ajoute un type livre
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Ajouter_Type_Livre";
            CmdSql.CommandType = CommandType.StoredProcedure;
      
            CmdSql.Parameters.Add(new MySqlParameter("_num", MySqlDbType.Int32));
            CmdSql.Parameters["_num"].Value = unType.UnNum;
            CmdSql.Parameters.Add(new MySqlParameter("_type", MySqlDbType.String));
            CmdSql.Parameters["_type"].Value = unType.UnType;
            exec();

        }
    }
}
