using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class serie
    {
        #region propriétés
        private string nomSerie;
        private int nb;
        #endregion
        #region constructeur
        public serie(string _nomSerie)
        {
            nomSerie = _nomSerie;
        }
        public serie(string _nomSerie,int _nb)
        {
            nomSerie = _nomSerie;
            nb = _nb;
        }
        #endregion
        #region méthodes
        public string GetNom//retourne et modifie le nom de la série
        {
            get { return nomSerie; }
                set { nomSerie = value; }
            }

        public int GetNb//retourne ou modifie le nombre 
        {
            get { return nb; }
            set { nb = value; }
        }
    }
    }
#endregion