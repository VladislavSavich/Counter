using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;
    public event Action<int> Changed;
    private int _counter;
    private bool _isActive = false;

    private void Start()
    {
        _counter = 0;
    }

    private IEnumerator IncreaseCount(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            _counter++;
            Changed?.Invoke(_counter);

            yield return wait;
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    public void SwitchState() => _isActive = !_isActive;

    private void OnButtonClicked()
    {
        if (_isActive)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
        else
        {
            _coroutine = StartCoroutine(IncreaseCount(_delay));
        }

        SwitchState();
    }
}