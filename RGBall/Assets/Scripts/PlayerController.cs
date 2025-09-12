using System.Collections;
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
    const float decelleration = 3f;
    bool _colorInvertion = false;
    Vector3 _respawnPosition;

    // Health points
    int _healthPoints = 5;
    const int maxHealthPoints = 5;

    // Rolling speed variables
    float _rollingSpeedForce = 20f;
    public const float minRollingSpeedForce = 20f;
    public const float maxRollingSpeedForce = 100f;
    float _rollingSpeedLimit = 20f;
    public const float minRollingSpeedLimit = 20f;
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
    public Vector3 RespawnPosition
    {
        get { return _respawnPosition; }
        set { _respawnPosition = value; }
    }

    public int HealthPoints
    {
        get { return _healthPoints; }
        set { _healthPoints = Mathf.Clamp(value, 0, maxHealthPoints); }
    }

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

    public bool ColorInvertion
    {
        get { return _colorInvertion; }
        set
        {
            _colorInvertion = value;
            InvertColors();
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

        RespawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPositionY(); // Check if player fell off the map
        MoveBall();
        HandleInputs();
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
            // Get camera directions
            Vector3 cameraForward = focalPointTransform.forward;
            Vector3 cmaeraRight = focalPointTransform.right;

            cameraForward.y = 0;
            cmaeraRight.y = 0;

            // Create a movement vector
            movementVector = (movementInputV * cameraForward) + (movementInputH * cmaeraRight);

            // Invert controls if colors are inverted
            if (ColorInvertion) { movementVector *= -1; }

            // Roll the ball
            playerRigidbody.AddForce(RollingSpeedForce * movementVector);
        }
    }

    void CheckPositionY()
    {
        if (transform.position.y < -5) { Kill(); }
    }

    void HandleInputs()
    {
        // Invert colors after pressing Space
        if (Input.GetKeyDown(KeyCode.Space)) { ColorInvertion = !ColorInvertion; }
    }

    public void ScaleBall(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
        mainCamera.GetComponent<RotateCameraX>().Offset = RotateCameraX.normalOffset * scale;
    }

    void InvertColors()
    {
        // Invert material colors
        int newColorR = 255 - Mathf.RoundToInt(GetComponent<Renderer>().material.color.r * 255);
        int newColorG = 255 - Mathf.RoundToInt(GetComponent<Renderer>().material.color.g * 255);
        int newColorB = 255 - Mathf.RoundToInt(GetComponent<Renderer>().material.color.b * 255);

        GetComponent<Renderer>().material.color = new Color32((byte)newColorR, (byte)newColorG, (byte)newColorB, 255);

        // Invert ball aspects
        RollingSpeedForce = (maxRollingSpeedForce - minRollingSpeedForce) / 255 * newColorR;
        RollingSpeedLimit = (maxRollingSpeedLimit - minRollingSpeedLimit) / 255 * newColorR;

        float scaleStep;
        float extraBounceStep;
        float bouncinessStep;

        if (ColorInvertion)
        {
            scaleStep = -1 * (normalScale - minScale) / 255f;
            extraBounceStep = -1 * (normalExtraBounceForce - minExtraBounceForce) / 255f;
            bouncinessStep = -1 * (normalBounciness - minBounciness) / 255f;
        }
        else
        {
            scaleStep = (maxScale - normalScale) / 255f;
            extraBounceStep = (maxExtraBounceForce - normalExtraBounceForce) / 255f;
            bouncinessStep = (maxBounciness - normalBounciness) / 255f;
        }

        ScaleBall(normalScale + scaleStep * newColorG);
        ExtraBounceForce = normalExtraBounceForce + extraBounceStep * newColorB;
        Bounciness = normalBounciness + bouncinessStep * newColorB;
    }

    public void Damage(int damage)
    {
        HealthPoints -= damage;
        print(HealthPoints);
        if (HealthPoints <= 0) { Respawn(); }
    }

    public void Kill()
    {
        Respawn();
    }

    public void Respawn()
    {
        HealthPoints = maxHealthPoints;
        playerRigidbody.linearVelocity = new Vector3(0, 0, 0);
        transform.position = RespawnPosition;
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

        if (other.CompareTag("CheckpointTrigger"))
        {
            RespawnPosition = other.transform.parent.GetComponent<CheckpointController>().respawnPosition;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("KillingFloor"))
        {
            playerRigidbody.AddExplosionForce(ExtraBounceForce, collision.GetContact(0).point, 5);
        }

        if (collision.gameObject.CompareTag("KillingFloor"))
        {
            StopCoroutine(nameof(Heal));
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("KillingFloor"))
        {
            StartCoroutine(nameof(Heal));
        }
    }

    //========================================================================
    // Coroutines
    //========================================================================  
    IEnumerator Heal()
    {
        yield return new WaitForSeconds(5);
        HealthPoints = maxHealthPoints;
        print("Regained full health");
    }
}
