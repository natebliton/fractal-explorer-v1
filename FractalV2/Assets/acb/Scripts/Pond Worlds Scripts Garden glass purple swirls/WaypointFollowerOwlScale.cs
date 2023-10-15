using UnityEngine;

public class WaypointFollowerOwlScale : MonoBehaviour
{
    // Turn owls on and off
    public GameObject owlFly;
    public GameObject owlLand;
    

    // add waypoints to moving object script in unity

    [SerializeField] private GameObject[] waypoints;

    // set variable to hold waypoint number
    private int currentWaypointIndex = 0;

    // Set speed of motion in Unity 
    [SerializeField] private float speed = 2f;
    [SerializeField] private float delayStart = 2f;
    [SerializeField] private float raiseWings = 0.2f;
    [SerializeField] private float landStart = 2f;
    [SerializeField] private float scaleStart = 0.5f;
    [SerializeField] private float scaleIncrement = 0.05f;

    float timer;
    private Animator flyToLand;
    Vector3 tempScale;

    private void Start()
    {
        // turn flying owl on and landing owl off
        
        owlFly.gameObject.SetActive(true);
        owlLand.gameObject.SetActive(false);

        // delay the owl launch
        Invoke("Update", delayStart);
        // landing parameter in animator = true to switch to landing animation
        flyToLand = GetComponent<Animator>();
        // flyToLand.SetBool("landing", false);
        // start owl at reduced size
        tempScale.x = scaleStart;
        tempScale.y = scaleStart;
        transform.localScale = tempScale;

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayStart)
        {
            flyToLand.SetBool("raise", true);
            
            // FollowPath();
        }
        if (timer > delayStart + raiseWings)
        {
            flyToLand.SetBool("fly", true);
            FollowPath();
        }

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
                flyToLand.SetBool("landing", true);
                //stop executing method


                if (timer > delayStart + raiseWings + landStart)
                {
                    // turn flying owl off and landing owl on after landStart delay
                    owlFly.gameObject.SetActive(false);
                    owlLand.gameObject.SetActive(true);
                    return;
                }
                //currentWaypointIndex = 0; if you want to go back to the first waypoint
            }

            // Move towards next waypoint. time.deltatime allows for different frame rates on different platforms
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

            // Scale up owl
             if (currentWaypointIndex >= 0)
                ScaleUpOwl();

             void ScaleUpOwl()
             {
                tempScale = transform.localScale;
                tempScale.x += scaleIncrement;
                tempScale.y += scaleIncrement;
                if (tempScale.x >= 1f - scaleIncrement)
                    tempScale.x = 1f;
                if (tempScale.y >= 1f - scaleIncrement)
                    tempScale.y = 1f;
                transform.localScale = tempScale;
                if (tempScale.x >= 1f)
                   return;
             }

        }

    }

}

