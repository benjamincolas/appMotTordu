using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class EmprunteurProc
    {
        // Propriétés
        private connexionBdd _connexion;
        private List<Emprunteur> _emprunteurs;
        private MySqlCommand CmdSql;

        #region Constructeur.s

        public EmprunteurProc()
        {
            _connexion = new connexionBdd();
            _emprunteurs = new List<Emprunteur>();
        }

        #endregion

        #region Méthode.s

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

        //cette méthode permet d'insérer un nouvelle entregistrement dans la table emprunteur
        public void AjouterEmprunteur(Emprunteur wEmprunteur)
        {
            _emprunteurs.Add(wEmprunteur);
            initProc("Ajouter_Emprunteur");
            foreach (Emprunteur unEmprunteur in _emprunteurs)
            {
                //mise en place des paramètres
                CmdSql.Parameters.Add(new MySqlParameter("wemp_nom", MySqlDbType.String));
                CmdSql.Parameters["wemp_nom"].Value = unEmprunteur.nomEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_prenom", MySqlDbType.String));
                CmdSql.Parameters["wemp_prenom"].Value = unEmprunteur.prenomEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_rue", MySqlDbType.String));
                CmdSql.Parameters["wemp_rue"].Value = unEmprunteur.rueEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_code_postal", MySqlDbType.String));
                CmdSql.Parameters["wemp_code_postal"].Value = unEmprunteur.codePostalEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_ville", MySqlDbType.String));
                CmdSql.Parameters["wemp_ville"].Value = unEmprunteur.villeEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_date_naiss", MySqlDbType.DateTime));
                CmdSql.Parameters["wemp_date_naiss"].Value = unEmprunteur.dateNaissEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_mail", MySqlDbType.String));
                CmdSql.Parameters["wemp_mail"].Value = unEmprunteur.mailEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_prem_adh", MySqlDbType.DateTime));
                CmdSql.Parameters["wemp_prem_adh"].Value = unEmprunteur.premEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_ren_adh", MySqlDbType.DateTime));
                CmdSql.Parameters["wemp_ren_adh"].Value = unEmprunteur.renEmp;
            }
            exec();
        }

        //cette méthode permet de modifier un entregistrement dans la table emprunteur
        public void ModifierEmprunteur(Emprunteur wEmprunteur)
        {
            _emprunteurs.Add(wEmprunteur);
            initProc("Modifier_Emprunteur");
            foreach (Emprunteur unEmprunteur in _emprunteurs)
            {
                //mise en place des paramètres
                CmdSql.Parameters.Add(new MySqlParameter("wemp_nom", MySqlDbType.String));
                CmdSql.Parameters["wemp_nom"].Value = unEmprunteur.nomEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_prenom", MySqlDbType.String));
                CmdSql.Parameters["wemp_prenom"].Value = unEmprunteur.prenomEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_rue", MySqlDbType.String));
                CmdSql.Parameters["wemp_rue"].Value = unEmprunteur.rueEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_code_postal", MySqlDbType.String));
                CmdSql.Parameters["wemp_code_postal"].Value = unEmprunteur.codePostalEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_ville", MySqlDbType.String));
                CmdSql.Parameters["wemp_ville"].Value = unEmprunteur.villeEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_date_naiss", MySqlDbType.Date));
                CmdSql.Parameters["wemp_date_naiss"].Value = unEmprunteur.dateNaissEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_mail", MySqlDbType.String));
                CmdSql.Parameters["wemp_mail"].Value = unEmprunteur.mailEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_prem_adh", MySqlDbType.Date));
                CmdSql.Parameters["wemp_prem_adh"].Value = unEmprunteur.premEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_ren_adh", MySqlDbType.Date));
                CmdSql.Parameters["wemp_ren_adh"].Value = unEmprunteur.renEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wemp_num", MySqlDbType.Int16));
                CmdSql.Parameters["wemp_num"].Value = unEmprunteur.numEmp;
            }
            exec();
        }

        //cette méthode permet de supprimer un entregistrement dans la table emprunteur
        public void SupprimerEmprunteur(Emprunteur wEmprunteur)
        {
            _emprunteurs.Add(wEmprunteur);
            initProc("Supprimer_Emprunteur");
            foreach (Emprunteur unEmprunteur in _emprunteurs)
            {
                //mise en place des paramètres
                CmdSql.Parameters.Add(new MySqlParameter("wemp_num", MySqlDbType.Int16));
                CmdSql.Parameters["wemp_num"].Value = unEmprunteur.numEmp;
                CmdSql.Parameters.Add(new MySqlParameter("wmotif_retrait", MySqlDbType.String));
                CmdSql.Parameters["wmotif_retrait"].Value = unEmprunteur.motifEmp;
            }
            exec();
        }

        public List<Emprunteur> listEmprunteur()
        {
            List<Emprunteur> uneListe;
            uneListe = new List<Emprunteur>();
            initProc("Afficher_Emprunteur");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Emprunteur unEmprunteur = new Emprunteur(unReader.GetInt16(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetString(4), unReader.GetString(5), unReader.GetDateTime(6), unReader.GetString(7), unReader.GetDateTime(8), unReader.GetDateTime(9));
                uneListe.Add(unEmprunteur);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }

        public List<Emprunteur> unelistEmprunteur(String id, String nom)
        {
            int? n = 0; // ? signifie que la variable n peut être null
            if(id == "")
            {
                n = null;
            }
            else
            {
                n = int.Parse(id);
            }
            List<Emprunteur> uneListe;
            uneListe = new List<Emprunteur>();
            initProc("Rechercher_Emprunteur");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();

            CmdSql.Parameters.Add(new MySqlParameter("wemp_num", MySqlDbType.Int16));
            CmdSql.Parameters["wemp_num"].Value = n;
            CmdSql.Parameters.Add(new MySqlParameter("wemp_nom", MySqlDbType.String));
            CmdSql.Parameters["wemp_nom"].Value = nom;

            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Emprunteur unEmprunteur = new Emprunteur(unReader.GetInt16(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetString(4), unReader.GetString(5), unReader.GetDateTime(6), unReader.GetString(7), unReader.GetDateTime(8), unReader.GetDateTime(9));
                uneListe.Add(unEmprunteur);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }

        //cette méthode permet d'insérer un nouvelle entregistrement dans la table emprunteur
        public void AjouterFamilleEmprunteur(Emprunteur wEmprunteur)
        {
            _emprunteurs.Add(wEmprunteur);
            initProc("Ajouter_Famille");
            foreach (Emprunteur unEmprunteur in _emprunteurs)
            {
                //mise en place des paramètres
                CmdSql.Parameters.Add(new MySqlParameter("numchef", MySqlDbType.String));
                CmdSql.Parameters["numchef"].Value = unEmprunteur.numResp;
                CmdSql.Parameters.Add(new MySqlParameter("num", MySqlDbType.String));
                CmdSql.Parameters["num"].Value = unEmprunteur.numEmp;
            }
            exec();
        }
        #endregion

    }
}
