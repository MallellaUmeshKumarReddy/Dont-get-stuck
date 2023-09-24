using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Transform cameraTarget; // Reference to the camera target's transform
    public float cameraFollowSpeed = 5f;
    public ParticleSystem collisionParticle;
    public AudioClip collisionSound;

    private Rigidbody rb;
    public AudioSource audioSource;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.isKinematic = false;
        rb.useGravity = true;


        if (collisionParticle != null)
        {
            collisionParticle.Stop();
        }

        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.convex = false;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.AddForce(movement * moveSpeed);

        // Update the camera target position
        if (cameraTarget != null)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.y = cameraTarget.position.y; // Maintain the same y position
            cameraTarget.position = Vector3.Lerp(cameraTarget.position, targetPosition, cameraFollowSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (collisionParticle != null && !collisionParticle.isPlaying)
            {
                collisionParticle.Play();
                //audioSource.PlayOneShot(collisionSound);
            }


            if (collisionSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collisionSound);
                Debug.Log("audio is working");
            }
        }
    }

    private void LateUpdate()
    {
        // Make the camera look at the camera target
        if (cameraTarget != null)
        {
            Camera.main.transform.LookAt(cameraTarget);
        }
    }
}
