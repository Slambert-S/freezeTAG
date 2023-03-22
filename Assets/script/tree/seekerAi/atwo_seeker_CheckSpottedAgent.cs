using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_CheckSpottedAgent : Node
{
    private scriptManager _scriptReference;

    public atwo_seeker_CheckSpottedAgent(scriptManager scriptReference)
    {
        _scriptReference = scriptReference;

    }

    // Start is called before the first frame update
    public override NodeState Evaluate()
    {
        // Debug.Log("inTestRaycast");
        //if (behaviourValue == null)
       // {
        //    return false;
        //}

        
        float speedDependentConeAngle = (_scriptReference.behaviourAgent.Velocity.magnitude / _scriptReference.behaviourAgent.maxSpeed) * 100;

        speedDependentConeAngle = 100 - speedDependentConeAngle;

        if (speedDependentConeAngle < 16)
        {
            speedDependentConeAngle = 16;
        }


        bool spottedEnemy = _scriptReference.coneOfView.checkInConeOfView(speedDependentConeAngle);

        if (spottedEnemy)
        {
            _rootNode.SetData("seeTargetAgent", _scriptReference.variableReference.seeTargetAgent);
            _rootNode.SetData("tagTarget", _scriptReference.variableReference.tagTarget);
            _rootNode.SetData("targetLastKnownNode", _scriptReference.variableReference.targetLastKnownNode);
            //_rootNode.SetData("seeTargetAgent", false);
            _rootNode.SetData("stopPatrol", true);

            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILURE;
        return state;
    }
}
