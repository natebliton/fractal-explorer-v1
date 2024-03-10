using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGreenGoldPhases : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject spaceShipTransparent;
    public GameObject spaceShipSolid;
    [SerializeField] private float goToCenter = 10f;
    [SerializeField] private float goTransparent = 1f;
    [SerializeField] private float goSolid = 20f;
    [SerializeField] private float goTransparent2 = 1f;
    [SerializeField] private float goSolid2 = 20f;
    [SerializeField] private float goTransparent3 = 1f;
    [SerializeField] private float goSolid3 = 20f;
    float timer;
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

        if (timer > goToCenter && timer <= goToCenter + goTransparent)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(true);
            spaceShipSolid.gameObject.SetActive(false);

        }
        if (timer > goToCenter + goTransparent && timer <= goToCenter + goTransparent + goSolid)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(false);

        }
        if (timer > goToCenter + goTransparent + goSolid && timer <= goToCenter + goTransparent + goSolid + goTransparent2)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(true);

        }
        if (timer > goToCenter + goTransparent + goSolid + goTransparent2 && timer <= goToCenter + goTransparent + goSolid + goTransparent2 + goSolid2)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(false);

        }
        if (timer > goToCenter + goTransparent + goSolid + goTransparent2 + goSolid2 && timer <= goToCenter + goTransparent + goSolid + goTransparent2 + goSolid2 + goTransparent3)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(true);

        }
        if (timer > goToCenter + goTransparent + goSolid + goTransparent2 + goSolid2 + goTransparent3 && timer <= goToCenter + goTransparent + goSolid + goTransparent2 + goSolid2 + goTransparent3 + goSolid3)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(false);

        }
        if (timer > goToCenter + goTransparent + goSolid + goTransparent2 + goSolid2 + goTransparent3 + goSolid3)
        {
            spaceShip.gameObject.SetActive(false);
            spaceShipTransparent.gameObject.SetActive(false);
            spaceShipSolid.gameObject.SetActive(true);

        }
    }
}
