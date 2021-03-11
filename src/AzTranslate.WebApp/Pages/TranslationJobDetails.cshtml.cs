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
        public Dictionary<string, string> WorkingLanguages { get; set; }
        private readonly IHubContext<TranslationHub> hubContext;

        public TranslationJobDetailsModel(IYouTubeServices youTubeServices, ISpeechServices speechServices,
            ILogger<TranslationJobDetailsModel> logger, IHubContext<TranslationHub> hubContext)
            : base(youTubeServices, speechServices, logger)
        {
            this.hubContext = hubContext;
        }

        public async Task<IActionResult> OnGetAsync(string youTubeUrl, string fromLanguage, IEnumerable<string> toLanguages)
        {
            var previousOriginalTranscriptLine = string.Empty;

            var fromLanguageName = speechServices.GetSpeechLanguageNameByCode(fromLanguage);
            WorkingLanguages = new Dictionary<string, string>();
            WorkingLanguages.Add(fromLanguage, fromLanguageName);

            foreach (var language in toLanguages)
            {
                var toLanguageName = speechServices.GetTranslationLanguageNameByCode(language);
                WorkingLanguages.Add(language, toLanguageName);
            }            

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
                if (!string.Equals(e.OriginalTranscriptLine, previousOriginalTranscriptLine))
                {
                    await hubContext.Clients.All.SendAsync("ReceiveMessage", "transcript-list", e.OriginalTranscriptLine);
                    previousOriginalTranscriptLine = e.OriginalTranscriptLine;
                }

                await hubContext.Clients.All.SendAsync("ReceiveMessage", $"translation-{e.TranslationLanguage.ToLower()}-list", e.TranslationTranscriptLine);
            };

            var video = await youTubeServices.GetVideoAsync(youTubeUrl);

            _ = speechServices.TranslateAsync(video.YouTubeVideo, fromLanguage, toLanguages);

            return Page();
        }
    }
}
