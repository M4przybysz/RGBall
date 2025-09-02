using Unity.Mathematics;
using UnityEngine;

public class RotateCameraY : MonoBehaviour
{
    [SerializeField] GameObject player;
    float rotationSpeed = 100f;
    float mouseInputX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        mouseInputX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseInputX * rotationSpeed * Time.deltaTime);
    }
}
