using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    // PlayerDamageEvent playerDamageEvent = new PlayerDamageEvent();
    private Animator animator;
    string animationState = "AnimationState";
    private string currentState = "landed-L";
    private const string LANDED_L = "landed-L";
    private const string LANDED_R = "landed-R";

    private const string TOHOVER_L = "me-h-tohover-L";
    private const string TOHOVER_R = "me-h-tohover-R";
    private const string HOVER_L = "me-h-hover-L";
    private const string HOVER_R = "me-h-hover-R";
    private const string FLY_L = "me-h-fly-L";
    private const string FLY_R = "me-h-fly-R";
    private const string TOFLY_L = "me-h-htofly-L";
    private const string TOFLY_R = "me-h-htofly-R";
    private const string FTOHOVER_L = "me-h-ftohover-L";
    private const string FTOHOVER_R = "me-h-ftohover-R";
    private const string TOLAND_L = "me-h-toland-L";
    private const string TOLAND_R = "me-h-toland-R";
    
        
    
    public float movementSpeed = 3.0f;

    private Vector2 movement = new Vector2();


    private Rigidbody2D rb2D;

    // SpriteRenderer fireLeft;
    // SpriteRenderer fireRight;
    Color visible = new Color(255, 255, 255, 255);
    Color invisible = new Color(255, 255, 255, 0);

    [SerializeField]
    GameObject prefabJumpFire;

    enum PlayerStates
    {
        flyRight=1,
        hoverRight=2,
        landedRight = 3,
        landedLeft = 4,
        hoverLeft=5,
        flyLeft=6
    }

    enum VerticalState
    {
        landed,
        landing,
        takingOff,
        hovering,
        toflying,
        flying,
        slowToHover

    }

    [SerializeField]
    VerticalState verticalState = VerticalState.landed;

    [SerializeField]
    PlayerStates playerState = PlayerStates.landedRight;
    PlayerStates playerStateLastDisplayed = PlayerStates.landedRight;

    #region Methods

    
    void ChangeAnimationState(string newState)
    {
        // guard against calling current state
        if(currentState == newState) return;
        currentState = newState;
        // play the animation
        animator.Play(newState);
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // fireLeft = GameObject.FindGameObjectWithTag("FireLeft").GetComponent<SpriteRenderer>();
        // fireRight = GameObject.FindGameObjectWithTag("FireRight").GetComponent<SpriteRenderer>();
        // fireLeft.color = invisible;
        // fireRight.color = invisible;

        // print("adding event invoker");
        // EventManager.AddPlayerDamageEventInvoker(this);
        //print(EventManager.playerDamageInvokers.Count);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        // check if there is a new target location, 
        // and if so, set velocity to move in that direction

        // or, get input from keyboard
        float xIn = Input.GetAxisRaw("Horizontal");
        float yIn = Input.GetAxisRaw("Vertical");
        movement = new Vector3(xIn, yIn);
        movement *= movementSpeed;
        rb2D.AddForce(movement, ForceMode2D.Force);
        
        Vector2 vel = rb2D.velocity;
        if(vel.magnitude > 0f) {
            if(vel.magnitude > 3f) {
                if(vel.x > 0f) {
                    playerState = PlayerStates.flyRight;
                } else {
                    playerState = PlayerStates.flyLeft;
                }
               // Quaternion deltaRotation = Quaternion.Euler(vel * Time.fixedDeltaTime);
               // rb2D.MoveRotation(rb2D.transform.rotation * deltaRotation);
            } else {
                if(vel.x > 0f) {
                    playerState = PlayerStates.hoverRight;
                } else {
                    playerState = PlayerStates.hoverLeft;
                }
            }

        }
        // if(xIn != 0 || yIn != 0) {
        //     print(xIn + " " + yIn + " " + vel.magnitude + " " + vel.x);
        //     print(playerState);
        // }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hit = collision.contacts[0].normal;
        print(hit);
        float angle = Vector3.Angle(hit, Vector3.up);

        // print("angle of impact: " + Mathf.Abs(angle - 0));

        if (Mathf.Abs(angle - 0) < 45)
        {
            //Down
           print("Landing");
           if(rb2D.velocity.x > 0) {
               playerState = PlayerStates.landedRight;
           } else {
               playerState = PlayerStates.landedLeft;
           }
           rb2D.velocity = new Vector2(0f,0f);
        }
        /*
        if(Mathf.Approximately(angle, 180))
        {
            //Up
            print("Up");
        }
        if(Mathf.Approximately(angle, 90)){
            // Sides
            Vector3 cross = Vector3.Cross(Vector3.forward, hit);
            if (cross.y > 0)
            { // left side of the player
                print("Left");
            }
            else
            { // right side of the player
                print("Right");
            }
        }*/
    }

    private void UpdateState()
    {
        switch (playerState) {
            case PlayerStates.landedRight:
                if(playerStateLastDisplayed == PlayerStates.landedRight) {
                    break;
                }
                if(playerStateLastDisplayed == PlayerStates.hoverRight) {
                    ChangeAnimationState(TOLAND_R);
                    playerStateLastDisplayed = PlayerStates.landedRight;
                } else {
                    ChangeAnimationState(LANDED_R);
                    playerStateLastDisplayed = PlayerStates.landedRight;
                }
                break;
            case PlayerStates.landedLeft:
                if(playerStateLastDisplayed == PlayerStates.landedLeft) {
                    break;
                }
                if(playerStateLastDisplayed == PlayerStates.hoverLeft) {
                    ChangeAnimationState(TOLAND_L);
                    playerStateLastDisplayed = PlayerStates.landedLeft;
                    break;
                } else {
                    ChangeAnimationState(LANDED_L);
                    playerStateLastDisplayed = PlayerStates.landedLeft;
                    break;
                }
            case PlayerStates.hoverLeft:
                if(playerStateLastDisplayed == PlayerStates.hoverLeft) {
                    break;
                }
                if(playerStateLastDisplayed == PlayerStates.landedLeft) {
                    ChangeAnimationState(TOHOVER_L);
                    playerStateLastDisplayed = PlayerStates.hoverLeft;
                    break;
                } else if (playerStateLastDisplayed == PlayerStates.flyLeft) {
                    ChangeAnimationState(FTOHOVER_L);
                    playerStateLastDisplayed = PlayerStates.hoverLeft;
                    break;
                } else {
                    ChangeAnimationState(HOVER_L);
                    playerStateLastDisplayed = PlayerStates.hoverLeft;
                    break;
                }
            case PlayerStates.hoverRight:
                if(playerStateLastDisplayed == PlayerStates.hoverRight) {
                    break;
                }
                if(playerStateLastDisplayed == PlayerStates.landedRight) {
                    ChangeAnimationState(TOHOVER_R);
                    playerStateLastDisplayed = PlayerStates.hoverRight;
                } else if (playerStateLastDisplayed == PlayerStates.flyRight) {
                    ChangeAnimationState(FTOHOVER_R);
                    playerStateLastDisplayed = PlayerStates.hoverRight;
                } else {
                    ChangeAnimationState(HOVER_R);
                    playerStateLastDisplayed = PlayerStates.hoverRight;
                }
                break;
            case PlayerStates.flyLeft:
                if(playerStateLastDisplayed == PlayerStates.flyLeft) {
                    break;
                }
                if(playerStateLastDisplayed == PlayerStates.hoverLeft) {
                    ChangeAnimationState(TOFLY_L);
                    playerStateLastDisplayed = PlayerStates.flyLeft;
                } else {
                    ChangeAnimationState(FLY_L);
                    playerStateLastDisplayed = PlayerStates.flyLeft;
                }
                break;
            case PlayerStates.flyRight:
                if(playerStateLastDisplayed == PlayerStates.flyRight) {
                    break;
                }
                if(playerStateLastDisplayed == PlayerStates.hoverRight) {
                    ChangeAnimationState(TOFLY_R);
                    playerStateLastDisplayed = PlayerStates.flyRight;
                } else {
                    ChangeAnimationState(FLY_R);
                    playerStateLastDisplayed = PlayerStates.flyRight;
                }
                break;
            
        }
        /*
        if (playerState != playerStateDisplayed) {
            animator.SetInteger(animationState, (int)playerState);
            playerStateDisplayed = playerState;
        }

        // if landed
        if(verticalState == VerticalState.landed) {

        }
*/
    }

/*
    public void AddPlayerDamageEvent(UnityAction<float> listener)
    {
        print("added damage listener");
        playerDamageEvent.AddListener(listener);
    }
    */
    #endregion
}
