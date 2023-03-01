using AutoMapper;
using Contracts;
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
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public SkusController
            (IRepositoryManager repository, IServiceManager service, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

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

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteSku(Guid skuId)
        {
            _service.SkuService.DeleteSku(skuId, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateSku(Guid id, [FromBody] SkuForUpdateDTO sku)
        {
            if (sku is null)
                return BadRequest("SkuForUpdateDto object is null");
            _service.SkuService.UpdateSku(id, sku, trackChanges: true);
            return NoContent();
        }
    }
}
