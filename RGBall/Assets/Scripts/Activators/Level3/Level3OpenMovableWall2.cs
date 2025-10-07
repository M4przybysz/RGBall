using UnityEngine;

public class Level3OpenMovableWall2 : MonoBehaviour, IActivatable
{
    float speed = 2.5f;
    bool isActivated = false;

    // Update is called once per frame
    void Update()
    {
        if (isActivated && transform.localPosition.y > -30f)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
    
    public void Activate()
    {
        isActivated = true;
    }
}
