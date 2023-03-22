using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrivedAtTarget : MonoBehaviour
{
    // Start is called before the first frame update
  //  private Vector3 Velocity; //Current speed of the agent
  //  public GameObject target;
    public float slowRadius;
    public float arrivedRadius;
  //  public float maxAccel; //max speed;
    public float timeToTarget;
    

    public Vector3 getSterring(float weight, SteeringAgent agent)
    {
        Vector3 targetVelocity = Vector3.zero;

        if ( AbsValueDistance.getAbsoluteDistance(agent.target.transform.position, agent.transform.position).magnitude > slowRadius)
        {
            Vector3 absDistance = AbsValueDistance.getAbsoluteDistance(agent.target.transform.position, agent.transform.position);

            targetVelocity = (agent.target.transform.position - agent.transform.position).normalized;
           

            targetVelocity *= agent.maxSpeed;
            targetVelocity -= agent.Velocity;

        }
        else if(AbsValueDistance.getAbsoluteDistance(agent.target.transform.position, agent.transform.position).magnitude < slowRadius)
        {
      
            
            targetVelocity = ((agent.target.transform.position - transform.position) / slowRadius) * agent.maxSpeed;

            targetVelocity = (targetVelocity - agent.Velocity) / timeToTarget;

           
        }
        
      


        return targetVelocity * weight;
    }

    public Vector3 getSterringSeeking(float weight, SteeringAgent agent, Vector3 point)
    {
        Vector3 targetVelocity = Vector3.zero;

        if (AbsValueDistance.getAbsoluteDistance(point, agent.transform.position).magnitude > slowRadius)
        {
            Vector3 absDistance = AbsValueDistance.getAbsoluteDistance(point, agent.transform.position);

            targetVelocity = (point - agent.transform.position).normalized;
           

            targetVelocity *= agent.maxSpeed;
            targetVelocity -= agent.Velocity;

         
        }
        else if (AbsValueDistance.getAbsoluteDistance(point, agent.transform.position).magnitude < slowRadius)
        {
            Debug.Log("In slow down radius : " + (point - transform.position));

            targetVelocity = ((point - transform.position) / slowRadius) * agent.maxSpeed;

            targetVelocity = (targetVelocity - agent.Velocity) / timeToTarget;

            
        }

       


        return targetVelocity * weight;
    }

    
}
