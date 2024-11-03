using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _ballRb;
    public float pushForce;
    private GameObject focalPoint;
    private bool activePowerUp;
    public GameObject _powerUpIndicator;
    
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
        PoweredUp();
    }
    
    void BallMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _ballRb.AddForce(focalPoint.transform.forward * Time.deltaTime * pushForce * verticalInput, ForceMode.Impulse);
    }

    void PoweredUp()
    {
        if (activePowerUp)
        {
            float rotateSpeed = 10f;
            _powerUpIndicator.SetActive(true);
            _powerUpIndicator.transform.Rotate(Vector3.up, rotateSpeed);
        }
    }

    private void LateUpdate()
    {
        _powerUpIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            activePowerUp = true;
            Destroy(other.gameObject);
            StartCountdwonPowerUp();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && activePowerUp)
        {
            float awayForce = 15F;
            Rigidbody _enemyPosition = other.gameObject.GetComponent<Rigidbody>();
            Vector3 pushAway = other.gameObject.transform.position - transform.position;
            _enemyPosition.AddForce(pushAway * awayForce, ForceMode.Impulse);
            Debug.Log($"Player collided with {other.gameObject.name} with power up set to {activePowerUp}");
        }
    }

    IEnumerator StartCountdwonPowerUp()
    {
        yield return new WaitForSeconds(7);
        activePowerUp = false;
        _powerUpIndicator.SetActive(false);
    }
}
