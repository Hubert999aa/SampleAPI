    using Microsoft.AspNetCore.Mvc;
using SampleAPI.Exceptions;
using SampleAPI.Services;

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
        public IActionResult GetMusicLabel(int id)
        {
            try { 
                var res = _dbService.GetMusicLabel(id);
                return Ok(res);
            }
            catch (MusicLabelDoNotExistsException exc)
            {
                return NotFound(exc.Message);
            }       
        }
    }
}