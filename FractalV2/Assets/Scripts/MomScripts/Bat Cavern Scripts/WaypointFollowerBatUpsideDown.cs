using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowerBatUpsideDown : MonoBehaviour
{
    // Turn owls on and off
    public GameObject bat;
    // public GameObject owlLand;
    

    // add waypoints to moving object script in unity

    [SerializeField] private GameObject[] waypoints;

    // set variable to hold waypoint number
    private int currentWaypointIndex = 0;

    // Set speed of motion in Unity 
    [SerializeField] private float speed = 2f;
    [SerializeField] private float delayStart = 2f;
    // [SerializeField] private float raiseWings = 0.2f;
    // [SerializeField] private float landStart = 2f;
    [SerializeField] private float scaleStart = 0f;
    [SerializeField] private float scaleIncrement = 0.05f;
    [SerializeField] private float scaleEnd = 1f;

    private float timer;
    private Animator flyToLand;
    private Vector3 tempScale;

    private void Start()
    {

        bat.gameObject.SetActive(false);
        // landing parameter in animator = true to switch to landing animation
        flyToLand = GetComponent<Animator>();
        // bat.gameObject.SetActive(true);
        // flyToLand.SetBool("landing", false);
        // start owl at reduced size
        tempScale.x = scaleStart;
        tempScale.y = scaleStart;
        transform.localScale = tempScale;
        // turn flying owl on and landing owl off

        bat.gameObject.SetActive(true);
        // owlLand.gameObject.SetActive(false);

        // delay the owl launch
        Invoke("Update", delayStart);


    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayStart)
        {
            // flyToLand.SetBool("raise", true);
            
            FollowPath();
        }
        //if (timer > delayStart + raiseWings)
        //{
        //    flyToLand.SetBool("fly", true);
        //    FollowPath();
        //}

        void FollowPath()
        {
            // check if touching waypoint and increment to the next one if so
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
                currentWaypointIndex++;
            // stop at last waypoint    
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = waypoints.Length - 1;

                //at last waypoint, land
                flyToLand.SetBool("land", true);
                //stop executing method
                return;
                               
            }

            // Move towards next waypoint. time.deltatime allows for different frame rates on different platforms
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

            // Scale up owl
             if (currentWaypointIndex >= 0)
                ScaleUpBat();

             void ScaleUpBat()
             {
                // Debug.Log("scale bat called");

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

    }

}

