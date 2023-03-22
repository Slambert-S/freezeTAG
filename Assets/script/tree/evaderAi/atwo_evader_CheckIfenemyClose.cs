using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_evader_CheckIfenemyClose : Node
{
    private Transform _transform;
    private scriptManager _scriptReference;
    private float _radius;

    public atwo_evader_CheckIfenemyClose(Transform transform, scriptManager scriptReference, float radius)
    {
         _transform = transform;
        _scriptReference = scriptReference;
        _radius = radius;

    }

    public override NodeState Evaluate()
    {


        
            List<Collider> spotedEnemy = _scriptReference.detectSeekerScript.checkAroundforSeeker(_radius);
            if (spotedEnemy.Count > 0)
            {
                _rootNode.SetData("listEnemy", spotedEnemy);

                return NodeState.SUCCESS;
            }
            else
            {
                _rootNode.SetData("needEvadePath", false);
            }

            return NodeState.FAILURE;
        
        
        return state;
    }
}
