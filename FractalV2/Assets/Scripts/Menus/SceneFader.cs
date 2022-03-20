using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    private void Start() {
        EventManager.AddEnterWorldListener(EnterWorld);
    }
    public void LoadNextScene(string nextScene){
        StartCoroutine(LoadScene(nextScene));
    }
    public void EnterWorld(WorldList.Worlds worldToEnter){
        // NULL check while I add worlds
        if(WorldList.WorldSceneNames[(int)worldToEnter] != "NULL") {
           StartCoroutine(LoadScene(WorldList.WorldSceneNames[(int)worldToEnter]));
        }
    }
    IEnumerator LoadScene(string nextScene) {
        transition.SetTrigger("Start");

        if(transitionTime > 0) {
            transition.speed = 1f/transitionTime;
        }

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(nextScene);
    }
}
