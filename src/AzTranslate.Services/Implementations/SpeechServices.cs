﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzTranslate.Services
{
    public class SpeechServices : ISpeechServices
    {
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
    }
}
