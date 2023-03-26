using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;


public class atwo_TaskSetUpPatrol : Node
{
    private List<node> _listOfWaypoint = new List<node>();
    // Start is called before the first frame update
    public atwo_TaskSetUpPatrol(List<node> listOfwaypoint)
    {
        //_transform = transform;
        //_scriptManager = scrpManager;
        _listOfWaypoint = listOfwaypoint;

    }

    // Update is called once per frame
    public override NodeState Evaluate()
    {
        object waypointIndex = GetData("waypointIndex");

        if(waypointIndex == null)
        {
            int newWaypointIndex = 0;
            _rootNode.SetData("waypointIndex", newWaypointIndex);

        }

        object waypointAmount = GetData("numberOfWaypoint");
        if (waypointAmount == null)
        {
           int newWaypointAmount = _listOfWaypoint.Count;
            _rootNode.SetData("numberOfWaypoint", newWaypointAmount);

        }
        List<node> listOfWaypoint = (List<node>)GetData("listOfWaypoint");
        if (listOfWaypoint == null)
        {
            waypointIndex = 0;
            _rootNode.SetData("listOfWaypoint", _listOfWaypoint);

        }

        List<node> forbidenNode = (List<node>)GetData("ForbidenNode");
        if (forbidenNode == null)
        {
            List<node> _forbidenNode = new List<node>();
            _rootNode.SetData("ForbidenNode", _forbidenNode);

        }
        object requestBackup = GetData("RequestBackup");
        if(requestBackup == null)
        {
            _rootNode.SetData("RequestBackup", true);
        }

        //lastPatrolPoint
        node lastWaypoint = (node)GetData("lastPatrolPoint");
        
        if(lastWaypoint == null)
        {
            
            lastWaypoint = _listOfWaypoint[0];
            
            if(lastWaypoint == null)
            {
                Debug.Log("The current Seeker does not have a valid first waypoint");
            }

            _rootNode.SetData("lastPatrolPoint", lastWaypoint);

        }

        node nextWaypoint = (node)GetData("nextPatrolPoint");
        if(nextWaypoint == null)
        {
            nextWaypoint = _listOfWaypoint[0 + 1];
            if (nextWaypoint == null)
            {
                Debug.Log("The current Seeker does not have a valid first next waypoint");
            }
            _rootNode.SetData("nextPatrolPoint", nextWaypoint);
        }
        object t = GetData("isLookingAround");

        if(t == null)
        {
            _rootNode.SetData("isLookingAround", false);
            _rootNode.SetData("lookingStep", 0);
        }

        

       
       
        //Debug.Log("all set up passes");

        state = NodeState.FAILURE;
        return state;
    }
}
