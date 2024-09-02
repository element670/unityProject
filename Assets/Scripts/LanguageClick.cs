using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LanguageClick : MonoBehaviour
{
    public static readonly string ACTION = "LANGUAGE_CLICK";
    [SerializeField] 
    private Language.Options language;
    [SerializeField]
    private Toggle button;

    private void Awake()
    {
        button.onValueChanged.RemoveAllListeners();
        button.onValueChanged.AddListener((isChecked) => { 
            if (isChecked)
            {
                EventBus.Trigger(ACTION, language);
                print(language + " is selected");
            }
        });
    }

    public Language.Options GetLanguage()
    {
        return language;
    }
    
    public void Toggle()
    {
        button.isOn = true;
    }
}
