using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject sceneFader;

    [SerializeField]
    DestinationList.Islands LeftDestination;

    [SerializeField]
    DestinationList.Islands RightDestination;

    [SerializeField]
    DestinationList.Islands UpDestination;

    [SerializeField]
    DestinationList.Islands DownDestination;

    SceneFader sceneFaderScript;
    PopupManager popupManager;



    Transform playerTransform;
    private Camera mainCamera;

    // this collider's dimensions determine the bounds of the camera in this scene

    private BoxCollider2D mapBoundaryCollider;

    private float xMin, xMax, yMin, yMax;
    private float camY,camX;
    private float camHeight;
    private float camWidth;

    private float offScreenThreshold = 1.0f;
    private float almostOffScreenThreshold = 1.0f;


    #endregion


    #region Public Methods
    public string cameraFollowingTag = "Player";

    #endregion

    #region private methods

    // Start is called before the first frame update
    void Start()
    {
        sceneFaderScript = sceneFader.GetComponent<SceneFader>();
        popupManager = GameObject.FindGameObjectWithTag("DirectionalPopup").GetComponent<PopupManager>();
        playerTransform = GameObject.FindGameObjectWithTag(cameraFollowingTag).GetComponent<Transform>();
        mapBoundaryCollider = GameObject.FindGameObjectWithTag("mapBoundaryObject").GetComponent<BoxCollider2D>();
        mainCamera = GetComponent<Camera>();

        xMin = mapBoundaryCollider.bounds.min.x;
        xMax = mapBoundaryCollider.bounds.max.x;
        yMin = mapBoundaryCollider.bounds.min.y;
        yMax = mapBoundaryCollider.bounds.max.y;
        camHeight = mainCamera.orthographicSize;
        camWidth = camHeight * mainCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // move the camera to follow the player
        // if the player has moved to the right
        if(Mathf.Abs(playerTransform.position.x - mainCamera.transform.position.x) > 0 ||
        Mathf.Abs(playerTransform.position.y - mainCamera.transform.position.y) > 0 )
        {
            mainCamera.transform.position =
                new Vector3(playerTransform.position.x,
                playerTransform.position.y,
                mainCamera.transform.position.z);
            clampCamera();
        }
        checkAlmostOffscreen();
        checkOffscreen();
    }

    // will clamp camera to not go outside of world bounds
    void clampCamera() {
        camY = Mathf.Clamp(playerTransform.position.y, yMin + camHeight, yMax - camHeight);
        camX = Mathf.Clamp(playerTransform.position.x, xMin + camWidth, xMax - camWidth);
        mainCamera.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }    

    private bool checkOffscreen(){
        if (playerTransform.position.x < (xMin - offScreenThreshold))
        {
            print("offscreen left");
            GoLeftScene();
            return true;
        } else if (playerTransform.position.x > (xMax + offScreenThreshold)){
            print("offscreen right");
            GoRightScene();
            return true;
        } else if (playerTransform.position.y < (yMin - offScreenThreshold)){
            print("offscreen down");
            GoDownScene();
            return true;
        } else if(playerTransform.position.y > (yMax + offScreenThreshold)){
            print("offscreen up");
            GoUpScene();
            return true;
        }
        return false;
    }

    public void GoLeftScene()
    {
        goToScene(LeftDestination.ToString());
    }
    public void GoRightScene()
    {
        goToScene(RightDestination.ToString());
    }
    public void GoDownScene()
    {
        goToScene(DownDestination.ToString());
    }
    public void GoUpScene()
    {
        goToScene(UpDestination.ToString());
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
        }
        popupManager.SetNewState(PopupManager.State.NoAlert);
        return false;
    }
    private void goToScene(string destination)
    {
        sceneFaderScript.LoadNextScene(destination);
        //MenuManager.GoToMenu(MenuName.Main);
    }

    private void goToMainMenu() {
        sceneFaderScript.LoadNextScene("MainMenu");
        //MenuManager.GoToMenu(MenuName.Main);
    }
    #endregion
}