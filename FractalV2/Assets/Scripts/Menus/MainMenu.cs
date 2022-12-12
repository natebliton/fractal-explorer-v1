using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for the OnClick events for the main menu buttons
/// </summary>
public class MainMenu : MonoBehaviour
{

    [SerializeField]
    GameObject levelLoader;

    LibPdInstance libPdInstance;
    SceneFader sceneFaderScript;

    private void Start() {
        sceneFaderScript = levelLoader.GetComponent<SceneFader>();
        libPdInstance = GameObject.FindGameObjectWithTag("sound").GetComponent<LibPdInstance>();
    }

    /// <summary>
    /// Handles the play button on click event.
    /// </summary>
    public void HandlePlayButtonOnClickEvent()
    {
        // play click sound
        //  AudioManager.Play(AudioClipName.MenuButtonClick);
        // go
        libPdInstance.SendBang("click1");
        print("going to GamePlay");
        //SceneManager.LoadScene("Scenes/Islands/Island1");
        sceneFaderScript.LoadNextScene("Scenes/Islands/Island1");
    }

    /// <summary>
    /// Handles the quit button on click event.
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        // play click sound
        //  AudioManager.Play(AudioClipName.MenuButtonClick);
        // go
        libPdInstance.SendBang("click1");
        print("Quitting!");
        Application.Quit();
    }

    /// <summary>
    /// Handles the help button on click event.
    /// </summary>
    public void HandleHelpButtonOnClickEvent()
    {
        // play click sound
        //  AudioManager.Play(AudioClipName.MenuButtonClick);
        // go
        libPdInstance.SendBang("click1");
        print("Help!");
        SceneManager.LoadScene("HelpMenu");
      //levelLoaderScript.LoadNextScene("HelpMenu");
      
    }
}
