using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{   
    [SerializeField]
    private float _swimSpeed = 1.0f;

    private Orientation _fishOrientation = Orientation.left;
    
    public enum Orientation {
        left,
        right
    }

    Animator orientationAnimator;


    #region public Methods
    /// <summary>
    /// Set orientation of fish to left or right
    /// </summary>
    /// <param name="orientation">Enumeration of left or right</param>
    public void SetOrientation(Orientation orientation){
        _fishOrientation = orientation;
        updateOrientation();
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
