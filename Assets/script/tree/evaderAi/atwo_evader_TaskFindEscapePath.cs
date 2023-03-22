using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class atwo_evader_TaskFindEscapePath : Node
{
    private Transform _transform;
    private List<node> _pathFindingList;
    public atwo_evader_TaskFindEscapePath(Transform transform, List<node> pathFindingList)
    {
        _transform = transform;
        _pathFindingList = pathFindingList;

    }

    public override NodeState Evaluate()
    {
        
        Vector3 averagePosition = Vector3.zero;
        List<Collider> listOfEnemy = (List<Collider>)GetData("listEnemy");

        foreach (Collider seeker in listOfEnemy)
        {
            averagePosition += seeker.transform.position;
        }
        int numberOfEllement = listOfEnemy.Count;
        averagePosition.x = averagePosition.x / numberOfEllement;
        averagePosition.y = averagePosition.y / numberOfEllement;
        averagePosition.z = averagePosition.z / numberOfEllement;

        node newTargetNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getRandomObjectiveNode(_transform.position, averagePosition, true);

        _rootNode.SetData("targetNode", newTargetNode);
        node nearestNode = (node)GetData("closestNode");
        _pathFindingList = GameObject.Find("Node List").GetComponent<pathFinding>().findPath(nearestNode, newTargetNode);
        _rootNode.SetData("nextNode", _pathFindingList[0]);
        _rootNode.SetData("pathFindingList", _pathFindingList);
        _rootNode.SetData("needEvadePath", false);

        state = NodeState.SUCCESS;
        return state;
        

    }
}
