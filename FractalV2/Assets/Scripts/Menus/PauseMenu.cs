using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pauses and unpauses the game. Listens for the OnClick
/// </summary>
public class PauseMenu : MonoBehaviour
{
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("generalSound").GetComponent<SoundManager>();
        // play click sound
     //   AudioManager.Play(AudioClipName.MenuButtonClick);
        // pause the game when added to the scene
        Time.timeScale = 0;
    }

    public void HandleResumeButtonOnClickEvent()
    {
        soundManager.PlayClick();
        // play click sound
        //  AudioManager.Play(AudioClipName.MenuButtonClick);
        // unpause the game and destroy the menu
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        soundManager.PlayClick();
        // play click sound
        //  AudioManager.Play(AudioClipName.MenuButtonClick);
        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
