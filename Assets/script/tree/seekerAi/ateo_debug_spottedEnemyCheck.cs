using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class ateo_debug_spottedEnemyCheck : Node
{
    private scriptManager _scriptReference;
    public ateo_debug_spottedEnemyCheck(scriptManager scriptReference)
    {
        _scriptReference = scriptReference;
    }

    public override NodeState Evaluate()
    {
        object seePatrol = GetData("seeTargetAgent");
        object stopPatrol = GetData("stopPatrol");

        if(seePatrol != null && stopPatrol != null){

            if((bool)seePatrol == false && (bool)stopPatrol == true) {
               // Debug.Log("passed the chek to move toward the enemy");
                state = NodeState.RUNNING;
                return state;
            }
        }

        if(_scriptReference.variableReference.helpRequested == true)
        {
            _rootNode.SetData("seeTargetAgent", false);
            _rootNode.SetData("RequestBackup", false);
            _rootNode.SetData("stopPatrol", true);
            _rootNode.SetData("targetLastKnownNode", _scriptReference.variableReference.targetLastKnownNode);
            _scriptReference.variableReference.helpRequested = false;

            
            state = NodeState.RUNNING;
            return state;
        }
    

        state = NodeState.FAILURE;
        return state;
    }
}
