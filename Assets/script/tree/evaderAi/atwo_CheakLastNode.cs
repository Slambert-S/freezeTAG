using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_CheakLastNode : Node
{
    public atwo_CheakLastNode()
    {
        // _transform = transform;

    }

    public override NodeState Evaluate()
    {
        List<node> listNode = (List<node>)GetData("pathFindingList");
        if (listNode == null)
        {
            //Debug.Log("PathFindingListIsNull");
            state = NodeState.FAILURE;
            return state;
        }
        else
        {
            //Debug.Log("PathFindingListIsNotNull");
            //last node in the list
            if (listNode.Count == 1)
            {
                
                state = NodeState.SUCCESS;
               // Debug.Log("Last node of the path");
                
            }
            else
            {
               // Debug.Log("Not the Last node of the path");
                state = NodeState.FAILURE;
            }
            _rootNode.SetData("closestNode", listNode[0]);
            //listNode.RemoveAt(0);
            //parent.parent.SetData("pathFindingList", listNode);




            return state;
        }


    }
}
