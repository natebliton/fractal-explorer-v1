using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAPlanet : MonoBehaviour
{
    private Animator planetSpin;
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        planetSpin = GetComponent<Animator>();
        planetSpin.SetBool("spin", false);
        // planetSpin.SetBool("stop", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            planetSpin.SetBool("spin", true);
            //planetSpin.SetBool("stop", false);
        }
        else
        {
            planetSpin.SetBool("spin", false);
            //planetSpin.SetBool("stop", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        // Debug.Log("hit detected");

        if (other.CompareTag("AlienCat"))
        {
            StartStop();
        }

    }

    public void StartStop()
    {
        if (!start) { start = true; }
        else { start = false; }
        // if (start) { start = false; }

    }
}
