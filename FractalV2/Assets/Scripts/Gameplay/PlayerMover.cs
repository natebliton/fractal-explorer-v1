using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    // PlayerDamageEvent playerDamageEvent = new PlayerDamageEvent();

    public float movementSpeed = 3.0f;

    private Vector2 movement = new Vector2();

    private Animator animator;

    string animationState = "AnimationState";

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
   
    }

    private void UpdateState()
    {
        switch (playerState) {
            case PlayerStates.landedRight:
                break;
        }
        if (playerState != playerStateDisplayed) {
            animator.SetInteger(animationState, (int)playerState);
            playerStateDisplayed = playerState;
        }

        // if landed
        if(verticalState == VerticalState.landed) {

        }

    }

/*
    public void AddPlayerDamageEvent(UnityAction<float> listener)
    {
        print("added damage listener");
        playerDamageEvent.AddListener(listener);
    }
    */
}
