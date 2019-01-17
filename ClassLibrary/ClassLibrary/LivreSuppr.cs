using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class LivreSuppr
    {
        #region propriétés
        private int BdId;
        private string motif;
        #endregion
        #region constructeur
        public LivreSuppr(int _BdId, string _motif)
        {
            BdId = _BdId;
            motif = _motif;
        }
        #endregion
        #region méthodes
        public int wBdID
        {
            get { return BdId; }//retourne et modifie l'id bd
            set { BdId = value; }
        }
        public string wMotif//retourne et modifie le motif
        {
            get { return motif; }
            set { motif = value; }
        }
    
    }
}
#endregion