using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _ballRb;
    public float pushForce;
    private GameObject focalPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        _ballRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        BallMovement();
    }
    
    void BallMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _ballRb.AddForce(focalPoint.transform.forward * Time.deltaTime * pushForce * verticalInput, ForceMode.Impulse);
    }
}
