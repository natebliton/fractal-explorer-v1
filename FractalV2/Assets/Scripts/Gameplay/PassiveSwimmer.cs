using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSwimmer : MonoBehaviour
{
    [SerializeField]
    private float swimSpeed = 0.1f;
    Rigidbody2D rb2D;
    Timer timer;
    bool pushSwim = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(1f,0f);
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1.0f;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.Finished)
        {
            pushSwim = !pushSwim;
            timer.Run();
        }
    }

    private void FixedUpdate() {
        if(pushSwim)
        {
            rb2D.AddForce(swimSpeed*(new Vector2(1f,0f)));
        }
    }
}
