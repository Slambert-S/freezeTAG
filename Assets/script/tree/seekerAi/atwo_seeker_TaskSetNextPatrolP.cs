using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_seeker_TaskSetNextPatrolP : Node
{
    //private Transform _transform;
    public atwo_seeker_TaskSetNextPatrolP()
    {
        //_transform = transform;
        //_scriptManager = scrpManager;
        //_listOfWaypoint = listOfwaypoint;

    }
    // Start is called before the first frame update
    public override NodeState Evaluate()
    {

        int rotationStep = (int)GetData("lookingStep");
        if(rotationStep == 3)
        {

            int waypointIndex = (int)GetData("waypointIndex");
            int numberOfWaypoint = (int)GetData("numberOfWaypoint");
            List<node> listOfWaypoint = (List<node>)GetData("listOfWaypoint");
            node lastPatrolPoint = (node)GetData("lastPatrolPoint");
            node nextPatrolPoint = (node)GetData("nextPatrolPoint");

            lastPatrolPoint = nextPatrolPoint;
            waypointIndex = ((waypointIndex + 1) % numberOfWaypoint);
            nextPatrolPoint = listOfWaypoint[(waypointIndex + 1) % numberOfWaypoint];

           // Debug.Log(lastPatrolPoint);
           // Debug.Log(nextPatrolPoint);
            //// Debug.Log((waypointIndex + 1));

            if(waypointIndex == 2)
            {
               // _rootNode.SetData("stopPatrol",  true);
              //  _rootNode.SetData("seeTargetAgent", false);
              //  Debug.Log("reached the 4 node");
            }
            _rootNode.SetData("waypointIndex", waypointIndex);
            _rootNode.SetData("lastPatrolPoint", lastPatrolPoint);
            _rootNode.SetData("nextPatrolPoint", nextPatrolPoint);
            _rootNode.SetData("lookingStep", 0);


            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
