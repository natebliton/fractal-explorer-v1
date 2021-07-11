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
    public bool cameraFollowLocked;
    #endregion

    #region private methods

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // move the camera to follow the player
        // if camera lock is engaged
        if(cameraFollowLocked) {
            cameraFollow();
        }

    }

    // if player is not centered in camera, move camera to match player position
    void cameraFollow() {
        if(player.transform.position.x > mainCamera.transform.position.x ||
           player.transform.position.x < mainCamera.transform.position.x ||
           player.transform.position.y > mainCamera.transform.position.y ||
           player.transform.position.y < mainCamera.transform.position.y
        )
        {
            mainCamera.transform.position =
                new Vector3(player.transform.position.x,
                player.transform.position.y,
                mainCamera.transform.position.z);
        } 
    }

    #endregion
}
