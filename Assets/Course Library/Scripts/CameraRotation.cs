using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed;
    public Rigidbody ballRb;
    public float pushForce;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BallMovement();
        CameraRotate();
    }

    void BallMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        ballRb.AddForce(Vector3.forward * Time.deltaTime * pushForce * verticalInput, ForceMode.Impulse);
    }

    void CameraRotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput);
    }
}
