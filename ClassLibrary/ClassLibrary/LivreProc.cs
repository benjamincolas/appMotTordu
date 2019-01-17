using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class LivreProc
    { //propriétée.s
        private connexionBdd _connexion;
        private MySqlCommand CmdSql;
        private List<Livre> _livre;
        private List<Livre> _livreSuppr;
        private int a;

        #region constructeur
        //constructeur de la classe livre 
        public LivreProc()
        {
            _connexion = new connexionBdd();
            _livre = new List<Livre>();
        }
        #endregion
        #region méthodes
        public void exec() //permet d'éxcuter la procédure
        {
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            //execution de la requête
            CmdSql.ExecuteNonQuery();
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
        }
        public void initProc(String nomProc)//permet d'initialiser une procédure stockées
        {
            //création objet Command et association à la Ps
            CmdSql = new MySqlCommand();
            CmdSql.CommandText = nomProc;
            CmdSql.CommandType = CommandType.StoredProcedure;
            CmdSql.Connection = _connexion.laConnection;
        }
        public void AjouterLivre(Livre unLivre)//permet d'ajouter un livre a la base de données
        {
           
            initProc("Ajouter_Livre");
           


                CmdSql.Parameters.Add(new MySqlParameter("TitreBd", MySqlDbType.String));
                CmdSql.Parameters["TitreBd"].Value = unLivre.wBdTitre;
                CmdSql.Parameters.Add(new MySqlParameter("IsbnBd", MySqlDbType.String));
                CmdSql.Parameters["IsbnBd"].Value = unLivre.wBdIsbn;
                CmdSql.Parameters.Add(new MySqlParameter("TomeBd", MySqlDbType.String));
                CmdSql.Parameters["TomeBd"].Value = unLivre.wBdTome;
                CmdSql.Parameters.Add(new MySqlParameter("ParutionBd", MySqlDbType.String));
                CmdSql.Parameters["ParutionBd"].Value = unLivre.wBdParution;
                CmdSql.Parameters.Add(new MySqlParameter("NbPagesBd", MySqlDbType.Int32));
                CmdSql.Parameters["NbPagesBd"].Value = unLivre.wBdPages;
                CmdSql.Parameters.Add(new MySqlParameter("ImageBd", MySqlDbType.String));
                CmdSql.Parameters["ImageBd"].Value = unLivre.wBdImage;
                CmdSql.Parameters.Add(new MySqlParameter("CouleurBd", MySqlDbType.String));
                CmdSql.Parameters["CouleurBd"].Value = unLivre.wBdCouleur;
                CmdSql.Parameters.Add(new MySqlParameter("CommentairesBd", MySqlDbType.String));
                CmdSql.Parameters["CommentairesBd"].Value = unLivre.wBdCommentaires;
                CmdSql.Parameters.Add(new MySqlParameter("FormatBd", MySqlDbType.String));
                CmdSql.Parameters["FormatBd"].Value = unLivre.wBdFormat;
                CmdSql.Parameters.Add(new MySqlParameter("SerieNum", MySqlDbType.Int32));
                CmdSql.Parameters["SerieNum"].Value = unLivre.wBdNumSerie;
                CmdSql.Parameters.Add(new MySqlParameter("editeurNum", MySqlDbType.Int32));
                CmdSql.Parameters["editeurNum"].Value = unLivre.wBdNumEditeur;
            
            exec();
        }
        public int Afficher_idBd_enFctionNom(string wtitre)//donne l'ID en fonction du nom
        {
            initProc("Afficher_idBd_enFctionNom");

           
            _connexion.OuvrirConnexion();
            int a;
            a = 0;
            MySqlDataReader unReader;
            CmdSql.Parameters.Add(new MySqlParameter("wtitre", MySqlDbType.String));
            CmdSql.Parameters["wtitre"].Value = wtitre;


            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                a = unReader.GetInt32(0);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();

            return a;
        }
        public List<Livre> listBdTitre()//donne une liste de titre de livre
        {
            List<Livre> uneListe;
            uneListe = new List<Livre>();
            initProc("Afficher_TitreBD");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Livre unLivre = new Livre(unReader.GetString(0));
                uneListe.Add(unLivre);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;

        }
        public void ModifierLivre(Livre unLivre)//permet de modifier un livre
        {
          
            initProc("Modifier_Livre");
           
            
                CmdSql.Parameters.Add(new MySqlParameter("TitreBd", MySqlDbType.String));
                CmdSql.Parameters["TitreBd"].Value = unLivre.wBdTitre;
                CmdSql.Parameters.Add(new MySqlParameter("IsbnBd", MySqlDbType.String));
                CmdSql.Parameters["IsbnBd"].Value = unLivre.wBdIsbn;
                CmdSql.Parameters.Add(new MySqlParameter("TomeBd", MySqlDbType.String));
                CmdSql.Parameters["TomeBd"].Value = unLivre.wBdTome;
                CmdSql.Parameters.Add(new MySqlParameter("ParutionBd", MySqlDbType.String));
                CmdSql.Parameters["ParutionBd"].Value = unLivre.wBdParution;
                CmdSql.Parameters.Add(new MySqlParameter("NbPagesBd", MySqlDbType.Int32));
                CmdSql.Parameters["NbPagesBd"].Value = unLivre.wBdPages;
                CmdSql.Parameters.Add(new MySqlParameter("ImageBd", MySqlDbType.String));
                CmdSql.Parameters["ImageBd"].Value = unLivre.wBdImage;
                CmdSql.Parameters.Add(new MySqlParameter("CouleurBd", MySqlDbType.String));
                CmdSql.Parameters["CouleurBd"].Value = unLivre.wBdCouleur;
                CmdSql.Parameters.Add(new MySqlParameter("CommentairesBd", MySqlDbType.String));
                CmdSql.Parameters["CommentairesBd"].Value = unLivre.wBdCommentaires;
                CmdSql.Parameters.Add(new MySqlParameter("FormatBd", MySqlDbType.String));
                CmdSql.Parameters["FormatBd"].Value = unLivre.wBdFormat;
                CmdSql.Parameters.Add(new MySqlParameter("SerieNum", MySqlDbType.Int32));
                CmdSql.Parameters["SerieNum"].Value = unLivre.wBdNumSerie;
                CmdSql.Parameters.Add(new MySqlParameter("editeurNum", MySqlDbType.Int32));
                CmdSql.Parameters["editeurNum"].Value = unLivre.wBdNumEditeur;
                CmdSql.Parameters.Add(new MySqlParameter("wbdId", MySqlDbType.Int32));
                CmdSql.Parameters["wbdId"].Value = unLivre.wBdID;
            
            exec();
        }
        public void SupprimerLivre(Livre leLivre)
        {
            _livreSuppr.Add(leLivre);

            foreach (Livre unLivre in _livreSuppr)
            {
                initProc("Supprimer_Livre");


                MySqlCommand CmdSql = new MySqlCommand();
                CmdSql.CommandText = "Supprimer_Livre";
                CmdSql.CommandType = CommandType.StoredProcedure;


                CmdSql.Parameters.Add(new MySqlParameter("wmotif", MySqlDbType.String));
                CmdSql.Parameters["wmotif"].Value = unLivre.wBdMotif;//unLivre.wBdMotif;
                CmdSql.Parameters.Add(new MySqlParameter("wid", MySqlDbType.Int32));
                CmdSql.Parameters["wid"].Value = unLivre.wBdID;
            }
            exec();
        }//permet de supprimer un livre
        public void RechercheLivre(Livre unLivre)//permet de rechercher un livre
        {
            MySqlCommand CmdSql = new MySqlCommand();
            CmdSql.CommandText = "Rechercher_Livre";
            CmdSql.CommandType = CommandType.StoredProcedure;

            CmdSql.Parameters.Add(new MySqlParameter("wdate", MySqlDbType.String));
            CmdSql.Parameters["wdate"].Value = unLivre.wBdParution;
            CmdSql.Parameters.Add(new MySqlParameter("wtitre", MySqlDbType.String));
            CmdSql.Parameters["wtitre"].Value = unLivre.wBdTitre;
            exec();

        }
        public string Afficher_SerieISBN(string codeIsbn) //Donne la série d'un livre en fonction de son code ISBN
        {
            initProc("Afficher_SerieISBN");

            CmdSql.Parameters.Add(new MySqlParameter("codeIsbn", MySqlDbType.String));
            CmdSql.Parameters["codeIsbn"].Value = codeIsbn;
         
            exec();
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            string a;
            a = "";
            while (unReader.Read())
            {
                a = unReader.GetString(0);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return a;

        }
        public string Afficher_auteursDessins(string codeIsbn) // donne l'auteur d'un livre en fonction de son code isbn
        {
            initProc("Afficher_auteursDessins");

            CmdSql.Parameters.Add(new MySqlParameter("codeIsbn", MySqlDbType.String));
            CmdSql.Parameters["codeIsbn"].Value = codeIsbn;

            exec();
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            string a;
            a = "";
            while (unReader.Read())
            {
                a = unReader.GetString(0);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return a;

        }
        public string Afficher_auteurScenario(string codeIsbn)//donne l'auteur des scénarios d'un livre en fonction de son code isbn
        {
            initProc("Afficher_auteurScenario");

            CmdSql.Parameters.Add(new MySqlParameter("codeIsbn", MySqlDbType.String));
            CmdSql.Parameters["codeIsbn"].Value = codeIsbn;

            exec();
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            string a;
            a = "";
            while (unReader.Read())
            {
                a = unReader.GetString(0);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return a;

        }
        public string Afficher_EditeurISBN(string codeIsbn)//donne l'editeur d'un livre en fonction  de son code isbn
        {
            initProc("Afficher_EditeurISBN");

            CmdSql.Parameters.Add(new MySqlParameter("codeIsbn", MySqlDbType.String));
            CmdSql.Parameters["codeIsbn"].Value = codeIsbn;

            exec();
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            string a;
            a = "";
            while (unReader.Read())
            {
                a = unReader.GetString(0);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return a;
        }
        public List<Livre> listLivre() // liste tout les livres présent dans la base de données
        {
            List<Livre> uneListe;
            uneListe = new List<Livre>();
            initProc("Afficher_Livres");
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Livre unLivre = new Livre(unReader.GetString(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetInt32(4), unReader.GetString(5), unReader.GetString(6), unReader.GetString(7), unReader.GetString(8), unReader.GetInt32(9), unReader.GetInt32(10), unReader.GetInt32(11));
                uneListe.Add(unLivre);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }
        public List<Livre> listRechercheLivre(Livre wLivre)//Liste tous les livres obtenu par la procédure stockée "recherche_livre"
        {

            List<Livre> uneListe;
            uneListe = new List<Livre>();
            initProc("Rechercher_Livre");

            CmdSql.Parameters.Add(new MySqlParameter("wdate", MySqlDbType.String));
            CmdSql.Parameters["wdate"].Value = wLivre.wBdParution;
            CmdSql.Parameters.Add(new MySqlParameter("wtitre", MySqlDbType.String));
            CmdSql.Parameters["wtitre"].Value = wLivre.wBdTitre;
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Livre unLivre = new Livre(unReader.GetString(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetInt32(4), unReader.GetString(5), unReader.GetString(6), unReader.GetString(7), unReader.GetString(8), unReader.GetInt32(9), unReader.GetInt32(10), unReader.GetInt32(11));
                uneListe.Add(unLivre);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }
        public List<Livre> listRechercheNomLivre(Livre wLivre)//Liste tous les livres obtenu avec le nom saisi
        {

            List<Livre> uneListe;
            uneListe = new List<Livre>();
            initProc("Rechercher_NomLivre");

        
            CmdSql.Parameters.Add(new MySqlParameter("wtitre", MySqlDbType.String));
            CmdSql.Parameters["wtitre"].Value = wLivre.wBdTitre;
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Livre unLivre = new Livre(unReader.GetString(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetInt32(4), unReader.GetString(5), unReader.GetString(6), unReader.GetString(7), unReader.GetString(8), unReader.GetInt32(9), unReader.GetInt32(10));
                uneListe.Add(unLivre);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }
        public List<Livre> Recherche_Date_Livre(Livre wLivre)//liste les livres obtenu avec la date saisi
        {

            List<Livre> uneListe;
            uneListe = new List<Livre>();
            initProc("Recherche_Date_Livre");


            CmdSql.Parameters.Add(new MySqlParameter("wdate", MySqlDbType.String));
            CmdSql.Parameters["wdate"].Value = wLivre.wBdTitre;
            //on ouvre la connection à la base de données
            _connexion.OuvrirConnexion();
            MySqlDataReader unReader;
            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                Livre unLivre = new Livre(unReader.GetString(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetInt32(4), unReader.GetString(5), unReader.GetString(6), unReader.GetString(7), unReader.GetString(8), unReader.GetInt32(9), unReader.GetInt32(10));
                uneListe.Add(unLivre);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();
            return uneListe;
        }
        //public List<Livre> listRechercheNomLivre(Livre wLivre)
        //{

        //    List<Livre> uneListe;
        //    uneListe = new List<Livre>();
        //    initProc("Rechercher_Livre");

        //    CmdSql.Parameters.Add(new MySqlParameter("wdate", MySqlDbType.String));
        //    CmdSql.Parameters["wdate"].Value = wLivre.wBdParution;
        //    CmdSql.Parameters.Add(new MySqlParameter("wtitre", MySqlDbType.String));
        //    CmdSql.Parameters["wtitre"].Value = wLivre.wBdTitre;
        //    //on ouvre la connection à la base de données
        //    _connexion.OuvrirConnexion();
        //    MySqlDataReader unReader;
        //    unReader = CmdSql.ExecuteReader();
        //    while (unReader.Read())
        //    {
        //        Livre unLivre = new Livre(unReader.GetString(0), unReader.GetString(1), unReader.GetString(2), unReader.GetString(3), unReader.GetInt32(4), unReader.GetString(5), unReader.GetString(6), unReader.GetString(7), unReader.GetString(8), unReader.GetInt32(9), unReader.GetInt32(10));
        //        uneListe.Add(unLivre);
        //    }
        //    //on ferme la connection à la base de données
        //    _connexion.fermerConnexion();
        //    return uneListe;
        //}

        public int GetId(string _ISBN)
        {
            initProc("Afficher_ID");
            _connexion.OuvrirConnexion();
            int a;
            a = 0;
            MySqlDataReader unReader;
            CmdSql.Parameters.Add(new MySqlParameter("CodeIsbn", MySqlDbType.String));
            CmdSql.Parameters["CodeIsbn"].Value = _ISBN;


            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                a = unReader.GetInt32(0);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();

            return a;
        }//permet d'avoir l'id d'une bd en fonction d'un code isbn
        public int GetNumEditeur(string _nom)
        {
            initProc("Afficher_NumEditeur");
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
        }//permet d'avoir le numéro de l'éditeur en fonction de son nom
        public int GetNumSerier(string _nom)
        {
            initProc("Afficher_NumSerie");
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
        }//permet d'avoir le numéro de série en fonction de son nom
        public string getNomEditeur(int _num)
        {
            initProc("Afficher_NomEditeurEnFctionNum");
            _connexion.OuvrirConnexion();
            string a;
            a = "";
            MySqlDataReader unReader;
            CmdSql.Parameters.Add(new MySqlParameter("wnum", MySqlDbType.Int32));
            CmdSql.Parameters["wnum"].Value = _num;


            unReader = CmdSql.ExecuteReader();
            while (unReader.Read())
            {
                a = unReader.GetString(0);
            }
            //on ferme la connection à la base de données
            _connexion.fermerConnexion();

            return a;
        }//permet d'avoir le nom de l'editeur en fonction de son numéro
    }
}
#endregion