using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int maxBalls = 5;
    [SerializeField] private float spawnAreaSize = 5f;
    [SerializeField] private float disappearTime = 5f;

    private List<GameObject> balls = new List<GameObject>();

    private void Update()
    {
        if (balls.Count < maxBalls)
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        GameObject ball = ObjectPooler.Instance.GetPooledObject();
        
        if (ball != null)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(-spawnAreaSize, spawnAreaSize),
                5f,
                Random.Range(-spawnAreaSize, spawnAreaSize)
            );

            ball.transform.position = spawnPos;
            ball.SetActive(true);

            Ball ballScript = ball.GetComponent<Ball>();
            ballScript.Initialize(disappearTime);

            balls.Add(ball);
        }
    }

    public void RemoveBall(GameObject ball)
    {
        balls.Remove(ball);
    }
}

