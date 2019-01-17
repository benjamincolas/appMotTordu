using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class LivreSupprProccs
    {
        #region propriétés
        private connexionBdd _connexion;
        private MySqlCommand CmdSql;
        private List <LivreSuppr>_livreSuppr;
        #endregion
        #region constructeur
        public LivreSupprProccs()
        {
            _connexion = new connexionBdd();
            _livreSuppr = new List<LivreSuppr>();
        }
        #endregion
        #region méthodes
        public void exec()//execute les procédures stockées
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
        public void SupprimerLivre(LivreSuppr wLivre)//supprimer un livre
        {
            _livreSuppr.Add(wLivre);
            initProc("Supprimer_Livre");
            foreach (LivreSuppr unLivre in _livreSuppr)
            {
                CmdSql.Parameters.Add(new MySqlParameter("wid", MySqlDbType.Int32));
                CmdSql.Parameters["wid"].Value = unLivre.wBdID;
                CmdSql.Parameters.Add(new MySqlParameter("wmotif", MySqlDbType.String));
                CmdSql.Parameters["wmotif"].Value = unLivre.wMotif;
            }
            exec();
        }
    }
}
#endregion