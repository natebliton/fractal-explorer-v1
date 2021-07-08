using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth : MonoBehaviour
{
    Rigidbody2D rb2D;

    // timer for bouncing butterfly
    Timer bounceTimer;

    float wingBentWidth = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bounceTimer = gameObject.AddComponent<Timer>();
        bounceTimer.Duration = 1f;
        bounceTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(bounceTimer.ElapsedSeconds > bounceTimer.Duration/2)
        {
            // this should scale 0 to 1 on second half of timer duration
            float ratio = (bounceTimer.ElapsedSeconds - (bounceTimer.Duration/2)) / (bounceTimer.Duration/2);
            transform.localScale = new Vector3((1 - ((1 - wingBentWidth)*ratio)), 1, 1);
        } else if (bounceTimer.ElapsedSeconds < bounceTimer.Duration/6)
        {
            float ratio = (bounceTimer.ElapsedSeconds / (bounceTimer.Duration/6));
            transform.localScale = new Vector3(((1 - wingBentWidth)*ratio), 1, 1);
        }
        
         else {
            transform.localScale = new Vector3(1, 1, 1);
        }
        // print("bounce timer at " + bounceTimer.ElapsedSeconds);
        if(bounceTimer.Finished)
        {
            bounce();
        }
    }

    void bounce() {

        print("bounce");
        
        // restart timer
        bounceTimer.Duration = Random.Range(0.2f, 2f);
        bounceTimer.Run();

        // bounce moth
        float upward = Random.Range(2f, 10f);
        float toSides = Random.Range(-1f, 1f);
        rb2D.velocity = new Vector2(toSides, upward);
        //rb2D.AddForce(new Vector2(1, 0.4f));
    }
}
