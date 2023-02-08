using AutoMapper;
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
    public class InformationService : IinformationService
    {
        private readonly IinformationRepository _informationRepository;
        private readonly IMapper _mapper;
        public InformationService(IinformationRepository informationRepository, IMapper mapper)
        {
            _informationRepository = informationRepository;
            _mapper = mapper;
        }

        public async Task<InformationDTO> AddAsync(int id, string firstName, string lastName, DateTime birthDate,EMOF eMOF, string hMO)
        {
            return _mapper.Map<InformationDTO>(await _informationRepository.AddAsync(id,firstName,lastName,birthDate,eMOF,hMO));
        }

        public async Task DeleteAsync(int id)
        {
            await _informationRepository.DeleteAsync(id);
        }

        public async Task<List<InformationDTO>> GetAllAsync()
        {
            return _mapper.Map<List<InformationDTO>>(await _informationRepository.GetAllAsync());
        }

        public async Task<InformationDTO> GetByIdAsync(int Id)
        {
            return _mapper.Map<InformationDTO>(await _informationRepository.GetByIdAsync(Id));
        }

        public async Task<InformationDTO> UpdateAsync(Informations information)
        {
            return _mapper.Map<InformationDTO>(await _informationRepository.UpdateAsync(information));
        }
    }
}
