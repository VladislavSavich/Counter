using System;
using UnityEngine;
using UnityEngine.UI;

public class Switcher : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _counter.SwitchState();
    }
}