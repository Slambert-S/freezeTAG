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

        Vector3 steering = agent.fleeScript.getSteeringAvoid(futurePosition, agent) - agent.Velocity;
        /*
        Velocity = Velocity + (steering * Time.deltaTime);
        Velocity = Vector3.ClampMagnitude(Velocity, maxAccel);
        */
        return Quaternion.LookRotation(steering);
    }

    /*
        public Vector3 flee( Vector3 targetPos)
        {


            Vector3 absTargetToCharacter = getAbsoluteDistance();

            Vector3 desiredVelocity = (transform.position - targetPos);


            Debug.Log(desiredVelocity.x / absTargetToCharacter.x + " acceleration : " + desiredVelocity.x + "   ABS : " + absTargetToCharacter.x);
            desiredVelocity.x = desiredVelocity.x / absTargetToCharacter.x;
            desiredVelocity.y = desiredVelocity.y / absTargetToCharacter.y;
            desiredVelocity.z = desiredVelocity.z / absTargetToCharacter.z;
            desiredVelocity = desiredVelocity * maxAccel;

            Vector3 steering = desiredVelocity - Velocity;

            Velocity = Velocity + (steering * Time.deltaTime);
            Debug.Log("steering X  : " + steering.x + "  Steering  Z : " + steering.z);
            Velocity = Vector3.ClampMagnitude(Velocity, maxAccel);

            return Velocity;




        }

        */
    /*
        public Vector3 getAbsoluteDistance()
        {
            float TPX = target.transform.position.x;
            float TPY = target.transform.position.y;
            float TPZ = target.transform.position.z;

            float CPX = transform.position.x;
            float CPY = transform.position.y;
            float CPZ = transform.position.z;

            Vector3 absTargetToCharacter;

            absTargetToCharacter.x = Mathf.Abs(CPX - TPX);
            absTargetToCharacter.y = Mathf.Abs(  CPY - TPY);
            absTargetToCharacter.z = Mathf.Abs(  CPZ - TPZ);

            return absTargetToCharacter;
        }
    */
}
