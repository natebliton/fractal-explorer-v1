using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{

    [SerializeField]
    GameObject water1;

    [SerializeField]
    GameObject water2;

    [SerializeField]
    GameObject water3;

    [SerializeField]
    GameObject water4;

    [SerializeField]
    GameObject water5;

    [SerializeField]
    GameObject water6;

    [SerializeField]
    GameObject water7;

    [SerializeField]
    GameObject water8;

    [SerializeField]
    GameObject water9;

    GameObject[] waters;

    Camera mainCamera;
    GameObject waterManager;


    // Start is called before the first frame update
    void Start()
    {
        waters = new GameObject[9];
        waters[0] = water1;
        waters[1] = water2;
        waters[2] = water3;
        waters[3] = water4;
        waters[4] = water5;
        waters[5] = water6;
        waters[6] = water7;
        waters[7] = water8;
        waters[8] = water9;

        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
//if(waters[0].transform.position.x + waterManager.transform.position.x)
   //     print("water0 " + waters[0].transform.position.y);
      //  print(mainCamera.transform.position.x + " " + mainCamera.transform.position.y);

        for(int i = 0; i < waters.Length; i++) {
            if(waters[i].transform.position.x - mainCamera.transform.position.x < -15)
            {
                waters[i].transform.position = new Vector3(
                    waters[i].transform.position.x + 30,
                    waters[i].transform.position.y,
                    waters[i].transform.position.z);
            } else
            if(waters[i].transform.position.x - mainCamera.transform.position.x > 15)
            {
                waters[i].transform.position = new Vector3(
                    waters[i].transform.position.x - 30,
                    waters[i].transform.position.y,
                    waters[i].transform.position.z);
            }
        

            if(waters[i].transform.position.y - mainCamera.transform.position.y < -15)
            {
                waters[i].transform.position = new Vector3(
                    waters[i].transform.position.x,
                    waters[i].transform.position.y + 30,
                    waters[i].transform.position.z);
            } else
            if(waters[i].transform.position.y - mainCamera.transform.position.y > 15)
            {
                waters[i].transform.position = new Vector3(
                    waters[i].transform.position.x,
                    waters[i].transform.position.y - 30,
                    waters[i].transform.position.z);
            }
        }
    }
}
