using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneralClickSound : MonoBehaviour
{
    LibPdInstance libPdInstance;

    PlaySoundEvent playSoundEvent = new PlaySoundEvent();

    // Start is called before the first frame update
    void Start()
    {
        libPdInstance = GameObject.FindGameObjectWithTag("sound").GetComponent<LibPdInstance>();
        EventManager.AddPlaySoundInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundViaBang(string soundName)
    {
        // libPdInstance.SendBang(soundName);
        print("trying to play sound from GeneralClickSound");
        playSoundEvent.Invoke("click");
    }

    /// <summary>
    /// add Play Sound Event listener
    /// </summary>
    /// <param name="listener"></param>
    public void AddZoomCameraEvent(UnityAction<string> listener)
    {
        playSoundEvent.AddListener(listener);
    }
}
