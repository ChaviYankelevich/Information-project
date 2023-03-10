using Information.Common.DTOs;
using Information.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chailds.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaildController : ControllerBase
    {
        private readonly IChaildService _ChaildService;
        public ChaildController(IChaildService ChaildService)
        {
            _ChaildService = ChaildService;
        }
        [HttpGet]
        public async Task<List<ChaildDTO>> Get()
        {
            return await _ChaildService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<ChaildDTO> Get(int id)
        {
            return await _ChaildService.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task<ChaildDTO> Post([FromBody]List<ChaildDTO> Chaildren)
        {

            return await _ChaildService.AddAsync(Chaildren);
        }
        [HttpPut("{id}")]
        public async Task<ChaildDTO> Put(int id, [FromBody] ChaildDTO Chaild)
        {
            return await _ChaildService.UpdateAsync(Chaild);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ChaildService.DeleteAsync(id);
        }
    }
}
