using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCommand : Command
{
    private readonly Vector2 _destination;
    //private readonly NavMeshAgent _agent;
    private FishMover fishMover;

    public MoveToCommand(Vector2 destination, FishMover moverScript) 
    {
        _destination = destination;
        fishMover = moverScript;
    }

    public override void Execute()
    {
        fishMover.SetTarget(_destination);
        fishMover.AtTarget = false;
        //_agent.SetDestination(_destination);
    }

    public override bool IsFinished
    {
        get 
        {
            return fishMover.AtTarget;
        }
    } 
}
