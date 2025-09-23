using UnityEngine;

public class RectTubeRotate : MonoBehaviour, IActivatable
{
    public void Activate()
    {
        transform.eulerAngles = new Vector3(-90, 0, 0);
    }
}
