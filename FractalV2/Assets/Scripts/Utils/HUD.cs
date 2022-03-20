using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUD : MonoBehaviour
{
    #region Fields

    [SerializeField]
    static Text displayText;

    private static float currentScore = 0;
    private static float ballsLeft = 10;

    GameOverEvent gameOverEvent = new GameOverEvent();
  //  BallLostEvent ballLostEvent = new BallLostEvent();
  //  SpawnBallEvent spawnBallEvent = new SpawnBallEvent();
  //  LastBallRemovedEvent lastBallRemovedEvent = new LastBallRemovedEvent();
  //  BlockDestroyedEvent blockDestroyedEvent = new BlockDestroyedEvent();

    // array of balls for game over checking
  //  GameObject[] balls;
    
    #endregion

    #region Properties

    public static float CurrentScore
    {
        get { return currentScore; }
    }

    public static float BallsLeft
    {
        get { return ballsLeft; }
    }

    #endregion


    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // reset score in case of restart
        currentScore = 0;

        ballsLeft = (int)ConfigurationUtils.BallsAvailableTotal;

        displayText = GameObject.FindGameObjectWithTag("DisplayText").GetComponent<Text>();
        displayText.text = "Score: " + currentScore + "  Balls Left: " + ballsLeft;

       // EventManager.AddGameOverInvoker(this);

        /*
        EventManager.AddPointsAddedListener(AddPoints);
        EventManager.AddBallLostListener(SubtractBall);
        EventManager.AddSpawnBallEventInvoker(this);
        EventManager.AddLastBallRemovedListener(GameOver);
        EventManager.AddLastBallRemovedInvoker(this);
        */
    }

    void SubtractBall()
    {
        if (ballsLeft > 0)
        {
            ballsLeft -= 1;
            displayText.text = "Score: " + currentScore + "  Balls Left: " + ballsLeft;
           // spawnBallEvent.Invoke();
        } else
        {
            //double-check for straggling balls
          //  balls = GameObject.FindGameObjectsWithTag("Ball");
          //  print("balls still left " + balls.Length);
          //  if (balls.Length <= 1)
         //   {
          //      gameOverEvent.Invoke();
          //  }
        }
    }

    // game over for special circumstance
    void GameOver()
    {
        gameOverEvent.Invoke();
    }

    // add points to current score and update display
    void AddPoints(float points)
    {
        currentScore += points;
        displayText.text = "Score: " + currentScore + "  Balls Left: " + ballsLeft;
    }

    #endregion


    #region Public Methods

    public void AddGameOverEventListener(UnityAction listener)
    {
        gameOverEvent.AddListener(listener);
    }

    #endregion
}
