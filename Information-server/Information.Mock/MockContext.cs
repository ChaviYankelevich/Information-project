using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Information.Repository.Entity;
using Information.Repository.Interfaces;

namespace Information.Mock
{
    public class MockContext//:IContext
    {
        public List<Informations> informations { get; set; }//פה יהיו הנתונים מטבלת roles
        public List<Chaild> chaildren { get; set; }        
        public MockContext()
        {
            informations = new List<Informations>();
            chaildren = new List<Chaild>();            
        }
        }
    }
