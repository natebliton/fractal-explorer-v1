using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummingbirdMorphSpaceship : MonoBehaviour
{
    public GameObject hummingbirdGlide;
    public GameObject hummingbirdToSpaceship;
    public GameObject spaceshipToTransparent;
    public GameObject hummingbirdInSpaceship;

    [SerializeField] private float delayStart = 2f;
    [SerializeField] private float gliding = 2f;
    [SerializeField] private float changeToSpaceship = 2f;
    [SerializeField] private float spaceshipGoesTransparent = 2f;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        hummingbirdGlide.gameObject.SetActive(true);
        hummingbirdToSpaceship.gameObject.SetActive(false);
        spaceshipToTransparent.gameObject.SetActive(false);
        hummingbirdInSpaceship.gameObject.SetActive(false);
        Invoke("Update", delayStart);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayStart + gliding && timer <= delayStart + gliding + changeToSpaceship)
        {
            // turn flying owl off and landing owl on after landStart delay
            hummingbirdGlide.gameObject.SetActive(false);
            hummingbirdToSpaceship.gameObject.SetActive(true);
            // return;
        }
        if (timer > delayStart + gliding + changeToSpaceship && timer <= delayStart + gliding + changeToSpaceship + spaceshipGoesTransparent)
        {
            // turn flying owl off and landing owl on after landStart delay
            hummingbirdGlide.gameObject.SetActive(false);
            hummingbirdToSpaceship.gameObject.SetActive(false);
            spaceshipToTransparent.gameObject.SetActive(true);
            // return;
        }
        if (timer > delayStart + gliding + changeToSpaceship + spaceshipGoesTransparent)
        {
            // turn flying owl off and landing owl on after landStart delay
            hummingbirdGlide.gameObject.SetActive(false);
            hummingbirdToSpaceship.gameObject.SetActive(false);
            spaceshipToTransparent.gameObject.SetActive(false);
            hummingbirdInSpaceship.gameObject.SetActive(true);
            return;
        }
    }
}
