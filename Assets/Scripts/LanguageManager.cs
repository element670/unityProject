using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static readonly string ACTION = "SELECTED_LANG";
    private static string SELECTED_LANG = "selected_lang";
    private Dictionary<string, string> _translations = new Dictionary<string, string>();
    void Start()
    {
        var lang = PlayerPrefs.GetString(SELECTED_LANG, "am").ToLanguage();
        GetLanguage(lang);
        EventBus.Register<Language.Options>(LanguageClick.ACTION, ChangeLanguage);
        EventBus.Trigger(ACTION, new ChangeTranslations { language = lang, translations = _translations});
    }
    private void ChangeLanguage(Language.Options language)
    {
        PlayerPrefs.SetString(SELECTED_LANG, language.ToString());
        PlayerPrefs.Save();
        GetLanguage(language);
        EventBus.Trigger(ACTION, new ChangeTranslations { language = language, translations = _translations});
    }
    private void GetLanguage(Language.Options language)
    {
        _translations = ReadFromJson.LoadTranslatins(language);
    }

 public struct ChangeTranslations
    {
        public Language.Options language;
        public Dictionary<string, string> translations;
    }
}
