using System;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    Vector2 _offset = new(1.25f, -0.75f);
    public static readonly Vector2 normalOffset = new(1.25f, -0.75f);
    float rotationSpeed = 100f;
    float minRotation = -75;
    float maxRotation = 75;
    float rotationX;
    public bool isCameraLocked = false;

    // Backing fields
    public Vector2 Offset
    {
        get { return _offset; }
        set
        {
            _offset = value;
            transform.localPosition = new Vector3(0, _offset.x, _offset.y);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move camera up and down
        if(!isCameraLocked)
        {
            rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            rotationX = Math.Clamp(rotationX, minRotation, maxRotation); // Limit camera movement
            transform.eulerAngles = new Vector3(rotationX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
