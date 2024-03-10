using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRobotCosmicEgg : MonoBehaviour
{
    public GameObject AlienRobotShip;
    public GameObject AlienRobotBright;
    public GameObject AlienRobot;
   


    [SerializeField] private float gliding = 2f;
    [SerializeField] private float ChangeToBrightFlashes = 2f;
    [SerializeField] private float changeToAlienRig = 2f;
    [SerializeField] private float changeToSpaceship = 2f;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        AlienRobotShip.gameObject.SetActive(true);
        AlienRobotBright.gameObject.SetActive(false);
        AlienRobot.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > gliding && timer <= gliding + ChangeToBrightFlashes)
        {
            // turn flying owl off and landing owl on after landStart delay
            AlienRobotShip.gameObject.SetActive(false);
            AlienRobotBright.gameObject.SetActive(true);
            // return;
        }
        if (timer > gliding + ChangeToBrightFlashes && timer <= gliding + ChangeToBrightFlashes + changeToAlienRig)
        {
            // turn flying owl off and landing owl on after landStart delay
            AlienRobotShip.gameObject.SetActive(false);
            AlienRobotBright.gameObject.SetActive(false);
            AlienRobot.gameObject.SetActive(true);
            // return;
        }
        if (timer > gliding + ChangeToBrightFlashes + changeToAlienRig + changeToSpaceship)
        {
            // turn flying owl off and landing owl on after landStart delay
            AlienRobotShip.gameObject.SetActive(true);
            AlienRobotBright.gameObject.SetActive(false);
            AlienRobot.gameObject.SetActive(false);
            return;
        }
    }
}
