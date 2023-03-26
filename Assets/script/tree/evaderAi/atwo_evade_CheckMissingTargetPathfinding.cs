using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_evade_CheckMissingTargetPathfinding : Node
{
    // Start is called before the first frame update
    private Transform _transform;
    // Start is called before the first frame update
    public atwo_evade_CheckMissingTargetPathfinding(Transform transform)
    {
        _transform = transform;

    }

    public override NodeState Evaluate()
    {
        object t = GetData("targetNode");
        if (t == null)
        {
            //TODO (Change NONE to a correct type)
            //node nearestNode = findClosestNode.getClosestNode(_transform.position);
            //parent.parent.SetData("targetNode", nearestNode);
            object isInvestigating = GetData("isInvestigating");

            //if(isInvestigating == null || (bool) isInvestigating == false)
            //{
                state = NodeState.SUCCESS;
                return state;
            //}
    

        }
        else
        {
            state = NodeState.FAILURE;

            return state;
        }

        state = NodeState.FAILURE;
        return state;


    }

    // Update is called once per frame

}
