using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzTranslate.Services;
using AzTranslate.WebApp.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using VideoLibrary;

namespace AzTranslate.WebApp.Pages
{
    public class TranslationJobDetailsModel : PageModelBase<TranslationJobDetailsModel>
    {
        public string FromLanguage { get; set; }
        public string ToLanguages { get; set; }
        private readonly IHubContext<TranslationHub> hubContext;

        public TranslationJobDetailsModel(IYouTubeServices youTubeServices, ISpeechServices speechServices, 
            ILogger<TranslationJobDetailsModel> logger, IHubContext<TranslationHub> hubContext)
            : base(youTubeServices, speechServices, logger)
        {
            this.hubContext = hubContext;
        }

        public async Task<IActionResult> OnGetAsync(string youTubeUrl, string fromLanguage, IEnumerable<string> toLanguages)
        {
            FromLanguage = fromLanguage;
            ToLanguages = toLanguages.FirstOrDefault();

            var org = new StringBuilder();
            var trn = new StringBuilder();

            speechServices.SpeechSessionStarted += async (s, e) =>
            {
                await hubContext.Clients.All.SendAsync("ReceiveMessage", "logList", e.Information);
            };

            speechServices.SpeechSessionStopped += async (s, e) =>
            {
                await hubContext.Clients.All.SendAsync("ReceiveMessage", "logList", e.Information);
            };

            speechServices.SpeechCanceled += async (s, e) =>
            {
                await hubContext.Clients.All.SendAsync("ReceiveMessage", "logList", e.Information);
            };

            speechServices.SpeechEndDetected += async (s, e) =>
            {
                await hubContext.Clients.All.SendAsync("ReceiveMessage", "logList", e.Information);
            };

            speechServices.SpeechStartDetected += async (s, e) =>
            {
                await hubContext.Clients.All.SendAsync("ReceiveMessage", "logList", e.Information);
            };

            speechServices.SpeechRecognized += async (s, e) =>
            {
                org.AppendLine(e.OriginalTranscriptLine);
                trn.AppendLine(e.TranslationTranscriptLine);

                await hubContext.Clients.All.SendAsync("ReceiveMessage", "transcriptList", e.OriginalTranscriptLine);
                await hubContext.Clients.All.SendAsync("ReceiveMessage", "translationList", e.TranslationTranscriptLine);
            };

            var video = await youTubeServices.GetVideoAsync(youTubeUrl);

            _ = speechServices.TranslateAsync(video.YouTubeVideo, fromLanguage, toLanguages);

            return Page();
        }
    }
}
