using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_TaskGetPathToPatrolPoint : Node
{
    private Transform _transform;
    private node _debugTarget;
    private List<node> _pathFindingList = new List<node>();
    // Start is called before the first frame update
    public atwo_seeker_TaskGetPathToPatrolPoint(Transform transform, List<node> pathFindingList, node debugTarget)
    {
        _transform = transform;
        _pathFindingList = pathFindingList;
        _debugTarget = debugTarget;
    }
    public override NodeState Evaluate()
    {

        node TargetNode = (node)GetData("lastPatrolPoint");

        if (TargetNode != null)
        {

            _rootNode.SetData("targetNode", TargetNode);
            node nearestNode = (node)GetData("closestNode");
            _pathFindingList = GameObject.Find("Node List").GetComponent<pathFinding>().findPath(nearestNode, TargetNode);
            _rootNode.SetData("nextNode", _pathFindingList[0]);
            _rootNode.SetData("pathFindingList", _pathFindingList);
            Debug.Log("afterGettingthe List");
            state = NodeState.SUCCESS;
            return state;

        }
        else
        {
            state = NodeState.FAILURE;
            return state;
        }

    }

}
