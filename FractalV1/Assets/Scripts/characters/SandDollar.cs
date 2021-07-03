using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandDollar : MonoBehaviour
{

    private bool burying = true;
    private int buryingState = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(burying)
        {
            buryingState += 1;
            if((buryingState/10)%2 > 0) {
                transform.Rotate(new Vector3(0,0,5));
            } else {
                transform.Rotate(new Vector3(0,0,-5));
            }
        }
    }

    public void Bury() {
        // when you aproach this too quickly, the sand dollar will bury itself
        // quickly wiggle (z rotation) and then shrink its mask
        if(!burying)
            burying = true;
        
    }
}
