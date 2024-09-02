using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public static readonly string ACTION = "START_CLICK";

    [SerializeField] private Button _startButton;
    [SerializeField] private GameObject _holder;

    private void Awake()
    {
        _startButton.onClick.AddListener(() =>
        {
            EventBus.Trigger(ACTION, _holder);
        });
    }

    public GameObject GetHolder()
    {
        return _holder;
    }
}
