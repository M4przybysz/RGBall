using UnityEngine;

public class HintManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject child;
            for (int i = 0; i < transform.childCount; i++)
            {
                child = transform.GetChild(i).gameObject;
                child.SetActive(!child.activeInHierarchy);
            }
        }
    }
}
