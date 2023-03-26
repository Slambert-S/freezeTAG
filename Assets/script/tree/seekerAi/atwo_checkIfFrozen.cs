using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_checkIfFrozen : Node
{
    private scriptManager _scriptReference;
    public atwo_checkIfFrozen(scriptManager scriptReference)
    {
        _scriptReference = scriptReference;
    }
    public override NodeState Evaluate()
    {
        bool isFrozen = _scriptReference.variableReference.isFreesed;

        if(isFrozen == true)
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
