using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Emprunteur
    {
        // Propriétés
        private int emp_num;
        private String emp_nom;
        private String emp_prenom;
        private String emp_rue;
        private String emp_code_postal;
        private String emp_ville;
        private DateTime emp_date_naiss;
        private String emp_mail;
        private DateTime emp_prem_adh;
        private DateTime emp_ren_adh;
        private String supp_motif;
        private int fam_emp_resp;

        #region Constructeur.s

        // Constructeur 
        public Emprunteur(int wemp_num, String wemp_nom, String wemp_prenom, String wemp_rue, String wemp_code_postal, String wemp_ville, DateTime wemp_date_naiss, String wemp_mail, DateTime wemp_prem_adh, DateTime wemp_ren_adh)
        {
            emp_num = wemp_num;
            emp_nom = wemp_nom;
            emp_prenom = wemp_prenom;
            emp_rue = wemp_rue;
            emp_code_postal = wemp_code_postal;
            emp_ville = wemp_ville;
            emp_date_naiss = wemp_date_naiss;
            emp_mail = wemp_mail;
            emp_prem_adh = wemp_prem_adh;
            emp_ren_adh = wemp_ren_adh;
        }

        public Emprunteur(int wemp_num, String wsupp_motif)
        {
            emp_num = wemp_num;
            supp_motif = wsupp_motif;
        }
        public Emprunteur(int wemp_num,string wemp_nom,string wemp_prenom)
        {
            emp_num = wemp_num;
            emp_nom = wemp_nom;
            emp_prenom = wemp_prenom;

        }
        public Emprunteur(Emprunteur wEmprunteur)
        {
            emp_num = wEmprunteur.emp_num;
            emp_nom = wEmprunteur.emp_nom;
            emp_prenom = wEmprunteur.emp_prenom;

        }

        public Emprunteur(int wnum_resp, int wemp_num)
        {
            fam_emp_resp = wnum_resp;
            emp_num = wemp_num;
        }

        #endregion

        #region Méthode.s

        public int numEmp
        {
            get { return emp_num; }
            set { emp_num = value; }
        }

        public String nomEmp
        {
            get { return emp_nom; }
            set { emp_nom = value; }
        }

        public String prenomEmp
        {
            get { return emp_prenom; }
            set { emp_prenom = value; }
        }

        public String rueEmp
        {
            get { return emp_rue; }
            set { emp_rue = value; }
        }

        public String codePostalEmp
        {
            get { return emp_code_postal; }
            set { emp_code_postal = value; }
        }

        public String villeEmp
        {
            get { return emp_ville; }
            set { emp_ville = value; }
        }

        public DateTime dateNaissEmp
        {
            get { return emp_date_naiss; }
            set { emp_date_naiss = value; }
        }

        public String mailEmp
        {
            get { return emp_mail; }
            set { emp_mail = value; }
        }

        public DateTime premEmp
        {
            get { return emp_prem_adh; }
            set { emp_prem_adh = value; }
        }

        public DateTime renEmp
        {
            get { return emp_ren_adh; }
            set { emp_ren_adh = value; }
        }

        public String motifEmp
        {
            get { return supp_motif; }
            set { supp_motif = value; }
        }

        public int numResp
        {
            get { return fam_emp_resp; }
            set { fam_emp_resp = value; }
        }

        #endregion

    }
}
