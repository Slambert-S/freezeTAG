using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_checkNodeTrigger : Node
{
    // Start is called before the first frame update
    private scriptManager _scriptReference;
    public atwo_seeker_checkNodeTrigger( scriptManager scriptReference)
    {
        _scriptReference = scriptReference;
    }
    public override NodeState Evaluate()
    {
        node nodeTrigger = _scriptReference.variableReference.nodeTrigger;

        if(nodeTrigger != null)
        {
            object isInvestigating = GetData("isInvestigating");

            if (isInvestigating == null || (bool)isInvestigating == false)
            {
                state = NodeState.SUCCESS;
                return state;
            }
            
        }
        state = NodeState.FAILURE;
        return state;
    }
}
