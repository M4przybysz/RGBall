using UnityEngine;

public class Level2OpenEndDoor : MonoBehaviour, IActivatable
{
    public void Activate()
    {
        Destroy(gameObject);
    }
}
