using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class atwo_CheckhaveTarget : Node
{
    private Transform _transform;

    public atwo_CheckhaveTarget(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {

        object t = GetData("target");
        if (t == null)
        {
            GameObject newtarget = GameObject.Find("target");
            if(newtarget != null)
            {
               // parent.parent.SetData("target", newtarget.transform);
                //Debug.Log(" have a new target");
                state = NodeState.SUCCESS;
                return state;
            }
            else
            {
                state = NodeState.FAILURE;
                return state;
            }

        }
        else
        {
            state = NodeState.SUCCESS;
            return state;

        }
            //Note : retrive the object related to the key "target" in the root node
           // Transform target = (Transform)GetData("target");

        // Note : the you move toward this specific note 
      /*  if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            //TODO:Move towards target
            _transform.position = Vector3.MoveTowards(_transform.position, target.position, GuardBT.speed * Time.deltaTime);

            _transform.LookAt(target.position);
        }*/

        state = NodeState.RUNNING;
        return state;
    }
}
