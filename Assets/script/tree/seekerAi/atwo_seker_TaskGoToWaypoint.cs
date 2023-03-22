using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seker_TaskGoToWaypoint : Node
{
    private Transform _transform;
    private scriptManager _scriptRef;

    public atwo_seker_TaskGoToWaypoint(scriptManager scriptRef)
    {
        _scriptRef = scriptRef;
        
    }

    public override NodeState Evaluate()
    {

        node target = (node)GetData("nextPatrolPoint");
        // Debug.Log("potatp");
        if (_scriptRef.seekScript != null)
        {
           // Debug.Log("Potato");

            Vector3 steering = _scriptRef.seekScript.beaviourSeek(4, target.transform.position, _scriptRef.behaviourAgent, false);
            _scriptRef.behaviourAgent.moveAgent(steering);
            state = NodeState.RUNNING;
            return state;
        }

        
        state = NodeState.SUCCESS;
        return state;
    }
}
