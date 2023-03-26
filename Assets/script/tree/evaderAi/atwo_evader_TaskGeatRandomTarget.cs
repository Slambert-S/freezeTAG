using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_evader_TaskGeatRandomTarget : Node
{
    private Transform _transform;
    private node _debugTarget;
    private List<node> _pathFindingList = new List<node>();
    // Start is called before the first frame update
    public atwo_evader_TaskGeatRandomTarget(Transform transform, List<node> pathFindingList )
    {
        _transform = transform;
        _pathFindingList = pathFindingList;
        
    }

    public override NodeState Evaluate()
    {

        node TargetNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getRandomNode();
       // Debug.Log("SurpisePotota");
        object potato = GetData("potatoDebug");

        if (TargetNode != null  )
        {
           /* if (potato == null || (bool)potato == true)
            {
                _rootNode.SetData("potatoDebug", false);
            }*/

            _rootNode.SetData("targetNode", TargetNode);
            node nearestNode = (node)GetData("closestNode");
            _pathFindingList = GameObject.Find("Node List").GetComponent<pathFinding>().findPathDager(nearestNode, TargetNode, new List<node>());
            _rootNode.SetData("nextNode", _pathFindingList[0]);
            _rootNode.SetData("pathFindingList", _pathFindingList);
            _rootNode.SetData("wandering", true);
            _rootNode.SetData("nearNode", false);

            // _rootNode.SetData("potatoDebug", false);
            //Debug.Log("afterGettingthe List");

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
