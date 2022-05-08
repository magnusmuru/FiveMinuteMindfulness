namespace FiveMinuteMindfulness.Core.Models;

public class LanguageString : Dictionary<string, string>
{
    private const string DefaultCulture = "en";

    public new string this[string key]
    {
        get => base[key];
        set => base[key] = value;
    }

    public LanguageString(string value) : this(value, Thread.CurrentThread.CurrentUICulture.Name)
    {
    }


    public LanguageString()
    {
    }

    public LanguageString(string value, string culture)
    {
        this[culture] = value;
    }

    public void SetTranslation(string value)
    {
        this[Thread.CurrentThread.CurrentUICulture.Name] = value;
    }

    public string? Translate(string? currentUserCulture = null)
    {
        if (Count == 0) return null;

        currentUserCulture = currentUserCulture?.Trim() ?? Thread.CurrentThread.CurrentUICulture.Name;

        /*
         in database - en, en-GB
         in query - en, en-GB, en-US
         */

        // do we have exact match - en-GB == en-GB
        if (ContainsKey(currentUserCulture))
        {
            return this[currentUserCulture];
        }

        // do we have match without the region en-US.StartsWith(en)
        var key = Keys.FirstOrDefault(t => currentUserCulture.StartsWith(t));
        if (key != null)
        {
            return this[key];
        }

        // try to find the default culture
        key = Keys.FirstOrDefault(t => t.StartsWith(DefaultCulture));
        if (key != null)
        {
            return this[key];
        }

        // just return the first in list or null
        return null;
    }

    public override string ToString()
    {
        return Translate() ?? "????";
    }

    public static implicit operator string(LanguageString? l) => l?.ToString() ?? "null";
    public static implicit operator LanguageString(string s) => new LanguageString(s);
}