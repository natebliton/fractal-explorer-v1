using System.Collections;
using UnityEngine;

public class WaypointFollowerButterflyScale : MonoBehaviour
{

    public GameObject butterfly;

    [SerializeField]
    private Transform[] routes;

    [SerializeField] private float angleOffset = 90f;

    private int routeToGo;

    private float tParam;

    private float tPrevious;

    private Vector2 catPosition;

    private Vector2 catPrevious;

    [SerializeField] private float speedModifier = 0.2f;

    private float timer;
    

    private bool coroutineAllowed;
    

    // Set speed of motion in Unity 
    // [SerializeField] private float speed = 2f;
    [SerializeField] private float delayStart = 2f;
    [SerializeField] private float flyOff = 0.2f;
    [SerializeField] private float scaleStart = 0.1f;
    [SerializeField] private float scaleFinish = 0.5f;
    [SerializeField] private float scaleIncrement = 0.05f;

    
    private Animator fly;
    Vector3 tempScale;

    private void Start()
    {

        butterfly.gameObject.SetActive(true);

        // delay the butterfly launch
        Invoke("Update", delayStart);
        // fly parameter in animator = true to switch to flying animation
        fly = GetComponent<Animator>();
        // fly.SetBool("fly", false);
        // start owl at reduced size
        tempScale.x = scaleStart;
        tempScale.y = scaleStart;
        transform.localScale = tempScale;
        coroutineAllowed = true;

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delayStart)
        {
            butterfly.gameObject.SetActive(true);

            ScaleUpButterfly();
        }
        if (timer > delayStart + flyOff)
        {
            fly.SetBool("fly", true);
            StartRoute();
        }
        void StartRoute()
        {
            if (coroutineAllowed)
                StartCoroutine(GoByTheRoute(routeToGo));
        }

        IEnumerator GoByTheRoute(int routeNumber)
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

            // Stop after counting down routes
            if (routeToGo <= routes.Length - 1)
                coroutineAllowed = true;


        }

        void ScaleUpButterfly()
        {
            tempScale = transform.localScale;
            tempScale.x += scaleIncrement;
            tempScale.y += scaleIncrement;
            if (tempScale.x >= scaleFinish - scaleIncrement)
                tempScale.x = scaleFinish;
            if (tempScale.y >= scaleFinish - scaleIncrement)
                tempScale.y = scaleFinish;
            transform.localScale = tempScale;
            if (tempScale.x >= scaleFinish)
                return;
        }

    }

}

