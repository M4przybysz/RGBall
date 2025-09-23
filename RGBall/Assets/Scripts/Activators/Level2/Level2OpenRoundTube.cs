using UnityEngine;

public class Level2OpenRoundTube : MonoBehaviour, IActivatable
{
    float speed = 2;
    bool isActivated = false;

    // Update is called once per frame
    void Update()
    {
        if (isActivated && transform.localPosition.x < 9.25f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void Activate()
    {
        isActivated = true;
    }
}
