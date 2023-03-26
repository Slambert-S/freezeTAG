using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_evader_CheckWandering : Node
{
    public override NodeState Evaluate()
    {
        object wandering = GetData("wandering");

        if (wandering == null || (bool)wandering == true)
        {
            _rootNode.SetData("nearNode",false);
            state = NodeState.SUCCESS;
            return state;
        };

        state = NodeState.FAILURE;
        return state;

        
    }
}
