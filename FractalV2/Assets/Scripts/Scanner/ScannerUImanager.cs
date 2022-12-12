using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerUImanager : MonoBehaviour
{
    [SerializeField]
    private GameObject scannerTopBar;
    [SerializeField]
    private GameObject scannerMainWindow;
    [SerializeField]
    private ScannerStates scannerState = ScannerStates.closed;
    private ScannerStates scannerStateLastDisplayed = ScannerStates.closed;

    private ScannerBarStates scannerBarState = ScannerBarStates.hidden;
    private ScannerBarStates scannerBarStateLastDisplayed = ScannerBarStates.hidden;

    private Rigidbody2D rb2D;

    private Animator scannerAnimator;
    private Animator topBarAnimator;

    LibPdInstance libPdInstance;

    enum ScannerStates
    {
        closed = 0,
        open = 1,
        scanning = 2
    }

    enum ScannerBarStates
    {
        hidden = 0,
        revealed = 1
    }
    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        scannerAnimator = gameObject.transform.Find("MainScanner").transform.Find("MainScannerWindow").GetComponent<Animator>();
        topBarAnimator = gameObject.transform.Find("TopBar").transform.Find("TopBarWindow").GetComponent<Animator>();
        libPdInstance = GameObject.FindGameObjectWithTag("sound").GetComponent<LibPdInstance>();
    }

    void Update()
    {
        if(scannerState !=scannerStateLastDisplayed)
        {
            UpdateState();
        }

        UpdateBarState();
        if (Input.GetAxis("Toggle Scanner") > 0)
        {
            scannerBarState = ScannerBarStates.hidden;
            scannerState = ScannerStates.open;
        }
    }

    private void UpdateBarState()
    {
        switch (scannerBarState)
        {
            case ScannerBarStates.hidden:
                topBarAnimator.SetBool("TopBarRevealed", false);
                break;
            case ScannerBarStates.revealed:
                topBarAnimator.SetBool("TopBarRevealed", true);
                break;
        }
  
    }

    public void HandleCloseScannerEvent()
    {
        scannerState = ScannerStates.closed;
        // scannerMainWindow.SetActive(false);
        scannerBarState = ScannerBarStates.hidden;
        libPdInstance.SendBang("click1");
    }

    public void HandleStartScanningEvent()
    {
        scannerState = ScannerStates.scanning;
        scannerTopBar.SetActive(true);
        scannerBarState = ScannerBarStates.revealed;
        libPdInstance.SendBang("click1");
    }

    public void HandleStopScanningEvent()
    {
        scannerState = ScannerStates.open;
        //scannerTopBar.SetActive(false);
        scannerBarState = ScannerBarStates.hidden;
        libPdInstance.SendBang("click1");
    }


    void ChangeAnimationState(Animator animator, string newState)
    {
        // guard against calling current state
       // if (scannerCurrentState == newState) return;
      //  scannerCurrentState = newState;
        print("play the animation");
        animator.Play(newState);
    }





    private void UpdateState()
    {
        print("state is " + scannerState + " "+ (int)scannerState);
        switch (scannerState)
        {
            case ScannerStates.closed:
                scannerAnimator.SetInteger("State", (int)scannerState);
                break;
            case ScannerStates.scanning:
                scannerAnimator.SetInteger("State", (int)scannerState);
                break;
            case ScannerStates.open:
                scannerAnimator.SetInteger("State", (int)scannerState);
                break;
        }

        scannerStateLastDisplayed = scannerState;
        /*
        if (playerState != playerStateDisplayed) {
            animator.SetInteger(animationState, (int)playerState);
            playerStateDisplayed = playerState;
        }

        // if landed
        if(verticalState == VerticalState.landed) {

        }
*/
    }

}
