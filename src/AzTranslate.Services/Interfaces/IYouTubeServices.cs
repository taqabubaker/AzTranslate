using AzTranslate.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace AzTranslate.Services
{
    public interface IYouTubeServices
    {
        Task<YouTubeVideoDto> GetVideoAsync(string youtubeUrl);
        Task<YouTubeAudioDto> GetAudioAsync(string youtubeUrl);
        Task<IEnumerable<YouTubeVideoDto>> GetAllVideosAsync(string youtubeUrl);
        Task<IEnumerable<YouTubeAudioDto>> GetAllAudiosAsync(string youtubeUrl);
    }
}
