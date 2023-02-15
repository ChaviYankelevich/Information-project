using Information.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Information.Repository.Entity;

namespace Information.Service.Interfaces
{
    public interface IChaildService
    {
        Task<List<ChaildDTO>> GetAllAsync();
        Task<ChaildDTO> GetByIdAsync(int Id);
        Task<ChaildDTO> AddAsync(List<ChaildDTO>chaildren);
        Task<ChaildDTO> UpdateAsync(ChaildDTO c);
        Task DeleteAsync(int id);        
    }
}
