using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    public void LoadNextScene(string nextScene){
        StartCoroutine(LoadScene(nextScene));
    }
    IEnumerator LoadScene(string nextScene) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(nextScene);
    }
}
