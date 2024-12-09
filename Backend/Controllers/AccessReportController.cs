using Backend.DTO;
using Backend.Services.Implementations;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessReportController : ControllerBase
    {
        private readonly IAccessReportService _service;

        public AccessReportController(IAccessReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<AccessReportDTO> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<AccessReportDTO> Get(int id)
        {
            var report = _service.Get(id);
            if (report == null)
                return NotFound();
            return Ok(report);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccessReportDTO dto)
        {
            _service.Add(dto);
            return Ok(dto);
        }

     
    }
}
