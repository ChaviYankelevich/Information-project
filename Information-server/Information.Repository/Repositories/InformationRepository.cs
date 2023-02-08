using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Information.Repository.Interfaces;
using Information.Repository.Entity;

namespace Information.Repository.Repositories
{
    public class InformationRepository:IinformationRepository
    {
        private readonly IContext _context;

        public InformationRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Informations> AddAsync(int id, string firstName, string lastName, DateTime birthDate, EMOF eMOF, string hMO)
        {
            
            var added = _context.Informations.Add(new Informations { Id = id, FirstName=firstName,LastName = lastName, BirthDate = birthDate,EMOF=eMOF,HMO=hMO});
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            Informations i = _context.Informations.ToList<Informations>().Find(i => i.Id == id);
            _context.Informations.Remove(i);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Informations>> GetAllAsync()
        {
            await _context.SaveChangesAsync();
            return _context.Informations.ToList<Informations>();
        }

        public async Task<Informations> GetByIdAsync(int Id)
        {
            await _context.SaveChangesAsync();

            return _context.Informations.ToList<Informations>().Find(r => r.Id == Id);
        }

        public async Task<Informations> UpdateAsync(Informations information)
        {
            _context.Informations.ToList<Informations>().Find(r => r.Id == information.Id).FirstName = information.FirstName;
            _context.Informations.ToList<Informations>().Find(r => r.Id == information.Id).LastName = information.LastName;
            _context.Informations.ToList<Informations>().Find(r => r.Id == information.Id).BirthDate = information.BirthDate;
            _context.Informations.ToList<Informations>().Find(r => r.Id == information.Id).EMOF = information.EMOF;
            _context.Informations.ToList<Informations>().Find(r => r.Id == information.Id).HMO = information.HMO;
            await _context.SaveChangesAsync();
            return information;
        }
    }
}

