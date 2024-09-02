using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public static readonly string ACTION = "CLOSE_WINDOW_CLICK";

    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject holder;
    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            EventBus.Trigger(ACTION, holder);
            print("Close button is clicked");
        });
    }
}
