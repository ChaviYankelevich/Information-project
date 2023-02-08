using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Information.Repository.Entity
{
    public class Chaild
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int ParentId { get; set; }
        public Chaild()
        {

        }
        public Chaild(int Id,string Name, DateTime BirthDate,int ParentId)
        {
            this.Id = Id;
            this.Name = Name;   
            this.BirthDate = BirthDate;
            this.ParentId = ParentId;
        }
    }
}
