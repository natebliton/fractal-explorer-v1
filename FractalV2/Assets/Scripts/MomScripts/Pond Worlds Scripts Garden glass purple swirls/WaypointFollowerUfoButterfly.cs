using UnityEngine;

public class WaypointFollowerUfoButterfly : MonoBehaviour
{
    // Turn 0pen ship and wing brightness beats on and off
    public GameObject openShip;
    public GameObject openToClose;
    public GameObject closeShip;
    public GameObject wingBeats;

    // add waypoints to moving object script in unity

    [SerializeField] private GameObject[] waypoints;

    // set variable to hold waypoint number
    private int currentWaypointIndex = 0;

    // Set speed of motion in Unity 
    [SerializeField] private float speed = 2f;
    [SerializeField] private float delayStart = 2f;
    [SerializeField] private float landStart = 2f;
    // [SerializeField] private float shakeStart = 2f; shaking happens on ufoButterfly object with UfoButterflyShakes script
    [SerializeField] private float wingBeatStart = 2f;
    [SerializeField] private float closeAndLeave = 2f;


    float timer;
    
    void Start()
    {
        // turn open ship and wing beats off
        openShip.gameObject.SetActive(false);
        closeShip.gameObject.SetActive(true);
        wingBeats.gameObject.SetActive(false);
        openToClose.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayStart)
        {
            if (timer < delayStart + landStart + wingBeatStart + closeAndLeave) 
            {
                // Debug.Log("follow path zero called");
                FollowPath0();
            }
            
        }
        

            if (timer >= delayStart + landStart + wingBeatStart + closeAndLeave)
            {
                
                FollowPath1();
            }
        
        void FollowPath0()
        {
            
                if (timer > delayStart + landStart + wingBeatStart)
                {
                    // turn flying owl off and landing owl on after landStart delay
                    wingBeats.gameObject.SetActive(true);

                    return;
                }
                if (timer > delayStart + landStart)
                {
                    // turn open ship on after landStart delay
                    closeShip.gameObject.SetActive(false);
                    openShip.gameObject.SetActive(true);

                    return;
                }
                
                
            // Move towards next waypoint. time.deltatime allows for different frame rates on different platforms
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
            

        }
        void FollowPath1()
        {
            
                if (timer > delayStart + landStart + wingBeatStart + closeAndLeave)
                {
                    // turn flying owl off and landing owl on after landStart delay
                    openToClose.gameObject.SetActive(true);

                    // return;
                }

            if (Vector2.Distance(waypoints[1].transform.position, transform.position) < 0.1f)
            { 
                return; 
            }
            

            // Move towards next waypoint. time.deltatime allows for different frame rates on different platforms
            // transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position, Time.deltaTime * speed);
            
            // Debug.Log("transform.position called");

        }
    }
}
