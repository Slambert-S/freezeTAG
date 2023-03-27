using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_TaskRotate360 : Node
{
    private Transform _transform;
    private scriptManager _scriptManager;
    public atwo_seeker_TaskRotate360(Transform transform, scriptManager scriptManager)
    {
        _transform = transform;
        _scriptManager = scriptManager;

    }
    public override NodeState Evaluate()
    {
        bool isLokingAround = (bool)GetData("isLookingAround");
        if (isLokingAround == false)
        {
           // Debug.Log("In roatetion");
            _rootNode.SetData("lookingStep", 1);

            _rootNode.SetData("isLookingAround", true);

            Vector3 dirrectionToLookAt = _transform.right;
            _rootNode.SetData("lookRirection", dirrectionToLookAt);
            state = NodeState.RUNNING;
            return state;
        }
        else
        {

            int rotationStep = (int)GetData("lookingStep");
            Vector3 lookDirection = (Vector3)GetData("lookRirection");
            lookDirection *= 2;
            if (rotationStep >= 1 && rotationStep < 5)
            {
                // Debug.Log("in rotation potato one");
                if (Vector3.Dot(_transform.forward, lookDirection.normalized) < 0.99)
                {
                    //Debug.Log("in rotation potato Two");
                    Quaternion targetRotation = Quaternion.LookRotation(lookDirection);

                    // Smoothly rotate towards the target point.
                    _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, 3f * Time.deltaTime);
                    _scriptManager.behaviourAgent.Velocity = Vector3.zero;
                    state = NodeState.RUNNING;
                    return state;

                }
                else
                {
                    rotationStep++;
                    _rootNode.SetData("lookingStep", rotationStep);
                    _rootNode.SetData("lookRirection", _transform.right);
                    state = NodeState.RUNNING;
                    return state;

                }

            }
            else
            {

                _rootNode.SetData("lookingStep", 6);
                _rootNode.SetData("isLookingAround", false);
                _rootNode.SetData("awayFromWaypoint", true);
                _rootNode.SetData("stopPatrol", false);
                _rootNode.SetData("seeTargetAgent", false);
                _rootNode.ClearData("targetNode");
                _rootNode.SetData("isInvestigating", false);
                _scriptManager.variableReference.nodeTrigger = null;
                _rootNode.SetData("RequestBackup", true);





                //Debug.Log("In failure");
                state = NodeState.FAILURE;
                return state;
            }
        }
    }
}
