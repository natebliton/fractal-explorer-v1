using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Fields

    GameObject player;
    Camera mainCamera;

    #endregion


    #region Public Methods
    public string cameraFollowingTag = "Player";

    // this object's dimensions determine the bounds of the camera in this scene
    public GameObject boundingBackground;

    #endregion

    #region private methods

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(cameraFollowingTag);
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // move the camera to follow the player
        // if the player has moved to the right
        if(Mathf.Abs(player.transform.position.x - mainCamera.transform.position.x) > 0 ||
        Mathf.Abs(player.transform.position.y - mainCamera.transform.position.y) > 0 )
        {
            mainCamera.transform.position =
                new Vector3(player.transform.position.x,
                player.transform.position.y,
                mainCamera.transform.position.z);
            clampCamera();
        }
    }

    // will clamp camera to not go outside of world bounds
    void clampCamera() {

    }    

    #endregion
}