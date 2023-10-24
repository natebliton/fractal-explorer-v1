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

    [SerializeField] private DestinationList.Islands parentIsland;
    private int parentIslandInt;
    // this collider's dimensions determine the bounds of the camera in this scene

    private BoxCollider2D mapBoundaryCollider;

    private float xMin, xMax, yMin, yMax;
    private float camY,camX;
    private float camHeight;
    private float camWidth;

    private float offScreenThreshold = 1.0f;
    private float almostOffScreenThreshold = 1.0f;

    private PopupManager popupManager;

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
        popupManager = GameObject.FindGameObjectWithTag("DirectionalPopup").GetComponent<PopupManager>();


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
        parentIslandInt = (int)parentIsland;
    }

    // Update is called once per frame
    void Update()
    {
        // just check offscreen
        checkOffscreen();
        checkAlmostOffscreen();
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
    private bool checkAlmostOffscreen()
    {
        if (playerTransform.position.x < (xMin + almostOffScreenThreshold))
        {
            print("almost offscreen left");
            popupManager.SetNewState(PopupManager.State.AlertLeft);
            return true;
        }
        else if (playerTransform.position.x > (xMax - almostOffScreenThreshold))
        {
            print("almost offscreen right");
            popupManager.SetNewState(PopupManager.State.AlertRight);
            return true;
        }
        else if (playerTransform.position.y < (yMin + almostOffScreenThreshold))
        {
            print("almost offscreen down");
            popupManager.SetNewState(PopupManager.State.AlertBottom);
            return true;
        }
        else if (playerTransform.position.y > (yMax - almostOffScreenThreshold))
        {
            print("almost offscreen up");
            popupManager.SetNewState(PopupManager.State.AlertTop);
            return true;
        } else
        {
            popupManager.SetNewState(PopupManager.State.NoAlert);
        }
        return false;
    }
    public void goToParent() {
        
        string nextScene = parentIsland.ToString();
        if(nextScene != "NULL") {
            sceneFaderScript.LoadNextScene(nextScene);        
        } else {
            MenuManager.GoToMenu(MenuName.Main);
        }
    }
    #endregion
}