using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_TaskAskBackup : Node
{
    // Start is called before the first frame update
    private scriptManager _scriptReference;
    private Transform _transform;
    public atwo_seeker_TaskAskBackup(scriptManager scriptReference, Transform transform)
    {
        _scriptReference = scriptReference;
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object needBackup = GetData("RequestBackup");

        if(needBackup != null && (bool)needBackup == true)
        {
            List<node> pathToTarget = (List<node>)GetData("pathFindingList");
            
            int numberOfStep = pathToTarget.Count;
            List<node> listForBackup = new List<node>();
            if(numberOfStep >= 5)
            {
                for(int i = 0; i<= 3; i++)
                {
                    listForBackup.Add(pathToTarget[numberOfStep -1 - i]);
                }
            }
            else if (numberOfStep >= 3)
            {
                listForBackup.Add(pathToTarget[numberOfStep - 1 ]);
                listForBackup.Add(pathToTarget[numberOfStep - 2]);
            }
            else
            {
               // listForBackup.Add(pathToTarget[numberOfStep - 1]);
            }
            _rootNode.SetData("RequestBackup", false);

            int j = 0;
            foreach(node n in listForBackup)
            {
                Debug.Log("Name of node " + j + " :");
                Debug.Log(n.name);
                j++;
            }

            _scriptReference.variableReference.debugBackup.GetComponent<atwo_variable_reference>().forbidenList = listForBackup;
            _scriptReference.variableReference.debugBackup.GetComponent<atwo_variable_reference>().helpRequested = true;
            _scriptReference.variableReference.debugBackup.GetComponent<atwo_variable_reference>().targetLastKnownNode = (node)GetData("targetLastKnownNode");
            //Debug.Log(listForBackup);
            Debug.Log("Requesting assistamce");
            
        }

        state = NodeState.SUCCESS;
        return state;

    }
}
