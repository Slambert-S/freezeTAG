using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;


public class atwo_TaskRotateTowardPoint : Node
{
    // Start is called before the first frame update
    private Transform _transform;
    private scriptManager _scriptManager;
    public atwo_TaskRotateTowardPoint(Transform transform, scriptManager scrpManager)
    {
        _transform = transform;
        _scriptManager = scrpManager;

    }
    // Update is called once per frame
    public override NodeState Evaluate()
    {
        node nextNode = (node)GetData("nextNode");

        if(nextNode == null)
        {
            nextNode = (node)GetData("nextPatrolPoint");
        }
        Vector3 facingVector = nextNode.transform.position - _transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(facingVector);

        // Smoothly rotate towards the target point.
        _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, 3f * Time.deltaTime);
        //_scriptManager.behaviourAgent.Velocity = Vector3.zero;

        state = NodeState.RUNNING;
        return state;
    }
}
