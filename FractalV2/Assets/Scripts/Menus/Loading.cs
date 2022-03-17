using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField]
    GameObject LoadingObject;

    [SerializeField]
    Slider LoadingSlider;

    public IEnumerator LoadingAndSwitch(string sceneName)
    {
        LoadingObject.SetActive(true);
        LoadingSlider.value = 0;
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, mode: LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            LoadingSlider.value = async.progress;
            yield return null;
        }
        LoadingSlider.value = 1.0f;
        yield return new WaitForSeconds(1f); // for debugging in unity editor. remove later
        async.allowSceneActivation = true;
    }
    public void Switch(string sceneName)
    {
        StartCoroutine(LoadingAndSwitch(sceneName));
    }
}
