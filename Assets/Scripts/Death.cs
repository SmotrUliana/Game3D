using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField]
    private Health _health;
    [SerializeField]
    private GameObject _vfx;
    [SerializeField]
    private float _delay;

    private bool _killing;
    
    private void Update()
    {
        if(_health.Current <= 0 && !_killing)
        {
            _killing = true;
            StartCoroutine(Kill());
        }
    }

    private IEnumerator Kill()
    {
        Instantiate(_vfx, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}