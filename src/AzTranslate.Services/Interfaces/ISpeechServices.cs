using System.Collections.Generic;

namespace AzTranslate.Services
{
    public interface ISpeechServices
    {
        IDictionary<string, string> GetSpeechSupportedLanguages();
        IDictionary<string, string> GetTranslationSupportedLanguages();
    }
}