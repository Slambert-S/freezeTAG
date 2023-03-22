using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class CheckEnemyInFOVRange : Node
{
    private static int _enemyLayerMask = 1 << 6;

    private Transform _transform;
    private Animator _animator;

    public CheckEnemyInFOVRange(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        //Note : GetData check if the object associated with the string "target" is present in the dictionary of the node
        object t = GetData("target");
        if (t == null)
        {
            
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, GuardBT.fovRange, _enemyLayerMask);

            if (colliders.Length > 0)
            {
                //Note Set the data in the node as the object detected in the sphere colider and add it to the rootNode 
                parent.parent.SetData("target", colliders[0].transform);
                _animator.SetBool("Walking", true);

                //TODO (Change NONE to a correct type)
                state = NodeState.SUCCESS;
                return state;
            }


            //TODO (Change NONE to a correct type)
            state = NodeState.FAILURE;
            return state;
        }


        //TODO (Change NONE to a correct type)
        state = NodeState.SUCCESS;
        return state;
    }

}
