using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    private Rigidbody rb;
    private float disappearTime = 5f;  // Can be changed via Spawner

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Initialize(float _disappearTime)
    {
        disappearTime = _disappearTime;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Invoke(nameof(DestroyBall), disappearTime);
    }

    private void DestroyBall()
    {
        gameObject.SetActive(false);
    }
}

