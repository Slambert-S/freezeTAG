using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_seeker_TaskSetUpInvestigateCollectible : Node
{
    private scriptManager _scriptReference;
    public atwo_seeker_TaskSetUpInvestigateCollectible(scriptManager scriptReference)
    {
        _scriptReference = scriptReference;
    }

    public override NodeState Evaluate()
    {
        node nodeTrigger = _scriptReference.variableReference.nodeTrigger;

        _rootNode.SetData("targetLastKnownNode", nodeTrigger);
        _rootNode.SetData("stopPatrol", true);
        _rootNode.SetData("seeTargetAgent", false);
        _rootNode.ClearData("targetNode");
        _rootNode.SetData("isInvestigating", true);
        Debug.Log("Past the set up");
        state = NodeState.SUCCESS;
        return state;
    }

}
