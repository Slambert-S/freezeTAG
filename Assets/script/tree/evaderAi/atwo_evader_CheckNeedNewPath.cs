using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_evader_CheckNeedNewPath : Node
{

   
    private scriptManager _scriptManager;
    // Start is called before the first frame update
    public atwo_evader_CheckNeedNewPath( scriptManager scriptManager)
    {
       
        _scriptManager = scriptManager;

    }
    public override NodeState Evaluate()
    {
        _rootNode.SetData("needEvadePath", _scriptManager.variableReference.needNewPath);
        object needNewEvadePath = GetData("needEvadePath");

        if (needNewEvadePath == null || (bool)needNewEvadePath == true)
        {
            _scriptManager.timerForNewPath.startCooldown();
            state = NodeState.SUCCESS;
            return state;

        }

        
      /*  if (stallPrvention >= 9000)
        {
            
            stallPrvention = 0;
        }*/


        
        state = NodeState.FAILURE;
        return state;


    }
   
    
}


