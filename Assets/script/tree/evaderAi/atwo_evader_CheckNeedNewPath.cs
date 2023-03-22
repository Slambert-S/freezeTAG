using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_evader_CheckNeedNewPath : Node
{
    private int stallPrvention = 0;
    public override NodeState Evaluate()
    {
        object needNewEvadePath = GetData("needEvadePath");
        if (needNewEvadePath == null || (bool)needNewEvadePath == true)
        {
            state = NodeState.SUCCESS;
            return state;

        }

        stallPrvention++;

        if(stallPrvention >= 30)
        {
            _rootNode.SetData("needEvadePath", true);
            stallPrvention = 0;
        }

        state = NodeState.FAILURE;
        return state;


    }
}
