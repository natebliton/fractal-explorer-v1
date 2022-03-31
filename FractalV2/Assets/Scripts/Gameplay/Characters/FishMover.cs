using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishMover : MonoBehaviour
{
    private MoveToCommand _currentCommand;
    private Queue<MoveToCommand> _commands = new Queue<MoveToCommand>();

    private Rigidbody2D _rb2D;

    private Vector2 _nextDestination;
    private bool _atTarget = true;
    private float _closeEnough = 0.5f;

    private bool _traveling = false;

    private float _initialTargetDistance = 0.0f;

    private float _acceleration = 0.005f;
    private float _maxSpeed = 0.03f;
    private Vector2 _currentSpeed = new Vector2(0,0);

    private Fish fishScript;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        fishScript = GetComponent<Fish>();
    }

    // Update is called once per frame
    void Update()
    {
        ListenForCommands();
        ProcessCommands();
    }

    private void ProcessCommands() 
    {

        if ( _currentCommand != null && _currentCommand.IsFinished == false)
            return;

        if (_commands.Count <= 0)
            return;

        print("has non-null command! there are " + _commands.Count);
        if(fishScript.Oriented) {
            _currentCommand = _commands.Dequeue();
            _currentCommand.Execute();
            print("moving!");
        }
    }

    private void ListenForCommands() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            print("clicked");
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         //   if(Physics2D.Raycast(ray, out var hitInfo)) {
             
            MoveToCommand moveToCommand = new MoveToCommand(new Vector2(position.x, position.y), this);
            _commands.Enqueue(moveToCommand);
           // }
        }
    }

    /// <summary>
    /// returns current speed of character
    /// </summary>
    /// <value></value>
    public Vector2 CurrentSpeed { 
        get{ return _currentSpeed; }
    }
    

    /// <summary>
    /// Sets target destination
    /// </summary>
    /// <param name="destination"></param>
    public void SetTarget(Vector2 destination){
        _nextDestination = destination;
        _atTarget = false;
        StopCoroutine("Movement2");
        StartCoroutine("Movement2", destination);
        print("moving!" + destination);
    }

    /// <summary>
    /// Returns whether the character has reached its destination
    /// </summary>
    /// <value></value>
    public bool AtTarget {
        get { return _atTarget; }
        set { _atTarget = value; }
    }


    /// <summary>
    /// Coroutine to move the Bus towards its target destination
    /// speed capped by busMaxSpeed, with visible property BusMaxSpeed
    /// </summary>
    IEnumerator Movement2(Vector2 target)
    {
        _traveling = true;
        Vector2 initialPosition = transform.position;
        _initialTargetDistance = Vector2.Distance(initialPosition, target);
        float speed = 0;
        float progress = 0;

        //while (Vector2.Distance(transform.position, target) > 0.05f)
        while (_traveling)
        {
            //progress = ProgressToCity;

           // speed = MovementSpeed * Time.deltaTime;
            if (progress < _initialTargetDistance / 2)
            {
                speed += _acceleration;
                if(speed > _maxSpeed)
                {
                    speed = _maxSpeed;
                }
            }

            //transform.position = Vector2.Lerp(transform.position, target, MovementSpeed * Time.deltaTime);
            Vector3 nextPosition = Vector2.Lerp(transform.position, target, speed);
            _currentSpeed = transform.position - nextPosition;
            transform.position = nextPosition;

            if(Vector2.Distance(transform.position, target) < _closeEnough) {
                _traveling = false;
            }
            //Vector2.Angle(transform.position, target)
            yield return null;
        }

        print("target reached");

        _traveling = false;
        _atTarget = true;

    }

    IEnumerator Movement3(Vector2 target)
    {
        _traveling = true;
        Vector2 initialPosition = transform.position;
        _initialTargetDistance = Vector2.Distance(initialPosition, target);
        float speed = 0;
        float progress = 0;

        while (_traveling)
        {
            //progress = ProgressToCity;

            speed = calculateSpeed(progress, _initialTargetDistance);
            print("Speed is " + speed);
            //transform.position = Vector2.Lerp(transform.position, target, MovementSpeed * Time.deltaTime);
            float angle = Vector2.Angle(transform.position, target);
            //transform.position = Vector2.MoveTowards(transform.position, target, speed);
            transform.position = Vector2.Lerp(transform.position, target, speed);
            //Vector2.Angle(transform.position, target)
            yield return null;
        }

        print("target reached");

        _traveling = false;

    }

    /// <summary>
    /// Calculates bus speed
    /// </summary>
    /// <param name="currentDistance">current distance to target</param>
    /// <param name="maxDistance">initial max distance to target</param>
    /// <returns></returns>
    float calculateSpeed(float currentDistance, float maxDistance)
    {
        float accelDistance = maxDistance / 10f;

        if (currentDistance < accelDistance)
        {
            return (currentDistance / accelDistance) * _maxSpeed;
        }
        else if (maxDistance - currentDistance < accelDistance)
        {
            return _maxSpeed - (_maxSpeed * (maxDistance - currentDistance));
        }
        else
        {
            return _maxSpeed;
        }
    }
}
