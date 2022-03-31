using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{   
    [SerializeField]
    private float _swimSpeed = 1.0f;
    private bool _facingCorrectDirection = true;

    private Orientation _fishOrientation = Orientation.left;

    public enum Orientation {
        left,
        right
    }

    Animator orientationAnimator;
    Animator[] swimAnimators;

    FishMover moverScript;

    #region public Methods
    /// <summary>
    /// Set orientation of fish to left or right
    /// </summary>
    /// <param name="orientation">Enumeration of left or right</param>
    public void SetOrientation(Orientation orientation){
        _fishOrientation = orientation;
        updateOrientation();
    }

    public bool Oriented {
        get{ return _facingCorrectDirection; }
    }
    #endregion

    #region private methods

    /// <summary>
    /// Updates the left/right orientation animation
    /// </summary>
    private void updateOrientation() {
        orientationAnimator.SetInteger("orientation",(int)_fishOrientation);
    }

    // Start is called before the first frame update
    void Start()
    {
        orientationAnimator = GetComponent<Animator>();
        moverScript = GetComponent<FishMover>();
        swimAnimators = GetComponentsInChildren<Animator>();
        print("found " + swimAnimators.Length + " swimAnimators");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _swimSpeed = moverScript.CurrentSpeed.magnitude;
        float xSpeed = moverScript.CurrentSpeed.x;
       // print(_swimSpeed);
        if(xSpeed > 0) {
            if(_fishOrientation == Orientation.left)
            {
                SetOrientation(Orientation.right);
                _facingCorrectDirection = false;
            } else if (orientationAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_facingCorrectDirection) {
                handleOriented();
            }
        } else if (xSpeed < 0) {
            if(_fishOrientation == Orientation.right)
            {
                SetOrientation(Orientation.left);
                _facingCorrectDirection = false;
            } else if (orientationAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_facingCorrectDirection) {
                handleOriented();
            }
        }
        if(_facingCorrectDirection)
        {
            updateSpeed();
        }
    }

    private void updateSpeed() {
        foreach(Animator animator in swimAnimators){
            animator.SetFloat("swimSpeed",_swimSpeed);
        }
    }

    public void handleOriented(){
        _facingCorrectDirection = true;
        print("finished turning");
    }

    #endregion
}
