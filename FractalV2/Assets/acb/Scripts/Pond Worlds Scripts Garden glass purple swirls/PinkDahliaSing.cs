using UnityEngine;

public class PinkDahliaSing : MonoBehaviour
{
    [SerializeField] private float singTime = 2f;
    float timer;
    private Animator dahliaSing;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Update", singTime);
        dahliaSing = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > singTime)
        {
            dahliaSing.SetBool("move", true);

        }
    }
}
