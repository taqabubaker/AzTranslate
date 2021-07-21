using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace AzTranslate.Services.Dtos
{
    public class YouTubeVideoDto
    {
        private readonly YouTubeVideo youTubeVideo;
        public YouTubeVideoInfo YouTubeVideoInfo { get; private set; }
        public string YouTubeUrl { get; private set; }
        public YouTubeVideoDto(YouTubeVideo youTubeVideo, string youtubeUrl)
            : this(youTubeVideo)
        {
            this.YouTubeUrl = youtubeUrl;
        }
        public YouTubeVideoDto(YouTubeVideo youTubeVideo)
        {
            this.youTubeVideo = youTubeVideo;
            this.YouTubeUrl = default(string);
            
            YouTubeVideoInfo = new YouTubeVideoInfo(this.youTubeVideo.Info.Title, 
                this.youTubeVideo.Info.LengthSeconds, 
                this.youTubeVideo.Info.Author,
                this.youTubeVideo.Resolution,
                this.youTubeVideo.Format);
        }
        public string YouTubeEmbedVideo
        {
            get
            {
                if (string.IsNullOrEmpty(YouTubeUrl))
                    return string.Empty;

                var embedUri = new Uri(YouTubeUrl);
                var queries = embedUri.Query.Split(new string[] { "?", "&" }, StringSplitOptions.RemoveEmptyEntries);
                var vidId = queries
                    .SingleOrDefault(x => x.Contains("v="))
                    .Replace("v=", "");
                return $"{embedUri.Scheme}://{embedUri.Host}/embed/{vidId}";
            }
        }
        public YouTubeVideo YouTubeVideo => youTubeVideo;
    }

    public class YouTubeVideoInfo : VideoInfo
    {
        public bool Is3D { get; private set; }
        public int Resolution { get; private set; }
        public VideoFormat VideoFormat { get; private set; }

        public YouTubeVideoInfo(string title, int? second, string author, int resolution, VideoFormat videoFormat)
            : base(title, second, author)
        {
            this.Resolution = resolution;
            this.VideoFormat = videoFormat;
        }
    }
}
