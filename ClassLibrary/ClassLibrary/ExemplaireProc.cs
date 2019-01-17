using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ExemplaireProc
    {
        #region propriétés
        private connexionBdd _connexion;
        private MySqlCommand CmdSql;
        private List<Exemplaire> _exemplaire;
        #endregion
        #region constructeur
        public ExemplaireProc()
        {
            _connexion = new connexionBdd(); //instancie une nouvelle connexion

        }
        #endregion
        #region méthodes
        public void exec()
        {
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            //execution de la requête
            CmdSql.ExecuteNonQuery();
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
        }//éxecute la procédure stockée
        public void initProc(String nomProc)
        {
            //création objet Command et association à la Ps
            CmdSql = new MySqlCommand();
            CmdSql.CommandText = nomProc;
            CmdSql.CommandType = CommandType.StoredProcedure;
            CmdSql.Connection = _connexion.laConnection;
        }//initialise la procédure stockée
        public void AjouterExemplaire(Exemplaire unExemplaire)
        {
           
            initProc("Ajouter_Exemplaire_Livre");

          
                //    MySqlCommand CmdSql = new MySqlCommand();
                //CmdSql.CommandText = "Ajouter_Exemplaire_Livre";
                //CmdSql.CommandType = CommandType.StoredProcedure;

                CmdSql.Parameters.Add(new MySqlParameter("idBd", MySqlDbType.Int32));
                CmdSql.Parameters["idBd"].Value = unExemplaire.wbdId;
                CmdSql.Parameters.Add(new MySqlParameter("wetat", MySqlDbType.String));
                CmdSql.Parameters["wetat"].Value = unExemplaire.wBdEtatRef;
                CmdSql.Parameters.Add(new MySqlParameter("wref", MySqlDbType.String));
                CmdSql.Parameters["wref"].Value = unExemplaire.wBdEmpRef;
            
            exec();

        }//ajoute un exemplaire
        public void ModifierEtatExemplaire(Exemplaire unExemplaire)
        {
            initProc("Modifier_Etat_Exemplaire");

            CmdSql.Parameters.Add(new MySqlParameter("wEtat", MySqlDbType.String));
            CmdSql.Parameters["wEtat"].Value = unExemplaire.wBdMotif;
            CmdSql.Parameters.Add(new MySqlParameter("wref", MySqlDbType.String));
            CmdSql.Parameters["wRef"].Value = unExemplaire.wBdEmpRef;
            exec();

        }//modifie l'état d'un exemplaire
        public void SupprimerExemplaire(Exemplaire unExemplaire)
        {
            initProc("Supprimer_Exemplaire_Livre");


            CmdSql.Parameters.Add(new MySqlParameter("wref", MySqlDbType.String));
            CmdSql.Parameters["wref"].Value = unExemplaire.wBdEmpRef;
            CmdSql.Parameters.Add(new MySqlParameter("wmotif", MySqlDbType.String));
            CmdSql.Parameters["wmotif"].Value = unExemplaire.wBdMotif;
            exec();

        }//supprime un exemplaire
        public void Supprimer_ExemplaireEmprunté(Exemplaire unExemplaire)
        {
            initProc("Supprimer_ExemplaireEmprunté");


            CmdSql.Parameters.Add(new MySqlParameter("wref", MySqlDbType.String));
            CmdSql.Parameters["wref"].Value = unExemplaire.wBdEmpRef;
           
            exec();

        }//supprime un exemplaire emprunté dans la classe emprunter
        public void DateRetourExemplaire(Exemplaire unExemplaire)
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "DateRetour_Exemplaire";
            CmdSql.CommandType = CommandType.StoredProcedure;

            CmdSql.Parameters.Add(new MySqlParameter("widRefEmpl", MySqlDbType.String));
            CmdSql.Parameters["widRefEmpl"].Value = unExemplaire.wBdEmpRef;
            exec();


        }//ajoute une date de retour pour un exemplaire 
        public void AfficherNombreExemplairelivre()
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Afficher_Nombre_Exemplaire_livre";
            CmdSql.CommandType = CommandType.StoredProcedure;

            exec();


        }//affiche pour chaque livre le nombre d'exemplaire de celui ci 
        public void AfficherLivreSansCouv()
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Afficher_Livre_Sans_Couv";
            CmdSql.CommandType = CommandType.StoredProcedure;

            exec();


        }//affiche tous les exemplaires 
        public void AfficherExemplairesTresAbimes()
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Afficher_Exemplaires_Tres_Abimes";
            CmdSql.CommandType = CommandType.StoredProcedure;

            exec();


        }//affiche les exemplaire très abimés
        public void AfficherNomAuteur()
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Afficher_NomAuteur";
            CmdSql.CommandType = CommandType.StoredProcedure;


            exec();


        }//affiche le nom de l'auteur
        public void AfficherNomEditeur()
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Afficher_NomEditeur";
            CmdSql.CommandType = CommandType.StoredProcedure;

            exec();


        }//affiche le nom de l'éditeur
        public void AfficherNomSerie()
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Afficher_NomSerie";
            CmdSql.CommandType = CommandType.StoredProcedure;

            exec();


        }//affiche le nom de la série
        public void AfficherExemplaireLivreEtEtat()
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Afficher_Exemplaire_Livre_et_Etat";
            CmdSql.CommandType = CommandType.StoredProcedure;

            exec();

        }//affiche tous les exemplaires inscit dans la base de données avec son état
        public void AjouterDateEmprunt(Exemplaire unExemplaire)
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Ajouter_DateEmprunt";
            CmdSql.CommandType = CommandType.StoredProcedure;

            CmdSql.Parameters.Add(new MySqlParameter("widEmpNum", MySqlDbType.Int32));
            CmdSql.Parameters["widEmpNum"].Value = unExemplaire.wBdUnEmprunteur.numEmp;
            CmdSql.Parameters.Add(new MySqlParameter("widRefExemplaire", MySqlDbType.String));
            CmdSql.Parameters["widRefExemplaire"].Value = unExemplaire.wBdEmpRef;
            CmdSql.Parameters.Add(new MySqlParameter("_date", MySqlDbType.DateTime));
            CmdSql.Parameters["_date"].Value = unExemplaire.wBdDate;
            exec();
        }//Define l'exemplaire saisie en exemplaire emprunté 
        public void LivresNonRendus()
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Livre_non_rendus";
            CmdSql.CommandType = CommandType.StoredProcedure;

            exec();
        }//affiche les livres non rendus malgré la date limite dépassée
        public List<Exemplaire> listExemplaireAbime()
        {
            List<Exemplaire> uneListe;
            uneListe = new List<Exemplaire>();
            initProc("Afficher_Exemplaires_Tres_Abimes");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Exemplaire unExemplaire = new Exemplaire(unReader.GetString(0), unReader.GetString(1));
                uneListe.Add(unExemplaire);

            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }//Liste les exemplaires très abimés
        public List<Exemplaire> listExempNonrendus()
        {
            List<Exemplaire> uneListe;
            uneListe = new List<Exemplaire>();
            initProc("Livre_non_rendus");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Exemplaire unExemplaire = new Exemplaire(unReader.GetString(0), unReader.GetDateTime(1));
                uneListe.Add(unExemplaire);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;

        }//Liste les exemplaires non rendus malgré date limite dépassée
        public List<Exemplaire> listExempNbLivre()
        {
            List<Exemplaire> uneListe;
            uneListe = new List<Exemplaire>();
            initProc("Afficher_Nombre_Exemplaire_livre");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Exemplaire unExemplaire = new Exemplaire(unReader.GetString(0), unReader.GetInt32(1));
                uneListe.Add(unExemplaire);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;

        }//liste nombre d'exemplaire par livre
        public List<auteur> ListNomAuteur()
        {
            List<auteur> uneListe;
            uneListe = new List<auteur>();
            initProc("Afficher_NomAuteur");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                auteur unAuteur = new auteur(unReader.GetString(0));
                uneListe.Add(unAuteur);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;

        }//Liste les noms auteurs
        public List<Editeur> ListNomEditeur()
        {
            List<Editeur> uneListe;
            uneListe = new List<Editeur>();
            initProc("Afficher_Editeur");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Editeur unEditeur = new Editeur(unReader.GetString(1));
                uneListe.Add(unEditeur);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;

        }//Liste les noms d'éditeurs
        public List<serie> ListNomSerie()
        {
            List<serie> uneListe;
            uneListe = new List<serie>();
            initProc("Afficher_NomSerie");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                serie uneSerie = new serie(unReader.GetString(0));
                uneListe.Add(uneSerie);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;

        }//Liste les noms de série
        public List<Exemplaire> ListExemplaire()
        {
            List<Exemplaire> uneListe;
            uneListe = new List<Exemplaire>();
            initProc("Afficher_Exemplaire_Livre_et_Etat");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Exemplaire unExemplaire = new Exemplaire(unReader.GetString(0), unReader.GetString(1), unReader.GetString(2));
                uneListe.Add(unExemplaire);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;

        }//liste les exemplaires
        public List<Exemplaire> Afficher_LivreEmprunter()
        {
            List<Exemplaire> uneListe;
            uneListe = new List<Exemplaire>();
            initProc("Afficher_LivreEmprunter");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Exemplaire unExemplaire = new Exemplaire(unReader.GetString(0), unReader.GetString(1));
                uneListe.Add(unExemplaire);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;

        }//liste les livres empruntés
        public List<Exemplaire> Afficher_LivreNonEmprunter()
        {
            List<Exemplaire> uneListe;
            uneListe = new List<Exemplaire>();
            initProc("Afficher_LivreNonEmprunter");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Exemplaire unExemplaire = new Exemplaire(unReader.GetString(0), unReader.GetString(1));
                uneListe.Add(unExemplaire);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;

        }//liste les exemplaires non empruntés

    }
}
#endregion