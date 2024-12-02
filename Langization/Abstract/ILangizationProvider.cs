namespace Langization.Abstract;

public interface ILangizationProvider
{
    string Translate(string culture, string key);
}