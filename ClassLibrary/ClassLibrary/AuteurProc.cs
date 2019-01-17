using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class AuteurProc
    {
        //propriété.s
        private connexionBdd _connexion;
        private List<auteur> _auteur;
        private List<auteur> uneListe;
        private MySqlCommand CmdSql;
        private DataSet unDataset;

        #region constructeur.s
        //constructeur.s sans de la classe auteur
        public AuteurProc()
        {
            _connexion = new connexionBdd();
            _auteur = new List<auteur>();
            MySqlCommand CmdSql = new MySqlCommand();
        }
        #endregion

        #region méthode.s
        //méthode.s de la classe auteur
        public void Execution()
        {
            //ouverture de la connexion à la bdd
            _connexion.OuvrirConnexion();

            //execution de la requête
            CmdSql.ExecuteNonQuery();

            //fermeture de la connexion à la bdd
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

        //insertion d'un nouvel auteur dans la table auteur
        public void insertionAuteur(auteur wAuteur)
        {
            _auteur.Add(wAuteur);
            CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Ajouter_Auteur";
            CmdSql.CommandType = CommandType.StoredProcedure;
            CmdSql.Connection = _connexion.laConnection;

            //mise en place des paramètres
            foreach (auteur unAuteur in _auteur)
            {
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Nom", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Nom"].Value = unAuteur.nom;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Prenom", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Prenom"].Value = unAuteur.prenom;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Pseudo", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Pseudo"].Value = unAuteur.pseudo;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Naiss", MySqlDbType.DateTime));
                CmdSql.Parameters["Auteur_Naiss"].Value = unAuteur.naissance;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Deces", MySqlDbType.DateTime));
                CmdSql.Parameters["Auteur_Deces"].Value = unAuteur.deces;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Pays", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Pays"].Value = unAuteur.pays;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Bio", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Bio"].Value = unAuteur.bio;
            }

            Execution();
        }


        //modification d'un auteur dans la table auteur
        public void modificationAuteur(auteur wAuteur)
        {
            _auteur.Add(wAuteur);
            CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Modifier_Auteur";
            CmdSql.CommandType = CommandType.StoredProcedure;
            CmdSql.Connection = _connexion.laConnection;

            //mise en place des paramètres
            foreach (auteur unAuteur in _auteur)
            {
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Id", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Id"].Value = unAuteur.Id;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Nom", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Nom"].Value = unAuteur.nom;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Prenom", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Prenom"].Value = unAuteur.prenom;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Pseudo", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Pseudo"].Value = unAuteur.pseudo;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Naiss", MySqlDbType.DateTime));
                CmdSql.Parameters["Auteur_Naiss"].Value = unAuteur.naissance;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Deces", MySqlDbType.DateTime));
                CmdSql.Parameters["Auteur_Deces"].Value = unAuteur.deces;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Pays", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Pays"].Value = unAuteur.pays;
                CmdSql.Parameters.Add(new MySqlParameter("Auteur_Bio", MySqlDbType.String));
                CmdSql.Parameters["Auteur_Bio"].Value = unAuteur.bio;
            }

            Execution();

        }
        public void AjouterAuteurLivre(auteur wAuteur)
        {
            _auteur.Add(wAuteur);
            CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Ajouter_Livre_Auteur";
            CmdSql.CommandType = CommandType.StoredProcedure;
            CmdSql.Connection = _connexion.laConnection;

            //mise en place des paramètres
            foreach (auteur unAuteur in _auteur)
            {
                CmdSql.Parameters.Add(new MySqlParameter("_numbd", MySqlDbType.Int32));
                CmdSql.Parameters["_numbd"].Value =unAuteur.wnumBd;
                CmdSql.Parameters.Add(new MySqlParameter("_numparticipant", MySqlDbType.Int32));
                CmdSql.Parameters["_numparticipant"].Value = unAuteur.wnumParticipant;
                CmdSql.Parameters.Add(new MySqlParameter("_numtype", MySqlDbType.Int32));
                CmdSql.Parameters["_numtype"].Value = unAuteur.wnumType;
            
            }

            Execution();

        }
        public int GetNumAuteur(string _nom)
        {
            initProc("Afficher_NumAuteurEnFctionNom");
            _connexion.OuvrirConnexion();
            int a;
            a = 0;
            MySqlDataReader unReader;
            CmdSql.Parameters.Add(new MySqlParameter("wnom", MySqlDbType.String));
            CmdSql.Parameters["wnom"].Value = _nom;


            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                a = unReader.GetInt32(0);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();

            return a;
        }
        public List<auteur> listAuteur()
        {

            
            List<auteur> uneListe;
            uneListe = new List<auteur>();
          // _auteur.Add(wAuteur);
            CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Afficher_Auteur";
            CmdSql.CommandType = CommandType.StoredProcedure;
            CmdSql.Connection = _connexion.laConnection;
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            auteur unAuteur;
            while (unReader.Read())
            {
                if (unReader.GetValue(4).ToString() == "") //pas de date naissance ni décès
                {
                    unAuteur = new auteur(unReader.GetInt16(0), unReader.GetString(1), unReader.GetString(2), unReader.GetValue(3).ToString(), unReader.GetString(6), unReader.GetValue(7).ToString());

                }
                else if (unReader.GetValue(5).ToString() == "") //pas de date décès
                {
                    unAuteur = new auteur(unReader.GetInt16(0), unReader.GetString(1), unReader.GetString(2), unReader.GetValue(3).ToString(), unReader.GetDateTime(4), unReader.GetString(6), unReader.GetValue(7).ToString());
                }
                else
                {
                    unAuteur = new auteur(unReader.GetInt16(0), unReader.GetString(1), unReader.GetString(2), unReader.GetValue(3).ToString(), unReader.GetDateTime(4), unReader.GetDateTime(5), unReader.GetString(6), unReader.GetValue(7).ToString());
                }


                uneListe.Add(unAuteur);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }

        public List<auteur> uneListeAuteur(String nom, String pseudo)
        {
            uneListe = new List<auteur>();

            CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Rechercher_Auteur";
            CmdSql.CommandType = CommandType.StoredProcedure;
            CmdSql.Connection = _connexion.laConnection;

            _connexion.OuvrirConnexion();

            CmdSql.Parameters.Add(new MySqlParameter("Auteur_Nom", MySqlDbType.String));
            CmdSql.Parameters["Auteur_Nom"].Value = nom;
            CmdSql.Parameters.Add(new MySqlParameter("Auteur_pseudo", MySqlDbType.String));
            CmdSql.Parameters["Auteur_pseudo"].Value = pseudo;

            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                auteur unAuteur = new auteur(unReader.GetString(1), unReader.GetValue(3).ToString());
            }

            _connexion.fermerConnexion();
            return uneListe;
        }

        #endregion
    }
}

