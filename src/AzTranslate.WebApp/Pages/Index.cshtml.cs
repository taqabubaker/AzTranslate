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

namespace AzTranslate.WebApp.Pages
{
    public class IndexModel : PageModelBase<IndexModel>
    {
        [BindProperty]
        [Display(Name = "YouTube URL")]
        [Url]
        public string YouTubeUrl { get; set; }

        public YouTubeVideoDto Video { get; set; }

        public IndexModel(IYouTubeServices youTubeServices, ILogger<IndexModel> logger)
            : base(youTubeServices, logger)
        {            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Video = await youTubeServices.GetVideoAsync(YouTubeUrl);

            return Page();
        }
    }
}
