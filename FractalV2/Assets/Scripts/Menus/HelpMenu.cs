using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for the OnClick events for the help menu button(s)
/// </summary>
public class HelpMenu : MonoBehaviour
{

    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("generalSound").GetComponent<SoundManager>();
    }
    /// <summary>
    /// Handles the return button on click event.
    /// </summary>
    public void HandleReturnButtonOnClickEvent()
    {
        // play click sound
        soundManager.PlayClick();
        // go
        SceneManager.LoadScene("MainMenu");
    }
}
