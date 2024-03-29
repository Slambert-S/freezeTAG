using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_TaskGetLastKnownNodeOfEvader : Node
{

    private Transform _transform;
    private node _debugTarget;
    private scriptManager _scriptReference;
    private List<node> _pathFindingList = new List<node>();
    // Start is called before the first frame update
    public atwo_seeker_TaskGetLastKnownNodeOfEvader(Transform transform, List<node> pathFindingList, node debugTarget,scriptManager scriptReference)
    {
        _transform = transform;
        _pathFindingList = pathFindingList;
        _debugTarget = debugTarget;
        _scriptReference = scriptReference;
    }
    public override NodeState Evaluate()
    {
        node TargetNode = (node)GetData("targetLastKnownNode");

        if (TargetNode != null)
        {
            List<node> forbidenNode = (List<node>)GetData("ForbidenNode");
            _rootNode.SetData("targetNode", TargetNode);
            node nearestNode = (node)GetData("closestNode");
            _pathFindingList = GameObject.Find("Node List").GetComponent<pathFinding>().findPath(nearestNode, TargetNode, forbidenNode);

            if (_pathFindingList.Count < 1)
            {
                _rootNode.ClearData("targetLastKnownNode");
                return NodeState.FAILURE;
            }
            _rootNode.SetData("nextNode", _pathFindingList[0]);
            _rootNode.SetData("pathFindingList", _pathFindingList);
            Debug.Log("afterGettingthe List");
            state = NodeState.SUCCESS;
            return state;

        }
        else
        {
            _rootNode.SetData("stopPatrol", false);
            _rootNode.SetData("awayFromWaypoint", true);
            _scriptReference.variableReference.isStuck = true;
            Debug.Log("Target last known node is null");
            state = NodeState.SUCCESS;
            return state;
        }
    }
}


