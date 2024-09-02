using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;

    [SerializeField] 
    private Button startButton;
    [SerializeField]
    private LanguageClick en;
    [SerializeField]
    private LanguageClick ru;
    [SerializeField]
    private LanguageClick am;

    [SerializeField] private TextMeshProUGUI startTitle;
    [SerializeField] private TextMeshProUGUI welcomeTitle;
    [SerializeField] private TextMeshProUGUI gameTitle;

    [SerializeField] private TextMeshProUGUI findingOpponent;
    [SerializeField] private TextMeshProUGUI yourName;
    [SerializeField] private TextMeshProUGUI cancelButton;

    [SerializeField] private GameUI _gameUI;
    private void Awake()
    {
        closeButton.onClick.AddListener(() => {
            Show(false);
        });
        startButton.onClick.AddListener(() =>
        {
            _gameUI.ShowGameUI(true);
        });
        EventBus.Register<LanguageManager.ChangeTranslations>(LanguageManager.ACTION, SetSelectedLanguage);
    }

    #region ClosingPanel
    public void Show(bool show)
    {
        Debug.Log("The function Show works");
        gameObject.SetActive(show);
    }
    #endregion
    private void SetSelectedLanguage(LanguageManager.ChangeTranslations translation)
    {
        if(en.GetLanguage() == translation.language) 
        { 
            print("en is toggled");
            en.Toggle();
        }
        if(ru.GetLanguage() == translation.language)
        {
            print("ru is toggled");
            ru.Toggle();
        }
        if (am.GetLanguage() == translation.language)
        {
            print("am is toggled");
            am.Toggle();
        }
        
        SetTranslations(translation);
    }

    private void SetTranslations(LanguageManager.ChangeTranslations translation)
    {
        //translation.translations.TryGetValue("start", out var value);
        //translation.translations.TryGetValue("welcome", out var ke);
        //chooseLanguageText.text = ke;
        //tv.text = value;
        //translation.translations.TryGetValue("language_en", out var str);
      

        foreach (var el in translation.translations)
        {
            print($"{el.Key} : value is {el.Value}");
        }
        translation.translations.TryGetValue("start", out var value);
        startTitle.text = value;
        Debug.Log($"start title is: {startTitle.text}");
        
        translation.translations.TryGetValue("welcome", out var welc);
        welcomeTitle.text = welc;
        Debug.Log($"welcome title is: {welcomeTitle.text}");

        
    }
}
