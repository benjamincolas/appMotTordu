using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Emprunter
    {
        private DateTime thisDate;
        private Emprunter unEmprunteur;
        private string ex_ref;
        private connexionBdd _connexion;
        private int idEmp;
        private MySqlCommand CmdSql;
        public Emprunter(string _ex_ref,DateTime _thisDate,int _idEmp)
        {
            ex_ref = _ex_ref;
            thisDate = _thisDate;
            idEmp = _idEmp;
        }
        public Emprunter()
        {
            _connexion = new connexionBdd();
        }
        public string wex_ref
        {
            get { return ex_ref; }
            set { ex_ref = value; }
        }
        public DateTime wthisDate
        {
            get { return thisDate; }
            set { thisDate = value; }
        }
        public int widEmp
        {
            get { return idEmp; }
            set { idEmp = value; }
        }
        public void exec()
        {
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            //execution de la requête
            CmdSql.ExecuteNonQuery();
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
        }

        public void initProc(String nomProc)
        {
            //création objet Command et association à la Ps
            CmdSql = new MySqlCommand();
            CmdSql.CommandText = nomProc;
            CmdSql.CommandType = CommandType.StoredProcedure;
            CmdSql.Connection = _connexion.laConnection;
        }

        public void Ajouter_DateEmprunt(Emprunter unEmprunt)
        {
            initProc("Ajouter_DateEmprunt");

            CmdSql.Parameters.Add(new MySqlParameter("widEmpNum", MySqlDbType.Int32));
            CmdSql.Parameters["widEmpNum"].Value = unEmprunt.idEmp;

            CmdSql.Parameters.Add(new MySqlParameter("widRefExemplaire", MySqlDbType.String));
            CmdSql.Parameters["widRefExemplaire"].Value = unEmprunt.ex_ref;

            CmdSql.Parameters.Add(new MySqlParameter("_date", MySqlDbType.Datetime));
            CmdSql.Parameters["_date"].Value = unEmprunt.thisDate;
            exec();
            

        }
    }
}
