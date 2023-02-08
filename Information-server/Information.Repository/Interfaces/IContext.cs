using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Information.Repository.Entity;

namespace Information.Repository.Interfaces
{
    public interface IContext
    {
        DbSet<Informations> Informations { get; set; }
        DbSet<Chaild> Chaildren { get; set; }
        Task<int> SaveChangesAsync();
    }
}
