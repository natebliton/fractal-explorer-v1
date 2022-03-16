using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch(name)
        {
            case MenuName.Main:
                // go to MainMenu scene
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:
                // instantiate prefab
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.Help:
                // go to HelpMenu scene
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.GameOver:
                // display GameOver message prefab
                Object.Instantiate(Resources.Load("GameOverMenu"));
                break;
        }
    }
    
}
