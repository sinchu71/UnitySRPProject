using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{
   public float rotationSpeed = 100f; // Degrees per second
    
     // Start is called before the first frame update
    void Start()
    {
        // Rotate the cube continuously on the Y-axis
        LeanTween.rotateAround(gameObject, Vector3.up, 360f, 360f / rotationSpeed).setLoopClamp();
    }

}
