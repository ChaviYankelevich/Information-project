using Information.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Information.Common.DTOs
{
    //public enum EMOF { male, female }
    public class InformationDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public EMOF EMOF { get; set; }
        public string HMO { get; set; }        
    }
}
