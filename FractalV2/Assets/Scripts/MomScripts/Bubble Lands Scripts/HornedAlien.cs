using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornedAlien : MonoBehaviour
{
    public GameObject hornedAlienSpaceship;
    public GameObject hornedAlienSpaceshipGoTransparent;
    public GameObject HornedAlienDancer; 
    public GameObject HornedAlienSpaceshipGoSolid;


    [SerializeField] private float delayStart = 2f;
    [SerializeField] private float gliding = 2f;
    [SerializeField] private float spaceshipGoesTransparent = 1f;
    [SerializeField] private float Dancing = 2f;
    [SerializeField] private float spaceshipGoesSolid = 2f;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        hornedAlienSpaceship.gameObject.SetActive(false);
        hornedAlienSpaceshipGoTransparent.gameObject.SetActive(false);
        HornedAlienDancer.SetActive(false);
        HornedAlienSpaceshipGoSolid.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayStart) 
        { 
            hornedAlienSpaceship.gameObject.SetActive(true); 
        }
        if (timer > delayStart + gliding && timer <= delayStart + gliding + spaceshipGoesTransparent)
        {
            
            hornedAlienSpaceship.gameObject.SetActive(false);
            hornedAlienSpaceshipGoTransparent.gameObject.SetActive(true);
            
        }
        if (timer > delayStart + gliding + spaceshipGoesTransparent && timer <= delayStart + gliding + spaceshipGoesTransparent + Dancing)
        {
            
            hornedAlienSpaceship.gameObject.SetActive(false);
            hornedAlienSpaceshipGoTransparent.gameObject.SetActive(false);
            HornedAlienDancer.SetActive(true);
            
        }
        if (timer > delayStart + gliding + spaceshipGoesTransparent + Dancing)
        {
            
            hornedAlienSpaceship.gameObject.SetActive(false);
            hornedAlienSpaceshipGoTransparent.gameObject.SetActive(false);
            HornedAlienDancer.SetActive(false);
            HornedAlienSpaceshipGoSolid.gameObject.SetActive(true);
            return;
        }
    }
}
