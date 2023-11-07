using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloBeachBallSpin : MonoBehaviour
{
    [SerializeField] private float stopSpin = 4f;
    float timer;
    private bool spinBall = false;
    private Animator beachball;
    // Start is called before the first frame update
    void Start()
    {
        beachball = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Debug.Log("updating");
        
        if (spinBall)
        {
            //Debug.Log("spin set to true");
            beachball.SetBool("spin", true);
        }
        timer += Time.deltaTime;
        if (timer > stopSpin)
        {
            beachball.SetBool("stop", true);
            beachball.SetBool("spin", false);

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // trigger has to be turned on in collider, Rigidbody 2d needs to be assigned  to objects
        //Debug.Log("hit detected");

        if (other.CompareTag("Armadillo"))
        {
            //Debug.Log("Armadillo tag works");
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
        spinBall = true;

    }
    //public void TurnOffCommunicator()
    //{
    //    commOn = false;
    //}
}
