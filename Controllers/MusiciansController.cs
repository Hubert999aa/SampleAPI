using Microsoft.AspNetCore.Mvc;
using SampleAPI.Exceptions;
using SampleAPI.Services;
using System.Threading.Tasks;

namespace SampleAPI.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {

        private readonly IMusicDbService _dbService;

        public MusiciansController(IMusicDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveMusician(int id)
        {
            try
            {
                await _dbService.RemoveMusician(id);
                return NoContent();
            }
            catch (MusicianDoesNotExistsException exc)
            {
                return NotFound(exc.Message);
            }
        }
    }
}
    