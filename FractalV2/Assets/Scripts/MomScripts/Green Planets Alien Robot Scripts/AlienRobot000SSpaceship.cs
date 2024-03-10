using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRobot000SSpaceship : MonoBehaviour
{
    private float timer;

    [SerializeField] private float Transparent = 2f;
    [SerializeField] private float Solid = 2f;

    private Animator spaceship;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = GetComponent<Animator>();
        timer += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > Transparent && timer <= Transparent + Solid)
        {
            spaceship.SetBool("goClear", true);
            spaceship.SetBool("goSolid", false);
        }
        if (timer > Transparent + Solid)
        {
            spaceship.SetBool("goClear", false);
            spaceship.SetBool("goSolid", true);
            
        }
    }
}
