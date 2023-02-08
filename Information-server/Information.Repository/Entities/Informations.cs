using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Information.Repository.Entity
{
    public enum EMOF { male,female}
    public enum HMO { מכבי,מאוחדת,כללית,לאומית}
    public class Informations
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public EMOF EMOF { get; set;}
        public string HMO { get; set; }
        public Informations() { }
        public Informations(int id, string firstName, string lastName, DateTime birthDate, EMOF eMOF, string hMO)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            EMOF = eMOF;
            HMO = hMO;
        }
    }
}
