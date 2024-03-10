using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandBlackHole : MonoBehaviour
{
    float timer;
    [SerializeField] private float WaitToExpand = 10f;
    private Animator expandBlackHole;

    // Start is called before the first frame update
    void Start()
    {
        expandBlackHole = GetComponent<Animator>();
        expandBlackHole.SetBool("expand", false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > WaitToExpand)
        {
            expandBlackHole.SetBool("expand", true);
        }
    }
}
