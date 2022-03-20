using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    bool zoomingIn = false;
    float zoomDx = 1f;
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        EventManager.AddZoomCameraListener(ZoomIn);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (zoomingIn){
            print(zoomingIn);
           ZoomingInUpdate();
        }
    }

    void ZoomingInUpdate()
    {
        mainCamera.orthographicSize *= zoomDx;
    }

    private void ZoomIn(float input) {
        print("ZoomIn!");
        zoomDx = input;
        zoomingIn = true;
    }


}
