using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MoveGems : MonoBehaviour
{
    public Transform grabDetect;
    private RaycastHit2D grabGem;
    public Transform gemHolder;
    public float rayDist;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, transform.right, rayDist);
        
        //if (grabCheck.collider == null)
        //    { Debug.Log("grabCheck is null"); }
        if (grabCheck.collider != null && grabCheck.collider.tag == "Gem") 
        {
            
               // {
                // Debug.Log("Gem hit detected");
                // grabbedObject = grabCheck.collider.gameObject;
                grabCheck.collider.gameObject.transform.parent = gemHolder;
                grabCheck.collider.gameObject.transform.position = gemHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabGem = grabCheck;

                // }
        
        }
        if (grabCheck.collider != null && grabCheck.collider.tag == "HoardRoof")
        {
            // Debug.Log("HoardRoof hit detected");
            grabGem.collider.gameObject.transform.parent = null;
            // grabGem.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            
        }

    }
    
}
