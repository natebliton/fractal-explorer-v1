using UnityEngine;

public class OwlShuffleLookForward : MonoBehaviour
{
    [SerializeField] private float lookForwardTime = 10f;
    float timer;
    private Animator lookForward;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Update", lookForwardTime);
        lookForward = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lookForwardTime)
        {
            lookForward.SetBool("lookForward", true);

            
        }
    }
}
