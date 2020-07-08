using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Services
{
    public interface IMusicDbService
    {
        MusicLabel GetMusicLabel(int id);

        void RemoveMusician(int id);
    }
}
