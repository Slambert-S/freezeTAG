using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_TaskGoBackToPatrol : Node
{
    public override NodeState Evaluate()
    {
        _rootNode.SetData("awayFromWaypoint", false);
        _rootNode.SetData("lookingStep", 0);
        _rootNode.ClearData("nextNode");
        _rootNode.ClearData("targetNode");
        //_rootNode.SetData("")
        state = NodeState.SUCCESS;
        return state;
    }
}
