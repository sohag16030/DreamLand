using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TestWeb.Core
{
    [Route("identity/[controller]")]
    [ApiController]
    public class CrudController<D> : ControllerBase
    {
        private readonly ICrudService<D> _Service;

        public CrudController(ICrudService<D> service)
        {
            _Service = service;
        }
        
        [HttpPost]
        [Route("Create")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<IActionResult> Create(D dto)
        {
            return Ok(await _Service.Create(dto));
        }
        [HttpPut]
        [Route("Update")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<IActionResult> Update(D dto)
        {
            return Ok(await _Service.Update(dto));
        }

        [HttpGet]
        [Route("GetList")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _Service.GetList());
        }
        
        [HttpGet]
        [Route("GetById/{Id}")]
        [SwaggerOperation(Description = "Example { }")]
        public async Task<IActionResult> GetById(long Id)
        {
            return Ok(await _Service.GetById(Id));
        }
    }
}