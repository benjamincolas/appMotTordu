using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class type
    {
        #region propriétés
        private int num;
        private string wtype;
        private int numparticipant;
        private int numtype;
        #endregion
        #region constructeurs
        public type(int wnum, int wnumparticipant, int wnumtype)
        {
            num = wnum;
            numparticipant = wnumparticipant;
            numtype = wnumtype;
        }
        public type(int wnum, string Untype)
        {
            num = wnum;
            wtype = Untype;
        }
        #endregion
        #region méthodes
        public int UnNum //retourne et modifie le numéro 
        {
            get { return num; }
            set { num = value; }
        }
        public string UnType//retourne et modifie le type
        {
            get { return wtype; }
            set { wtype = value; }
        }
        public int UnNumParticipant//retourne et modifie le numéro de participant
        {
            get { return numparticipant; }
            set { numparticipant = value; }
        }

        public int UnNumType//retourne et modifie le numéro de type
        {
            get { return numtype; }
            set { numtype = value; }
        }

    }
}
#endregion