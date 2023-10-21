using UnityEngine;

public class OwlsFlyingUp : MonoBehaviour
{
    [SerializeField] private float delayStart = 2f;
    [SerializeField] private float delayFly = 2f;
    float timer;
    private Animator sitToFlyUp;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Update", delayStart);
        // flyUp parameter in animator = true to switch to landing animation
        sitToFlyUp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayStart)
        {
            sitToFlyUp.SetBool("hop", true);
        }
        if (timer > delayFly)
        {
            sitToFlyUp.SetBool("flyUp", true);
        }
    }
}
