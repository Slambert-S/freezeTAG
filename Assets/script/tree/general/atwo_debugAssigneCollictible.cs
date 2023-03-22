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
        GameObject collectible = _scriptReference.variableReference.collectible;
        _rootNode.SetData("collectible", collectible);
        state = NodeState.SUCCESS;
        return state;
    }

}
