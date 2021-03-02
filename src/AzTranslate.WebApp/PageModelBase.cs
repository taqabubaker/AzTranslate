using AzTranslate.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzTranslate.WebApp
{
    public class PageModelBase<T> : PageModel
    {
        protected readonly IYouTubeServices youTubeServices;
        protected readonly ILogger<T> logger;

        public PageModelBase(IYouTubeServices youTubeServices, ILogger<T> logger)
        {
            this.youTubeServices = youTubeServices;
            this.logger = logger;
        }
    }
}
