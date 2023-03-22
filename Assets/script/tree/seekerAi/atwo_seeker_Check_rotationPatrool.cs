using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_Check_rotationPatrool : Node
{
    // Start is called before the first frame update

    private Transform _transform;

    // Start is called before the first frame update
    public atwo_seeker_Check_rotationPatrool(Transform transform)
    {
        _transform = transform;

    }

    public override NodeState Evaluate()
    {
        bool isLokingAround = (bool)GetData("isLookingAround");
        if (isLokingAround == false)
        {
            Debug.Log("In roatetion");
            _rootNode.SetData("lookingStep", 1);

            _rootNode.SetData("isLookingAround", true);

            Vector3 dirrectionToLookAt = _transform.up;
            _rootNode.SetData("lookRirection", dirrectionToLookAt);
            state = NodeState.SUCCESS;
            return state;

        }
        else if(isLokingAround == false)
        {


        }

        state = NodeState.FAILURE;
        return state;
    }

}
