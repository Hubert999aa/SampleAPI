using Microsoft.EntityFrameworkCore;
using SampleAPI.Exceptions;
using SampleAPI.Models;
using System.Linq;

namespace SampleAPI.Services
{
    public class SqlServerMusicDbService : IMusicDbService
    {
        private readonly MusicDbContext _context;

        public SqlServerMusicDbService(MusicDbContext context)
        {
            _context = context;
        }

        public MusicLabel GetMusicLabel(int id)
        {
            var musicLabel = _context.MusicLabels
                                     .Include(m => m.Albums)
                                     .SingleOrDefault(m => m.IdMusicLabel == id);

            if (musicLabel == null)
            {
                throw new MusicLabelDoNotExistsException($"Music label with an id={id} does not exist");
            }

            musicLabel.Albums = musicLabel.Albums.OrderByDescending(ml => ml.PublishDate).ToList();
            return musicLabel;
        }

        public void RemoveMusician(int id)
        {
            var musician = _context.Musicians
                                   .Include(m => m.MusicianTracks)
                                   .SingleOrDefault(m => m.IdMusician == id);

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
