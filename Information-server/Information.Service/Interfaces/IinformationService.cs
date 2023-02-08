using Information.Common.DTOs;
using Information.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Information.Service.Interfaces
{
    public interface IinformationService
    {
        Task<List<InformationDTO>> GetAllAsync();
        Task<InformationDTO> GetByIdAsync(int Id);
        Task<InformationDTO> AddAsync(int id, string firstName, string lastName, DateTime birthDate,EMOF eMOF, string hMO);
        Task<InformationDTO> UpdateAsync(Informations information);
        Task DeleteAsync(int id);
    }
}
