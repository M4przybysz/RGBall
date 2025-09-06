using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    Vector2 _offset = new Vector2(1.5f, -1.5f);
    float rotationSpeed = 100f;
    float minRotation = -75;
    float maxRotation = 75;
    float rotationX;

    // Backing fields
    public Vector2 Offset
    {
        get { return _offset; }
        set
        {
            _offset = value;
            transform.localPosition = new Vector3(0, value.x, value.y);
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
        rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        rotationX = Math.Clamp(rotationX, minRotation, maxRotation); // Limit camera movement
        transform.eulerAngles = new Vector3(rotationX, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
