using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ContinueGame);
        if(!PlayerPrefs.HasKey("Level"))
            button.interactable = false;
    }

    private void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Level"));
    }
}