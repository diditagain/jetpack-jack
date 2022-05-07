using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustForceMagnitude;
    [SerializeField] float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustForceMagnitude * Time.deltaTime);
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Rotate on Negative Z axis");
            ApplyRotation(rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Rotate Positive Z Axis");
            ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.back * rotation * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
