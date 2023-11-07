using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloBeachBallBounce : MonoBehaviour
{
    private bool bounceBall = false;
    private Animator beachballparent;
    // Start is called before the first frame update
    void Start()
    {
        beachballparent = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("updating");
        // communicator.SetBool("turnOn", true);
        if (bounceBall)
        {
            //Debug.Log("turnOn set to true");
            beachballparent.SetBool("bounce", true);
        }
        //else
        //{
        //    communicator.SetBool("turnOn", false);
        //}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // trigger has to be turned on in collider, Rigidbody 2d needs to be assigned  to objects
        Debug.Log("hit detected");

        if (other.CompareTag("Armadillo"))
        {
            Debug.Log("Armadillo tag works");
            BounceTheBall();
        }

    }
    //private void OnTriggerExit2D(Collider2D other)
    // {

    //     //Debug.Log("hit finished");

    //     if (other.CompareTag("PinkBrownOwl"))
    //     {
    //         TurnOffCommunicator();
    //     }

    // }
    public void BounceTheBall()
    {
        //Debug.Log("commOn turned true called");
        bounceBall = true;

    }
    //public void TurnOffCommunicator()
    //{
    //    commOn = false;
    //}
}
