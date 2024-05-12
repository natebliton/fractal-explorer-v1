using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSoundManager : MonoBehaviour
{
    [SerializeField] private Transform petalsBone;
    [SerializeField] private Transform stemBone;

    [SerializeField] private float petalsWidth;
    [SerializeField] private float petalsRotation;
    [SerializeField] private float petalsRotationLast;
    [SerializeField] private float petalsRotationDelta;
    [SerializeField] private float petalsRotationMaxDelta;
    [SerializeField] private float petalsRotationMinDelta;
    [SerializeField] private float petalsBoneLength;


    [SerializeField] private float soundMultiplier = 300.0F;

    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("generalSound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // petalsRotationDelta = petalsBone.rotation.z * Time.deltaTime;
        petalsRotation = petalsBone.rotation.z;
        petalsRotationDelta = petalsRotation - petalsRotationLast;
        petalsRotationLast = petalsRotation;
        if (petalsRotationDelta != 0.0 )
        {
            print("Moving! " + petalsRotationDelta + " " + soundMultiplier);
            soundManager.FlowerMove(0, petalsRotationDelta * soundMultiplier);
        }
        if (petalsRotationDelta > petalsRotationMaxDelta)
        {
            petalsRotationMaxDelta = petalsRotationDelta;
        }
        if (petalsRotationDelta < petalsRotationMinDelta)
        {
            petalsRotationMinDelta = petalsRotationDelta;
        }
    }
}
