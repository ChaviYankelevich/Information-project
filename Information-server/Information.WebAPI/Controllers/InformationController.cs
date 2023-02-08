using Information.Common.DTOs;
using Information.Repository.Entity;
using Information.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Information.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly IinformationService _informationService;
        public InformationController(IinformationService informationService)
        {
            _informationService = informationService;
        }
        [HttpGet]
        public async Task<List<InformationDTO>> Get()
        {
            return await _informationService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<InformationDTO> Get(int id)
        {
            return await _informationService.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task<InformationDTO> Post([FromBody] InformationDTO information) => await _informationService.AddAsync(information.Id, information.FirstName, information.LastName, information.BirthDate, (Repository.Entity.EMOF)information.EMOF, information.HMO);
        [HttpPut("{id}")]
        public async Task<InformationDTO> Put(int id, [FromBody] InformationDTO information)
        {
            //if(id/100000000==0||id/ 1000000000!=0)
            //{
            //    throw new ArgumentException("invalid id!");
            //}
            return await _informationService.UpdateAsync(new Informations() { Id = id, FirstName = information.FirstName, LastName = information.LastName, BirthDate = information.BirthDate, EMOF =information.EMOF, HMO = information.HMO });
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _informationService.DeleteAsync(id);
        }
    }
}
