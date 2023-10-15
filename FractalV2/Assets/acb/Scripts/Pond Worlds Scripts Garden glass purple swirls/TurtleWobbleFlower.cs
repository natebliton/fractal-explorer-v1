using UnityEngine;

public class TurtleWobbleFlower : MonoBehaviour
{
   private bool wobbleFlower = false;
    private Animator flower;

    private void Start()
    {
        flower = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if (wobbleFlower)
        {
            flower.SetBool("wobble", true);
        }
        else
        {
            flower.SetBool("wobble", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // Debug.Log("hit detected");

        if (other.CompareTag("Turtle"))
        {
            FlowerWobble();
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        //Debug.Log("hit finished");

        if (other.CompareTag("Turtle"))
        {
            FlowerStill();
        }

    }
    public void FlowerWobble()
    {
        wobbleFlower = true;
    }
    public void FlowerStill()
    {
        wobbleFlower = false;
    }
}
