using TMPro;
using UnityEngine;

public class UIPlayerResourcesTracker : UIScreen
{
    [SerializeField] private TextMeshProUGUI _currentValue;
    [SerializeField] private TextMeshProUGUI _maxValue;

    public virtual void SetUIData(float currentValue, float maxValue)
    {
        _currentValue.text = currentValue.ToString("F0");
        _maxValue.text = maxValue.ToString("F0");
    }
}
