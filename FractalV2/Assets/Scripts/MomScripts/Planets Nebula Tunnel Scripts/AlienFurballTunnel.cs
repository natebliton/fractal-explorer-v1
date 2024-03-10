using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFurballTunnel : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject spaceShipTransparent;
    public GameObject AlienFurball;
    public GameObject spaceShipSolid;
    [SerializeField] private float goToLanding = 10f;
    [SerializeField] private float goTransparent = 1f;
    //[SerializeField] private float goAlien = 1f;
    [SerializeField] private float goSolid = 20f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        spaceShip.gameObject.SetActive(true);
        spaceShipTransparent.gameObject.SetActive(false);
        AlienFurball.gameObject.SetActive(false);
        spaceShipSolid.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > goToLanding && timer <= goToLanding + goTransparent)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(true);
            AlienFurball.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(false);

        }
        if (timer > goToLanding + goTransparent && timer <= goToLanding + goTransparent + goSolid)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            AlienFurball.gameObject.SetActive(true);
            spaceShipSolid.gameObject.SetActive(false);

        }
        if (timer > goToLanding + goTransparent + goSolid)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            AlienFurball.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(true);

        }
    }
}
