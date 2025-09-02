using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // External elements
    [SerializeField] GameObject focalPoint;
    Transform mainCameraTransform;

    // Internal elements
    float movementInputH;
    float movementInputV;
    Vector3 movementVector;
    Rigidbody playerRigidbody;

    // Gameplay variables
    int healthPoints = 5;
    float rollingSpeed = 10f;
    float maxRollingSpeed = 10f;
    float decelleration = 3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.linearDamping = rollingSpeed / maxRollingSpeed;

        mainCameraTransform = focalPoint.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveBall();
    }


    void MoveBall()
    {
        movementInputH = Input.GetAxis("Horizontal");
        movementInputV = Input.GetAxis("Vertical");
        // movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (movementInputH == 0 && movementInputV == 0 && playerRigidbody.linearVelocity != Vector3.zero)
        {
            playerRigidbody.AddForce(-playerRigidbody.linearVelocity * decelleration);
        }
        else
        {
            Vector3 cameraForward = mainCameraTransform.forward;
            Vector3 cmaeraRight = mainCameraTransform.right;

            cameraForward.y = 0;
            cmaeraRight.y = 0;

            movementVector = (movementInputV * cameraForward) + (movementInputH * cmaeraRight);

            playerRigidbody.AddForce(rollingSpeed * movementVector);
        }
    }
}
