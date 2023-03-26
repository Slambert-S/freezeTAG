using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_debugAssigneCollictible : Node
{
    // Start is called before the first frame update
    private scriptManager _scriptReference;

    public atwo_debugAssigneCollictible(scriptManager scriptReference )
    {
        _scriptReference = scriptReference;
    }

    public override NodeState Evaluate()
    {
      
            GameObject collectible = GameObject.Find("gameManger").GetComponent<coinManager>().assigneCollectible(); 
            if(collectible == null)
            {
                return NodeState.FAILURE;
            }
        //_scriptReference.variableReference.collectible;
           // Debug.Log("in debug assigne collectible");
            _rootNode.SetData("collectible", collectible);
            // Debug.Log(collectible);
            state = NodeState.FAILURE;
            return state;
        

     
        
    }

}
