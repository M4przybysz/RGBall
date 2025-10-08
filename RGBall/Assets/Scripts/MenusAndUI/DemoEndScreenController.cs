using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoEndScreenController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void SaveAndQuit()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
