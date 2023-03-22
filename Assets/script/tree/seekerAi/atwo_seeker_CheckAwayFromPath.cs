using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_CheckAwayFromPath : Node
{
    public override NodeState Evaluate()
    {
        object t = GetData("awayFromWaypoint");
        if (t != null)
        {
            if ((bool)t == true)
            {
                state = NodeState.SUCCESS;
                return state;
            }
        }

        state = NodeState.FAILURE;
        return state;

    }
}
