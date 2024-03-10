using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFishLaunchHummingbird : MonoBehaviour
{
    public GameObject ffishToHummingbird;
    public GameObject hummingbirdGlide;
    [SerializeField] private float launchStart = 14f;
    [SerializeField] private float hummingbirdStart = 1f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        hummingbirdGlide.gameObject.SetActive(false);
        ffishToHummingbird.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > launchStart && timer <= launchStart + hummingbirdStart)
        {
            hummingbirdGlide.gameObject.SetActive(false);
            ffishToHummingbird.gameObject.SetActive(true);
        }
        if (timer > launchStart + hummingbirdStart)
        {
            hummingbirdGlide.gameObject.SetActive(true);
            ffishToHummingbird.gameObject.SetActive(false);
        }
    }
}
