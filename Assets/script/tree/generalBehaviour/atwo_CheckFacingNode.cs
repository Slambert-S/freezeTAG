using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_CheckFacingNode : Node
{
    private Transform _transform;

    // Start is called before the first frame update
    public atwo_CheckFacingNode(Transform transform)
    {
        _transform = transform;

    }
    public override NodeState Evaluate()
    {
        node nextNode = (node)GetData("nextNode");

        if (nextNode != null)
        {
            //Check if we need to turn to face the node
            Vector3 facingVector = nextNode.transform.position - _transform.position;
            if (Vector3.Dot(_transform.forward, facingVector.normalized) < 0.99)
            {
                state = NodeState.SUCCESS;
                return state;
            }
            state = NodeState.FAILURE;
            return state;

        }

        nextNode = (node)GetData("nextPatrolPoint");

        if (nextNode != null)
        {
            int rotationStep = (int)GetData("lookingStep");
            if(rotationStep == 0)
            {
               // Debug.Log("Check facing node");
                Vector3 facingVector = nextNode.transform.position - _transform.position;
                if (Vector3.Dot(_transform.forward, facingVector.normalized) < 0.99)
                {
                    state = NodeState.SUCCESS;
                    return state;
                }
            }
            //Check if we need to turn to face the node
            
        }
        state = NodeState.FAILURE;
        return state;
    }
 }
