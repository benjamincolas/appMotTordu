using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Livre
    {
        #region propriétés
        //propriétée.s
        private int BdId;
        private string BdTitre;
        private string BdIsbn;
        private string BdTome;
        private string BdParution;
        private int BdNbPages;
        private string BdImage;
        private string BdCouleur;
        private string BdCommentaires;
        private string BdFormat;
        private int BdNumSerie;
        private int BdNumEditeur;
        private string motif;
        #endregion
        #region constructeur.s
        //constructeur.s de la classe livre 
        public Livre(int _BdId, string _motif)
        {
            BdId = _BdId;
            motif = _motif;
        }


        public Livre(string _BdTitre, string _BdIsbn, string _BdTome, string _BdParution, int _BdNbPages, string _BdImage, string _BdCouleur, string _BdCommentaires, string _bdFormat, int _BdNumSerie, int _BdNumEditeur)
        {

            BdTitre = _BdTitre;
            BdIsbn = _BdIsbn;
            BdTome = _BdTome;
            BdParution = _BdParution;
            BdNbPages = _BdNbPages;
            BdImage = _BdImage;
            BdCouleur = _BdCouleur;
            BdCommentaires = _BdCommentaires;
            BdFormat = _bdFormat;
            BdNumSerie = _BdNumSerie;
            BdNumEditeur = _BdNumEditeur;
         
        }
        public Livre( string _BdTitre, string _BdIsbn, string _BdTome, string _BdParution, int _BdNbPages, string _BdImage, string _BdCouleur, string _BdCommentaires, string _bdFormat, int _BdNumSerie, int _BdNumEditeur,int _BdId)
        {
            
            BdTitre = _BdTitre;
            BdIsbn = _BdIsbn;
            BdTome = _BdTome;
            BdParution = _BdParution;
            BdNbPages = _BdNbPages;
            BdImage = _BdImage;
            BdCouleur = _BdCouleur;
            BdCommentaires = _BdCommentaires;
            BdFormat = _bdFormat;
            BdNumSerie = _BdNumSerie;
            BdNumEditeur = _BdNumEditeur;
            BdId = _BdId;

        }
        public Livre(string _BdTitre,string _BdParution)
        {
            BdTitre = _BdTitre;
            BdParution = _BdParution;

        }
        public Livre(string _BdTitre)
        {
            BdTitre = _BdTitre;
          

        }
        
        //public Livre(string _BdTitre,string _BdIsbn,string _BdTome,string _BdParution,int _BdNbPages,string _BdImage,string _BdCouleur,string _BdCommentaires,string _bdFormat,int _BdNumSerie,int _BdNumEditeur,string _motif)
        //{

        //    BdTitre = _BdTitre;
        //    BdIsbn = _BdIsbn;
        //    BdTome = _BdTome;
        //    BdParution = _BdParution;
        //    BdNbPages = _BdNbPages;
        //    BdImage = _BdImage;
        //    BdCouleur = _BdCouleur;
        //    BdCommentaires = _BdCommentaires;
        //    BdFormat = _bdFormat;
        //    BdNumSerie = _BdNumSerie;
        //    BdNumEditeur = _BdNumEditeur;
        //    motif = _motif;

        //}

        #endregion
        #region méthode.s
        //gettter.s setter.s
        public int wBdID //retourne ou modifie l'id
        {
            get { return BdId; }
            set { BdId = value; }
        }

        public string wBdTitre//retourne ou modifie le titre
        {
            get { return BdTitre; }
            set { BdTitre = value; }
        }

        public string wBdIsbn//retourne ou modifie le code isbn
        {
            get { return BdIsbn; }
            set { BdIsbn = value; }
        }

        public string wBdTome//retourne ou modifie le tome
        {
            get { return BdTome; }
            set { BdTome = value; }
        }

        public string wBdParution//retourne ou modifie la date de parution
        {
            get { return BdParution; }
            set { BdParution = value; }
        }

        public int wBdPages//retourne ou modifie le nombre de page
        {
            get { return BdNbPages; }
            set { BdNbPages = value; }
        }
        public string wBdImage//retourne ou modifie l'image
        {
            get { return BdImage; }
            set { BdImage = value; }
        }
        public string wBdCouleur//retourne ou modifie la couleur du livre
        {
            get { return BdCouleur; }
            set { BdCouleur = value; }
        }
        public string wBdCommentaires//retourne ou modifie le commentaire
        {
            get { return BdCommentaires; }
            set { BdCommentaires = value; }
        }
        public string wBdFormat//retourne ou modifie le format
        {
            get { return BdFormat; }
            set { BdFormat = value; }
        }
        public int wBdNumSerie//retourne ou modifie le numéro de série
        {
            get { return BdNumSerie; }
            set { BdNumSerie = value; }
        }
        public int wBdNumEditeur//retourne ou modifie de l'éditeur
        {
            get { return BdNumEditeur; }
            set { BdNumEditeur = value; }
        }
        public string wBdMotif//retourne ou modifie le motif
        {
            get { return motif; }
            set { motif = value; }
        }
        #endregion
    }
}
