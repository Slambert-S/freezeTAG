using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_seekerLookLR : Node
{
    private Transform _transform;
    private scriptManager _scriptManager;

    // Start is called before the first frame update
    public atwo_seekerLookLR(Transform transform, scriptManager scriptManager)
    {
        _transform = transform;
        _scriptManager = scriptManager;

    }

    public override NodeState Evaluate()
    {
        bool isLokingAround = (bool)GetData("isLookingAround");
        if (isLokingAround == false)
        {
            //Debug.Log("In roatetion");
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
            if (rotationStep == 1)
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
                    _rootNode.SetData("lookRirection", lookDirection * -1);
                    state = NodeState.RUNNING;
                    return state;

                }
               
            }
            else if (rotationStep == 2)
            {
                //Debug.Log("in rotation potato three");
                if (Vector3.Dot(_transform.forward, lookDirection.normalized) < 0.99)
                {
                   // Debug.Log("in rotation potato four");
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
                    _rootNode.SetData("isLookingAround", false);
                    state = NodeState.RUNNING;
                    return state;

                }
                

            }
            else
            {
                Debug.Log("In failure");
                state = NodeState.FAILURE;
                return state;

            }


        }
    }
}
