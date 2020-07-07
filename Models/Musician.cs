using System.Collections.Generic;

namespace SampleAPI.Models
{
    public class Musician
    {

        public int IdMusician { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public ICollection<MusicianTrack> MusicianTracks { get; set; }
    }
}
