using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    private float offScreenThreshold = 1.0f;
    private GameObject bottomAlert;
    private GameObject topAlert;
    private GameObject rightAlert;
    private GameObject leftAlert;

    private State currentState = State.unset;
    private State newState = State.NoAlert;

    public enum State {
        AlertLeft, AlertRight, AlertTop, AlertBottom, NoAlert, unset
    }

    // Start is called before the first frame update
    void Start()
    {
        bottomAlert = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        topAlert = gameObject.transform.GetChild(0).GetChild(1).gameObject;
        rightAlert = gameObject.transform.GetChild(0).GetChild(2).gameObject;
        leftAlert = gameObject.transform.GetChild(0).GetChild(3).gameObject;
        Button bottomButton = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Button>();
        Button topButton = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Button>();
        Button leftButton = gameObject.transform.GetChild(0).GetChild(2).GetComponent<Button>();
        Button rightButton = gameObject.transform.GetChild(0).GetChild(3).GetComponent<Button>();
        if(Camera.main.GetComponent<CameraFollow>() != null)
        {
            bottomButton.onClick.AddListener(delegate { Camera.main.GetComponent<CameraFollow>().GoDownScene(); });
            topButton.onClick.AddListener(delegate { Camera.main.GetComponent<CameraFollow>().GoUpScene(); });
            leftButton.onClick.AddListener(delegate { Camera.main.GetComponent<CameraFollow>().GoLeftScene(); });
            rightButton.onClick.AddListener(delegate { Camera.main.GetComponent<CameraFollow>().GoRightScene(); });
        }
        if (Camera.main.GetComponent<CameraBoundaryManager>() != null)
        {
            bottomButton.onClick.AddListener(delegate { Camera.main.GetComponent<CameraBoundaryManager>().goToParent(); });
            topButton.onClick.AddListener(delegate { Camera.main.GetComponent<CameraBoundaryManager>().goToParent(); });
            leftButton.onClick.AddListener(delegate { Camera.main.GetComponent<CameraBoundaryManager>().goToParent(); });
            rightButton.onClick.AddListener(delegate { Camera.main.GetComponent<CameraBoundaryManager>().goToParent(); });
        }

        currentState = newState = State.NoAlert;
        bottomAlert.SetActive(false);
        topAlert.SetActive(false);
        rightAlert.SetActive(false);
        leftAlert.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(newState != currentState)
        {
            switch(newState)
            {
                case State.AlertBottom:
                    bottomAlert.SetActive(true);
                    topAlert.SetActive(false);
                    rightAlert.SetActive(false);
                    leftAlert.SetActive(false);
                    break;
                case State.AlertTop:
                    bottomAlert.SetActive(false);
                    topAlert.SetActive(true);
                    rightAlert.SetActive(false);
                    leftAlert.SetActive(false);
                    break;
                case State.AlertRight:
                    bottomAlert.SetActive(false);
                    topAlert.SetActive(false);
                    rightAlert.SetActive(true);
                    leftAlert.SetActive(false);
                    break;
                case State.AlertLeft:
                    bottomAlert.SetActive(false);
                    topAlert.SetActive(false);
                    rightAlert.SetActive(false);
                    leftAlert.SetActive(true);
                    break;
                case State.NoAlert:
                    bottomAlert.SetActive(false);
                    topAlert.SetActive(false);
                    rightAlert.SetActive(false);
                    leftAlert.SetActive(false);
                    break;
                default:
                    break;

            }
        }
    }

    public void SetNewState(State state)
    {
        this.newState = state;
    }

    public State GetCurrentState()
    {
        return currentState;
    }
}
