using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_CheckIfStuck : Node
{
    private scriptManager _scriptReference;
    public atwo_CheckIfStuck(scriptManager scriptReference)
    {
        _scriptReference = scriptReference;
    }
    public override NodeState Evaluate()
    {
        bool isStuck = _scriptReference.variableReference.isStuck;

        if (isStuck)
        {
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
