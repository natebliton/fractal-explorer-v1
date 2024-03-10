using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlanets : MonoBehaviour
{
    //private float timer;

    //[SerializeField] private float startSpin = 2f;
    //[SerializeField] private float stopSpin = 2f;
    private Animator planetSpin;
    private bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        planetSpin = GetComponent<Animator>();
        planetSpin.SetBool("start", false);
        planetSpin.SetBool("stop", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            planetSpin.SetBool("start", true);
            planetSpin.SetBool("stop", false);
        }
        else
        {
            planetSpin.SetBool("start", false);
            planetSpin.SetBool("stop", true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        // Debug.Log("hit detected");

        if (other.CompareTag("AlienFurball"))
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
