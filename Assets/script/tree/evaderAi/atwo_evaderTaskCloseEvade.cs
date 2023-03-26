using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;


public class atwo_evaderTaskCloseEvade : Node
{
    private Transform _transform;
    private scriptManager _scriptReference;
    // Start is called before the first frame update
    public atwo_evaderTaskCloseEvade(Transform transform, scriptManager scriptReference)
    {
        _transform = transform;
        _scriptReference = scriptReference;

    }

    // Update is called once per frame
    public override NodeState Evaluate()
    {

        List<Collider> closeSeekerList = (List<Collider>)GetData("listEnemy");
        Vector3 steering = Vector3.zero;
        float closestDistance = float.MaxValue;
        float currentSeekerDistance;
        Collider closestEnemy = closeSeekerList[0];
        foreach (Collider seeker in closeSeekerList)
        {
            steering += _scriptReference.evadeScript.atwoAvoid(3, _scriptReference.behaviourAgent, seeker.transform.position, _scriptReference);
            currentSeekerDistance = Vector3.Distance(_transform.position, seeker.transform.position);
            if(currentSeekerDistance <= closestDistance)
            {
                closestDistance = currentSeekerDistance;
                closestEnemy = seeker;
            }
        }
        _scriptReference.freezeBombScript.trowFreezeBomb(closestEnemy,_transform.position,_scriptReference.variableReference.bombCharge);
        //Debug.Log(steering);
        _scriptReference.behaviourAgent.avoidTarget(steering);
        return NodeState.RUNNING;
    }
}
