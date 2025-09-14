using System.Collections;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    GameObject launcherWall;
    public float multiplier;
    float launchSpeed = 5f;
    bool launch = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        launcherWall = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (launch && launcherWall.transform.localPosition.y < 0)
        {
            launcherWall.transform.Translate(Vector3.up * launchSpeed * Time.deltaTime);
        }
        else
        {
            launch = false;
        }

        if (!launch && launcherWall.transform.localPosition.y > -0.5)
        {
            launcherWall.transform.Translate(Vector3.down * launchSpeed * Time.deltaTime);
        }
    }

    public void Launch()
    {
        StartCoroutine(nameof(ActivateLauncherWall));
    }

    IEnumerator ActivateLauncherWall()
    {
        yield return new WaitForSeconds(0.5f);
        launch = true;
    }

}
