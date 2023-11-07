using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class WaypointPorcupine : MonoBehaviour
{
    // Turn owls on and off
    //public GameObject flower;
    
    // add waypoints to moving object script in unity

    [SerializeField] private GameObject[] waypoints;

    // set variable to hold waypoint number
    private int currentWaypointIndex = 0;

    // Set speed of motion in Unity 
    [SerializeField] private float speedWalk = 2f;
    
    [SerializeField] private float delayStart = 2f;
    [SerializeField] private float EatTime = 1f;
    

    float timer;
    private float TriggeredTime;
    private Animator porcupine;
    // Vector3 tempRotation;

    private void Start()
    {

        porcupine = GetComponent<Animator>();
        porcupine.SetBool("walk", false);
        // start porcupine facing left but didn't work. something about a quaternion conflict
        //tempRotation.x = 0;
        //tempRotation.y = 180; 
        //transform.localRotation = tempRotation;
        
        // delay the launch
        Invoke("Update", delayStart);

    }
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > delayStart)
        {
            if (currentWaypointIndex == 0)
            {
                porcupine.SetBool("walk", true);
                FollowPath0();
            }
            if (currentWaypointIndex == 1)
            {
                porcupine.SetBool("eat", true);
                porcupine.SetBool("walk", false);
            }
            //    FollowPath1();
        }

        if (timer > TriggeredTime + EatTime)
        {
            if (currentWaypointIndex == 1)
            {
                porcupine.SetBool("walk", true);
                porcupine.SetBool("eat", false);
                currentWaypointIndex = 0;
                FollowPath0();
                
            }
            
        }
        void FollowPath0()
        {
            // check if touching waypoint and increment to the next one if so
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
            {
                currentWaypointIndex = 1;
                // currentWaypointIndex++;
                return;
            }
            
            // Move towards next waypoint. time.deltatime allows for different frame rates on different platforms
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speedWalk);

            

        }

        //void FollowPath1()
        //{
        //    // check if touching waypoint and increment to the next one if so
        //    if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        //    {
        //        porcupine.SetBool("move", true);
        //        return;
        //    }
            

        //    // Move towards next waypoint. time.deltatime allows for different frame rates on different platforms
        //    transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speedWalk);

        //}
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // trigger has to be turned on in collider
        // Debug.Log("hit detected porcupine");
        // Don't forget to put a rigid body on the owl with zero gravity
        TriggeredTime = timer;
        EatFlower();
        //if (other.CompareTag("Porcupine"))
        //{
        //    // Debug.Log("PinkBrownOwl tag works");
        //    EatFlower();
        //}

    }
   
    private void EatFlower()
    {
        porcupine.SetBool("eat", true);
        porcupine.SetBool("walk", false);
        currentWaypointIndex = 1;

    }
    
}

