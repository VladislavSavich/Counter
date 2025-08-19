using System.Collections;
using TMPro;
using UnityEngine;

public class CounterVew : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void Start()
    {
        _counterText.text = "0";
    }

    private void OnEnable()
    {
        _counter.Changed += ShowCount;
    }

    private void OnDisable()
    {
        _counter.Changed -= ShowCount;
    }

    private void ShowCount(int count)
    {
        _counterText.text = count.ToString("");
    }
}
