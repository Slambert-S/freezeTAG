using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_evader_TaskMoveToCollectCollectible : Node
{
    private Transform _transform;
    private scriptManager _scriptReference;
    public atwo_evader_TaskMoveToCollectCollectible(Transform transform, scriptManager scriptreference)
    {
        _transform = transform;
        _scriptReference = scriptreference;
    }

    public override NodeState Evaluate()
    {
        GameObject collectible = (GameObject)GetData("collectible");

        if (Vector3.Distance(_transform.position, collectible.transform.position) >= 0.5f)
        {
            Vector3 steering = _scriptReference.seekScript.beaviourSeek(2, collectible.transform.position, _scriptReference.behaviourAgent, false);
            _scriptReference.behaviourAgent.pursueTarget(steering);
            _rootNode.SetData("nearNode", true);
            Debug.Log(Vector3.Distance(_transform.position, collectible.transform.position));
            state = NodeState.RUNNING;
            return state;

        }
        else
        {
            _rootNode.SetData("collectible", null);
            
            Debug.Log("toutch the collectible");
            _rootNode.SetData("nearNode", false);
            state = NodeState.FAILURE;
            return state;
        }
    }


}
