using UnityEngine;
using UnityEngine.UI;

public class TrapIntervalView : MonoBehaviour
{
    [SerializeField]
    private Trap _trap;
    [SerializeField]
    private Image _image;

    private void Update()
    {
        var progress = _trap.KillingIntervalProgress;

        if(progress == 0)
            _image.fillAmount = 0;
        else
            _image.fillAmount = 1 - progress;
    }
}