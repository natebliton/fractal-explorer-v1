using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCommunicator : MonoBehaviour
{
    private bool flashCommunicator = false;
    private Animator communicator;
    // Start is called before the first frame update
    void Start()
    {
        communicator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flashCommunicator)
        {
            communicator.SetBool("flash", true);
        }
        //else
        //{
        //    communicator.SetBool("flash", false);
        //}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

         Debug.Log("hit detected");

        if (other.CompareTag("LargeDiscOwl"))
        {
            CommunicatorFlash();
        }

    }
    //private void OnTriggerExit2D(Collider2D other)
    //{

    //    Debug.Log("hit finished");

    //    if (other.CompareTag("LargeDiscOwl"))
    //    {
    //        FlowerGrow();
    //    }

    //}
    public void CommunicatorFlash()
    {
        flashCommunicator = true;
    }
    //public void FlowerGrow()
    //{
    //    flashCommunicator = false;
    //}
}


