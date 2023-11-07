using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class WaypointFollowerFlower : MonoBehaviour
{
    // Turn owls on and off
    public GameObject flower;
    
    // add waypoints to moving object script in unity

    [SerializeField] private GameObject[] waypoints;

    // set variable to hold waypoint number
    private int currentWaypointIndex = 0;

    // Set speed of motion in Unity 
    [SerializeField] private float speedRise = 2f;
    [SerializeField] private float speedFall = 2f;
    [SerializeField] private float delayStart = 2f;
    // [SerializeField] private float flowerAngle = 0f;
    // [SerializeField] private float landStart = 2f;
    [SerializeField] private float scaleStart = 0.0f;
    [SerializeField] private float scaleEnd = 1.0f;
    [SerializeField] private float scaleIncrement = 0.005f;

    private float timer;
    private Animator flowerAnimate;
    Vector3 tempScale;

    private void Start()
    {
                
        flowerAnimate = GetComponent<Animator>();
        flowerAnimate.SetBool("move", false);
        // start flower at zero size
        tempScale.x = scaleStart;
        tempScale.y = scaleStart;
        transform.localScale = tempScale;
        flower.gameObject.SetActive(true);
        // delay the launch
        Invoke("Update", delayStart);

    }
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > delayStart)
        {
            if (currentWaypointIndex == 0)
                FollowPath0();
            if (currentWaypointIndex == 1)
                FollowPath1();
        }
        

        void FollowPath0()
        {
            // check if touching waypoint and increment to the next one if so
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
            {
                return;
            }

            // Move towards next waypoint. time.deltatime allows for different frame rates on different platforms
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speedRise);

            // Scale up flower
             if (currentWaypointIndex == 0)
                ScaleUpFlower();

             void ScaleUpFlower()
             {
                tempScale = transform.localScale;
                tempScale.x += scaleIncrement;
                tempScale.y += scaleIncrement;
                if (tempScale.x >= scaleEnd - scaleIncrement)
                    tempScale.x = scaleEnd;
                if (tempScale.y >= scaleEnd - scaleIncrement)
                    tempScale.y = scaleEnd;
                transform.localScale = tempScale;
                if (tempScale.x >= scaleEnd)
                    return;
            }

        }

        void FollowPath1()
        {
            // check if touching waypoint and increment to the next one if so
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
            {
                flowerAnimate.SetBool("move", true);
                return;
            }
            

            // Move towards next waypoint. time.deltatime allows for different frame rates on different platforms
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speedFall);

            
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // trigger has to be turned on in collider
        // Debug.Log("hit detected");
        // Don't forget to put a rigid body on the owl with zero gravity
        if (other.CompareTag("HalloweenOwl"))
        {
            // Debug.Log("PinkBrownOwl tag works");
            KnockFlowerDown();
        }
        if (other.CompareTag("Porcupine"))
        {
            // Debug.Log("PinkBrownOwl tag works");
            TurnFlowerOff();
        }

    }
   
    private void KnockFlowerDown()
    {
        currentWaypointIndex = 1;

    }

    private void TurnFlowerOff()
    {
        flower.gameObject.SetActive(false);

    }



}

