using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_seeker_CheckAtWaypoint : Node
{
    private Transform _transform;
    public atwo_seeker_CheckAtWaypoint(Transform transform)
    {
        _transform = transform;
        //_scriptManager = scrpManager;
        //_listOfWaypoint = listOfwaypoint;

    }

    public override NodeState Evaluate()
    {
        //Debug.Log(" In check atWaypoint");
        node nextPatrolPoint = (node)GetData("nextPatrolPoint");
        if (nextPatrolPoint == null)
        {
            //Debug.Log(" nextPatrolPoint is null");
            state = NodeState.FAILURE;
            return state;
        }
        else
        {
            //Debug.Log((node)GetData("nextNode"));
            if (Vector3.Distance(_transform.position, nextPatrolPoint.transform.position) <= 0.5f)
            {
               // Debug.Log("near the node");
                //parent.parent.SetData("closestNode", targetNode);
                state = NodeState.SUCCESS;
                return state;
            }
            else
            {
                state = NodeState.FAILURE;

                return state;

            }
        }
    }
}
