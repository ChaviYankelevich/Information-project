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
    public interface IinformationRepository
    {
        Task<List<Informations>> GetAllAsync();
        Task<Informations> GetByIdAsync(int Id);
        Task<Informations> AddAsync(int id, string firstName, string lastName, DateTime birthDate, EMOF eMOF, string hMO);
        Task<Informations> UpdateAsync(Informations information);
        Task DeleteAsync(int id);
    }
}
