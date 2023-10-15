using UnityEngine;

public class CommFlash : MonoBehaviour
{
    private bool commOn = false;
    private Animator communicator;
    // Start is called before the first frame update
    void Start()
    {
        communicator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("updating");
        // communicator.SetBool("turnOn", true);
        if (commOn)
        {
            //Debug.Log("turnOn set to true");
            communicator.SetBool("turnOn", true);
        }
        //else
        //{
        //    communicator.SetBool("turnOn", false);
        //}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // trigger has to be turned on in collider
        //Debug.Log("hit detected");

        if (other.CompareTag("PinkBrownOwl"))
        {
            // Debug.Log("PinkBrownOwl tag works");
            TurnOnCommunicator();
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
    public void TurnOnCommunicator()
    {
        //Debug.Log("commOn turned true called");
        commOn = true;

    }
    //public void TurnOffCommunicator()
    //{
    //    commOn = false;
    //}
}


