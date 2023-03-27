using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_TaskAskBackup : Node
{
    // Start is called before the first frame update
    private scriptManager _scriptReference;
    private Transform _transform;
    private List<GameObject> _listOfSeeker = new List<GameObject>();
    public atwo_seeker_TaskAskBackup(scriptManager scriptReference, Transform transform)
    {
        _scriptReference = scriptReference;
        _transform = transform;

        SeekerBT[] potato = GameObject.Find("seekerList").transform.GetComponentsInChildren<SeekerBT>();

        foreach (SeekerBT n in potato)
        {
            _listOfSeeker.Add(n.gameObject);
        }
    }

    public override NodeState Evaluate()
    {
        object needBackup = GetData("RequestBackup");

        if(needBackup != null && (bool)needBackup == true)
        {
            List<node> pathToTarget = (List<node>)GetData("pathFindingList");
            if(pathToTarget == null)
            {
                pathToTarget = new List<node>();
            }
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

            float distance = float.MaxValue;
            GameObject closestSeeker = _listOfSeeker[0];
            float currentDistance = 0;
            foreach (GameObject seeker in _listOfSeeker)
            {
                currentDistance = Vector3.Distance(_transform.position, seeker.transform.position);
                if(currentDistance < 3)
                {
                    //do nothing
                }
                else if (currentDistance <= distance)
                {
                    distance = currentDistance;
                    closestSeeker = seeker;
                }
            }

            closestSeeker.GetComponent<atwo_variable_reference>().forbidenList = listForBackup;
            closestSeeker.GetComponent<atwo_variable_reference>().helpRequested = true;
            closestSeeker.GetComponent<atwo_variable_reference>().targetLastKnownNode = (node)GetData("targetLastKnownNode");
            //Debug.Log(listForBackup);
            Debug.Log("Requesting assistamce from :"  +closestSeeker);
            
        }

        state = NodeState.SUCCESS;
        return state;

    }
}
