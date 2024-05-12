using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for the OnClick events for the main menu buttons
/// </summary>
public class MainMenu : MonoBehaviour
{

    [SerializeField]
    GameObject levelLoader;

    SceneFader sceneFaderScript;

    SoundManager soundManager;

    private void Start() {
        sceneFaderScript = levelLoader.GetComponent<SceneFader>();
        soundManager = GameObject.FindGameObjectWithTag("generalSound").GetComponent<SoundManager>();
    }

    /// <summary>
    /// Handles the play button on click event.
    /// </summary>
    public void HandlePlayButtonOnClickEvent()
    {
        // play click sound
        soundManager.PlayClick();
        // go
        print("going to GamePlay");
        sceneFaderScript.LoadNextScene("Scenes/Islands/Island1");
    }

    /// <summary>
    /// Handles the quit button on click event.
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        // play click sound
        soundManager.PlayClick();
        // go
        print("Quitting!");
        Application.Quit();
    }

    /// <summary>
    /// Handles the help button on click event.
    /// </summary>
    public void HandleHelpButtonOnClickEvent()
    {
        // play click sound
        soundManager.PlayClick();
        // go
        print("Help!");
        SceneManager.LoadScene("HelpMenu");
      //levelLoaderScript.LoadNextScene("HelpMenu");
      
    }
}
