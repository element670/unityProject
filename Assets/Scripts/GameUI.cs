using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    public void ShowGameUI(bool active)
    {
        gameObject.SetActive(active);
    }
    
}
