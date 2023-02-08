using Information.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Information.Repository.Interfaces
{
    public interface IChaildRepository
    {
        Task<List<Chaild>> GetAllAsync();
        Task<Chaild> GetByIdAsync(int Id);
        Task<Chaild> AddAsync(int Id, string Name, DateTime BirthDate,int ParentId);
        Task<Chaild> UpdateAsync(Chaild c);
        Task DeleteAsync(int id);
    }
}
