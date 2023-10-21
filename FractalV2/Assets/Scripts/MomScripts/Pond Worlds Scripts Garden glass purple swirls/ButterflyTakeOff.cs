using System.Collections;
using UnityEngine;

public class ButterflyTakeOff : MonoBehaviour
{
    // from Alexander Zotof Youtube Unity Tutorial Make a game object move along bezier curve
    // following a bezier curve that was set up with Route.cs
    [SerializeField] private Transform[] routes;

    [SerializeField] private float angleOffset = 90f;

    private int routeToGo;

    private float tParam;

    private float tPrevious;

    private Vector2 catPosition;

    private Vector2 catPrevious;

    [SerializeField] private float speedModifier = 0.2f;

    private float timer;

    [SerializeField] private float delayStart = 2f;

    private bool coroutineAllowed;

    private Animator flyToLand;

    // Start is called before the first frame update
    void Start()
    {

        // connect with animator, butterfly starts out resting in animator
        flyToLand = GetComponent<Animator>();
        
        // delay the butterfly launch
        Invoke("Update", delayStart);

        routeToGo = 0;
        tParam = 0f;
        tPrevious = 0f;
        coroutineAllowed = true;
        timer += Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayStart)
        {
            // On take off switch to side-flying animation for 1st route
            if (routeToGo == 0)
                flyToLand.SetBool("TakeOff", true);
            StartRoute();
        }
        void StartRoute()
        {
            if (coroutineAllowed)
                StartCoroutine(GoByTheRoute(routeToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;


        while (tParam < 1)
        {

            tPrevious = tParam;
            tParam += Time.deltaTime * speedModifier;

            catPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            catPrevious = Mathf.Pow(1 - tPrevious, 3) * p0 +
                3 * Mathf.Pow(1 - tPrevious, 2) * tPrevious * p1 +
                3 * (1 - tPrevious) * Mathf.Pow(tPrevious, 2) * p2 +
                Mathf.Pow(tPrevious, 3) * p3;

            transform.position = catPosition;


            AdjustAngle();
            void AdjustAngle()
            {
                Vector2 dir = catPosition - catPrevious;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                angle = angle - angleOffset;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;

        routeToGo += 1;
        
        // Turn the butterfly and fly off on second route
        if (routeToGo == 1)
        {
            flyToLand.SetBool("Turn", true);
            coroutineAllowed = true;
        }
        if (routeToGo <= routes.Length - 1)
            coroutineAllowed = true;
        
        if (routeToGo > routes.Length - 1)
            coroutineAllowed = false;
        

        yield return new WaitForEndOfFrame();


    }

}
