using SampleAPI.Models;
using System.Threading.Tasks;

namespace SampleAPI.Services
{
    public interface IMusicDbService
    {
        Task<MusicLabel> GetMusicLabel(int id);

        Task RemoveMusician(int id);
    }
}
