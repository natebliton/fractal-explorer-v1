using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    LibPdInstance libPdInstance;

    [SerializeField]
    private UISounds clickSound = UISounds.Click2;

    [SerializeField]
    private UISounds alarmSound = UISounds.AlarmBell;

    // Start is called before the first frame update
    void Start()
    {
        libPdInstance = transform.GetChild(0).GetComponent<LibPdInstance>();
    }

    public void PlayClick()
    {
        print("playing click sound");

        libPdInstance.SendBang(clickSound.Value);
    }

    public void PlayError()
    {
        print("playing alarm sound");

        libPdInstance.SendBang(alarmSound.Value);
    }

    public void FlowerMove(int flowerNumber, float amount)
    {
        if (flowerNumber == 0)
        {
            libPdInstance.SendFloat("flowerMove0", amount);
        }
        if (flowerNumber == 1)
        {
            libPdInstance.SendFloat("flowerMove1", amount);
        }
    }
}
