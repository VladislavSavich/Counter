using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;
    [SerializeField] float _delay = 0.5f;

    private int _counter;
    private bool _isActive = false;

    void Start()
    {
        _counter = 0;
        _text.text = "0";
    }

    private IEnumerator IncreaseCount(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true) 
        { 
            _counter++;
            DisplayCount(_counter);
            yield return wait;
        }
    }

    private void DisplayCount(int count)
    {
        _text.text = count.ToString("");
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void SwitchState() => _isActive = !_isActive;

    private void OnButtonClicked()
    {
        if (_isActive)
            StopAllCoroutines();
        else 
            StartCoroutine(IncreaseCount(_delay));

        SwitchState();
    }
}
