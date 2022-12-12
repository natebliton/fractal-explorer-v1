using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScannerManager : MonoBehaviour
{   
    [SerializeField]
    private GameObject topBar;

    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Toggle Scanner") > 0)
        {
            gameObject.SetActive(true);
        }
    }

    public void HandleCloseScannerEvent()
    {
        gameObject.SetActive(false);
    }

    public void HandleStartScanningEvent()
    {
        topBar.SetActive(true);
    }

    public void HandleStopScanningEvent()
    {
        topBar.SetActive(false);
    }



}
