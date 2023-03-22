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

        desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

        Vector3 steerring = desiredVelocity - agent.Velocity;

        return steerring * weight;
    }

    public Vector3 getSteeringAvoid(Vector3 target, SteeringAgent agent)
    {

        Vector3 absTargetToCharacter = AbsValueDistance.getAbsoluteDistance(agent.transform.position, target);
        Vector3 desiredVelocity = (agent.transform.position - target);
     
        desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

        Vector3 steerring = desiredVelocity - agent.Velocity;

        return steerring ;
    }

    public Vector3 getSteeringAvoidSeeker(float weight,Vector3 target, SteeringAgent agent)
    {

        Vector3 absTargetToCharacter = AbsValueDistance.getAbsoluteDistance(agent.transform.position, target);
        
        Vector3 desiredVelocity = (agent.transform.position - target);
   

        desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

        Vector3 steerring = desiredVelocity - agent.Velocity;

        return steerring* weight;
    }

    public Vector3 atwoGetSteeringAvoidSeeker(float weight, Vector3 target, bhv_strg_agent agent)
    {

        Vector3 absTargetToCharacter = AbsValueDistance.getAbsoluteDistance(agent.transform.position, target);

        Vector3 desiredVelocity = (agent.transform.position - target);


        desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

        Vector3 steerring = desiredVelocity /* - agent.Velocity*/;

        return steerring * weight;
    }
}
