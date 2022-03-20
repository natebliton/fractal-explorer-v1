using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaryManager : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject sceneFader;

    SceneFader sceneFaderScript;

    Transform playerTransform;
    private Camera mainCamera;

    [SerializeField] private IslandList.Islands parentIsland;

    // this collider's dimensions determine the bounds of the camera in this scene

    private BoxCollider2D mapBoundaryCollider;

    private float xMin, xMax, yMin, yMax;
    private float camY,camX;
    private float camHeight;
    private float camWidth;

    private float offScreenThreshold = 1.0f;

    #endregion


    #region Public Methods
    public string cameraFollowingTag = "Player";

    #endregion

    #region private methods

    // Start is called before the first frame update
    void Start()
    {
        sceneFaderScript = sceneFader.GetComponent<SceneFader>();
        playerTransform = GameObject.FindGameObjectWithTag(cameraFollowingTag).GetComponent<Transform>();
        mainCamera = GetComponent<Camera>();
        
        camHeight = mainCamera.orthographicSize;
        camWidth = camHeight * mainCamera.aspect;
        xMin = camWidth * -1f;
        xMax = camWidth;
        yMin = camHeight * -1f;
        yMax = camHeight;
        print("camera dimensions: ");
        print(xMin);
        print(xMax);
        print(yMin);
        print(yMax);
        
    }

    // Update is called once per frame
    void Update()
    {
        // just check offscreen
        checkOffscreen();
    }

    private bool checkOffscreen(){
        if(playerTransform.position.x < (xMin - offScreenThreshold)){
            print("offscreen left");
            goToParent();
            return true;
        } else if (playerTransform.position.x > (xMax + offScreenThreshold)){
            print("offscreen right");
            goToParent();
            return true;
        } else if (playerTransform.position.y < (yMin - offScreenThreshold)){
            print("offscreen down");
            goToParent();
            return true;
        } else if(playerTransform.position.y > (yMax + offScreenThreshold)){
            print("offscreen up");
            goToParent();
            return true;
        }
        return false;
    }

    private void goToParent() {
        string nextScene = IslandList.IslandSceneNames[(int)parentIsland];
        if(nextScene != "NULL") {
            sceneFaderScript.LoadNextScene(nextScene);        
        } else {
            MenuManager.GoToMenu(MenuName.Main);
        }
    }
    #endregion
}