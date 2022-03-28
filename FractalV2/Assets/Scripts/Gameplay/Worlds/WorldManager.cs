using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    float playerScale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Transform>().localScale = new Vector3(playerScale,playerScale,1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
