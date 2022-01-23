using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// game manager
/// </summary>
public class FractalGameManager : MonoBehaviour
{
    //  GameOverEvent gameOverEvent = new GameOverEvent();
    // GameObject[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        // call game over method if game over event is invoked
        EventManager.AddGameOverListener(GameOver);
      //  EventManager.AddBlockDestroyedListener(CheckIfOnlyOneBlockLeft);
    }

    // Update is called once per frame
    void Update()
    {
        // pause game on escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }        
        // test
        if (Input.GetKeyDown(KeyCode.A))
        {
           // GameOver();
        }
    }
/*
    void CheckIfOnlyOneBlockLeft(BlockType blockType)
    {
        if (blockType == BlockType.Standard)
        {

        }
        blocks = GameObject.FindGameObjectsWithTag("BlockGeneral");
        print("Blocks left: " + blocks.Length);
        if (blocks.Length <= 1)
        {
            GameOver();
        }
        
    }
*/

    void GameOver()
    {
      //  AudioManager.Play(AudioClipName.GameOver);
        MenuManager.GoToMenu(MenuName.GameOver);
    }
}
