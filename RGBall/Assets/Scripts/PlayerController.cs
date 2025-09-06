using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // External elements
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject focalPoint;
    Transform focalPointTransform;

    // Internal elements
    float movementInputH;
    float movementInputV;
    Vector3 movementVector;
    Rigidbody playerRigidbody;

    // Gameplay variables
    int healthPoints = 5;
    float _rollingSpeedForce = 10f;
    float _maxRollingSpeed = 15f;
    float _ExtraBounceForce = 1500f;
    float decelleration = 3f;

    // Backing fields
    public float RollingSpeedForce
    {
        get { return _rollingSpeedForce; }
        set { _rollingSpeedForce = Mathf.Clamp(value, 10f, 100f); }
    }

    public float MaxRollingSpeed
    {
        get { return _maxRollingSpeed; }
        set { _maxRollingSpeed = Mathf.Clamp(value, 15f, 255f); }
    }

    public float ExtraBounceForce
    {
        get { return _ExtraBounceForce; }
        set { _ExtraBounceForce = Mathf.Clamp(value, 1500f, 5000f); }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.linearDamping = RollingSpeedForce / MaxRollingSpeed;

        focalPointTransform = focalPoint.transform;
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
            Vector3 cameraForward = focalPointTransform.forward;
            Vector3 cmaeraRight = focalPointTransform.right;

            cameraForward.y = 0;
            cmaeraRight.y = 0;

            movementVector = (movementInputV * cameraForward) + (movementInputH * cmaeraRight);

            playerRigidbody.AddForce(RollingSpeedForce * movementVector);
        }
    }

    public void ScaleBall(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
        mainCamera.GetComponent<RotateCameraX>().Offset *= scale / 1.5f;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Orb"))
        {
            other.gameObject.GetComponent<Orb>().ChanagePlayerAspect();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            playerRigidbody.AddExplosionForce(ExtraBounceForce, collision.GetContact(0).point, 5);
        }
    }
}
