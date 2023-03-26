using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_TaskPursue : Node
{
    // Start is called before the first frame update
    private scriptManager _scriptReference;
    private Transform _transform;
    public atwo_seeker_TaskPursue(Transform transform, scriptManager scriptReference)
    {
        _transform = transform;
        _scriptReference = scriptReference;

    }
    public override NodeState Evaluate()
    {
        bhv_strg_agent tagTarget = (bhv_strg_agent)GetData("tagTarget");
        if(tagTarget == null)
        {
            //Debug.Log("tag target is null");
            state = NodeState.FAILURE;
            return state;
        }
        else
        {
           // Debug.Log("In tag target not null ");
            Vector3 targetPosition = tagTarget.transform.position;
            Vector3 steering = _scriptReference.seekScript.beaviourSeek(4, targetPosition, _scriptReference.behaviourAgent, false);
            _scriptReference.behaviourAgent.pursueTarget(steering);
            
            float distance = Vector3.Distance(_transform.position, targetPosition);
            if (distance <= 0.3f)
            {
                tagTarget.GetComponent<atwo_evader_getCought>().getCought();
                _rootNode.ClearData("tagTarget");
                state = NodeState.FAILURE;
                return state;
            }
            state = NodeState.RUNNING;
            return state;
        }
    }
}
