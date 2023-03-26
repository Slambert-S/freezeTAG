using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_TaskResetPathTraking : Node
{
    private scriptManager _scriptReference;
    private Transform _transform;
    public atwo_seeker_TaskResetPathTraking(scriptManager scriptReference, Transform transform)
    {
        _scriptReference = scriptReference;
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        node closestNode = _scriptReference.variableReference.debugStuckNode;
        float distance = Vector3.Distance(_transform.position, closestNode.transform.position);

        if(distance <= 0.3f)
        {
            _rootNode.ClearData("targetNode");
            _rootNode.ClearData("closestNode");
            _rootNode.SetData("awayFromWaypoint", true);
            _scriptReference.variableReference.isStuck = false;
            state = NodeState.FAILURE;
            return state;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}
