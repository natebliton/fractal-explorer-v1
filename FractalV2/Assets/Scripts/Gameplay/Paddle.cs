using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the Paddle
/// </summary>
public class Paddle : MonoBehaviour
{

    #region Fields

    // getting Rigidbody2D
    Rigidbody2D rb2D;

    // hold on to half width of paddle collider
    float halfColliderWidth;
    float halfColliderHeight;

    const float BounceAngleHalfRange = 60f * Mathf.Deg2Rad;

    // paddle freezing support
    Timer paddleFreezeTimer;
    float freezeTimerDuration;
    bool paddleFrozen = false;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // get rigidbody now for efficiency
        rb2D = GetComponent<Rigidbody2D>();

        // save half the paddle width and height
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
        halfColliderHeight = GetComponent<BoxCollider2D>().size.y / 2;
     //   print(halfColliderWidth + " x " + halfColliderHeight);
     //   EventManager.AddFreezerListener(FreezePaddle);

        // paddle freezing
        paddleFreezeTimer = gameObject.AddComponent<Timer>();
        freezeTimerDuration = ConfigurationUtils.FreezerDuration;
        paddleFreezeTimer.Duration = freezeTimerDuration;

    }

    // moves the paddle
    private void FixedUpdate()
    {
        // get horizontal axis input
        float horizontalInput = Input.GetAxis("Horizontal");

        // make Vector2 with current position added tohorizontal motion calculated, vertical 0
        Vector2 moveTo = rb2D.position + new Vector2(horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime, 0);

        // clamp the x value of the new position to keep the paddle on the screen
        moveTo.x = CalculateClampedX(moveTo.x);

        // move the paddle to the new position, if unfrozen
        if (!paddleFrozen) { 
           rb2D.MovePosition(moveTo);
        }

    }

    // clamps the xIn value to keep the paddle in the screen
    float CalculateClampedX(float xIn)
    {
        if (xIn - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            xIn = ScreenUtils.ScreenLeft + halfColliderWidth;
        } else if (xIn + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            xIn = ScreenUtils.ScreenRight - halfColliderWidth;
        }

        return xIn;

    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            // play click sound
         //   AudioManager.Play(AudioClipName.PaddleHit);

            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();

            if (TopCollision(coll))
            {
                ballScript.SetDirection(direction);
           //     print("setting direction");
            } else
            {
         //       print("not setting direction");
            }

        }
    }

    /// <summary>
    /// returns true if the collision was on top (instructor solution)
    /// </summary>
    /// <returns><c>true</c>, if collision was toped, <c>false</c> otherwise.</returns>
    /// <param name="coll">Coll.</param>
    bool TopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location, so their |difference| is less than the tolerance
        ContactPoint2D[] contacts = coll.contacts;
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    // Update is called once per frame
    void Update()
    {
        // unfreeze paddle if timer is finished and it is still frozen
        if (paddleFreezeTimer.Finished & paddleFrozen)
        {
            paddleFrozen = false;
            print("paddle unfrozen!");
        }
    }

    /// <summary>
    /// freezes the paddle
    /// </summary>
    public void FreezePaddle()
    {
        print("PADDLE FROZEN!");
        if (!paddleFrozen)
        {
            paddleFrozen = true;
            paddleFreezeTimer.Duration = freezeTimerDuration;
            paddleFreezeTimer.Run();
            print(paddleFreezeTimer.Duration);
        }
        else
        {
            paddleFreezeTimer.Duration += freezeTimerDuration;
            print("double frozen! " + paddleFreezeTimer.Duration);
        
        }

    }

    #endregion
}
