using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_evader_CheckIfenemyClose : Node
{
    private Transform _transform;
    private scriptManager _scriptReference;

    public atwo_evader_CheckIfenemyClose(Transform transform, scriptManager scriptReference)
    {
         _transform = transform;
        _scriptReference = scriptReference;

    }

    public override NodeState Evaluate()
    {
        bool spotedEnemy = _scriptReference.detectSeekerScript.checkAroundforSeeker();
        if (spotedEnemy)
        {
            return NodeState.FAILURE;
        }

        return NodeState.FAILURE;
    }
}
