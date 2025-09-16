using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

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
        // Show or hide cursor
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;

        // Show or hide all menu elements
        GameObject child;
        for (int i = 0; i < transform.childCount; i++)
        {
            child = transform.GetChild(i).gameObject;
            child.SetActive(!child.activeInHierarchy);
        }
    }

    public void SaveAndQuit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
