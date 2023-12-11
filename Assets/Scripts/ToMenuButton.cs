using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToMenuButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene("Menu");
    }
}