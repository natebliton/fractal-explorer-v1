using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    // PlayerDamageEvent playerDamageEvent = new PlayerDamageEvent();

    public float movementSpeed = 3.0f;

    Vector2 movement = new Vector2();

    Animator animator;

    string animationState = "AnimationState";

    Rigidbody2D rb2D;

    // SpriteRenderer fireLeft;
    // SpriteRenderer fireRight;
    Color visible = new Color(255, 255, 255, 255);
    Color invisible = new Color(255, 255, 255, 0);

    [SerializeField]
    GameObject prefabJumpFire;

    enum PlayerStates
    {
        landedRight = 0,
        landedLeft = 1,
        toHoverRight=2,
        toHoverLeft=3,
        hoverRight=4,
        hoverLeft=5,
        toFlyRight=6,
        toFlyLeft=7,
        flyRight=8,
        flyLeft=9,
        flyToHoverRight=10,
        flyToHoverLeft=11,
        landingRight=12,
        landingLeft=13
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

    private void OnMouseDown()    
    {
    }

    private void MoveCharacter()
    {
        if(Input.GetMouseButtonDown(0)) {
            print("Pressed left click.");
            if(playerState == PlayerStates.landedRight) {
                playerState = PlayerStates.landedLeft;
            } else {
                playerState = PlayerStates.landedRight;
            }
            animator.SetInteger(animationState,
                (int)playerState);
            print("clicked");
        }

        if(Input.GetMouseButtonDown(1)){
            print("Pressed right click.");
            playerState = PlayerStates.hoverRight;
            animator.SetInteger(animationState,
                (int)playerState);
        }
        
        if(Input.GetMouseButtonDown(2)){
            print("Pressed middle click.");
            playerState = PlayerStates.hoverLeft;
            animator.SetInteger(animationState,
                (int)playerState);
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        
        movement.y = Input.GetAxisRaw("Vertical");

        rb2D.velocity = movement * movementSpeed;
       // print(rb2D.velocity.y + "is Y");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
   
    }

    private void UpdateState()
    {
        // if landed
        if(verticalState == VerticalState.landed) {

        }
        // if falling, or if movement.y is positive, go to hover
        // if not, walk if movement.x is positive
        // else, state is landed if not already set
        // if speed is high, tip forward

        // if above midway, flip upside down
        /*
        if(transform.position.y > 0.5 && verticalState != VerticalState.landInvert)
        {
            verticalState = VerticalState.floatingInvert;
        }

        if(transform.position.y < -0.5 && verticalState != VerticalState.land)
        {
            verticalState = VerticalState.floating;
        }

        if (verticalState == VerticalState.land)
        {
            if (movement.x > 0)
            {
                animator.SetInteger(animationState,
                    (int)PlayerStates.walkRight);
            }
            else if (movement.x < 0)
            {
                animator.SetInteger(animationState,
                    (int)PlayerStates.walkLeft);
            }
            else
            {
                animator.SetInteger(animationState,
                    (int)PlayerStates.idleRight);
            }
        }
        else if (verticalState == VerticalState.landInvert)
        {
            if (movement.x > 0)
            {
                animator.SetInteger(animationState,
                    (int)PlayerStates.walkRightInvert);
            }
            else if (movement.x < 0)
            {
                animator.SetInteger(animationState,
                    (int)PlayerStates.walkLeftInvert);
            }
            else
            {
                animator.SetInteger(animationState,
                    (int)PlayerStates.idleRightInvert);
            }
        }

        else if (verticalState == VerticalState.floating)
        {
            // first check we are right-side-up
            if (animator.GetInteger(animationState) != (int)PlayerStates.flyIdle &&
                animator.GetInteger(animationState) != (int)PlayerStates.flyLeft &&
                animator.GetInteger(animationState) != (int)PlayerStates.flyRight)
            {
                animator.SetInteger(animationState,
                    (int)PlayerStates.flipRightInvert);
            }

            // then, pick flying or not
            if (animator.GetInteger(animationState) != (int)PlayerStates.flipRightInvert)
            { 
                if (movement.x > 0)
                {
                    animator.SetInteger(animationState,
                        (int)PlayerStates.flyRight);
                }
                else if (movement.x < 0)
                {
                    animator.SetInteger(animationState,
                        (int)PlayerStates.flyLeft);
                }
                else
                {
                    animator.SetInteger(animationState,
                        (int)PlayerStates.flyIdle);
                }
            }
        }
        else if (verticalState == VerticalState.floatingInvert)
        {
            // first check if we are right side up
            if (animator.GetInteger(animationState) != (int)PlayerStates.flyIdleInvert &&
                   animator.GetInteger(animationState) != (int)PlayerStates.flyLeftInvert &&
                   animator.GetInteger(animationState) != (int)PlayerStates.flyRightInvert)
            { 
                animator.SetInteger(animationState,
                    (int)PlayerStates.flipRight);
            }

            // then, pick flying or not
            if (animator.GetInteger(animationState) != (int)PlayerStates.flipRight)
            {
                if (movement.x > 0)
                {
                    animator.SetInteger(animationState,
                        (int)PlayerStates.flyRightInvert);
                }
                else if (movement.x < 0)
                {
                    animator.SetInteger(animationState,
                        (int)PlayerStates.flyLeftInvert);
                }
                else
                {
                    animator.SetInteger(animationState,
                        (int)PlayerStates.flyIdleInvert);
                }
            }
        }*/
    }

/*
    public void AddPlayerDamageEvent(UnityAction<float> listener)
    {
        print("added damage listener");
        playerDamageEvent.AddListener(listener);
    }
    */
}
