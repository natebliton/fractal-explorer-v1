using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyUfoChange : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject spaceShipTransparent;
    public GameObject spaceShipSolid;
    public GameObject spaceShipFlash;
    [SerializeField] private float goToFfish = 3f;
    [SerializeField] private float goTransparent = 1f;
    [SerializeField] private float goSolid = 11f;
    [SerializeField] private float flash = 11f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        spaceShip.gameObject.SetActive(true);
        spaceShipTransparent.gameObject.SetActive(false);
        spaceShipSolid.gameObject.SetActive(false);
        spaceShipFlash.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > goToFfish && timer <= goToFfish + goTransparent)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(true);
            spaceShipSolid.gameObject.SetActive(false);
            spaceShipFlash.gameObject.SetActive(false);

        }
        if (timer > goToFfish + goTransparent && timer <= goToFfish + goTransparent + goSolid)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(false);
            spaceShipFlash.gameObject.SetActive(false);

        }
        if (timer > goToFfish + goTransparent + goSolid && timer <= goToFfish + goTransparent + goSolid +flash)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(true);
            spaceShipFlash.gameObject.SetActive(false);

        }
        if (timer > goToFfish + goTransparent + goSolid + flash)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(false);
            spaceShipFlash.gameObject.SetActive(true);

        }
    }
}
