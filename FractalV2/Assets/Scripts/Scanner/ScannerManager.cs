using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerManager : MonoBehaviour
{   
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleCloseScannerEvent() {
        Destroy(gameObject);
    }
}
