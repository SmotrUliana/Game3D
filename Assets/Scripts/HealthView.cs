using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Health _health;

    private void Update()
    {
        _image.fillAmount = _health.Current / _health.MaxHp;
    }
}