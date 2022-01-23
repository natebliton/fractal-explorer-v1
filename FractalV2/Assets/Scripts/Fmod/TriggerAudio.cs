using UnityEngine;
using FMODUnity;

public class TriggerAudio : MonoBehaviour
{

    public bool PlayOnAwake;
    public bool PlayOnDestroy;

    public void PlayOneShot()
    {
    //    MyEvent.Path
        //FMODUnity.RuntimeManager.PlayOneShotAttached(eventPath, gameObject);
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayOnAwake){
            PlayOneShot();
        }
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    private void OnDestroy()
    {
        if(PlayOnDestroy){
            PlayOneShot();
        }
    }
}
