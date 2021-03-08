﻿using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Translation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using Xabe.FFmpeg;

namespace AzTranslate.Services
{
    public class SpeechServices : ISpeechServices
    {
        public event EventHandler<SpeechServicesEventArgs> SpeechRecognized;
        public event EventHandler<SpeechServicesEventArgs> SpeechStartDetected;
        public event EventHandler<SpeechServicesEventArgs> SpeechEndDetected;
        public event EventHandler<SpeechServicesEventArgs> SpeechSessionStarted;
        public event EventHandler<SpeechServicesEventArgs> SpeechSessionStopped;
        public event EventHandler<SpeechServicesEventArgs> SpeechCanceled;

        public IDictionary<string, string> GetSpeechSupportedLanguages()
        {
            return new Dictionary<string, string>
            {
                { "ar-BH", "Arabic (Bahrain)" },
                { "ar-EG", "Arabic (Egypt)" },
                { "ar-IQ", "Arabic (Iraq)" },
                { "ar-JO", "Arabic (Jordan)" },
                { "ar-KW", "Arabic (Kuwait)" },
                { "ar-LB", "Arabic (Lebanon)" },
                { "ar-OM", "Arabic (Oman)" },
                { "ar-QA", "Arabic (Qatar)" },
                { "ar-SA", "Arabic (Saudi Arabia)" },
                { "ar-PS", "Arabic (State of Palestine)" },
                { "ar-SY", "Arabic (Syria)" },
                { "ar-AE", "Arabic (United Arab Emirates)" },
                { "bg-BG", "Bulgarian (Bulgaria)" },
                { "ca-ES", "Catalan (Spain)" },
                { "zh-HK", "Chinese (Cantonese, Traditional)" },
                { "zh-CN", "Chinese (Mandarin, Simplified)" },
                { "zh-TW", "Chinese (Taiwanese Mandarin)" },
                { "hr-HR", "Croatian (Croatia)" },
                { "cs-CZ", "Czech (Czech Republic)" },
                { "da-DK", "Danish (Denmark)" },
                { "nl-NL", "Dutch (Netherlands)" },
                { "en-AU", "English (Australia)" },
                { "en-CA", "English (Canada)" },
                { "en-GH", "English (Ghana)" },
                { "en-HK", "English (Hong Kong)" },
                { "en-IN", "English (India)" },
                { "en-IE", "English (Ireland)" },
                { "en-KE", "English (Kenya)" },
                { "en-NZ", "English (New Zealand)" },
                { "en-NG", "English (Nigeria)" },
                { "en-PH", "English (Philippines)" },
                { "en-SG", "English (Singapore)" },
                { "en-ZA", "English (South Africa)" },
                { "en-TZ", "English (Tanzania)" },
                { "en-GB", "English (United Kingdom)" },
                { "en-US", "English (United States)" },
                { "et-EE", "Estonian(Estonia)" },
                { "fil-PH", "Filipino (Philippines)" },
                { "fi-FI", "Finnish (Finland)" },
                { "fr-CA", "French (Canada)" },
                { "fr-FR", "French (France)" },
                { "fr-CH", "French (Switzerland)" },
                { "de-AT", "German (Austria)" },
                { "de-DE", "German (Germany)" },
                { "el-GR", "Greek (Greece)" },
                { "gu-IN", "Gujarati (Indian)" },
                { "hi-IN", "Hindi (India)" },
                { "hu-HU", "Hungarian (Hungary)" },
                { "id-ID", "Indonesian (Indonesia)" },
                { "ga-IE", "Irish(Ireland)" },
                { "it-IT", "Italian (Italy)" },
                { "ja-JP", "Japanese (Japan)" },
                { "ko-KR", "Korean (Korea)" },
                { "lv-LV", "Latvian (Latvia)" },
                { "lt-LT", "Lithuanian (Lithuania)" },
                { "ms-MY", "Malay(Malaysia)" },
                { "mt-MT", "Maltese(Malta)" },
                { "mr-IN", "Marathi (India)" },
                { "nb-NO", "Norwegian (Bokmål, Norway)" },
                { "pl-PL", "Polish (Poland)" },
                { "pt-BR", "Portuguese (Brazil)" },
                { "pt-PT", "Portuguese (Portugal)" },
                { "ro-RO", "Romanian (Romania)" },
                { "ru-RU", "Russian (Russia)" },
                { "sk-SK", "Slovak (Slovakia)" },
                { "sl-SI", "Slovenian (Slovenia)" },
                { "es-AR", "Spanish (Argentina)" },
                { "es-BO", "Spanish (Bolivia)" },
                { "es-CL", "Spanish (Chile)" },
                { "es-CO", "Spanish (Colombia)" },
                { "es-CR", "Spanish (Costa Rica)" },
                { "es-CU", "Spanish (Cuba)" },
                { "es-DO", "Spanish (Dominican Republic)" },
                { "es-EC", "Spanish (Ecuador)" },
                { "es-SV", "Spanish (El Salvador)" },
                { "es-GQ", "Spanish (Equatorial Guinea)" },
                { "es-GT", "Spanish (Guatemala)" },
                { "es-HN", "Spanish (Honduras)" },
                { "es-MX", "Spanish (Mexico)" },
                { "es-NI", "Spanish (Nicaragua)" },
                { "es-PA", "Spanish (Panama)" },
                { "es-PY", "Spanish (Paraguay)" },
                { "es-PE", "Spanish (Peru)" },
                { "es-PR", "Spanish (Puerto Rico)" },
                { "es-ES", "Spanish (Spain)" },
                { "es-UY", "Spanish (Uruguay)" },
                { "es-US", "Spanish (USA)" },
                { "es-VE", "Spanish (Venezuela)" },
                { "sv-SE", "Swedish (Sweden)" },
                { "ta-IN", "Tamil (India)" },
                { "te-IN", "Telugu (India)" },
                { "th-TH", "Thai (Thailand)" },
                { "tr-TR", "Turkish (Turkey)" },
                { "vi-VN", "Vietnamese (Vietnam)" }
            };
        }

        public IDictionary<string, string> GetTranslationSupportedLanguages()
        {
            return new Dictionary<string, string>
            {
                {"af", "Afrikaans" },
                {"ar", "Arabic" },
                {"bn", "Bangla" },
                {"bs", "Bosnian (Latin)" },
                {"bg", "Bulgarian" },
                {"yue", "Cantonese (Traditional)" },
                {"ca", "Catalan" },
                {"zh-Hans", "Chinese Simplified" },
                {"zh-Hant", "Chinese Traditional" },
                {"hr", "Croatian" },
                {"cs", "Czech" },
                {"da", "Danish" },
                {"nl", "Dutch" },
                {"en", "English" },
                {"et", "Estonian" },
                {"fj", "Fijian" },
                {"fil", "Filipino" },
                {"fi", "Finnish" },
                {"fr", "French" },
                {"de", "German" },
                {"el", "Greek" },
                {"gu", "Gujarati" },
                {"ht", "Haitian Creole" },
                {"he", "Hebrew" },
                {"hi", "Hindi" },
                {"mww", "Hmong Daw" },
                {"hu", "Hungarian" },
                {"id", "Indonesian" },
                {"ga", "Irish" },
                {"it", "Italian" },
                {"ja", "Japanese" },
                {"kn", "Kannada" },
                {"sw", "Kiswahili" },
                {"tlh-Latn", "Klingon" },
                {"tlh-Piqd", "Klingon (plqaD)" },
                {"ko", "Korean" },
                {"lv", "Latvian" },
                {"lt", "Lithuanian" },
                {"mg", "Malagasy" },
                {"ms", "Malay" },
                {"ml", "Malayalam" },
                {"mt", "Maltese" },
                {"mi", "Maori" },
                {"mr", "Marathi" },
                {"nb", "Norwegian" },
                {"fa", "Persian" },
                {"pl", "Polish" },
                {"pt-br", "Portuguese (Brazil)" },
                {"pt-pt", "Portuguese (Portugal)" },
                {"pa", "Punjabi" },
                {"otq", "Queretaro Otomi" },
                {"ro", "Romanian" },
                {"ru", "Russian" },
                {"sm", "Samoan" },
                {"sr-Cyrl", "Serbian (Cyrillic)" },
                {"sr-Latn", "Serbian (Latin)" },
                {"sk", "Slovak" },
                {"sl", "Slovenian" },
                {"es", "Spanish" },
                {"sv", "Swedish" },
                {"ty", "Tahitian" },
                {"ta", "Tamil" },
                {"te", "Telugu" },
                {"th", "Thai" },
                {"to", "Tongan" },
                {"tr", "Turkish" },
                {"uk", "Ukrainian" },
                {"ur", "Urdu" },
                {"vi", "Vietnamese" },
                {"cy", "Welsh" },
                {"yua", "Yucatec Maya" }
            };
        }

        public async Task TranslateAsync(YouTubeVideo youTubeVideo, string fromLanguage, IEnumerable<string> toLanguages)
        {
            var downloadFilePath = @"Output\input.mp4";
            var transcriptFilePaths = new List<string>();
            var originalFilePath = @"Output\original.srt";
            var tsb = new StringBuilder();
            var osb = new StringBuilder();
            var info = new StringBuilder();
            var speechServicesEventArgs = new SpeechServicesEventArgs();

            var config = SpeechTranslationConfig.FromSubscription("6e2b02facce94cdc9af14dcced9bcc41", "westeurope");
            config.SpeechRecognitionLanguage = fromLanguage;

            foreach (var language in toLanguages)
            {
                config.AddTargetLanguage(language);
                transcriptFilePaths.Add($@"Output\transcript_{language}.srt");
            }

            Housekeeping();

            var vidBytes = await youTubeVideo.GetBytesAsync();
            await File.WriteAllBytesAsync(downloadFilePath, vidBytes);
            var wavAudioFile = await ExtractingWavAudioAsync(downloadFilePath);

            var stopTranslation = new TaskCompletionSource<int>();
            var lineCount = 1;

            using (var audioInput = AudioConfig.FromWavFileInput(wavAudioFile))
            {
                using (var recognizer = new TranslationRecognizer(config, audioInput))
                {
                    // Subscribes to events.
                    recognizer.Recognized += async (s, e) =>
                    {
                        if (e.Result.Reason == ResultReason.TranslatedSpeech)
                        {
                            foreach (var element in e.Result.Translations)
                            {
                                var fromTime = TimeSpan.FromTicks(e.Result.OffsetInTicks);
                                var toTime = fromTime.Add(e.Result.Duration);

                                osb.AppendLine($"{lineCount}");
                                osb.AppendLine($"{fromTime.ToString(@"hh\:mm\:ss\.fff")} --> {toTime.ToString(@"hh\:mm\:ss\.fff")}");
                                osb.AppendLine(e.Result.Text);
                                osb.AppendLine();

                                tsb.AppendLine($"{lineCount++}");
                                tsb.AppendLine($"{fromTime.ToString(@"hh\:mm\:ss\.fff")} --> {toTime.ToString(@"hh\:mm\:ss\.fff")}");
                                tsb.AppendLine(element.Value);
                                tsb.AppendLine();

                                var transcriptFilePath = transcriptFilePaths.FirstOrDefault(x =>
                                x.Split('_', '.')
                                .Any(x => 
                                x == element.Key));

                                speechServicesEventArgs.OriginalTranscriptLine = osb.ToString();
                                speechServicesEventArgs.TranslationTranscriptLine = tsb.ToString();
                                speechServicesEventArgs.Information = string.Empty;

                                await File.AppendAllTextAsync(originalFilePath, speechServicesEventArgs.OriginalTranscriptLine);
                                await File.AppendAllTextAsync(transcriptFilePath, speechServicesEventArgs.TranslationTranscriptLine);

                                osb.Clear();
                                tsb.Clear();

                                SpeechRecognized?.Invoke(this, speechServicesEventArgs);
                            }
                        }
                        else if (e.Result.Reason == ResultReason.RecognizedSpeech)
                        {
                            info.AppendLine($"RECOGNIZED: Text={e.Result.Text}");
                            info.AppendLine($"    Speech not translated.");

                            speechServicesEventArgs.OriginalTranscriptLine = string.Empty;
                            speechServicesEventArgs.TranslationTranscriptLine = string.Empty;
                            speechServicesEventArgs.Information = info.ToString();

                            info.Clear();
                            SpeechRecognized?.Invoke(this, speechServicesEventArgs);
                        }
                        else if (e.Result.Reason == ResultReason.NoMatch)
                        {
                            info.AppendLine($"NOMATCH: Speech could not be recognized.");
                            speechServicesEventArgs.OriginalTranscriptLine = string.Empty;
                            speechServicesEventArgs.TranslationTranscriptLine = string.Empty;
                            speechServicesEventArgs.Information = info.ToString();
                            info.Clear();

                            SpeechRecognized?.Invoke(this, speechServicesEventArgs);
                        }
                    };

                    recognizer.Canceled += (s, e) =>
                    {
                        info.AppendLine($"CANCELED: Reason={e.Reason}");

                        if (e.Reason == CancellationReason.Error)
                        {
                            info.AppendLine($"CANCELED: ErrorCode={e.ErrorCode}");
                            info.AppendLine($"CANCELED: ErrorDetails={e.ErrorDetails}");
                            info.AppendLine($"CANCELED: Did you update the subscription info?");
                        }

                        speechServicesEventArgs.OriginalTranscriptLine = string.Empty;
                        speechServicesEventArgs.TranslationTranscriptLine = string.Empty;
                        speechServicesEventArgs.Information = info.ToString();
                        info.Clear();

                        SpeechCanceled?.Invoke(this, speechServicesEventArgs);
                        stopTranslation.TrySetResult(0);
                    };

                    recognizer.SpeechStartDetected += (s, e) =>
                    {
                        info.AppendLine("Speech start detected event.");
                        speechServicesEventArgs.OriginalTranscriptLine = string.Empty;
                        speechServicesEventArgs.TranslationTranscriptLine = string.Empty;
                        speechServicesEventArgs.Information = info.ToString();

                        SpeechStartDetected?.Invoke(this, speechServicesEventArgs);
                        info.Clear();
                    };

                    recognizer.SpeechEndDetected += (s, e) =>
                    {
                        info.AppendLine("Speech end detected event.");
                        speechServicesEventArgs.OriginalTranscriptLine = string.Empty;
                        speechServicesEventArgs.TranslationTranscriptLine = string.Empty;
                        speechServicesEventArgs.Information = info.ToString();

                        SpeechEndDetected?.Invoke(this, speechServicesEventArgs);
                        info.Clear();
                    };

                    recognizer.SessionStarted += (s, e) =>
                    {
                        info.AppendLine("Start translation...");
                        info.AppendLine("Session started event.");
                        speechServicesEventArgs.OriginalTranscriptLine = string.Empty;
                        speechServicesEventArgs.TranslationTranscriptLine = string.Empty;
                        speechServicesEventArgs.Information = info.ToString();

                        SpeechSessionStarted?.Invoke(this, speechServicesEventArgs);
                        info.Clear();
                    };

                    recognizer.SessionStopped += (s, e) =>
                    {
                        info.AppendLine("Session stopped event.");
                        info.AppendLine("Stop translation.");
                        speechServicesEventArgs.OriginalTranscriptLine = string.Empty;
                        speechServicesEventArgs.TranslationTranscriptLine = string.Empty;
                        speechServicesEventArgs.Information = info.ToString();


                        SpeechSessionStopped?.Invoke(this, speechServicesEventArgs);
                        info.Clear();
                        stopTranslation.TrySetResult(0);
                    };

                    // Starts continuous recognition. Uses StopContinuousRecognitionAsync() to stop recognition.

                    await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

                    // Waits for completion.
                    // Use Task.WaitAny to keep the task rooted.
                    Task.WaitAny(new[] { stopTranslation.Task });

                    // Stops translation.
                    await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
                }
            }
        }


        private void Housekeeping()
        {
            var dirInfo = Directory.CreateDirectory("Output");
            dirInfo.Attributes = FileAttributes.Normal;

            foreach (var file in dirInfo.GetFiles())
            {
                File.Delete(file.FullName);
            }
        }
        private async Task<string> ExtractingWavAudioAsync(string file)
        {
            string output = Path.ChangeExtension(Path.GetFullPath(file), "wav");
            var conversion = await FFmpeg.Conversions.FromSnippet.ExtractAudio(file, output);
            await conversion.Start();

            return output;
        }
    }

    public class SpeechServicesEventArgs : EventArgs
    {
        public string OriginalTranscriptLine { get; set; }
        public string TranslationTranscriptLine { get; set; }
        public string Information { get; set; }
    }
}