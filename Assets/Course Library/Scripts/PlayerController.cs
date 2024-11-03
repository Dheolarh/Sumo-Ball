using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _ballRb;
    public float pushForce;
    // Start is called before the first frame update
    void Start()
    {
        _ballRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BallMovement();
    }
    
    void BallMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _ballRb.AddForce(Vector3.forward * Time.deltaTime * pushForce * verticalInput, ForceMode.Impulse);
    }
}
