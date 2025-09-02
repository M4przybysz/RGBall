using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    float rotationSpeed = 100f;
    float mouseInputY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseInputY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.left, mouseInputY * rotationSpeed * Time.deltaTime);
    }
}
