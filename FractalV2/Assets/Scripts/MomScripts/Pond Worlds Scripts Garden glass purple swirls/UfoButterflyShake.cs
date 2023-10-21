using UnityEngine;

public class UfoButterflyShake : MonoBehaviour
{
    [SerializeField] private float delayStart = 2f;
    float timer;
    private Animator ufoButterflyShake;
    // Start is called before the first frame update
    void Start()
    {
        // delay the shake
        Invoke("Update", delayStart);
        
        ufoButterflyShake = GetComponent<Animator>();
          
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayStart)
        {
            ufoButterflyShake.SetBool("shake", true);
            return;
        }
    }
}
