using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBearAlien : MonoBehaviour
{
    public GameObject pinkBearShip;
    public GameObject pinkBearTransparent;
    public GameObject alienPinkBear;
    public GameObject pinkBearSolid;


    [SerializeField] private float gliding = 2f;
    [SerializeField] private float spaceshipGoesTransparent = 2f;
    [SerializeField] private float changeToAlienRig = 2f;
    [SerializeField] private float changeToSolidShip = 2f;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        pinkBearShip.gameObject.SetActive(true);
        pinkBearTransparent.gameObject.SetActive(false);
        alienPinkBear.gameObject.SetActive(false);
        pinkBearSolid.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > gliding + spaceshipGoesTransparent && timer <= gliding + spaceshipGoesTransparent + changeToAlienRig)
        {
            // turn flying owl off and landing owl on after landStart delay
            pinkBearShip.gameObject.SetActive(false);
            pinkBearTransparent.gameObject.SetActive(true);
            // return;
        }
        if (timer > gliding + spaceshipGoesTransparent + changeToAlienRig )
        {
            // turn flying owl off and landing owl on after landStart delay
            pinkBearShip.gameObject.SetActive(false);
            pinkBearTransparent.gameObject.SetActive(false);
            alienPinkBear.gameObject.SetActive(true);
            // return;
        }
        if (timer > gliding + spaceshipGoesTransparent + changeToAlienRig + changeToSolidShip)
        {
            // turn flying owl off and landing owl on after landStart delay
            pinkBearShip.gameObject.SetActive(false);
            pinkBearTransparent.gameObject.SetActive(false);
            alienPinkBear.gameObject.SetActive(false);
            pinkBearSolid.gameObject.SetActive(true);
            return;
        }

    }
}
