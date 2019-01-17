using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class auteur
    {
        //propriétés
        private int AuteurId;
        private String AuteurNom;
        private String AuteurPrenom;
        private String AuteurPseudo;
        private DateTime AuteurDateNaiss;
        private DateTime AuteurDeces;
        private String AuteurPays;
        private String AuteurBiographie;
        private int numbd;
        private int numParticipant;
        private int numType;
        #region constructeur
        //constructeur.s de la classe auteur
        public auteur(int wAuteurId, String wAuteurNom, String wAuteurPrenom, String wAuteurPseudo, DateTime wAuteurDateNaiss, DateTime wAuteurDeces, String wAuteurPays, String wAuteurBiographie)
        {
            AuteurId = wAuteurId;
            AuteurNom = wAuteurNom;
            AuteurPrenom = wAuteurPrenom;
            AuteurPseudo = wAuteurPseudo;
            AuteurDateNaiss = wAuteurDateNaiss;
            AuteurDeces = wAuteurDeces;
            AuteurPays = wAuteurPays;
            AuteurBiographie = wAuteurBiographie;
        }

        //ajout d'un 2eme constructeur pour gérer les auteurs sans date de décès.
        public auteur(int wAuteurId, String wAuteurNom, String wAuteurPrenom, String wAuteurPseudo, DateTime wAuteurDateNaiss, String wAuteurPays, String wAuteurBiographie)
        {
            AuteurId = wAuteurId;
            AuteurNom = wAuteurNom;
            AuteurPrenom = wAuteurPrenom;
            AuteurPseudo = wAuteurPseudo;
            AuteurDateNaiss = wAuteurDateNaiss;
            AuteurPays = wAuteurPays;
            AuteurBiographie = wAuteurBiographie;
        }

        //ajout d'un 3eme constructeur pour gérer les auteurs sans date de naissance et décès.
        public auteur(int wAuteurId, String wAuteurNom, String wAuteurPrenom, String wAuteurPseudo, String wAuteurPays, String wAuteurBiographie)
        {
            AuteurId = wAuteurId;
            AuteurNom = wAuteurNom;
            AuteurPrenom = wAuteurPrenom;
            AuteurPseudo = wAuteurPseudo;
            AuteurPays = wAuteurPays;
            AuteurBiographie = wAuteurBiographie;
        }
        public auteur(string wAuteurNom) {
            AuteurNom = wAuteurNom;
        }
        public auteur(int _numBd,int _numParticipant,int _numtype) {
            numbd = _numBd;
            numParticipant = _numParticipant;
            numType = _numtype;
        }

        public auteur(String wAuteurNom, String wAuteurPseudo)
        {
            AuteurNom = wAuteurNom;
            AuteurPseudo = wAuteurPseudo;
        }
        #endregion

        #region méthodes
        //méthode.s de la classe auteur

        public int wnumBd
        {
            get { return numbd; }
            set { numbd = value; }
        }
        public int wnumParticipant
        {
            get { return numParticipant; }
            set { numParticipant = value; }
        }
        public int wnumType
        {
            get { return numType; }
            set { numType = value; }
        }
        public int Id
        {
            get { return AuteurId; }
            set { AuteurId = value; }
        }

        public String nom
        {
            get { return AuteurNom; }
            set { AuteurNom = value; }
        }

        public String prenom
        {
            get { return AuteurPrenom; }
            set { AuteurPrenom = value; }
        }

        public String pseudo
        {
            get { return AuteurPseudo; }
            set { AuteurPseudo = value; }
        }

        public DateTime naissance
        {
            get { return AuteurDateNaiss;  }
            set { AuteurDateNaiss = value; }
        }

        public DateTime deces
        {
            get { return AuteurDeces; }
            set { AuteurDeces = value; }
        }

        public String pays
        {
            get { return AuteurPays; }
            set { AuteurPays = value; }
        }

        public String bio
        {
            get { return AuteurBiographie; }
            set { AuteurBiographie = value; }
        }

        #endregion

    }
}

