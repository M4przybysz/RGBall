using UnityEngine;

public class RotateCameraY : MonoBehaviour
{
    [SerializeField] GameObject player;
    float rotationSpeed = 100f;
    float mouseInputX;
    public bool isCameraLocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set focal point to the player's position
        transform.position = player.transform.position;

        // Move camera left and right
        if(!isCameraLocked)
        {
            mouseInputX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up, mouseInputX * rotationSpeed * Time.deltaTime);
        }
    }
}
