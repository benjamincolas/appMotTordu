using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Exemplaire
    {
        #region propriétés 
        private string Exemp_ref;
        private string etat_ref;
        private int idBd;
        private string motif;
        private DateTime Date;
        private Emprunteur unEmprunteur;
        private string titre;
        private int nbExemp;
        #endregion
        #region constructeurs
        public Exemplaire( string _Exemp_ref,string _etat_ref,int _idBd) {
            Exemp_ref = _Exemp_ref;
            etat_ref = _etat_ref;
            idBd = _idBd;
        
        }
        public Exemplaire(string _Exemp_ref, string _motif)
        {
            Exemp_ref = _Exemp_ref;
            motif = _motif;

        }

        public Exemplaire(string _Exemp_ref, string _etat_ref, string _TitreBd)
        {
            Exemp_ref = _Exemp_ref;
            etat_ref = _etat_ref;
            titre = _TitreBd;
           
        }
        public Exemplaire(string _Exemp_ref)
        {
            Exemp_ref = _Exemp_ref;
        

        }
        public Exemplaire(string _Exemp_ref, DateTime _date,Emprunteur unEmprunteur)
        {
            Exemp_ref = _Exemp_ref;
            Date = _date;
            this.unEmprunteur = unEmprunteur;
            
        }
        //public Exemplaire(string _Exemp_ref, string _etat_ref)
        //{
        //    Exemp_ref = _Exemp_ref;
        //    etat_ref = _etat_ref;
        //}
   
        public Exemplaire(string _Exemp_ref, DateTime _date)
        {
            Date = _date;
            Exemp_ref = _Exemp_ref;
        }
        public Exemplaire(string _titre, int _nbExemp)
        {
             titre= _titre;
            nbExemp = _nbExemp;
        }
        #endregion
        #region méhthodes
        public string wBdTitre//retourne et modifie le titre
        {
            get { return titre; }
            set { titre = value; }
        }
        public int wBdnbExemp//retourne et modifie le nombre d'exemplaire
        {
            get { return nbExemp; }
            set { nbExemp = value; }
        }
        public string wBdEmpRef//retourne et modifie la référence de l'exemplaire
        {
            get { return Exemp_ref; }
            set { Exemp_ref = value; }
        }
        public DateTime wBdDate//retourne et modifie une date 
        {
            get { return Date; }
            set { Date = value; }
        }
        public Emprunteur wBdUnEmprunteur//retourne et modifie l'emprunteur
        {
            get { return unEmprunteur; }
            set { unEmprunteur = value; }
        }
        public string wBdEtatRef//retourne et modifie l'état de l'exemplaire
        {
            get { return etat_ref; }
            set { etat_ref = value; }
        }
        public string wBdMotif//retourne et modifie le motif
        {
            get { return motif; }
            set { motif = value; }
        }
        public int wbdId//retourne et modifie l'id de la bd 
        {
            get { return idBd; }
            set { idBd = value; }
        }
    }
}
#endregion