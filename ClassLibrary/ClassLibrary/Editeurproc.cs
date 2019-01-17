using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class Editeurproc
    {

        //propriétés
        private connexionBdd _connexion;
        private List<Editeur> _editeur;
        private MySqlCommand CmdSql;


        //constructeur
        public Editeurproc()
        {
            _connexion = new connexionBdd();
            _editeur = new List<Editeur>();
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


        //méthodes permettant d'ajouter un éditeur
        public void AjouterEditeur(Editeur wediteur)
        {
            _editeur.Add(wediteur);
            initProc("Ajouter_Editeur");
            foreach (Editeur unEditeur in _editeur)
            {
                CmdSql.Parameters.Add(new MySqlParameter("EditeurNomins", MySqlDbType.String));
                CmdSql.Parameters["EditeurNomins"].Value = unEditeur.wnom;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurAdresseins", MySqlDbType.String));
                CmdSql.Parameters["EditeurAdresseins"].Value = unEditeur.wadresse;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurCPins", MySqlDbType.String));
                CmdSql.Parameters["EditeurCPins"].Value = unEditeur.wcp;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurCreationins", MySqlDbType.Int32));
                CmdSql.Parameters["EditeurCreationins"].Value = unEditeur.wcreation;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurFaxins", MySqlDbType.String));
                CmdSql.Parameters["EditeurFaxins"].Value = unEditeur.wfax;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurMailins", MySqlDbType.String));
                CmdSql.Parameters["EditeurMailins"].Value = unEditeur.wmail;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurTelins", MySqlDbType.String));
                CmdSql.Parameters["EditeurTelins"].Value = unEditeur.wtel;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurVilleins", MySqlDbType.String));
                CmdSql.Parameters["EditeurVilleins"].Value = unEditeur.wville;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurNomContactins", MySqlDbType.String));
                CmdSql.Parameters["EditeurNomContactins"].Value = unEditeur.wnom_contact;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurPrenomContactins", MySqlDbType.String));
                CmdSql.Parameters["EditeurPrenomContactins"].Value = unEditeur.wprenom_contact;
            }
            exec();

        }

        //méthodes permettant de modifier un éditeur
        public void ModifierEditeur(Editeur wediteur)
        {
            _editeur.Add(wediteur);
            initProc("Modifier_Editeur");
            foreach (Editeur unEditeur in _editeur)
            {
                CmdSql.Parameters.Add(new MySqlParameter("EditeurNumup", MySqlDbType.Int32));
                CmdSql.Parameters["EditeurNumup"].Value = unEditeur.wnumero;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurNomup", MySqlDbType.String));
                CmdSql.Parameters["EditeurNomup"].Value = unEditeur.wnom;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurCreationup", MySqlDbType.Int32));
                CmdSql.Parameters["EditeurCreationup"].Value = unEditeur.wcreation;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurAdresseup", MySqlDbType.String));
                CmdSql.Parameters["EditeurAdresseup"].Value = unEditeur.wadresse;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurCPup", MySqlDbType.String));
                CmdSql.Parameters["EditeurCPup"].Value = unEditeur.wcp;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurVilleup", MySqlDbType.String));
                CmdSql.Parameters["EditeurVilleup"].Value = unEditeur.wville;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurTelup", MySqlDbType.String));
                CmdSql.Parameters["EditeurTelup"].Value = unEditeur.wtel;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurFaxup", MySqlDbType.String));
                CmdSql.Parameters["EditeurFaxup"].Value = unEditeur.wfax;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurMailup", MySqlDbType.String));
                CmdSql.Parameters["EditeurMailup"].Value = unEditeur.wmail;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurPrenomContactup", MySqlDbType.String));
                CmdSql.Parameters["EditeurPrenomContactup"].Value = unEditeur.wprenom_contact;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurNomContactup", MySqlDbType.String));
                CmdSql.Parameters["EditeurNomContactup"].Value = unEditeur.wnom_contact;
            }
            exec();
        }

        //méthodes permettant de supprimer un éditeur
        public void SupprimerEditeur(Editeur wediteur)
        {
            _editeur.Add(wediteur);
            initProc("Supprimer_Editeur");
            foreach (Editeur unEditeur in _editeur)
            {
                CmdSql.Parameters.Add(new MySqlParameter("EditeurNumdel", MySqlDbType.Int32));
                CmdSql.Parameters["EditeurNumdel"].Value = unEditeur.wnumero;
                CmdSql.Parameters.Add(new MySqlParameter("EditeurMotif", MySqlDbType.String));
                CmdSql.Parameters["EditeurMotif"].Value = unEditeur.wmotif;
            }
            exec();
        }

        //méthode permettant d'afficher tous les éditeurs
        public List<Editeur> listEditeur()
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
                Editeur unEditeur = new Editeur(unReader.GetInt32(0), unReader.GetString(1), unReader.GetInt32(2), unReader.GetString(3), unReader.GetString(4), unReader.GetString(5), unReader.GetString(6), unReader.GetString(7), unReader.GetString(8), unReader.GetString(9), unReader.GetString(10));
                uneListe.Add(unEditeur);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }


        //méthode permettant d'afficher les éditeurs recherchés
        public List<Editeur> rechercheEditeur(Editeur wEditeur)

        {
            List<Editeur> uneListe;
            uneListe = new List<Editeur>();
            initProc("Rechercher_Editeur");

            CmdSql.Parameters.Add(new MySqlParameter("EditeurNomRech", MySqlDbType.String));
            CmdSql.Parameters["EditeurNomRech"].Value = wEditeur.wnom;
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Editeur unEditeur = new Editeur(unReader.GetInt32(0), unReader.GetString(1), unReader.GetInt32(2), unReader.GetString(3), unReader.GetString(4), unReader.GetString(5), unReader.GetString(6), unReader.GetString(7), unReader.GetString(8), unReader.GetString(9), unReader.GetString(10));
                uneListe.Add(unEditeur);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }


    }
    }

