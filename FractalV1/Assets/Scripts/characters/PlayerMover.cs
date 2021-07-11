using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    Vector2 movement = new Vector2();

    Vector3 clickedAt = new Vector3(0,0,0);

   // [SerializeField]
    public float maxSpeed = 6f;


    Rigidbody2D rb2D;
   // Rigidbody2D backgroundRb2D;

    [SerializeField]
    public float movementSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0.0f;
      //  backgroundRb2D = GameObject.FindGameObjectWithTag("Background").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        moveCharacter();
        checkRotation();

        checkClicked();
    }

    private void moveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(clickedAt.x != 0)
            movement.x += clickedAt.x - transform.position.x;
        if(clickedAt.y != 0)
            movement.y += clickedAt.y - transform.position.y;

        // reset clickedAt after use 
        clickedAt.x = 0;
        clickedAt.y = 0;

        rb2D.velocity += (movement * movementSpeed);
        rb2D.velocity = clampSpeed(rb2D.velocity);
    }

    private void checkRotation() {
        // tan angle = opp/adj
        float angle = Mathf.Atan2(rb2D.velocity.y, rb2D.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //float angle = Mathf.Atan2(backgroundRb2D.velocity.y, backgroundRb2D.velocity.x);
        //print(angle);

    }

     private void checkClicked() {
        if ( Input.GetAxisRaw("MousePress") > 0) {

            clickedAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            print("pressed at " + clickedAt.y + " " + clickedAt.y);
        }
    }

    
    private Vector2 clampSpeed(Vector2 input) {
        
       // print("in "+ input.x + " " +  input.y);

        if (input.x > maxSpeed) {
            input.x = maxSpeed;
        } else if (input.x < -1 * maxSpeed) {
            input.x = -1 * maxSpeed;
        }
        if (input.y > maxSpeed) {
            input.y = maxSpeed;
        } else if (input.y < -1 * maxSpeed) {
            input.y = -1 * maxSpeed;
        }
       // print(input.x + " " + input.y);
        return input;

    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        print("clicked on fish");
    }
}
