﻿using AutoMapper;
using Information.Common.DTOs;
using Information.Repository.Entity;
using Information.Repository.Interfaces;
using Information.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Information.Service.Services
{
    internal class ChaildService : IChaildService
    {
        private readonly IChaildRepository _chaildRepository;
        private readonly IMapper _mapper;       
        public ChaildService(IChaildRepository chaildRepository, IMapper mapper)
        {
            _chaildRepository = chaildRepository;
            _mapper = mapper;
        }

        public async Task<ChaildDTO> AddAsync(int Id, string Name, DateTime BirthDate,int ParentId)
        {    
            return _mapper.Map<ChaildDTO>(await _chaildRepository.AddAsync(Id, Name, BirthDate,ParentId));
        }

        public async Task DeleteAsync(int id)
        {
            await _chaildRepository.DeleteAsync(id);
        }

        public async Task<List<ChaildDTO>> GetAllAsync()
        {
            return _mapper.Map<List<ChaildDTO>>(await _chaildRepository.GetAllAsync());
        }

        public async Task<ChaildDTO> GetByIdAsync(int Id)
        {
            return _mapper.Map<ChaildDTO>(await _chaildRepository.GetByIdAsync(Id));
        }

        public async Task<ChaildDTO> UpdateAsync(Chaild c)
        {
            return _mapper.Map<ChaildDTO>(await _chaildRepository.UpdateAsync(c));
        }
    }
}
