using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for the OnClick events for the main menu buttons
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Handles the play button on click event.
    /// </summary>
    public void HandlePlayButtonOnClickEvent()
    {
        // play click sound
      //  AudioManager.Play(AudioClipName.MenuButtonClick);
        // go
        print("going to GamePlay");
        SceneManager.LoadScene("GamePlay");
    }

    /// <summary>
    /// Handles the quit button on click event.
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        // play click sound
      //  AudioManager.Play(AudioClipName.MenuButtonClick);
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
      //  AudioManager.Play(AudioClipName.MenuButtonClick);
        // go
      print("Quitting!");
      SceneManager.LoadScene("HelpMenu");
    }
}
