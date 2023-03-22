using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_TaskSelectNextNode : Node
{
    private Node _parentRoot;
    // Start is called before the first frame update
    public atwo_TaskSelectNextNode(int i )
    {
      

    }

    public override NodeState Evaluate()
    {
        //Debug.Log("In task select next node");
        List<node> listNode = (List<node>)GetData("pathFindingList");
        listNode.RemoveAt(0);
        _rootNode.SetData("pathFindingList", listNode);
        _rootNode.SetData("nextNode", listNode[0]);
       // Debug.Log(GetData("nextNode"));
        
        state = NodeState.SUCCESS;
        return state;

    }

};
