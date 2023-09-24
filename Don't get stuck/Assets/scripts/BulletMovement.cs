using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour
{
    private Vector3 direction;
    private float speed ;
    private float destroyDelay = 6f;
    private float rotatespeed = 0f;
    public Transform particleEffect;
    private ScoreManager scoreManager;
    private int score;


    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }


    public void Initialize(Vector3 bulletDirection, float bulletSpeed)
    {
        direction = bulletDirection.normalized;
        speed = bulletSpeed;
        Destroy(gameObject, destroyDelay);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotatespeed * Time.deltaTime);

        if (particleEffect != null)
        {
            particleEffect.position = transform.position;
            particleEffect.rotation = transform.rotation;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (scoreManager != null)
            {
                score = ScoreManager.GetScore();
            }

            // Save the score in a static variable to be accessed in the game over scene
            ScoreManager.SetScore(score);


            Debug.Log("player colloided");
            SceneManager.LoadScene(2);
        }
    }
}