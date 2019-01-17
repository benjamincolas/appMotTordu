using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary
{
    public class utilisateursProc
    {
        //propriétées
        private connexionBdd _connexion;
        private List<utilisateurs> _utilisateurs;
        private MySqlCommand CmdSql;
        private String _niveau;

        #region contructeur.s
        //constructeur de la class commande sans paramètre
        public utilisateursProc()
        {
            _connexion = new connexionBdd();
            _utilisateurs = new List<utilisateurs>();
        }
        #endregion

        #region méthode.s

        public String niveau
        {
            get { return _niveau; }
            set { _niveau = value; }
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
        //cette méthode permet d'insérer un nouvelle entregistrement dans la table commande
        public void ajoutUtilisateur(utilisateurs wUtilisateur)
        {
            _utilisateurs.Add(wUtilisateur);
            initProc("Ajouter_Utilisateur");
            foreach (utilisateurs unUtilisateur in _utilisateurs)
            {
                //mise en place des paramètres
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_prenom", MySqlDbType.String));
                CmdSql.Parameters["wUtil_prenom"].Value = unUtilisateur.prenom;
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_nom", MySqlDbType.String));
                CmdSql.Parameters["wUtil_nom"].Value = unUtilisateur.nom;
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_pseudo", MySqlDbType.String));
                CmdSql.Parameters["wUtil_pseudo"].Value = unUtilisateur.pseudo;
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_password", MySqlDbType.String));
                CmdSql.Parameters["wUtil_password"].Value = unUtilisateur.password;
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_niveau", MySqlDbType.String));
                CmdSql.Parameters["wUtil_niveau"].Value = unUtilisateur.niveau;
            }
            exec();
        }

        //cette méthode permet de modifier un entregistrement de la table commande
        public void modifUtilisateur(utilisateurs wUtilisateur)
        {
            _utilisateurs.Add(wUtilisateur);
            initProc("Modifier_Utilisateur");
            foreach (utilisateurs unUtilisateur in _utilisateurs)
            {
                //mise en place des paramètres
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_pseudo", MySqlDbType.String));
                CmdSql.Parameters["wUtil_pseudo"].Value = unUtilisateur.pseudo;
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_password", MySqlDbType.String));
                CmdSql.Parameters["wUtil_password"].Value = unUtilisateur.password;
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_niveau", MySqlDbType.String));
                CmdSql.Parameters["wUtil_niveau"].Value = unUtilisateur.niveau;
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_nom", MySqlDbType.String));
                CmdSql.Parameters["wUtil_nom"].Value = unUtilisateur.nom;
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_id", MySqlDbType.Int16));
                CmdSql.Parameters["wUtil_id"].Value = unUtilisateur.id;
            }
            exec();
        }

        //cette méthode permet de supprimer un entregistrement de la table commande
        public void supprUtilisateur(utilisateurs wUtilisateur)
        {
            _utilisateurs.Add(wUtilisateur);
            initProc("Supprimer_Utilisateur");
            foreach (utilisateurs unUtilisateur in _utilisateurs)
            {
                //mise en place des paramètres
                CmdSql.Parameters.Add(new MySqlParameter("wUtil_id", MySqlDbType.Int16));
                CmdSql.Parameters["wUtil_id"].Value = unUtilisateur.id;
            }
            exec();
        }

        public void connectApp(utilisateurs wUtilisateur)
        {
            _utilisateurs.Add(wUtilisateur);
            initProc("Connexion_Application");
            foreach (utilisateurs unUtilisateur in _utilisateurs)
            {
                //mise en place des paramètres en entrée
                CmdSql.Parameters.Add(new MySqlParameter("wPseudo", MySqlDbType.String));
                CmdSql.Parameters["wPseudo"].Value = unUtilisateur.pseudo;
                CmdSql.Parameters.Add(new MySqlParameter("wPass", MySqlDbType.String));
                CmdSql.Parameters["wPass"].Value = unUtilisateur.password;
                //mise en place des paramètres en sortie
                MySqlParameter PSortie_niv = new MySqlParameter("wUtil_niveau", MySqlDbType.String);
                CmdSql.Parameters.Add(PSortie_niv);
                PSortie_niv.Direction = ParameterDirection.Output;
                exec();
                _niveau = PSortie_niv.Value.ToString();
            }
        }

        public List<utilisateurs> listUtilisateur()
        {
            List<utilisateurs> uneListe;
            uneListe = new List<utilisateurs>();
            initProc("Afficher_Utilisateur");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                utilisateurs unUtilisateur = new utilisateurs(unReader.GetInt16(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetString(4), unReader.GetString(5));
                uneListe.Add(unUtilisateur);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }
        #endregion
    }
}
