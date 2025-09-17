using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelMenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GoBack();
    }

    public void SelectLevel(string levelName)
    {
        GameManager.Instance.LastPlayedLevel = levelName;
        SceneManager.LoadScene(levelName);
    }

    public void GoBack()
    {
        // Hide all menu elements
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void OpenMenu()
    {
        // Show all menu elements
        for (int i = 0; i < transform.childCount && i < GameManager.Instance.LevelsCompleted + 3; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
