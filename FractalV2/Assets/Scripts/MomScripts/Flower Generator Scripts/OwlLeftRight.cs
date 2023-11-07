using System.Collections;
using UnityEngine;

public class OwlLeftRight : MonoBehaviour
{
    // from Alexander Zotof Youtube Unity Tutorial Make a game object move along bezier curve
    // following a bezier curve that was set up with Route.cs
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private int sweepsToGo;

    private float tParam;

    private float tPrevious;

    private Vector2 catPosition;

    private Vector2 catPrevious;

    [SerializeField] private float speedModifier = 0.2f;

    private float timer;

    [SerializeField] private float delayStart = 2f;
    [SerializeField] private float flyBackStart = 2f;
    [SerializeField] private int sweeps = 2;

    private bool coroutineAllowed;

    private Animator flyToLand;

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        tPrevious = 0f;
        coroutineAllowed = true;
        timer += Time.deltaTime;

        // connect with animator
        flyToLand = GetComponent<Animator>();
        // delay the launch
        Invoke("Update", delayStart);

    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > delayStart)
        {
            flyToLand.SetBool("flyLeft", true);
            if (sweepsToGo >= sweeps)
            {
                flyToLand.SetBool("flyLeft", false);
            }
            if (routeToGo == 0)
            {
                StartRouteLeft();
            }
        }
        void StartRouteLeft()
        {
            if (coroutineAllowed)
                StartCoroutine(GoByTheRouteLeft(routeToGo));
        }
        if (timer > flyBackStart)
        {
            flyToLand.SetBool("flyRight", true);
            if (routeToGo == 1)
            {
                StartRouteRight();
            }
        }
        void StartRouteRight()
        {
            if (coroutineAllowed)
                StartCoroutine(GoByTheRouteRight(routeToGo));
        }
    }

    private IEnumerator GoByTheRouteLeft(int routeNumber)
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

            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;

        // routeToGo += 1;
        flyToLand.SetBool("landLeft", true);
        // setting timer to zero puts delayStart between routes
        // timer = 0;
        if (routeToGo == 0)
        {
            routeToGo = 1;
            coroutineAllowed = true;
            flyToLand.SetBool("landRight", false);
            flyToLand.SetBool("flyRight", false);
            
        }
          

    }

    private IEnumerator GoByTheRouteRight(int routeNumber)
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

            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;

        // routeToGo += 1;
        flyToLand.SetBool("landRight", true);
        // setting timer to zero puts delayStart between routes
        // timer = 0;
        if (routeToGo == 1)
        {
            routeToGo = 0;
            timer = 0;
            coroutineAllowed = true;
            flyToLand.SetBool("landLeft", false);
            flyToLand.SetBool("flyLeft", false);
            sweepsToGo += 1;
            if (sweepsToGo >= sweeps)
            {
                coroutineAllowed = false;
                
            }

        }

    }

}
