using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plat : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float slideForce = 10f;

    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float rotationX = verticalInput * rotationSpeed * Time.deltaTime;
        float rotationZ = -horizontalInput * rotationSpeed * Time.deltaTime;

        transform.Rotate(rotationX, 0f, rotationZ);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRigidbody.useGravity = false;
            Vector3 slopeDirection = collision.contacts[0].normal;
            playerRigidbody.velocity = slopeDirection * slideForce;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRigidbody.useGravity = true;
        }
    }
}
