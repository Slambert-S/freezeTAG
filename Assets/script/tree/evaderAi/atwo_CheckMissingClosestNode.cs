using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_CheckMissingClosestNode : Node
{
    private Transform _transform;
    // Start is called before the first frame update
    public atwo_CheckMissingClosestNode(Transform transform)
    {
        _transform = transform;
        
    }

    public override NodeState Evaluate()
    {
        object t = GetData("closestNode");
        //Debug.Log("potato + " + t);
        if (t == null)
        {
            //Need to set a new nearest node
            state = NodeState.SUCCESS;
           // Debug.Log("in check for closestNode");
            return state;
        }
        else
        {
            //Debug.Log("Fail Closest Node");
            //Already have a nearest node
            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.FAILURE;
        return state;

       
    }
}
