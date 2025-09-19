using UnityEngine;
using UnityEngine.SceneManagement;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Continue()
    {
        SceneManager.LoadScene(GameManager.Instance.LastPlayedLevel);
    }

    public void QuitGame()
    {
        GameManager.Instance.SavePlayerData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
