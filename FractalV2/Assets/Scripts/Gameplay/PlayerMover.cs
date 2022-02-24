using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    // PlayerDamageEvent playerDamageEvent = new PlayerDamageEvent();
    private Animator animator;
    string animationState = "AnimationState";
    private string currentState;
    private const string LANDED_L = "landed-L";
    private const string LANDED_R = "landed-R";

    private const string TOHOVER_L = "me-h-toHover-L";
    private const string TOHOVER_R = "me-h-toHover-R";
    private const string HOVER_L = "me-h-hover-L";
    private const string HOVER_R = "me-h-hover-R";
    private const string FLY_L = "me-h-fly-L";
    private const string FLY_R = "me-h-fly-R";
    private const string TOFLY_L = "me-h-htofly-L";
    private const string TOFLY_R = "me-h-htofly-R";
    private const string FTOHOVER_L = "me-h-ftoHover-L";
    private const string FTOHOVER_R = "me-h-ftoHover-R";
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
    PlayerStates playerStateDisplayed = PlayerStates.landedRight;

    #region Methods

    
    void ChangeAnimationState(string newState)
    {
        // guard against calling current state
        if(currentState == newState) return;

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
            } else {
                if(vel.x > 0f) {
                    playerState = PlayerStates.hoverRight;
                } else {
                    playerState = PlayerStates.hoverLeft;
                }
            }

        }
        if(xIn != 0 || yIn != 0) {
            print(xIn + " " + yIn + " " + vel.magnitude + " " + vel.x);
            print(playerState);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hit = collision.contacts[0].normal;
        print(hit);
        float angle = Vector3.Angle(hit, Vector3.up);

        if (Mathf.Approximately(angle, 0))
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
                ChangeAnimationState(LANDED_R);
                break;
            case PlayerStates.landedLeft:
                ChangeAnimationState(LANDED_L);
                break;
            case PlayerStates.hoverLeft:
                ChangeAnimationState(HOVER_L);
                break;
            case PlayerStates.hoverRight:
                ChangeAnimationState(HOVER_R);
                break;
            case PlayerStates.flyLeft:
                ChangeAnimationState(FLY_L);
                break;
            case PlayerStates.flyRight:
                ChangeAnimationState(FLY_R);
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
