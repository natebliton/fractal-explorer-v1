using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpinner : MonoBehaviour
{
    RectTransform rectTransform;

    bool mouseOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseOver)
            rotateImage();

    }

    void rotateImage()
    {
        float rotationAmount = 5;
        rectTransform.Rotate( 0, 0, rotationAmount, Space.Self );
    }

    /// <summary>
    /// Called when the mouse enters the GUIElement or Collider.
    /// </summary>
    void OnMouseEnter()
    {
        mouseOver = true;
        print("mouse over");
    }

    /// <summary>
    /// Called when the mouse is not any longer over the GUIElement or Collider.
    /// </summary>
    void OnMouseExit()
    {
        mouseOver = false;
        print("mouse exit");
    }
    /// <summary>
    /// Called every frame while the mouse is over the GUIElement or Collider.
    /// </summary>
    void OnMouseOver()
    {
        print("over");
        float rotationAmount = 5;
        //float tempRotatoin = rectTransform.localRotation.z;
        //Vector3 tempVector3 = new Vector3(rectTransform.localRotation.x,
        //rectTransform.localRotation.y,
        //rectTransform.localRotation.z + rotationAmount);
        rectTransform.Rotate( 0, 0, rotationAmount, Space.Self );

    }
}
