using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_resetToNearestNode : Node
{
    private Transform _transform;

    private scriptManager _scriptReference;
    public atwo_resetToNearestNode(Transform transform, scriptManager scriptReference)
    {
        _transform = transform;
        _scriptReference = scriptReference;
    }

    public override NodeState Evaluate()
    {
        node closestNode = _scriptReference.variableReference.debugStuckNode;
        if (closestNode == null)
        {
            closestNode = findClosestNode.getClosestNode(_transform.position);
            _scriptReference.variableReference.debugStuckNode = closestNode;
        }

        float distance = Vector3.Distance(_transform.position, closestNode.transform.position);

        Vector3 steering = _scriptReference.seekScript.beaviourSeek(4, closestNode.transform.position, _scriptReference.behaviourAgent, false);
        _scriptReference.behaviourAgent.moveAgent(steering);
        state = NodeState.SUCCESS;
        return state;




    }
}
