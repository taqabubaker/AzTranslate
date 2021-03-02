using AzTranslate.Services.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary;

namespace AzTranslate.Services
{
    public class YouTubeServices : IYouTubeServices
    {
        private readonly YouTube youtube;

        public YouTubeServices(YouTube youtube)
        {
            this.youtube = youtube;
        }

        public async Task<IEnumerable<YouTubeAudioDto>> GetAllAudiosAsync(string youtubeUrl)
        {
            //define the Dto list which will be returned to the caller
            var audios = new List<YouTubeAudioDto>();

            //get all videos and audios
            var videosAudios = await youtube.GetAllVideosAsync(youtubeUrl);

            //filter and get only the audios descending ordered by resolution
            videosAudios.Where(x => x.AdaptiveKind == AdaptiveKind.Audio)
                .OrderByDescending(x => x.AudioBitrate)
                .ToList()
                .ForEach(audio => audios.Add(new YouTubeAudioDto(audio)));

            return audios;
        }

        public async Task<IEnumerable<YouTubeVideoDto>> GetAllVideosAsync(string youtubeUrl)
        {
            //define the Dto list which will be returned to the caller
            var videos = new List<YouTubeVideoDto>();

            //get all videos and audios
            var videosAudios = await youtube.GetAllVideosAsync(youtubeUrl);

            //filter and get only the videos descending ordered by resolution
            videosAudios.Where(x => x.AdaptiveKind == AdaptiveKind.Video)
                .OrderByDescending(x => x.Resolution)
                .ToList()
                .ForEach(video => videos.Add(new YouTubeVideoDto(video, youtubeUrl)));

            return videos;
        }

        public async Task<YouTubeAudioDto> GetAudioAsync(string youtubeUrl)
        {
            var audios = await GetAllAudiosAsync(youtubeUrl);
            return audios.FirstOrDefault();
        }

        public async Task<YouTubeVideoDto> GetVideoAsync(string youtubeUrl)
        {
            var videoOrAudio = await youtube.GetVideoAsync(youtubeUrl);
            return new YouTubeVideoDto(videoOrAudio, youtubeUrl);
        }
    }
}
