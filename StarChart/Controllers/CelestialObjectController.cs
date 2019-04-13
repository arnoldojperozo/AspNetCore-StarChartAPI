using System.Linq;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var returnValue = _context.CelestialObjects.Where(x => x.Id == id)
                .Include(y=>y.Satellites);

            if (returnValue != null)
            {
                return Ok(returnValue);
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
