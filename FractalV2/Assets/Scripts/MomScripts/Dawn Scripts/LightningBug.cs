using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBug : MonoBehaviour
{
    private bool lightningBugFlash = false;
    private Animator flower;
    // Start is called before the first frame update
    void Start()
    {
        flower = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightningBugFlash)
        {
            flower.SetBool("flash", true);
        }
        else
        {
            flower.SetBool("flash", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        // Debug.Log("hit detected");

        if (other.CompareTag("Elk"))
        {
            FlashBug();
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        //Debug.Log("hit finished");

        if (other.CompareTag("Elk"))
        {
            DarkBug();
        }

    }
    public void FlashBug()
    {
        lightningBugFlash = true;
    }
    public void DarkBug()
    {
        lightningBugFlash = false;
    }
}
