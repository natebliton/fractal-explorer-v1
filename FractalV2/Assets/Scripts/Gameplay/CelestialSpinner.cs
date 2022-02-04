using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialSpinner : MonoBehaviour
{
   // Rigidbody2D rb2D;
    public float rotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
       // rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, rotationSpeed, Space.Self);
    }
}
