using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evade : MonoBehaviour
{
    // Start is called before the first frame update

   // private Vector3 Velocity;
   // public GameObject target;
   // public float maxAccel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // this.transform.position += avoid() * Time.deltaTime;
    }


    public Vector3 avoid(float weight, SteeringAgent agent, Vector3 evadePoint)
    {

        float distance = Vector3.Distance(agent.transform.position, evadePoint);
        float ahead = distance / 10;
        Vector3 futurePosition = evadePoint + Vector3.forward * ahead;

        Vector3 steering = agent.fleeScript.getSteeringAvoid(futurePosition, agent) - agent.Velocity;
        /*
        Velocity = Velocity + (steering * Time.deltaTime);
        Velocity = Vector3.ClampMagnitude(Velocity, maxAccel);
        */
        steering *= weight;
        return steering;
    }

    public Quaternion avoidRotation(float weight, SteeringAgent agent, GameObject evadePoint)
    {

        float distance = Vector3.Distance(agent.transform.position, evadePoint.transform.position);
        float ahead = distance / 10;
        Vector3 futurePosition = evadePoint.transform.position + Vector3.zero * ahead;

        Vector3 steering = Vector3.zero /*wagent.fleeScript(futurePosition, agent) - agent.Velocity*/;
        /*
        Velocity = Velocity + (steering * Time.deltaTime);
        Velocity = Vector3.ClampMagnitude(Velocity, maxAccel);
        */
        return Quaternion.LookRotation(steering);
    }

    public Vector3 atwoAvoid(float weight, bhv_strg_agent agent, Vector3 evadePoint, scriptManager scriptReference)
    {

        float distance = Vector3.Distance(agent.transform.position, evadePoint);
        float ahead = distance / 10;
        Vector3 futurePosition = evadePoint + Vector3.forward * ahead;

        Vector3 steering = scriptReference.fleeScript.atwoGetSteeringAvoidSeeker(1,futurePosition, agent) - agent.Velocity;
        /*
        Velocity = Velocity + (steering * Time.deltaTime);
        Velocity = Vector3.ClampMagnitude(Velocity, maxAccel);
        */
        steering *= weight;
        return steering;
    }
}
