using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipChange : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject spaceShipTransparent;
    public GameObject spaceShipSolid;
    [SerializeField] private float goToCommunicator = 10f;
    [SerializeField] private float goTransparent = 1f;
    [SerializeField] private float goSolid = 20f;
    float timer;
    // private Animator changeSpaceship;

    // Start is called before the first frame update
    void Start()
    {
        spaceShip.gameObject.SetActive(true); 
        spaceShipTransparent.gameObject.SetActive(false);
        spaceShipSolid.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //if (timer > goToCommunicator)
        //{
        //    changeSpaceship.SetBool("transparent", true);

        //}
        if (timer > goToCommunicator && timer <= goToCommunicator + goTransparent)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(true);
            spaceShipSolid.gameObject.SetActive(false);

        }
        if (timer > goToCommunicator + goTransparent && timer <= goToCommunicator + goTransparent + goSolid)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(false);

        }
        if (timer > goToCommunicator + goTransparent + goSolid)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(true);

        }
    }
}
