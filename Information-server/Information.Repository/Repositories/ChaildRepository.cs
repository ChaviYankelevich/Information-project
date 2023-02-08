using Information.Repository.Entity;
using Information.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Information.Repository.Repositories
{
    internal class ChaildRepository:IChaildRepository
    {
        private readonly IContext _context;

        public ChaildRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Chaild> AddAsync(int id, string name,DateTime birthDate,int parentId)
        {

            var added = _context.Chaildren.Add(new Chaild { Id = id, Name = name, BirthDate = birthDate,ParentId=parentId });
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            Chaild c = _context.Chaildren.ToList<Chaild>().Find(i => i.Id == id);
            _context.Chaildren.Remove(c);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Chaild>> GetAllAsync()
        {
            await _context.SaveChangesAsync();
            return _context.Chaildren.ToList<Chaild>();
        }

        public async Task<Chaild> GetByIdAsync(int Id)
        {
            await _context.SaveChangesAsync();

            return _context.Chaildren.ToList<Chaild>().Find(c => c.Id == Id);
        }

        public async Task<Chaild> UpdateAsync(Chaild c)
        {
            _context.Chaildren.ToList<Chaild>().Find(r => r.Id == c.Id).Name = c.Name;
            _context.Chaildren.ToList<Chaild>().Find(r => r.Id == c.Id).BirthDate = c.BirthDate;
            _context.Chaildren.ToList<Chaild>().Find(r => r.Id == c.Id).ParentId = c.ParentId;
            await _context.SaveChangesAsync();
            return c;
        }
    }
}

