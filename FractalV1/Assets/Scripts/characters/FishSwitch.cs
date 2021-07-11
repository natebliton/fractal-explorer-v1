using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwitch : MonoBehaviour
{

    public GameObject topSwimmer;
    SpriteRenderer topSwimmerSprite;
    public GameObject sideSwimmer;
    SpriteRenderer sideSwimmerSprite;
    public bool topSwimming = true;

    Color onColor = new Color(1f, 1f, 1f, 1f);
    Color offColor = new Color(1f, 1f, 1f, 0f);

    public GameObject playerObject;
    Animator topAnimator;
    Animator sideAnimator;
    Rigidbody2D rb2dTop;
    Vector3 currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        topSwimmerSprite = topSwimmer.GetComponent<SpriteRenderer>();
        sideSwimmerSprite = sideSwimmer.GetComponent<SpriteRenderer>();

        rb2dTop = playerObject.GetComponent<Rigidbody2D>();
        topAnimator = topSwimmer.GetComponent<Animator>();
        sideAnimator = sideSwimmer.GetComponent<Animator>();

        setTopSwimmingOnOff(topSwimming);

    }

    void setTopSwimmingOnOff(bool onOff) {
        if(onOff){
            topSwimmerSprite.color = onColor;
            sideSwimmerSprite.color = offColor;
        } else {
            topSwimmerSprite.color = offColor;
            sideSwimmerSprite.color = onColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = rb2dTop.velocity;
        print("speed is " + currentSpeed.magnitude);
        topAnimator.SetFloat("Speed", currentSpeed.magnitude + 0.1f);
        sideAnimator.SetFloat("Speed", currentSpeed.magnitude + 0.1f);
        
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        topSwimming = !topSwimming;
        setTopSwimmingOnOff(topSwimming);
    }
}
