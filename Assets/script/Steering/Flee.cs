using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getSteering(float weight, SteeringAgent agent)
    {

        Vector3 absTargetToCharacter = AbsValueDistance.getAbsoluteDistance( agent.transform.position, agent.target.transform.position);
        Vector3 desiredVelocity = (agent.transform.position - agent.target.transform.position);
        /*
        desiredVelocity.x = desiredVelocity.x / absTargetToCharacter.x;
        desiredVelocity.y = desiredVelocity.y / absTargetToCharacter.y;
        desiredVelocity.z = desiredVelocity.z / absTargetToCharacter.z;*/

        desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

        Vector3 steerring = desiredVelocity - agent.Velocity;

        return steerring * weight;
    }

    public Vector3 getSteeringAvoid(Vector3 target, SteeringAgent agent)
    {

        Vector3 absTargetToCharacter = AbsValueDistance.getAbsoluteDistance(agent.transform.position, target);
        Vector3 desiredVelocity = (agent.transform.position - target);
        /*
        desiredVelocity.x = desiredVelocity.x / absTargetToCharacter.x;
        desiredVelocity.y = desiredVelocity.y / absTargetToCharacter.y;
        desiredVelocity.z = desiredVelocity.z / absTargetToCharacter.z;*/

        desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

        Vector3 steerring = desiredVelocity - agent.Velocity;

        return steerring ;
    }

    public Vector3 getSteeringAvoidSeeker(float weight,Vector3 target, SteeringAgent agent)
    {

        Vector3 absTargetToCharacter = AbsValueDistance.getAbsoluteDistance(agent.transform.position, target);
        Vector3 desiredVelocity = (agent.transform.position - target);
        /*
        desiredVelocity.x = desiredVelocity.x / absTargetToCharacter.x;
        desiredVelocity.y = desiredVelocity.y / absTargetToCharacter.y;
        desiredVelocity.z = desiredVelocity.z / absTargetToCharacter.z;*/

        desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

        Vector3 steerring = desiredVelocity - agent.Velocity;

        return steerring* weight;
    }
}
