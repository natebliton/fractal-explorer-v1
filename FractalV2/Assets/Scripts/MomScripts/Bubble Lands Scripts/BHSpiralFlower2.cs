using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHSpiralFlower2 : MonoBehaviour
{
    [SerializeField] private float delayFastSpin = 2f;
    private float timer;
    private Animator spinFast;
    // Start is called before the first frame update
    void Start()
    {
        spinFast = GetComponent<Animator>();
        timer += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayFastSpin)
        {
            spinFast.SetBool("goFast", true);
        }
    }
}
