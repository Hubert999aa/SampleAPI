using Microsoft.AspNetCore.Mvc;
using SampleAPI.Exceptions;
using SampleAPI.Services;

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
        public IActionResult RemoveMusician(int id)
        {
            try
            {
                _dbService.RemoveMusician(id);
                return NoContent();
            }
            catch (MusicianDoesNotExistsException exc)
            {
                return NotFound(exc.Message);
            }
        }
    }
}
    