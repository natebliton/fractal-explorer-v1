using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for the OnClick events for the help menu button(s)
/// </summary>
public class HelpMenu : MonoBehaviour
{
    /// <summary>
    /// Handles the return button on click event.
    /// </summary>
    public void HandleReturnButtonOnClickEvent()
    {   
        // play click sound
      //  AudioManager.Play(AudioClipName.MenuButtonClick);
        // go
        SceneManager.LoadScene("MainMenu");
    }
}
