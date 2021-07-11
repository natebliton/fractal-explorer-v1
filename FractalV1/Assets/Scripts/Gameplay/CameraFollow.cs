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
        // if the player has moved to the right
        if(player.transform.position.x > mainCamera.transform.position.x)
        {
            mainCamera.transform.position =
                new Vector3(player.transform.position.x,
                mainCamera.transform.position.y,
                mainCamera.transform.position.z);
        }
    }

    #endregion
}
