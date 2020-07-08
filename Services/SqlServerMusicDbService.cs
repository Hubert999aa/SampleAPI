using Microsoft.EntityFrameworkCore;
using SampleAPI.Exceptions;
using SampleAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Services
{
    public class SqlServerMusicDbService : IMusicDbService
    {
        private readonly MusicDbContext _context;

        public SqlServerMusicDbService(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<MusicLabel> GetMusicLabel(int id)
        {
            var musicLabel = await _context.MusicLabels
                                     .Include(m => m.Albums)
                                     .SingleOrDefaultAsync(m => m.IdMusicLabel == id);

            if (musicLabel == null)
            {
                throw new MusicLabelDoNotExistsException($"Music label with an id={id} does not exist");
            }

            musicLabel.Albums = musicLabel.Albums.OrderByDescending(ml => ml.PublishDate).ToList();
            return musicLabel;
        }

        public async Task RemoveMusician(int id)
        {
            var musician = await _context.Musicians
                                   .Include(m => m.MusicianTracks)
                                   .SingleOrDefaultAsync(m => m.IdMusician == id);

            if (musician == null)
            {
                throw new MusicianDoesNotExistsException($"Musician with an id={id} does not exist");
            }

            _context.MusicianTracks.RemoveRange(musician.MusicianTracks);
            _context.Musicians.Remove(musician);
            _context.SaveChanges();
        }
    }
}
