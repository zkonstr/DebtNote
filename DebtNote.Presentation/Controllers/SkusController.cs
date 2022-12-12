using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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
            try
            {
                var users =
                _service.SkuService.GetAllSkus(trackChanges: false);
                return Ok(users);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
