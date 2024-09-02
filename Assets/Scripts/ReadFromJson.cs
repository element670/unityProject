using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ReadFromJson : MonoBehaviour
{
    //Language options is enum containing AM RU EN
    public static Dictionary<string, string> LoadTranslatins(Language.Options language)
    {
        string postfix = "en";
        switch (language)
        {
            case Language.Options.EN:
                postfix = "en";
                break;
            case Language.Options.RU:
                postfix = "ru";
                break;
            case Language.Options.AM:
                postfix = "am";
                break;
        }

        string fileName = $"Assets/Json/language_{postfix}.json";
        string jsonstr = File.ReadAllText(fileName);

        Debug.Log($"The json file is: {jsonstr}");


        Translations keyValuePairs = JsonUtility.FromJson<Translations>(jsonstr);
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (var kvp in keyValuePairs.keyValuePairs)
        {
            dictionary[kvp.key] = kvp.value;
        }
        
        return dictionary;
    }

    [System.Serializable]
    public class KeyValue
    {
        public string key;
        public string value;
    }

    [System.Serializable]
    public class Translations
    {
        public List<KeyValue> keyValuePairs;
    }
}