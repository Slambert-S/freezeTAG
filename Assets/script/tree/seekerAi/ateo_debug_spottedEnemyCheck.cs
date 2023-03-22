using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class ateo_debug_spottedEnemyCheck : Node
{
    public ateo_debug_spottedEnemyCheck()
    {
        
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

        state = NodeState.FAILURE;
        return state;
    }
}
