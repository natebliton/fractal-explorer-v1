using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    private void Start() {
        EventManager.AddEnterWorldListener(EnterDestination);
    }
    public void LoadNextScene(string nextScene){
        StartCoroutine(LoadScene(nextScene));
    }
    public void EnterDestination(DestinationList.Worlds worldToEnter){
        // NULL check while I add worlds
        if(worldToEnter.ToString() != "NULL") {
           StartCoroutine(LoadScene(worldToEnter.ToString()));
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
