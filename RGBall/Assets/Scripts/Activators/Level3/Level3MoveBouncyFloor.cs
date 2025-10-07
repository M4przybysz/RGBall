using UnityEngine;

public class Level3MoveBouncyFloor : MonoBehaviour, IActivatable
{
    [SerializeField] float target_height;
    float speed = 1f;
    bool isActivated = false;

    // Update is called once per frame
    void Update()
    {
        if (isActivated && transform.localPosition.y < target_height)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
    
    public void Activate()
    {
        isActivated = true;
    }
}
