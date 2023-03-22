using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_CheckArrivedAtNode : Node
{

    // Start is called before the first frame update
    private Transform _transform;
    private scriptManager _scriptManager;
    // Start is called before the first frame update
    public atwo_CheckArrivedAtNode(Transform transform, scriptManager scriptManager)
    {
        _transform = transform;
        _scriptManager = scriptManager;

    }
    public override NodeState Evaluate()
    {
        node targetNode = (node)GetData("nextNode");
        if (targetNode == null)
        {
      
            state = NodeState.FAILURE;
            return state;
        }
        else
        {
            //Debug.Log(" in check arrived at node : "+(node)GetData("nextNode"));
            if(Vector3.Distance(_transform.position, targetNode.transform.position) <= 1.0f)
            {
               // Debug.Log("near the node");
                _rootNode.SetData("closestNode", targetNode);
                _scriptManager.variableReference.lastNode = targetNode;
                state = NodeState.SUCCESS;
                return state;
            }
            else
            {
                //Debug.Log("Near node failure");
                state = NodeState.FAILURE;

                return state;

            }
        }


    }
}
