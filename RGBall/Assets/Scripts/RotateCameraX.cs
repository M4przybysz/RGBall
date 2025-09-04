using System;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    float rotationSpeed = 100f;
    float minRotation = -75;
    float maxRotation = 75;
    float rotationX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move camera up and down
        rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        rotationX = Math.Clamp(rotationX, minRotation, maxRotation); // Limit camera movement
        transform.eulerAngles = new Vector3(rotationX, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
