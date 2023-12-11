using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        GetComponent<Button>().onClick.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level1");
    }
}