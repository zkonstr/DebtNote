using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/skus")]
    [ApiController]
    public class SkusController : ControllerBase
    {
        private readonly IServiceManager _service;
        public SkusController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetSkus()
        {
            var skus = _service.SkuService.GetAllSkus(trackChanges: false);
            return Ok(skus);
        }
        [HttpGet("{id:guid}", Name = "SkuById")]
        public IActionResult GetSku(Guid id)
        {
            var sku = _service.SkuService.GetSku(id, trackChanges: false);
            return Ok(sku);
        }

        [HttpPost]
        public IActionResult CreateSku([FromBody] SkuForCreationDTO sku)
        {
            if (sku is null)
                return BadRequest("SkuForCreationDto object is null");
            var createdSku = _service.SkuService.CreateSku(sku);
            return CreatedAtRoute("SkuById", new { id = createdSku.Id },
            createdSku);
        }
    }
}
