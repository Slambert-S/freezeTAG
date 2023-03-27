using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class atwo_evader_TaskFindEscapePath : Node
{
    private Transform _transform;
    private List<node> _pathFindingList;
    private scriptManager _scriptReference;
    public atwo_evader_TaskFindEscapePath(Transform transform, List<node> pathFindingList,scriptManager scriptReference)
    {
        _transform = transform;
        _pathFindingList = pathFindingList;
        _scriptReference = scriptReference;


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
        _pathFindingList = GameObject.Find("Node List").GetComponent<pathFinding>().findPath(nearestNode, newTargetNode, new List<node>());
        while(_pathFindingList.Count < 3)
        {
            newTargetNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getRandomNode();
            _rootNode.SetData("targetNode", newTargetNode);
            nearestNode =findClosestNode.getClosestNode(_transform.position);
            _pathFindingList = GameObject.Find("Node List").GetComponent<pathFinding>().findPath(nearestNode, newTargetNode, new List<node>());
        }
        _rootNode.SetData("nextNode", _pathFindingList[0]);
        _rootNode.SetData("pathFindingList", _pathFindingList);
        _rootNode.SetData("needEvadePath", false);
        _rootNode.SetData("wandering", true);
        _scriptReference.variableReference.needNewPath = false;


        state = NodeState.SUCCESS;
        return state;
        

    }
}
