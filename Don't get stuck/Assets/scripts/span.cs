using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class span : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] spawnPoints;
    public Transform player;
    public float minBulletSpeed = 8f;
    public float maxBulletSpeed = 24f;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    private float nextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnBullet();
            SetNextSpawnTime();
        }
    }

    private void SpawnBullet()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject bullet = Instantiate(bulletPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
        BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();

        if (bulletMovement == null)
        {
            bulletMovement = bullet.AddComponent<BulletMovement>();
        }

        float bulletSpeed = Random.Range(minBulletSpeed, maxBulletSpeed);
        bulletMovement.Initialize(player.position - randomSpawnPoint.position, bulletSpeed);
    }

    private void SetNextSpawnTime()
    {
        float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        nextSpawnTime = Time.time + spawnInterval;
    }
}
