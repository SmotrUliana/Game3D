using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField]
    private string _nextLevelName;
    [SerializeField]
    private float _delay;

    private bool _switching;

    private void OnTriggerEnter(Collider other)
    {
        if(!_switching)
        {
            _switching = true;
            StartCoroutine(SwitchLevel());
        }
    }

    private IEnumerator SwitchLevel()
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_nextLevelName);
    }
}