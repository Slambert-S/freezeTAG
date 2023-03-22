using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform _transform;

    public TaskGoToTarget(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        //Note : retrive the object related to the key "target" in the root node
        Transform target = (Transform)GetData("target");

        // Note : the you move toward this specific note 
        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            //TODO:Move towards target
            _transform.position =Vector3.MoveTowards(_transform.position, target.position, GuardBT.speed * Time.deltaTime);
            
            _transform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }

}
