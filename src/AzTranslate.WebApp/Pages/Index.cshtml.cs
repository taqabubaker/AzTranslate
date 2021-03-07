using AzTranslate.Services.Dtos;
using AzTranslate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AzTranslate.WebApp.Pages
{
    public class IndexModel : PageModelBase<IndexModel>
    {
        [BindProperty]
        [Display(Name = "YouTube URL")]
        [Url]
        public string YouTubeUrl { get; set; }

        public YouTubeVideoDto Video { get; set; }

        public IEnumerable<YouTubeAudioDto> Audios { get; set; }

        public IEnumerable<SelectListItem> SpeachLanguages { get; set; }

        public IEnumerable<SelectListItem> TranslationLanguages { get; set; }

        [BindProperty]
        [Display(Name = "Translate From")]
        public string TranslateFrom { get; set; }

        [BindProperty]
        [Display(Name = "Translate To")]
        public IEnumerable<string> TranslateTo { get; set; }

        public IndexModel(IYouTubeServices youTubeServices, ISpeechServices speechServices, ILogger<IndexModel> logger)
            : base(youTubeServices, speechServices, logger)
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Video = await youTubeServices.GetVideoAsync(YouTubeUrl);
            Audios = await youTubeServices.GetAllAudiosAsync(YouTubeUrl);

            SpeachLanguages = speechServices
                .GetSpeechSupportedLanguages()
                .Select(lang =>
                new SelectListItem
                {
                    Value = lang.Key,
                    Text = lang.Value
                }).ToList();

            TranslationLanguages = speechServices
                .GetTranslationSupportedLanguages()
                .Select(lang =>
                new SelectListItem
                {
                    Value = lang.Key,
                    Text = lang.Value
                }).ToList();

            return Page();
        }
    }
}
