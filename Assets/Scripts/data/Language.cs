public static class Language
{
    public enum Options
    {
        EN, RU, AM
    }

    public static Language.Options ToLanguage(this string lang)
    {
        switch (lang)
        {
            case "en":
                return Language.Options.EN;
            case "ru":
                return Language.Options.RU;
            case "am":
                return Language.Options.AM;
        }

        return Language.Options.EN;
        
    }
}
