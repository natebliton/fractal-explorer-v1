using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ffishHummTransition : MonoBehaviour
{
    private bool turnToHummingbird = false;
    private Animator hummingbird;
    // Start is called before the first frame update
    void Start()
    {
        hummingbird = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnToHummingbird)
        {
            hummingbird.SetBool("turn", true);
        }
        else
        {
            hummingbird.SetBool("turn", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        // Debug.Log("hit detected");

        if (other.CompareTag("FFishHumm"))
        {
            HummingbirdTransition();
        }

    }
    //private void OnTriggerExit2D(Collider2D other)
    //{

    //    //Debug.Log("hit finished");

    //    if (other.CompareTag("Turtle"))
    //    {
    //        FlowerStill();
    //    }

    //}
    public void HummingbirdTransition()
    {
        turnToHummingbird = true;
    }
    //public void FlowerStill()
    //{
    //    turnToHummingbird = false;
    //}
}
