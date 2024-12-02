using Langization.Abstract;

namespace Langization;

public class LangizationManager
{
    private readonly ILangizationProvider _provider;
    private string _currentCulture = "en";

    public LangizationManager(ILangizationProvider provider)
    {
        _provider = provider;
    }

    public string Translate(string key, params object[] args)
    {
        var translation = _provider.Translate(_currentCulture, key);
        return string.Format(translation, args);
    }

    public void SetCulture(string culture) => _currentCulture = culture;

}