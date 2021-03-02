using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace AzTranslate.Services.Dtos
{
    public class YouTubeAudioDto
    {
        private readonly YouTubeVideo youTubeAudio;
        public YouTubeAudioInfo YouTubeAudioInfo { get; private set; }
        public YouTubeAudioDto(YouTubeVideo youTubeVideo)
        {
            this.youTubeAudio = youTubeVideo;

            YouTubeAudioInfo = new YouTubeAudioInfo(this.youTubeAudio.Info.Title, 
                this.youTubeAudio.Info.LengthSeconds, 
                this.youTubeAudio.Info.Author, 
                this.youTubeAudio.AudioBitrate, 
                this.youTubeAudio.AudioFormat);
            
        }
        public YouTubeVideo YouTubeAudio => youTubeAudio;
    }

    public class YouTubeAudioInfo : VideoInfo
    {
        public AudioFormat AudioFormat { get; private set; }
        public int AudioBitrate { get; private set; }
        public YouTubeAudioInfo(string title, int? second, string author, int audioBitrate, AudioFormat audioFormat)
            : base(title, second, author)
        {
            this.AudioBitrate = audioBitrate;
            this.AudioFormat = audioFormat;
        }
    }
}
