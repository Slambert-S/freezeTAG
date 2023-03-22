using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_TaskGetNearestNode : Node
{
    // Start is called before the first frame update
    private Transform _transform;
    private scriptManager _scriptReference; 
    public atwo_TaskGetNearestNode(Transform transform, scriptManager scriptManager)
    {
        _transform = transform;
        _scriptReference = scriptManager;

    }

    public override NodeState Evaluate()
    {
       
        node nearestNode = findClosestNode.getClosestNode(_transform.position);
       // Debug.Log("nearest node  :" + nearestNode);

        if(nearestNode != null)
        {

            _rootNode.SetData("closestNode", nearestNode);
            _scriptReference.variableReference.lastNode = nearestNode;
            //Debug.Log("in task for closestNode");
            state = NodeState.SUCCESS;
            return state;

        }
        else
        {
            state = NodeState.FAILURE;
            return state;
        }

    }
}