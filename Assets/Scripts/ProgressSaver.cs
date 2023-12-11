using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressSaver : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetString("Level", SceneManager.GetActiveScene().name);
    }
}