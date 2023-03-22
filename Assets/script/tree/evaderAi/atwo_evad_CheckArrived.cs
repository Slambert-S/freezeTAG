using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class atwo_evad_CheckArrived : Node
{
    // Start is called before the first frame update
    private Transform _transform;
    public List<node> _pathFindingList = new List<node>();
    public atwo_evad_CheckArrived(Transform transform ,List<node> pathfindingList)
    {
        _transform = transform;
        _pathFindingList = pathfindingList;

    }

    public override NodeState Evaluate()
    {

        object t = GetData("pathFindingNode");
        if (t == null)
        {
            GameObject newtarget = GameObject.Find("target");
            if (newtarget != null)
            {
                parent.parent.SetData("target", newtarget.transform);
                Debug.Log(" have a new target");
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
        Transform target = (Transform)GetData("target");

        // Note : the you move toward this specific note 
        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            //TODO:Move towards target
            _transform.position = Vector3.MoveTowards(_transform.position, target.position, GuardBT.speed * Time.deltaTime);

            _transform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
