using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFlower : MonoBehaviour
{
    private bool eatFlower = false;
    private Animator flower;
    // Start is called before the first frame update
    void Start()
    {
        flower = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eatFlower)
        {
            flower.SetBool("eat", true);
        }
        else
        {
            flower.SetBool("eat", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

         Debug.Log("hit detected");

        if (other.CompareTag("PorcupineBaby"))
        {
            FlowerEat();
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        Debug.Log("hit finished");

        if (other.CompareTag("PorcupineBaby"))
        {
            FlowerGrow();
        }

    }
    public void FlowerEat()
    {
        eatFlower = true;
    }
    public void FlowerGrow()
    {
        eatFlower = false;
    }
}


