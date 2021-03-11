using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Translation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary;

namespace AzTranslate.Services
{
    public interface ISpeechServices
    {
        IDictionary<string, string> GetSpeechSupportedLanguages();
        IDictionary<string, string> GetTranslationSupportedLanguages();
        string GetSpeechLanguageNameByCode(string languageCode);
        string GetTranslationLanguageNameByCode(string languageCode);
        Task TranslateAsync(YouTubeVideo youTubeVideo, string fromLanguage, IEnumerable<string> toLanguages);

        event EventHandler<SpeechServicesEventArgs> SpeechRecognized;
        event EventHandler<SpeechServicesEventArgs> SpeechCanceled;
        event EventHandler<SpeechServicesEventArgs> SpeechStartDetected;
        event EventHandler<SpeechServicesEventArgs> SpeechEndDetected;
        event EventHandler<SpeechServicesEventArgs> SpeechSessionStarted;
        event EventHandler<SpeechServicesEventArgs> SpeechSessionStopped;
    }
}