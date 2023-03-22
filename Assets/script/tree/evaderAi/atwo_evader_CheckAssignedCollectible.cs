using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_evader_CheckAssignedCollectible : Node
{


    public override NodeState Evaluate()
    {
        object collectible = GetData("collectible");
        if (collectible != null)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;

    }
}

