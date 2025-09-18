using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowOrHidePauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { ShowOrHidePauseMenu(); }
    }

    public void ShowOrHidePauseMenu()
    {
        // Show or hide all menu elements
        GameObject child = transform.GetChild(0).gameObject;
        for (int i = 0; i < transform.childCount; i++)
        {
            child = transform.GetChild(i).gameObject;
            child.SetActive(!child.activeInHierarchy);
        }

        // Show or hide cursor
        if (child.activeInHierarchy) { Cursor.visible = true; }
        else { Cursor.visible = false; }

        Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void SaveAndQuit()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
