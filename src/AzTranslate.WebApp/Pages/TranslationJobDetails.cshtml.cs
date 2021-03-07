using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzTranslate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using VideoLibrary;

namespace AzTranslate.WebApp.Pages
{
    public class TranslationJobDetailsModel : PageModelBase<TranslationJobDetailsModel>
    {
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }

        public TranslationJobDetailsModel(IYouTubeServices youTubeServices, ISpeechServices speechServices, ILogger<TranslationJobDetailsModel> logger) 
            : base(youTubeServices, speechServices, logger)
        {
        }

        public async Task<IActionResult> OnGetAsync(string youTubeUrl, string fromLanguage, IEnumerable<string> toLanguages)
        {
            var org = new StringBuilder();
            var trn = new StringBuilder();

            //TO DO: Subscribe to all events to know when the translation finishes.
            //TO DO: Implement SignalR to send translation realtime feed

            speechServices.SpeechSessionStarted += (s, e) =>
            {
            };

            speechServices.SpeechRecognized += (s, e) =>
            {
                org.AppendLine(e.OriginalTranscriptLine);
                trn.AppendLine(e.TranslationTranscriptLine);
            };

            var video = await youTubeServices.GetVideoAsync(youTubeUrl);

            _ = speechServices.TranslateAsync(video.YouTubeVideo, fromLanguage, toLanguages);

            OriginalText = org.ToString();
            TranslatedText = trn.ToString();

            return Page();
        }
    }
}
