using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //========================================================================
    // External elements
    //========================================================================
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject focalPoint;
    Transform focalPointTransform;

    //========================================================================
    // Internal elements
    //========================================================================
    float movementInputH;
    float movementInputV;
    Vector3 movementVector;
    Rigidbody playerRigidbody;

    //========================================================================
    // Gameplay variables
    //========================================================================
    int healthPoints = 5;
    const float decelleration = 3f;

    // Rolling speed variables
    float _rollingSpeedForce = 10f;
    public const float minRollingSpeedForce = 10f;
    public const float maxRollingSpeedForce = 100f; 
    float _rollingSpeedLimit = 15f;
    public const float minRollingSpeedLimit = 15f;
    public const float maxRollingSpeedLimit = 255f;

    // Bounce variables
    float _ExtraBounceForce = 1500f;
    public const float minExtraBounceForce = 0f;
    public const float normalExtraBounceForce = 1500f;
    public const float maxExtraBounceForce = 7500f;
    float _bounciness = 0.5f;
    public const float minBounciness = 0f;
    public const float normalBounciness = 0.5f;
    public const float maxBounciness = 1f;

    // Scale variables
    public const float minScale = 0.25f;
    public const float normalScale = 1f;
    public const float maxScale = 2.5f;

    //========================================================================
    // Backing fields
    //========================================================================
    public float RollingSpeedForce
    {
        get { return _rollingSpeedForce; }
        set { _rollingSpeedForce = Mathf.Clamp(value, minRollingSpeedForce, maxRollingSpeedForce); }
    }

    public float RollingSpeedLimit
    {
        get { return _rollingSpeedLimit; }
        set { _rollingSpeedLimit = Mathf.Clamp(value, minRollingSpeedLimit, maxRollingSpeedLimit); }
    }

    public float ExtraBounceForce
    {
        get { return _ExtraBounceForce; }
        set { _ExtraBounceForce = Mathf.Clamp(value, minExtraBounceForce, maxExtraBounceForce); }
    }

    public float Bounciness
    {
        get { return _bounciness; }
        set
        {
            _bounciness = Mathf.Clamp(value, minBounciness, maxBounciness);
            GetComponent<SphereCollider>().material.bounciness = _bounciness;
        }
    }

    //========================================================================
    // Start and Update
    //========================================================================

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.linearDamping = RollingSpeedForce / RollingSpeedLimit;

        focalPointTransform = focalPoint.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveBall();
    }

    //========================================================================
    // Original methods
    //========================================================================
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

    //========================================================================
    // Unity events
    //========================================================================    
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
