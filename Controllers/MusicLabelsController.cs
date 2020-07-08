using Microsoft.AspNetCore.Mvc;
using SampleAPI.Exceptions;
using SampleAPI.Services;
using System.Threading.Tasks;

namespace SampleAPI.Controllers
{
    [Route("api/music-labels")]
    [ApiController]
    public class MusicLabelsController : ControllerBase
    {
        private readonly IMusicDbService _dbService;

        public MusicLabelsController(IMusicDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMusicLabel(int id)
        {
            try { 
                var res = await _dbService.GetMusicLabel(id);
                return Ok(res);
            }
            catch (MusicLabelDoNotExistsException exc)
            {
                return NotFound(exc.Message);
            }       
        }
    }
}