using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Vector3 respawnPosition = new(0, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hide checkpoint trigger and respawn position marker
        transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);

        respawnPosition = transform.GetChild(1).transform.position;
    }
}
