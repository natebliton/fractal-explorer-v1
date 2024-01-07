using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    LibPdInstance libPdInstance;
    // Start is called before the first frame update
    void Start()
    {
        libPdInstance = transform.GetChild(0).GetComponent<LibPdInstance>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClick()
    {
        print("trying to play sound from sequencer1");

        libPdInstance.SendBang("click1");
    }
}
