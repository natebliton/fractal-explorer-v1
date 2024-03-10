using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummingbirdDive : MonoBehaviour
{
    // Turn owls on and off
    public GameObject hummingbirdGlide;
    public GameObject hummingbirdDive;
    [SerializeField] private float landStart = 2f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        hummingbirdGlide.gameObject.SetActive(true);
        hummingbirdDive.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > landStart)
        {
            hummingbirdGlide.gameObject.SetActive(false);
            hummingbirdDive.gameObject.SetActive(true);
        }
    }
}
