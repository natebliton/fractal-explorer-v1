using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages the Ball
/// </summary>
public class Ball : MonoBehaviour
{
    #region Fields

    Rigidbody2D rb2D;

    // ball spawn support
    Timer ballStartupTimer;
    bool moving = false;

    // ball lifetime support
    Timer ballLifetimeTimer;
    bool ballLifetimeTimerExpired = false;

    float halfColliderHeight;

    // BallSpawner ballSpawner;
    BallLostEvent ballLostEvent = new BallLostEvent();
    float ballSpeed;

    // speeding effect support
    Timer ballSpeedTimer;
   // bool ballSpeeding = false;


    #endregion

    #region Properties

    public float HalfColliderHeight
    {
        get { return halfColliderHeight; }
    }

    #endregion


    #region Methods

    // Start is called before the first frame update
    void Start()
    {
 
        // save these for later
        rb2D = GetComponent<Rigidbody2D>();
        halfColliderHeight = GetComponent<BoxCollider2D>().size.y / 2;

        // set up timer for starting the ball moving
        ballStartupTimer = gameObject.AddComponent<Timer>();
        ballStartupTimer.Duration = 1f;
        ballStartupTimer.Run();
        ballSpeed = ConfigurationUtils.BallImpulseForce;

        // set up timer for ball's lifetime
        ballLifetimeTimer = gameObject.AddComponent<Timer>();
        ballLifetimeTimer.Duration = ConfigurationUtils.BallLifetime;
        ballLifetimeTimer.Run();

        // set ball to its own layer as it is waiting to move, so it won't collide with other balls
        gameObject.layer = 8;

        ballSpeedTimer = gameObject.AddComponent<Timer>();

        // speed support
        ballSpeedTimer = gameObject.AddComponent<Timer>();
        ballSpeedTimer.Duration = ConfigurationUtils.SpeedupDuration;
     //   EventManager.AddSpeedupListener(SpeedupBall);
      //  EventManager.AddSpeedupSlowingListener(SlowdownBall);

        // ball count add/remove
      //  EventManager.AddBallLostInvoker(this);

    }

    /// <summary>
    /// start moving the ball
    /// </summary>
    void startMoving()
    {
        gameObject.layer = 0;
        moving = true;

      //  Vector2 initialForce;
      //  float angle = Mathf.Deg2Rad * -90;
     /*   if (EffectUtils.BallSpeeding)
        {
            initialForce = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))
                * ballSpeed * ConfigurationUtils.SpeedupChange;
        }
        else
        {
            initialForce = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))
                * ConfigurationUtils.BallImpulseForce;
        }
        */
       // rb2D.AddForce(initialForce, ForceMode2D.Impulse);

    }

    /// <summary>
    /// set the direction
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(Vector2 direction)
    {
       // rb2D.velocity = ConfigurationUtils.BallImpulseForce * direction * EffectUtils.SpeedingFactor;
      //  print(EffectUtils.SpeedingFactor);

    }

    /// <summary>
    /// when game object becomes invisible, perhaps off screen
    /// </summary>
    private void OnBecameInvisible()
    {
        if (!ballLifetimeTimerExpired)
        {
           // AudioManager.Play(AudioClipName.BallOffScreen);
            ballLostEvent.Invoke();
        }
        else
        {
          //  AudioManager.Play(AudioClipName.BallExpire);
            ballLostEvent.Invoke();
        }

        print("ball went off screen");
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        // start moving the ball after initial timer is up
        if (!moving & ballStartupTimer.Finished)
        {
            startMoving();
        }

        // destroy ball after time is up
        if (ballLifetimeTimer.Finished)
        {
            ballLifetimeTimerExpired = true;
            print("ball perished");
            Destroy(gameObject);     

        }

    }

    #endregion

    #region Public Methods

    /// <summary>
    /// speed up the ball
    /// </summary>
    public void SpeedupBall()
    {
        rb2D.velocity *= ConfigurationUtils.SpeedupChange;
    }

    /// <summary>
    /// slow down the ball
    /// </summary>
    public void SlowdownBall()
    {
        rb2D.velocity *= 1 / ConfigurationUtils.SpeedupChange;
    }

    /// <summary>
    /// add ball lost event listener
    /// </summary>
    /// <param name="listener"></param>
    public void AddBallLostEvent(UnityAction listener)
    {
        ballLostEvent.AddListener(listener);
    }

    // if ball hits another ball, play a sound
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            // play sound
           // AudioManager.Play(AudioClipName.PaddleHit);
        }
    }

    #endregion
}
