using System.Text.Json;
using Langization.Abstract;

namespace Langization;

public class JsonLangizationProvider : ILangizationProvider
{
    private readonly Dictionary<string, Dictionary<string, string>> _translations;

    public JsonLangizationProvider(string filePath)
    {
        var options = new JsonSerializerOptions
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        var json = File.ReadAllText(filePath, System.Text.Encoding.UTF8);
        _translations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json, options) ?? new Dictionary<string, Dictionary<string, string>>();
    }
    public string Translate(string culture, string key)
    {
        if (_translations.TryGetValue(culture, out var cultureTranslations) && cultureTranslations.TryGetValue(key, out var value))
            return value;
        return key;
    }
}