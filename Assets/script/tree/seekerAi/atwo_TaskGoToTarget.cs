using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_TaskGoToTarget : Node
{
    private Transform _transform;
    private seek _seekScript;
    private bhv_strg_agent _behaviourScript;
    private scriptManager _scritRef;

    public atwo_TaskGoToTarget(scriptManager managerScript)
    {
        
        _scritRef = managerScript;
        _behaviourScript = _scritRef.behaviourAgent;
        _seekScript = _scritRef.seekScript;
    }

    public override NodeState Evaluate()
    {
        object nearNode = GetData("nearNode");
        if (nearNode != null && (bool)nearNode == true)
        {
            //Debug.Log("patate");
            state = NodeState.SUCCESS;
            return state;
        }
        node target = (node)GetData("nextNode");

        if(target == null)
        {
            _rootNode.ClearData("targetNode");
            _rootNode.ClearData("closestNode");
            state = NodeState.FAILURE;
            return state;
        }
       
        
        if (_scritRef.seekScript != null)
        {
            // Debug.Log(target.gameObject);
            //Debug.Log("potatp + " + target);
            Vector3 steering = _seekScript.beaviourSeek(4, target.transform.position, _behaviourScript, false);
            _behaviourScript.moveAgent(steering);
            state = NodeState.RUNNING;
            return state;
        }
        
        return state;
    }
}
