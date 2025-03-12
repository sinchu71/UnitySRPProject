using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    [SerializeField]
    private int poolSize = 10; // Total number of balls that can be active at once
    
    [SerializeField]
    private float spawnInterval = 2f;

    public Vector3 spawnArea = new Vector3(10f, 5f, 10f);
    
    [SerializeField]
    private float spawnTimer;

    private void Start()
    {
        ObjectPooler.Instance.CreatePool("Ball", ballPrefab, poolSize);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnBall();
            spawnTimer = 0f;
        }
    }

    private void SpawnBall()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            spawnArea.y,
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        ObjectPooler.Instance.SpawnFromPool("Ball", spawnPosition, Quaternion.identity);
    }
}
