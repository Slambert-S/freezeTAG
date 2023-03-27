using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_evader_TaskSetColectibleNode : Node

{

    private Transform _transform;
    private node _debugTarget;
    private List<node> _pathFindingList = new List<node>();
    // Start is called before the first frame update
    public atwo_evader_TaskSetColectibleNode( List<node> pathFindingList, Transform transform)
    {
        _transform = transform;
        _pathFindingList = pathFindingList;

    }
    // Start is called before the first frame update
    public override NodeState Evaluate()
    {
       
        
            GameObject collectible = (GameObject)GetData("collectible");
            node TargetNode = findClosestNode.getClosestNode(collectible.transform.position);


            //Debug.Log("manifacure of potato");
            if (TargetNode != null)
            {

                _rootNode.SetData("targetNode", TargetNode);
                node nearestNode = (node)GetData("closestNode");
                _pathFindingList = GameObject.Find("Node List").GetComponent<pathFinding>().findPath(nearestNode, TargetNode, new List<node>());

                /*if (_pathFindingList.Count == 0)
                {
                   

                        _rootNode.SetData("collectible", null);
                        state = NodeState.FAILURE;
                        return state;
                    
                }*/
                _rootNode.SetData("nextNode", _pathFindingList[0]);
                _rootNode.SetData("pathFindingList", _pathFindingList);
                _rootNode.SetData("wandering", false);
                _rootNode.SetData("nearNode", false);

                //Debug.Log("afterGettingthe List");
                state = NodeState.SUCCESS;
                return state;

            }
            else
            {
                //_rootNode.SetData("collectible", null);
                state = NodeState.FAILURE;
                return state;
            }

        

    }
}
